using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Developoly.Client.Entities;
using System.Threading;
using Developoly.Client.Services.Interfaces;

namespace Developoly.Client.Services
{
    public partial class Service
    {

        private MainPageInterface _mainPage;
        public MainPageInterface MainPage { get => _mainPage; set => _mainPage = value; }

        private GamePageInterface _gamePage;
        public GamePageInterface GamePage { get => _gamePage; set => _gamePage = value; }

        private MenuPageInterface _menuPage;
        public MenuPageInterface MenuPage { get => _menuPage; set => _menuPage = value; }


        private TcpClient _client;
        private NetworkStream _stream;

        private bool _isConnected;
        private int _byteSize = 1024 * 1024;

        public JsonSerializerSettings jsonSetting = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore

        };


        public Service() { }

        public Service(string ip, int port, MainPageInterface mainPage)
        {
            _mainPage = mainPage;
            _client = new TcpClient();
            try
            {
                _client.Connect(ip, port);
                _stream = _client.GetStream();
                _isConnected = true;
                Thread threadClientListen = new Thread(Listen);
                threadClientListen.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Listen()
        {
            while (true)
            {
                Communication info = this.ReceiveData();
                if (info != null)
                {
                    this.ReceiveInfo(info);
                }
            }
        }


        public Communication ReceiveData()
        {
            try
            {
                byte[] inStream = new byte[_byteSize];
                int sizeBuffer = _stream.Read(inStream, 0, inStream.Length);
                try
                {
                    if (sizeBuffer > 0)
                    {
                        string commu = Encoding.Unicode.GetString(inStream);
                        return JsonConvert.DeserializeObject<Communication>(Encoding.Unicode.GetString(inStream), jsonSetting);
                    }
                }  catch (Exception e)
                {
                    Console.WriteLine("DeserializeQuiBeug. Exception: " + e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The server is not started. Exception: " + e);
            }
            return null;
        }

        public void SendData(Communication info)
        {
            if (_isConnected)
            {
                byte[] outStream = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(info, jsonSetting));
                _stream.Write(outStream, 0, outStream.Length);
                _stream.Flush();
            }
        }

        public void ReceiveInfo(Communication info)
        {
            switch (info.Action)
            {
                case "MyCompanyAddSuccess":
                    MyCompanyAddSuccess(info);
                    break;

                case "AddNewPlayerSuccess":
                    MainPage.ChangeLoading(info.Data);
                    break;

                case "RemovePlayerSuccess":
                    MainPage.ChangeLoading(info.Data);
                    break;

                case "MyCompanyAlreadyExist":
                    MainPage.MyCompanyAlreadyExist();
                    break;

                case "AddTheirCompany":
                    TheirCompanysAddSuccess(info);
                    break;

                case "MyDevAddSuccess":
                    GamePage.MyDevAddSuccess(info.Data);
                    break;

                case "HisDevAddSuccess":
                    GamePage.HisDevAddSuccess(info.Data);
                    break;

                case "MyDevAddNotEnoughMoney":
                    GamePage.MyDevAddNotEnoughMoney();
                    break;

                case "MyProjectAddSuccess":
                    GamePage.MyProjectAddSuccess(info.Data);
                    break;

                case "MyDevelopperNotQualified":
                    GamePage.MyDevelopperNotQualified(info.Data);
                    break;


                case "TheirProjectsAddSuccess":
                    GamePage.TheirProjectsAddSuccess(info.Data);
                    break;

                case "MyProjectAddAlreadyExist":
                    GamePage.MyProjectAddAlreadyExist();
                    break;

                case "MyDevToCourseSuccess":
                    GamePage.MyDevToCourseSuccess(info.Data);
                    break;

                case "HisDevToCourseSuccess":
                    GamePage.HisDevToCourseSuccess(info.Data);
                    break;

                case "SetupGame":
                    // KIM
                    break;
                case "NextTurnOk":
                    GamePage.MyTurnIsOver();
                    break;

                case "Win":
                    MenuPage.WinGame();
                    break;

                case "ACompanyLost":
                    MenuPage.ACompanyLost();
                    break;

                case "GameOver":
                    MenuPage.GameOver();
                    break;

                default:
                    break;
            }

            

        }



        private void MyCompanyAddSuccess(Communication info)
        {
            MainPage.General = JsonConvert.DeserializeObject<General>(info.Data, jsonSetting);
            MainPage.LoadingScreen();
        }
        
        private void TheirCompanysAddSuccess(Communication info)
        {
            (JsonConvert.DeserializeObject<List<Company>>(info.Data, jsonSetting)).ForEach(c =>
            {
                MainPage.General.TheirCompanys.Add(c);
            });
        }



    


    }
}

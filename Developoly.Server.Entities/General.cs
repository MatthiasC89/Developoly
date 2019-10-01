using Developoly.Server.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Server.Entities
{
    public class General
    {


        private Company _myCompany;
        public Company MyCompany { get => _myCompany; set => _myCompany = value; }

        private List<Company> _theirCompanys;
        public List<Company> TheirCompanys { get => _theirCompanys; set => _theirCompanys = value; }

        private List<Dev> _unemployedDevs;
        public List<Dev> UnemployedDevs { get => _unemployedDevs; set => _unemployedDevs = value; }

        private List<Project> _newProjects;
        public List<Project> NewProjects { get => _newProjects; set => _newProjects = value; }

        private List<School> _schools;
        public List<School> Schools { get => _schools; set => _schools = value; }


        private int nbActualPlayer;
        public int NbActualPlayer { get => nbActualPlayer; set => nbActualPlayer = value; }

        private int nbPlayerMax;
        public int NbPlayerMax { get => nbPlayerMax; set => nbPlayerMax = value; }

        private int moneyStart;
        public int MoneyStart { get => moneyStart; set => moneyStart = value; }

        private int nbTurn;
        public int NbTurn { get => nbTurn; set => nbTurn = value; }
        private int _winParameter;
        public int WinParameter { get => _winParameter; set => _winParameter = value; }
        private int _looseParameter;
        public int LooseParameter { get => _looseParameter; set => _looseParameter = value; }



        public General()
        {

        }

        public General(Company company, List<Company> theirCompanys, List<Dev> umployedD, List<Project> allProjects, List<School> allSchools, int nbActual, int nbMax, int money, int turn)
        {
            MyCompany = company;
            UnemployedDevs = umployedD;
            NewProjects = allProjects;
            Schools = allSchools;
            NbActualPlayer = nbActual;
            NbPlayerMax = nbMax;
            MoneyStart = money;
            NbTurn = turn;
            TheirCompanys = theirCompanys;
        }

        public General(Company company, List<Dev> umployedD, List<Project> allProjects, List<School> allSchools, int nbActual, int nbMax, int money, int turn)
        {
            MyCompany = company;
            UnemployedDevs = umployedD;
            NewProjects = allProjects;
            Schools = allSchools;
            NbActualPlayer = nbActual;
            NbPlayerMax = nbMax;
            MoneyStart = money;
            NbTurn = turn;
            TheirCompanys = new List<Company>();
        }

        public General(List<Dev> umployedD, List<Project> allProjects, List<School> allSchools)
        {
            MyCompany = null;
            UnemployedDevs = umployedD;
            NewProjects = allProjects;
            Schools = allSchools;
            TheirCompanys = new List<Company>();
        }
    }
}


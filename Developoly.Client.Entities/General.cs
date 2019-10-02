using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Entities
{
    public class General
    {

        private Object _service;
        public Object Service { get => _service; set => _service = value; }

        private Company _myCompany;
        public Company MyCompany { get => _myCompany; set => _myCompany = value; }

        private List<Company> _theirCompanys;
        public List<Company> TheirCompanys { get => _theirCompanys; set => _theirCompanys = value; }

        private List<Dev> _unemployedDevs;
        public List<Dev> UnemployedDevs { get => _unemployedDevs; set => _unemployedDevs = value; }

        private List<Dev> _myDevs;
        public List<Dev> MyDevs { get => _myDevs; set => _myDevs = value; }

        private List<Project> _newProjects;
        public List<Project> NewProjects { get => _newProjects; set => _newProjects = value; }

        private List<Project> _myProjects;
        public List<Project> MyProjects { get => _myProjects; set => _myProjects = value; }

        private List<Course> _newCourses;
        public List<Course> NewCourses { get => _newCourses; set => _newCourses = value; }

        private List<School> _schools;
        public List<School> Schools { get => _schools; set => _schools = value; }

        private int nbActualPlayer;
        public int NbActualPlayer { get => nbActualPlayer; set => nbActualPlayer = value; }

        private int nbPlayerMax;
        public int NbPlayerMax { get => nbPlayerMax; set => nbPlayerMax = value; }

        private int moneyStart;
        public int MoneyStart { get => moneyStart; set => moneyStart = value; }

        private int nbTurnActual;
        public int NbTurnActual { get => nbTurnActual; set => nbTurnActual = value; }

        private int nbTurn;
        public int NbTurn { get => nbTurn; set => nbTurn = value; }


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
            NbTurnActual = 1;
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
            NbTurnActual = 1;
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

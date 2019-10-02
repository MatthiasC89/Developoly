using System;
using System.Collections.Generic;
using System.Text;

namespace Administrator_Interface.Entities
{
    public class GameParameters
    {
        private int _money;
        private int _skillDev;
        private int _numberDev;
        private int _numberTurn;
        private int _projectDiff;
        private int _numberPlayer;
        private int _priceCourse;
        private int _minCourse;
        private int _maxCourse;
        private int _salaryDev;
        private int _hiringDev;
        private int _rewards;
        private int _skillProject;
        private int _minDurationProject;
        private int _maxDurationProject;
        private int _multiplierHiringDev;
        private int _multiplierSalaryDev;
        private int _multiplierCourse;
        private int _winpara;
        private int _loosepara;

        public int Money { get => _money; set => _money = value; }
        public int SkillDev { get => _skillDev; set => _skillDev = value; }
        public int NumberDev { get => _numberDev; set => _numberDev = value; }
        public int NumberTurn { get => _numberTurn; set => _numberTurn = value; }
        public int ProjectDiff { get => _projectDiff; set => _projectDiff = value; }
        public int NumberPlayer { get => _numberPlayer; set => _numberPlayer = value; }
        public int PriceCourse { get => _priceCourse; set => _priceCourse = value; }
        public int MinCourse { get => _minCourse; set => _minCourse = value; }
        public int MaxCourse { get => _maxCourse; set => _maxCourse = value; }
        public int SalaryDev { get => _salaryDev; set => _salaryDev = value; }
        public int HiringDev { get => _hiringDev; set => _hiringDev = value; }
        public int Rewards { get => _rewards; set => _rewards = value; }
        public int SkillProject { get => _skillProject; set => _skillProject = value; }
        public int MinDurationProject { get => _minDurationProject; set => _minDurationProject = value; }
        public int MaxDurationProject { get => _maxDurationProject; set => _maxDurationProject = value; }
        public int MultiplierHiringDev { get => _multiplierHiringDev; set => _multiplierHiringDev = value; }
        public int MultiplierSalaryDev { get => _multiplierSalaryDev; set => _multiplierSalaryDev = value; }
        public int MultiplierCourse { get => _multiplierCourse; set => _multiplierCourse = value; }
        public int Winparameter { get => _winpara; set => _winpara = value; }
        public int Looseparameter { get => _loosepara; set => _loosepara = value; }

        public GameParameters(int money, int skDev, int nbDev, int nbTurn, int nbPlayer, int pCourse, int miniCourse, int maxiCourse, int salaryDev, int hiringDev, int rewards, int skillProject, int minDurationProject, int maxDurationProject, int multiplierHiringDev, int multiplierSalaryDev, int multiplierCourse, int winParameter, int looseParameter)
        {
            Money = money;
            SkillDev = skDev;
            NumberDev = nbDev;
            NumberTurn = nbTurn;
            NumberPlayer = nbPlayer;
            PriceCourse = pCourse;
            MinCourse = miniCourse;
            MaxCourse = maxiCourse;
            SalaryDev = salaryDev;
            HiringDev = hiringDev;
            Rewards = rewards;
            SkillProject = skillProject;
            MinDurationProject = minDurationProject;
            MaxDurationProject = maxDurationProject;
            MultiplierHiringDev = multiplierHiringDev;
            MultiplierSalaryDev = multiplierSalaryDev;
            MultiplierCourse = multiplierCourse;
            Winparameter = winParameter;
            Looseparameter = looseParameter;
        }


    }

    
}

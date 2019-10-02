using Developoly.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Services.Interfaces
{
    public interface GamePageInterface
    {
        General General { get; set; }

        void InitializePlayerPlayed(Object company);

        void MyDevelopperNotQualified(string DevsNotQualified);

        void MyTurnIsOver();

        void MyTurnBegins(int idActualPlayer);

        void MyDevAddSuccess(string AddedDev);

        void HisDevAddSuccess(string AddedDev);

        void MyDevAddNotEnoughMoney();

        void MyDevAddAlreadyExist();

        void MyProjectAddAlreadyExist();

        void MyProjectAddSuccess(string ChoosedProject);

        void TheirProjectsAddSuccess(string ChoosedProject);

        void MyDevToCourseSuccess(string DevAndCourse);

        void HisDevToCourseSuccess(string DevAndCourse);


    }
}
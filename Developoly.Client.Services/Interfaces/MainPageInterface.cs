using Developoly.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Services.Interfaces
{
    public interface MainPageInterface
    {
        General General { get; set; }

        void MyCompanyAlreadyExist();

        void LoadingScreen();

        void ChangeLoading(string nbActualPlayer);

        void SetupGame();

    }
}

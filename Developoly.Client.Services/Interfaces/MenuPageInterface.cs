using Developoly.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Developoly.Client.Services.Interfaces
{
    public interface MenuPageInterface
    {
        General General { get; set; }

        void WinGame();

        void ACompanyLost();

        void GameOver();
    }
}

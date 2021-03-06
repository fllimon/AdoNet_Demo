﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetApplication
{
    interface IUiController
    {
        string GetChangeData();

        long GetPlayerId();

        void PrintPlayer(IEnumerable<Accounts> player);

        void PrintPlayerCars(IEnumerable<Cars> cars);

        void PrintMenu();
    }
}

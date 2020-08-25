using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetApplication
{
    [Flags]
    enum ActionKey
    {
        NoAction,
        PressExit,
        PressUpdateName,
        PressUpdateLastName,
        PressUpdateEmail,
        PressDeleteAccount,
        PressSelectInfo,
        PresSelectInfoAboutCars
    }
}

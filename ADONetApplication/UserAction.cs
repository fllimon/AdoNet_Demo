using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetApplication
{
    class UserAction
    {
        public ActionKey GetActionKey(ConsoleKey someKey)
        {
            Ui menu = new Ui();
            Database db = new Database();

            Bl player = new Bl(menu, db);
            ActionKey pressKey = ActionKey.NoAction;
            switch (someKey)
            {
                case ConsoleKey.Escape:
                    pressKey = ActionKey.PressExit;
                    break;
                case ConsoleKey.I:
                    pressKey = ActionKey.PressSelectInfo;

                    Console.Clear();
                    player.GetPlayerInfo();

                    break;
                case ConsoleKey.D:
                    pressKey = ActionKey.PressDeleteAccount;

                    Console.Clear();
                    player.DeletePlayer();

                    break;
                case ConsoleKey.F:
                    pressKey = ActionKey.PressUpdateLastName;

                    Console.Clear();
                    player.UpdateLastName();

                    break;
                case ConsoleKey.N:
                    pressKey = ActionKey.PressUpdateName;

                    Console.Clear();
                    player.UpdateFirstName();

                    break;
                case ConsoleKey.E:
                    pressKey = ActionKey.PressUpdateEmail;

                    Console.Clear();
                    player.UpdateEmail();

                    break;


                default:
                    break;
            }

            return pressKey;
        }
    }
}

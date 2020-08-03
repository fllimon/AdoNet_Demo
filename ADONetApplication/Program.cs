using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionKey someAction = ActionKey.NoAction;
            Ui menu = new Ui();
            UserAction action = new UserAction(); 

            do
            {
                menu.PrintMenu();
                someAction = menu.GetPressKey(action);
            } while (someAction != ActionKey.PressExit);
        }
    }
}

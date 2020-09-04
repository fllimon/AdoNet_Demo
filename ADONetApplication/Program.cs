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
            IDbController db = new RageMPDatabase();
            IUiController menu = new Ui();
            UserController controller = new UserController(menu, db);
            
            do
            {
                menu.PrintMenu();
                someAction = controller.GetPressKey();
            } while (someAction != ActionKey.PressExit);
        }
    }
}

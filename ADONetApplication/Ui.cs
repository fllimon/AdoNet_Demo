using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetApplication
{
    class Ui : IUiController
    {
        public void PrintMenu()
        {
            Console.WriteLine("=============== MENU ================");
            Console.WriteLine();
            Console.WriteLine("Нажмите <I> для просмотра информации о игроке");
            Console.WriteLine();
            Console.WriteLine("Если хотите изменить имя нажмите <N>");
            Console.WriteLine();
            Console.WriteLine("Если хотите изменить фамилию нажмите <F>");
            Console.WriteLine();
            Console.WriteLine("Если хотите изменить почту нажмите <E>");
            Console.WriteLine();
            Console.WriteLine("Если хотите удалить персонажа нажмите <D>");
            Console.WriteLine();
            Console.WriteLine("Нажмите <ESC> для выхода из программы");
            Console.WriteLine();
            Console.WriteLine("============================================");
        }

        public ActionKey GetPressKey(UserAction action)
        {
            ActionKey someAction;
            do
            {
                someAction = action.GetActionKey(Console.ReadKey(true).Key);
            } while (someAction == 0);

            return someAction;
        }

        public string GetChangeData()
        {
            string data = string.Empty;

            Console.Write("Введите новые данные для изменения: ");
            data = Console.ReadLine();

            if ((data == string.Empty) || (data == null))
            {
                return "Поле не может быть пустым";
            }

            return data;
        }

        public long GetPlayerId()
        {
            long id;

            Console.Write("Введите id игрока: ");
            string str = Console.ReadLine();

            if (!string.IsNullOrEmpty(str))
            {
                id = Convert.ToInt32(str);
            }
            else
            {
                return 0;
            }

            if ((id < 0))
            {
                return -1;
            }

            return id;
        }
    }
}

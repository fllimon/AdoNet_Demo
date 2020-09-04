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
            Console.WriteLine($"Нажмите <{DefaultSettings.DEFAULT_CHECK_PLAYER_INFO}> для просмотра информации о игроке");
            Console.WriteLine();
            Console.WriteLine($"Нажмите <{DefaultSettings.DEFAULT_CHECK_PLAYER_INFO_ABOUT_CARS}> для просмотра информации о машинах игрока");
            Console.WriteLine();
            Console.WriteLine($"Если хотите изменить имя нажмите <{DefaultSettings.DEFAULT_CHANGE_NAME}>");
            Console.WriteLine();
            Console.WriteLine($"Если хотите изменить фамилию нажмите <{DefaultSettings.DEFAULT_CHANGE_LAST_NAME}>");
            Console.WriteLine();
            Console.WriteLine($"Если хотите изменить почту нажмите <{DefaultSettings.DEFAULT_CHANGE_EMAIL}>");
            Console.WriteLine();
            Console.WriteLine($"Если хотите удалить персонажа нажмите <{DefaultSettings.DEFAULT_DELETE_PLAYER}>");
            Console.WriteLine();
            Console.WriteLine($"Нажмите <{DefaultSettings.DEFAULT_EXIT_KEY}> для выхода из программы");
            Console.WriteLine();
            Console.WriteLine("============================================");
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

        public void PrintPlayer(IEnumerable<Accounts> player)
        {
            foreach (var item in player)
            {
                Console.WriteLine();
                Console.Write($" FirstName: {item.FirstName} - LastName: {item.LastName} - Email: {item.Email} ");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void PrintPlayerCars(IEnumerable<Cars> cars)
        {
            foreach (var item in cars)
            {
                Console.WriteLine();
                Console.Write($" Engine Number: {item.EngineNumber} - Model Car: {item.ModelCar} ");
                Console.WriteLine();
                Console.WriteLine();
            }
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

            if (id < 0)
            {
                return -1;
            }

            return id;
        }
    }
}

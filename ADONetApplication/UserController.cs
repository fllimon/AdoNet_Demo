using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetApplication
{
    class UserController
    {
        #region =======------- PRIVATE DATA -------=========

        private readonly IDbController _dbController;
        private readonly IUiController _uiController;

        #endregion

        public UserController(IUiController menu, IDbController db)
        {
            _uiController = menu;
            _dbController = db;
        }

        public void GetPlayerInfo()
        {
            long id = _uiController.GetPlayerId();

            _uiController.PrintPlayer(_dbController.GetPlayerInfoById(id));
        }

        public void GetPlayerInfoAboutCars()
        {
            long id = _uiController.GetPlayerId();

            _uiController.PrintPlayer(_dbController.GetPlayerInfoById(id));
            _uiController.PrintPlayerCars(_dbController.GetPlayerCarsBuId(id));
        }

        public void DeletePlayer()
        {
            long id = _uiController.GetPlayerId();

            _dbController.DeletePlayerById(id);
        }

        public void UpdateFirstName()
        {
            long id = _uiController.GetPlayerId();
            string data = _uiController.GetChangeData();

            _dbController.UpdateFirstNameById(id, data);
        }

        public void UpdateLastName()
        {
            long id = _uiController.GetPlayerId();
            string data = _uiController.GetChangeData();

            _dbController.UpdateLastNameById(id, data);
        }

        public void UpdateEmail()
        {
            long id = _uiController.GetPlayerId();
            string data = _uiController.GetChangeData();

            _dbController.UpdateEmailById(id, data);
        }

        public ActionKey GetPressKey()
        {
            ActionKey someAction;
            do
            {
                someAction = GetActionKey(Console.ReadKey(true).Key);
            } while (someAction == 0);

            return someAction;
        }

        private ActionKey GetActionKey(ConsoleKey someKey)
        {
            //Ui menu = new Ui();
            //RageMPDatabase db = new RageMPDatabase();

            //UserController player = new UserController(menu, db);

            ActionKey pressKey = ActionKey.NoAction;

            switch (someKey)
            {
                case DefaultSettings.DEFAULT_EXIT_KEY:
                    pressKey = ActionKey.PressExit;

                    break;
                case DefaultSettings.DEFAULT_CHECK_PLAYER_INFO:
                    pressKey = ActionKey.PressSelectInfo;

                    Console.Clear();
                    GetPlayerInfo();

                    break;
                case DefaultSettings.DEFAULT_CHECK_PLAYER_INFO_ABOUT_CARS:
                    pressKey = ActionKey.PresSelectInfoAboutCars;

                    Console.Clear();
                    GetPlayerInfoAboutCars();

                    break;
                case DefaultSettings.DEFAULT_DELETE_PLAYER:
                    pressKey = ActionKey.PressDeleteAccount;

                    Console.Clear();
                    DeletePlayer();

                    break;
                case DefaultSettings.DEFAULT_CHANGE_LAST_NAME:
                    pressKey = ActionKey.PressUpdateLastName;

                    Console.Clear();
                    UpdateLastName();

                    break;
                case DefaultSettings.DEFAULT_CHANGE_NAME:
                    pressKey = ActionKey.PressUpdateName;

                    Console.Clear();
                    UpdateFirstName();

                    break;
                case DefaultSettings.DEFAULT_CHANGE_EMAIL:
                    pressKey = ActionKey.PressUpdateEmail;

                    Console.Clear();
                    UpdateEmail();

                    break;


                default:
                    break;
            }

            return pressKey;
        }
    }
}

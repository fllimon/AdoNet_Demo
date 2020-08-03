using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetApplication
{
    class Bl 
    {
        #region =======------- PRIVATE DATA -------=========

        private readonly IDbController _dbController;
        private readonly IUiController _uiController;

        #endregion

        public Bl(Ui menu, Database db)
        {
            _uiController = menu;
            _dbController = db;
        }

        public void GetPlayerInfo()
        {
            long id = _uiController.GetPlayerId();

            _dbController.GetPlayerInfoById(id);
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
    }
}

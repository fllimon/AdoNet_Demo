using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetApplication
{
    interface IDbController
    {
        void CreateAccounts(string firstName, string lastName, string password, string email);

        void GetPlayerInfoById(long id);

        void DeletePlayerById(long id);

        void UpdateFirstNameById(long id, string firstName);

        void UpdateLastNameById(long id, string lastName);

        void UpdateEmailById(long id, string email);
    }
}

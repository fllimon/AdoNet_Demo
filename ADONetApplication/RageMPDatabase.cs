using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ADONetApplication
{
    internal sealed class RageMPDatabase : IDisposable, IDbController
    {
        #region =====----- PRIVATE DATA -----=====

        private readonly string _connectionString = "Data Source=localhost;Initial Catalog=RageMPDataBase;User ID=Artur;Password=123321";
        private bool _disposed = false;
        private SqlConnection _connection;

        #endregion

        #region =====----- CTOR -----======

        public RageMPDatabase()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        #endregion

        public void CreateAccounts(string firstName, string lastName, string password, string email)
        {
            try
            {
                string sqlCommand = "INSERT INTO Accounts(FirstName, LastName, UserPassword, Email) " +
                                    "VALUES(@firstName, @lastName, @password, @email)";

                SqlCommand newCommand = _connection.CreateCommand();

                newCommand.CommandText = sqlCommand;

                SqlParameter firstNameParameter = new SqlParameter("@firstName", firstName);
                SqlParameter lastNameParameter = new SqlParameter("@lastName", lastName);
                SqlParameter passwordParameter = new SqlParameter("@password", password);
                SqlParameter emailParameter = new SqlParameter("@email", email);

                AddNewParameters(newCommand, firstNameParameter, lastNameParameter, passwordParameter, emailParameter);
                newCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public IEnumerable<Accounts> GetPlayerInfoById(long id)
        {
            string sqlCommand = "SELECT FirstName, LastName, Email " +
                                   "FROM Accounts WHERE (Id = @id) AND (IsDeleted = 0)";

            SqlCommand newCommand = _connection.CreateCommand();
            newCommand.CommandText = sqlCommand;

            SqlParameter idParameter = new SqlParameter("@id", id);
            AddNewParameters(newCommand, idParameter);

            using (SqlDataReader accountsReader = newCommand.ExecuteReader())
            {
                while (accountsReader.Read())
                {
                    yield return new Accounts
                    {
                        Id = id,
                        FirstName = accountsReader[0].ToString(),
                        LastName = accountsReader[1].ToString(),
                        Email = accountsReader[2].ToString()
                    };
                }
            }
        }

        public void DeletePlayerById(long id)
        {
            try
            {
                string sqlCommand = "UPDATE Accounts SET IsDeleted = 1 WHERE Id = @id";

                SqlCommand newCommand = _connection.CreateCommand();
                newCommand.CommandText = sqlCommand;

                SqlParameter idParameter = new SqlParameter("@id", id);

                AddNewParameters(newCommand, idParameter);
                newCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void UpdateFirstNameById(long id, string firstName)
        {
            try
            {
                string sqlCommand = "UPDATE Accounts SET FirstName = @firstName WHERE Id = @id";

                SqlCommand newCommand = _connection.CreateCommand();
                newCommand.CommandText = sqlCommand;

                SqlParameter idParameter = new SqlParameter("@id", id);
                SqlParameter firstNameParameter = new SqlParameter("@firstName", firstName);

                AddNewParameters(newCommand, idParameter, firstNameParameter);
                newCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void UpdateLastNameById(long id, string lastName)
        {
            try
            {
                string sqlCommand = "UPDATE Accounts SET LastName = @lastName WHERE Id = @id";

                SqlCommand newCommand = _connection.CreateCommand();
                newCommand.CommandText = sqlCommand;

                SqlParameter idParameter = new SqlParameter("@id", id);
                SqlParameter lastNameParameter = new SqlParameter("@lastName", lastName);

                AddNewParameters(newCommand, idParameter, lastNameParameter);
                newCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void UpdateEmailById(long id, string email)
        {
            try
            {
                string sqlCommand = "UPDATE Accounts SET Email = @email WHERE Id = @id";

                SqlCommand newCommand = _connection.CreateCommand();
                newCommand.CommandText = sqlCommand;

                SqlParameter idParameter = new SqlParameter("@id", id);
                SqlParameter emailParameter = new SqlParameter("@email", email);

                AddNewParameters(newCommand, idParameter, emailParameter);
                newCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private void AddNewParameters(SqlCommand newCommand, params SqlParameter[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                newCommand.Parameters.Add(data[i]);
            }
        } 

        ~RageMPDatabase()
        {
            if (!_disposed)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _connection.Close();    //ToDo: ?? Fix

            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}

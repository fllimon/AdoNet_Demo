using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Configuration;

namespace ADONetApplication
{
    internal  class RageMPDatabase : IDisposable, IDbController
    {
        #region =====----- PRIVATE DATA -----=====

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlConnection _connection;
        private bool _disposed = false;

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

        public IEnumerable<Cars> GetPlayerCarsBuId(long id)
        {
            string sqlCommand = "SELECT OV.EngineNumber, M.ModelCar " +
                                "FROM OwnerVehicle AS OV " +
                                "LEFT JOIN Cars AS C ON Ov.EngineNumber = C.EngineNumber " +
                                "LEFT JOIN Models AS M ON C.Id = M.Id " +
                                "WHERE (Ov.IdAccounts = @id) ";

            SqlCommand newCommand = _connection.CreateCommand();
            newCommand.CommandText = sqlCommand;

            SqlParameter idParameter = new SqlParameter("@id", id);
            AddNewParameters(newCommand, idParameter);

            using (SqlDataReader carsReader = newCommand.ExecuteReader())
            {
                while (carsReader.Read())
                {
                    yield return new Cars    // ToDo: ВОПРОС????
                    {
                        EngineNumber = (int)carsReader[0],
                        ModelCar = carsReader[1].ToString()
                    };
                }
            }
        }

        public IEnumerable<Accounts> GetPlayerInfoById(long? id = null)
        {
            string sqlCommand = "SELECT FirstName, LastName, Email, Id " +
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
                        FirstName = accountsReader[0].ToString(),
                        LastName = accountsReader[1].ToString(),
                        Email = accountsReader[2].ToString(),
                        Id = (long)accountsReader[3]
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
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Dispose();    //ToDo: ?? Fix
            }

            _disposed = true;

            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

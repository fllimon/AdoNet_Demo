using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ADONetApplication
{
    internal sealed class Database : IDbController
    {
        public void CreateAccounts(string firstName, string lastName, string password, string email)
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sqlCommand = "INSERT INTO Accounts(FirstName, LastName, UserPassword, Email) " +
                                        "VALUES(@firstName, @lastName, @password, @email)"; 

                    connection.Open();

                    SqlCommand newCommand = connection.CreateCommand();

                    newCommand.CommandText = sqlCommand;

                    SqlParameter firstNameParameter = new SqlParameter("@firstName", firstName);
                    SqlParameter lastNameParameter = new SqlParameter("@lastName", lastName);
                    SqlParameter passwordParameter = new SqlParameter("@password", password);
                    SqlParameter emailParameter = new SqlParameter("@email", email);

                    newCommand.Parameters.Add(firstNameParameter);
                    newCommand.Parameters.Add(lastNameParameter);
                    newCommand.Parameters.Add(passwordParameter);
                    newCommand.Parameters.Add(emailParameter);

                    newCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public void GetPlayerInfoById(long id)
        {
            string connectionString = GetConnectionString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCommand = "SELECT FirstName, LastName, Email " +
                                        "FROM Accounts WHERE (Id = @id) AND (IsDeleted = 0)";

                    connection.Open();

                    SqlCommand newCommand = connection.CreateCommand();
                    newCommand.CommandText = sqlCommand;

                    SqlParameter idParameter = new SqlParameter("@id", id);
                    newCommand.Parameters.Add(idParameter);

                    using (SqlDataReader accountsReader = newCommand.ExecuteReader())
                    {
                        while (accountsReader.Read())
                        {
                            Console.WriteLine();
                            Console.WriteLine($"FirstName: {accountsReader[0]}  -  LastName: {accountsReader[1]}  - Email: {accountsReader[2]}");
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void DeletePlayerById(long id)
        {
            try
            {
                string connectionString = GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCommand = "UPDATE Accounts SET IsDeleted = 1 WHERE Id = @id";

                    connection.Open();

                    SqlCommand newCommand = connection.CreateCommand();
                    newCommand.CommandText = sqlCommand;

                    SqlParameter idParameter = new SqlParameter("@id", id);

                    newCommand.Parameters.Add(idParameter);

                    newCommand.ExecuteNonQuery();
                }
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
                string connectionString = GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCommand = "UPDATE Accounts SET FirstName = @firstName WHERE Id = @id";

                    connection.Open();

                    SqlCommand newCommand = connection.CreateCommand();
                    newCommand.CommandText = sqlCommand;

                    SqlParameter idParameter = new SqlParameter("@id", id);
                    SqlParameter firstNameParameter = new SqlParameter("@firstName", firstName);

                    newCommand.Parameters.Add(idParameter);
                    newCommand.Parameters.Add(firstNameParameter);

                    newCommand.ExecuteNonQuery();
                }
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
                string connectionString = GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCommand = "UPDATE Accounts SET LastName = @lastName WHERE Id = @id";

                    connection.Open();

                    SqlCommand newCommand = connection.CreateCommand();
                    newCommand.CommandText = sqlCommand;

                    SqlParameter idParameter = new SqlParameter("@id", id);
                    SqlParameter lastNameParameter = new SqlParameter("@lastName", lastName);

                    newCommand.Parameters.Add(idParameter);
                    newCommand.Parameters.Add(lastNameParameter);

                    newCommand.ExecuteNonQuery();
                }
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
                string connectionString = GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlCommand = "UPDATE Accounts SET FirstName = @email WHERE Id = @id";

                    connection.Open();

                    SqlCommand newCommand = connection.CreateCommand();
                    newCommand.CommandText = sqlCommand;

                    SqlParameter idParameter = new SqlParameter("@id", id);
                    SqlParameter emailParameter = new SqlParameter("@email", email);

                    newCommand.Parameters.Add(idParameter);
                    newCommand.Parameters.Add(emailParameter);

                    newCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private string GetConnectionString()
        {
            SqlConnectionStringBuilder buildConnectionString = new SqlConnectionStringBuilder();

            buildConnectionString.DataSource = "localhost";
            buildConnectionString.InitialCatalog = "RageMPDataBase";
            buildConnectionString.UserID = "Artur";
            buildConnectionString.Password = "123321";

            string connectionString = string.Empty;

            return connectionString = buildConnectionString.ToString();
        }
    }
}

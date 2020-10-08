using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FinalProject.Entities;
using Users.DAL.Interfaces;

namespace Users.DAL
{
    public class dbUsersDAO : IUsersDAO
    {
        private static SqlConnection _connection = Objects.Connection;
        public bool Add(User user)
        {
            var query = "INSERT INTO dbo.Users(LastName, FirstName, Patronymic, Email, Phone, Password) " +
                    "VALUES(@LastName, @FirstName, @Patronymic, @Email, @Phone, @Password)";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@Patronymic", user.Patronymic);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@Password", user.Password);

            var result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool DeleteByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            var query = "SELECT Id, LastName, FirstName, Patronymic, Email, Phone, Password FROM Users";

            var command = new SqlCommand(query, _connection);


            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new User()
                {
                    ID = (int)reader["Id"],
                    LastName = reader["LastName"] as string,
                    FirstName = reader["FirstName"] as string,
                    Patronymic = reader["Patronymic"] as string,
                    Email = reader["Email"] as string,
                    Phone = reader["Phone"] as string,
                    Password = reader["Password"] as string
                };
            }
            reader.Close();
        }

        public bool SignIN(string login, string password)
        {
            var query = "SELECT FirstName FROM Users WHERE Email = \'" + login + "\' AND Password = \'" + password + "\'";
            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }

        public User GetUserByID(int ID)
        {
            var query = "SELECT Id, LastName, FirstName, Patronymic, Email, Phone FROM Users WHERE Id = \'" + ID + "\'";

            var command = new SqlCommand(query, _connection);

            var reader = command.ExecuteReader();

            reader.Read();
            User user = new User() {
                ID = (int)reader["Id"],
                LastName = reader["LastName"] as string,
                FirstName = reader["FirstName"] as string,
                Patronymic = reader["Patronymic"] as string,
                Email = reader["Email"] as string,
                Phone = reader["Phone"] as string
            };
            reader.Close();
            return user;
        }

        public bool Update(User user, string lastName, string firstName, string patronymic, string email, string phone, string password)
        {
            throw new NotImplementedException();
        }

        public int GetID(string email)
        {
            var query = "SELECT Id FROM Users WHERE Email = \'" + email + "\'";

            var command = new SqlCommand(query, _connection);

            var reader = command.ExecuteReader();

            reader.Read();
            int id = (int)reader["Id"];
            reader.Close();
            return id;
        }
    }
}

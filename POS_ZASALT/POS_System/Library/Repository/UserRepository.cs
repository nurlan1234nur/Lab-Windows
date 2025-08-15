using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Library.model;

namespace Library.Repository
{
    /// <summary>
    /// Хэрэглэгчийн репозитори үүсгэх
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Нэрээр хэрэглэгч авах
        /// </summary>
        public UserRepository() { }

        /// <summary>
        /// Нэрээр хэрэглэгч авах
        /// </summary>
        public User GetUserByUsername(string username)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string getUserByUsername = @"SELECT * FROM Users WHERE Username = @username";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = getUserByUsername;
                    command.Parameters.AddWithValue("@username", username);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3)
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

    }
}

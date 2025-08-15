using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Library.model;
using Microsoft.Data.Sqlite;

namespace Library.Repository
{
    public class CategoryRepository
    {

        public CategoryRepository() { }

        /// <summary>
        /// Бүх ангилалын жагсаалт авах
        /// </summary>
        public List<Category> GetAllCategories()
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string getAllCategories = @"SELECT * FROM Categories";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = getAllCategories;
                    using (var reader = command.ExecuteReader())
                    {
                        List<Category> categories = new List<Category>();
                        while (reader.Read())
                        {
                            Category category = new Category(reader.GetInt32(0), reader.GetString(1));
                            categories.Add(category);
                        }
                        return categories;
                    }
                }
            }
        }

        /// <summary>
        /// ID-аар ангилал авах
        /// </summary>
        public Category GetCategory(int id)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string getCategory = @"SELECT * FROM Categories WHERE Id = @id";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = getCategory;
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Category(reader.GetInt32(0), reader.GetString(1));
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Нэрээр ангилал авах
        /// </summary>
        public Category GetCategoryByName(string name)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string getCategoryByName = @"SELECT * FROM Categories WHERE CategoryName = @name";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = getCategoryByName;
                    command.Parameters.AddWithValue("@name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Category(reader.GetInt32(0), reader.GetString(1));
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ангилал нэмэх
        /// </summary>
        public void AddCategory(Category category)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string addCategory = @"INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = addCategory;
                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Ангилал засах
        /// </summary>
        public void UpdateCategory(Category category)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string updateCategory = @"UPDATE Categories SET CategoryName = @categoryName WHERE CategoryId = @categoryId";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = updateCategory;
                    command.Parameters.AddWithValue("@categoryName", category.CategoryName);
                    command.Parameters.AddWithValue("@categoryId", category.CategoryId);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Ангилал устгах
        /// </summary>
        public void DeleteCategory(Category category)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string deleteCategory = @"DELETE FROM Categories WHERE CategoryId = @categoryId";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = deleteCategory;
                    command.Parameters.AddWithValue("@categoryId", category.CategoryId);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}

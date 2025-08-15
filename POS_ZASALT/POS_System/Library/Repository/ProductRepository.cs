using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.model;
using System.Text.RegularExpressions;

namespace Library.Repository
{
    /// <summary>
    /// Бүтээгдэхүүний репозитори үүсгэх
    /// </summary>
    public class ProductRepository
    {
        /// <summary>
        /// Бүтээгдэхүүний репозитори үүсгэх
        /// </summary>
        public ProductRepository() { }

        /// <summary>
        /// Бүх бүтээгдэхүүний жагсаалт авах
        /// </summary>
        public List<Product> GetAllProducts()
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string getAllProducts = @"SELECT * FROM Products";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = getAllProducts;
                    using (var reader = command.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.Barcode = reader.GetInt32(0);
                            product.Name = reader.GetString(reader.GetOrdinal("Name"));
                            product.Discount = reader.GetInt32(2);
                            product.ImagePath = reader.GetString(3);
                            product.Price = reader.GetDouble(4);
                            product.CategoryId = reader.GetInt32(5);
                            products.Add(product);
                        }
                        return products;

                    }
                }
            }
        }

        /// <summary>
        /// Баркодоор бүтээгдэхүүн авах
        /// </summary>
        public Product GetProductByBarcode(int barcode)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                String getProductByBarcode = @"SELECT * FROM Products WHERE Barcode = @barcode";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = getProductByBarcode;
                    command.Parameters.AddWithValue("@barcode", barcode);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product product = new Product();
                            product.Barcode = reader.GetInt32(0);
                            product.Name = reader.GetString(reader.GetOrdinal("Name"));
                            product.Discount = reader.GetInt32(2);
                            product.ImagePath = reader.GetString(3);
                            product.Price = reader.GetDouble(4);
                            product.CategoryId = reader.GetInt32(5);
                            return product;
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
        /// Нэрээр бүтээгдэхүүн авах
        /// </summary>
        public Product GetProductByName(String ProductName)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                String getProductByName = @"SELECT * FROM Products WHERE Name = @name";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = getProductByName;
                    command.Parameters.AddWithValue("@name", ProductName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product product = new Product();
                            product.Barcode = reader.GetInt32(0);
                            product.Name = reader.GetString(reader.GetOrdinal("Name"));
                            product.Discount = reader.GetInt32(2);
                            product.ImagePath = reader.GetString(3);
                            product.Price = reader.GetDouble(4);
                            product.CategoryId = reader.GetInt32(5);
                            return product;
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
        /// Ангилалаар бүтээгдэхүүний жагсаалт авах
        /// </summary>
        public List<Product> GetProductsByCategoryId(int CategoryId)
        {
            using(var connectioin = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connectioin.Open();
                String getProductByCategoryId = @"SELECT * FROM Products WHERE CategoryId = @categoryId";
                using (var command = connectioin.CreateCommand())
                {
                    command.CommandText = getProductByCategoryId;
                    command.Parameters.AddWithValue("@categoryId", CategoryId);
                    using (var reader = command.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();
                        while (reader.Read())
                        {
                            products.Add(new Product()
                            {
                                Barcode = reader.GetInt32(0),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Discount = reader.GetInt32(2),
                                ImagePath = reader.GetString(3),
                                Price = reader.GetDouble(4),
                                CategoryId = reader.GetInt32(5)
                            });
                        }
                        return products;
                    }
                }
            }
        }

        /// <summary>
        /// Бүтээгдэхүүн нэмэх
        /// </summary>
        public void AddProduct(Product product)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string addProduct = @"INSERT INTO Products (Barcode, Name, Discount, ImagePath, Price, CategoryId) 
                                      VALUES (@barcode, @name, @discount, @imagePath, @price, @categoryId)";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = addProduct;
                    command.Parameters.AddWithValue("@barcode", product.Barcode);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@discount", product.Discount);
                    command.Parameters.AddWithValue("@imagePath", product.ImagePath);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@categoryId", product.CategoryId);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Бүтээгдэхүүн засах
        /// </summary>
        public void UpdateProduct(Product product)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string updateProduct = @"UPDATE Products SET Name = @name, Discount = @discount, ImagePath = @imagePath, Price = @price, CategoryId = @categoryId WHERE Barcode = @barcode";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = updateProduct;
                    command.Parameters.AddWithValue("@barcode", product.Barcode);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@discount", product.Discount);
                    command.Parameters.AddWithValue("@imagePath", product.ImagePath);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@categoryId", product.CategoryId);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Бүтээгдэхүүн устгах
        /// </summary>
        public void DeleteProduct(Product product)
        {
            using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string deleteProduct = @"DELETE FROM Products WHERE Barcode = @barcode";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = deleteProduct;
                    command.Parameters.AddWithValue("@barcode", product.Barcode);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

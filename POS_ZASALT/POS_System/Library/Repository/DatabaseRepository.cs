using Library.model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Repository
{
    public class DatabaseRepository
    {
        public DatabaseRepository() { }

        /// <summary>
        /// Өгөгдлийн сангийн үүсгэх
        /// </summary>
        public void CreateDatabase()
        {
            if (!File.Exists(DatabaseConfig.DbPath))
            {
                using (var connection = new SqliteConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();

                    string createUsers = @"
                            CREATE TABLE Users (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Username TEXT NOT NULL,
                                Password TEXT NOT NULL,
                                Role TEXT NOT NULL
                            );";
                    string createMails = @"CREATE TABLE MAILS(
                        ID INTEGER
                        MAILS TEXT";
                    string insertmails = @"INSERT INTO MAILS (ID, MAILS) VALUES (1, NUR)";
                    string createProducts = @"
                            CREATE TABLE Products (
                                Barcode INTEGER PRIMARY KEY,
                                Name TEXT NOT NULL,
                                Discount INTEGER,
                                ImagePath TEXT,
                                Price REAL NOT NULL,
                                CategoryId INTEGER
                            );";

                    string insertUsers = @"
                            INSERT INTO Users (Username, Password, Role) VALUES 
                            ('manager', '1234', 'Manager'),
                            ('cashier1', '1234', 'Cashier'),
                            ('cashier2', '1234', 'Cashier');";

                    string createCategories = @"
                            CREATE TABLE Categories (
                                CategoryId INTEGER PRIMARY KEY AUTOINCREMENT,
                                CategoryName TEXT NOT NULL
                            );";

                    string insertCategories = @"
                    INSERT INTO Categories (CategoryName) VALUES 
                    ('Snacks'),
                    ('Drinks'),
                    ('Beverages'),
                    ('Dairy'),
                    ('Bakery'),
                    ('Fruits'),
                    ('Vegetables'),
                    ('Frozen Foods'),
                    ('Household'),
                    ('Personal Care');"
                    ;
                    
                    string insertdata = @"INSERT INTO Products (Barcode, Name, Discount, ImagePath, Price, CategoryId) VALUES

                        -- Snacks (1)
                        (100004, 'Doritos Nacho Cheese', 15, 'doritos.jpg', 2.8, 1),
                        (100005, 'Popcorn (Microwave)', 0, 'popcorn.jpg', 1.5, 1),

                        -- Drinks (2)
                        (200004, 'Red Bull Energy Drink', 5, 'redbull.jpg', 2.2, 2),
                        (200005, 'Sprite 500ml', 0, 'sprite.jpg', 1.0, 2),

                        -- Beverages (3)
                        (300004, 'Cold Brew Coffee', 10, 'coldbrew.jpg', 2.5, 3),
                        (300005, 'Milk Tea Bottle', 5, 'milktea.jpg', 1.8, 3),

                        -- Dairy (4)
                        (400001, 'Whole Milk 1L', 0, 'milk.jpg', 1.2, 4),
                        (400002, 'Cheddar Cheese Block', 0, 'cheddar.jpg', 3.5, 4),
                        (400003, 'Yogurt Strawberry Cup', 10, 'yogurt.jpg', 0.9, 4),

                        -- Bakery (5)
                        (500001, 'Sliced Bread', 0, 'bread.jpg', 1.5, 5),
                        (500002, 'Croissant (Butter)', 5, 'croissant.jpg', 1.1, 5),
                        (500003, 'Chocolate Muffin', 0, 'muffin.jpg', 1.3, 5),

                        -- Fruits (6)
                        (600001, 'Bananas (1kg)', 0, 'banana.jpg', 1.0, 6),
                        (600002, 'Apples (1kg)', 0, 'apple.jpg', 1.8, 6),
                        (600003, 'Oranges (1kg)', 0, 'orange.jpg', 2.0, 6),

                        -- Vegetables (7)
                        (700001, 'Tomatoes (1kg)', 0, 'tomato.jpg', 1.5, 7),
                        (700002, 'Potatoes (1kg)', 0, 'potato.jpg', 1.2, 7),
                        (700003, 'Onions (1kg)', 0, 'onion.jpg', 1.0, 7),

                        -- Frozen Foods (8)
                        (800001, 'Frozen Dumplings 500g', 10, 'dumplings.jpg', 3.2, 8),
                        (800002, 'Frozen Pizza', 15, 'pizza.jpg', 4.5, 8),
                        (800003, 'Frozen French Fries', 0, 'fries.jpg', 2.5, 8),

                        -- Household (9)
                        (900001, 'Dishwashing Liquid 500ml', 0, 'dishwash.jpg', 1.8, 9),
                        (900002, 'Toilet Paper (4 pack)', 0, 'toiletpaper.jpg', 2.0, 9),
                        (900003, 'Laundry Detergent 1kg', 5, 'detergent.jpg', 4.0, 9),

                        -- Personal Care (10)
                        (1000001, 'Shampoo 400ml', 0, 'shampoo.jpg', 3.5, 10),
                        (1000002, 'Toothpaste 100g', 0, 'toothpaste.jpg', 1.5, 10),
                        (1000003, 'Hand Soap', 0, 'handsoap.jpg', 1.0, 10);

                    ";
                    using (var comand = connection.CreateCommand())
                    {
                        comand.CommandText = createMails;
                        comand.ExecuteNonQuery();
                    }
                    using (var comand = connection.CreateCommand())
                    {
                        comand.CommandText = insertmails;
                        comand.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = createUsers;
                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = createProducts;
                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = createCategories;
                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = insertUsers;
                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = insertCategories;
                        command.ExecuteNonQuery();
                    }
                    using(var command = connection.CreateCommand())
                    {
                        command.CommandText = insertdata;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }
    }
}

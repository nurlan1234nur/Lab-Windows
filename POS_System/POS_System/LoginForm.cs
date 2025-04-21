using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms;




namespace POS_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CreateDatabase();
        }

        public void CreateDatabase()
        {
            string DbPath = DatabaseConfig.DbPath;

            try
            {
                if (!File.Exists(DbPath))
                {
                    SQLiteConnection.CreateFile(DbPath);
                    using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
                    {
                        connection.Open();

                        string createUsers = @"
                            CREATE TABLE Users (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Username TEXT NOT NULL,
                                Password TEXT NOT NULL,
                                Role TEXT NOT NULL
                            );";

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

                        new SQLiteCommand(createUsers, connection).ExecuteNonQuery();
                        new SQLiteCommand(createProducts, connection).ExecuteNonQuery();
                        new SQLiteCommand(insertUsers, connection).ExecuteNonQuery();

                        MessageBox.Show("Successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Өгөгдлийн сан үүсгэхэд алдаа гарлаа: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string role = result.ToString();
                            Form1 mainForm = new Form1(role ?? "Guest");
                            this.Hide();
                            mainForm.FormClosed += (s, args) => this.Close();
                            mainForm.Show();
                        }
                        else
                        {
                            lblError.Text = "Нэр эсвэл нууц үг буруу!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Алдаа гарлаа: " + ex.Message);
                }
            }
        }


    }
}


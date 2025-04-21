using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Form1 : Form
    {
        private string? userRole;

        public Form1(string? role)
        {
            InitializeComponent();
            userRole = role ?? "Guest";
            Load += Form1_Load;
            
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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (userRole == "Manager")
            {
                productToolStripMenuItem.Enabled = true;
                categoriesToolStripMenuItem.Enabled = true;
                helpStripMenuItem1.Enabled = true;
            }
            else if (userRole == "Cashier")
            {
                productToolStripMenuItem.Enabled = true;
                categoriesToolStripMenuItem.Visible = false;
                helpStripMenuItem1.Enabled = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Products цэс дарсан!");
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userRole == "Manager")
            {
                MessageBox.Show("Categories цэс дарсан!");
            }
        }

        private void helpStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help цэс дарсан!");
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(quantityTextBox.Text) ||
                !int.TryParse(quantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Барааны код болон тоо хэмжээг зөв оруулна уу.");
                return;
            }

            AddProductToCart(productCodeTextBox.Text.Trim(), quantity);
        }

        private void InsertNewProduct(string code, string name, int quantity, decimal price)
        {
            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Products (Code, Name, Quantity, Price, CategoryId) VALUES (@Code, @Name, @Quantity, @Price, NULL)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateProductQuantity(string productCode, int newQuantity)
        {
            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Products SET Quantity=@newQuantity WHERE Code=@productCode";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@productCode", productCode);
                    cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AddProductToCart(string productCode, int quantity)
        {
            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE Code=@productCode";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@productCode", productCode);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int existingQuantity = Convert.ToInt32(reader["Quantity"]);
                            int newQuantity = existingQuantity + quantity;

                            UpdateProductQuantity(productCode, newQuantity);

                            decimal price = Convert.ToDecimal(reader["Price"]);
                            AddToCartListView(productCode, price, quantity);
                        }
                        else
                        {
                            string name = productNameTextBox.Text.Trim();
                            if (!decimal.TryParse(productPriceTextBox.Text, out decimal price))
                            {
                                MessageBox.Show("Үнэ буруу байна!");
                                return;
                            }

                            InsertNewProduct(productCode, name, quantity, price);
                            AddToCartListView(productCode, price, quantity);
                        }
                    }
                }
            }

            productCodeTextBox.Text = "";
            quantityTextBox.Text = "";
            productNameTextBox.Text = "";
            productPriceTextBox.Text = "";
        }

        private void AddToCartListView(string code, decimal price, int quantity)
        {
            ListViewItem item = new ListViewItem(code);
            item.SubItems.Add(price.ToString("F2"));
            item.SubItems.Add(quantity.ToString());
            cartListView.Items.Add(item);
        }

        

        private void payButton_Click(object sender, EventArgs e)
        {
           
        }

       
    }
}

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
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using Library;

namespace POS_System
{
    public partial class ManageProductForm : Form
    {
        private string mode; 
        private int? barcode;

        public ManageProductForm(string mode, int? barcode = null)
        {
            InitializeComponent();
            this.mode = mode;
            this.barcode = barcode;
            Load += ManageProductForm_Load;
        }

        private void ManageProductForm_Load(object? sender, EventArgs e)
        {
            Text = mode + " Product";

            if (mode == "Edit" || mode == "Delete")
            {
                LoadProductDetails((int)barcode);
            }
        }

        private void LoadProductDetails(int barcode)
        {
            using var connection = new SQLiteConnection(DatabaseConfig.ConnectionString);
            connection.Open();
            string query = "SELECT * FROM Products WHERE Barcode=@Barcode";
            using var cmd = new SQLiteCommand(query, connection);
            cmd.Parameters.AddWithValue("@Barcode", barcode);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                nameTextBox.Text = reader["Name"].ToString();
                priceTextBox.Text = reader["Price"].ToString();
                CategoryIdTextBox.Text = reader["CategoryId"].ToString();
                ImagePathTextBox.Text = reader["ImagePath"].ToString();
                DiscountTextBox.Text = reader["Discount"].ToString();
                barcodeTextBox.Text = reader["Barcode"].ToString();
                if (mode == "Delete")
                {
                    // текст оруулахыг хориглох
                    nameTextBox.ReadOnly = true;
                    priceTextBox.ReadOnly = true;
                    ImagePathTextBox.ReadOnly = true;
                    DiscountTextBox.ReadOnly = true;
                    barcodeTextBox.ReadOnly = true;
                    CategoryIdTextBox.ReadOnly = true;

                    saveButton.Text = "Delete";
                }
                if (mode == "Edit") saveButton.Text = "Update";
            }
            
        }

       

        private void barcodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            using var connection = new SQLiteConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            if (mode == "Add")
            {
                string insertQuery = "INSERT INTO Products (Barcode, Name, Price, Discount, ImagePath, CategoryId) VALUES (@Barcode, @Name, @Price, @Discount, @ImagePath, @CategoryId)";
                using var cmd = new SQLiteCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@Barcode", int.Parse(barcodeTextBox.Text.Trim()));
                cmd.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@Discount", int.Parse(DiscountTextBox.Text.Trim()));
                cmd.Parameters.AddWithValue("@ImagePath", ImagePathTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", int.Parse(CategoryIdTextBox.Text.Trim()));
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(priceTextBox.Text.Trim()));
                cmd.ExecuteNonQuery();
            }
            else if (mode == "Edit")
            {
                string updateQuery = "UPDATE Products SET Name=@Name, Price=@Price, Discount=@Discount, ImagePath=@ImagePath, CategoryId=@CategoryId WHERE Barcode=@Barcode";
                using var cmd = new SQLiteCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                cmd.Parameters.AddWithValue("@Name", nameTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@Discount", int.Parse(DiscountTextBox.Text.Trim()));
                cmd.Parameters.AddWithValue("@ImagePath", ImagePathTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", int.Parse(CategoryIdTextBox.Text.Trim()));
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(priceTextBox.Text.Trim()));
                cmd.ExecuteNonQuery();
            }
            else if (mode == "Delete")
            {
                string deleteQuery = "DELETE FROM Products WHERE Barcode=@Barcode";
                using var cmd = new SQLiteCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();

        }
    }

}

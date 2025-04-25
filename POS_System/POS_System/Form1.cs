using System;
using System.Data.SQLite;
using System.IO;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Library;
using SqlKata;

namespace POS_System
{
    public partial class Form1 : Form
    {
        private string? userRole;
        public int barcode;
        private bool columnsInitialized = false;


        public Form1(string? role)
        {
            InitializeComponent();
            userRole = role ?? "Guest";
            Load += Form1_Load;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (userRole == "Manager")
            {
                productToolStripMenuItem.Enabled = true;
                categoriesToolStripMenuItem.Enabled = true;
                helpStripMenuItem1.Enabled = true;

                addProductBtn.Visible = true;
                editProductBtn.Visible = true;
                deleteProductBtn.Visible = true;
            }
            else
            {
                productToolStripMenuItem.Enabled = true;
                categoriesToolStripMenuItem.Visible = false;
                helpStripMenuItem1.Enabled = true;

                addProductBtn.Visible = false;
                editProductBtn.Visible = false;
                deleteProductBtn.Visible = false;
            }

            LoadCategoriesToPanel();
            dataGridView2.CellClick += dataGridView2_CellClick;

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


        private void editProductBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productCodeTextBox.Text))
            {
                MessageBox.Show("Барааны код оруулна уу.");
                return;
            }

            barcode = int.Parse(productCodeTextBox.Text);
            Product product = GetProductByCode(barcode);
            if (product != null)
            {
                ManageProductForm form = new("Edit", barcode);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Бараа олдсонгүй.");
                return;
            }
        }

        private void deleteProductBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productCodeTextBox.Text))
            {
                MessageBox.Show("Барааны код оруулна уу.");
                return;
            }
            barcode = int.Parse(productCodeTextBox.Text);
            ManageProductForm form = new ManageProductForm("Delete", barcode);
            form.ShowDialog();

        }

        private Product GetProductByCode(int barcode)
        {
            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE Barcode=@Barcode";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                Price = Convert.ToInt32(reader["Price"]),
                                Name = (reader["Name"].ToString()),
                                Barcode = Convert.ToInt32(reader["Barcode"]),
                                Discount = Convert.ToInt32(reader["Discount"]),
                                ImagePath = reader["ImagePath"].ToString(),
                                CategoryId = Convert.ToInt32(reader["CategoryId"])
                            };
                        }
                    }
                }

            }
            return null;
        }


        private void LoadCategoriesToPanel()
        {
            CategoriesPanel.Controls.Clear();

            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT * FROM Categories WHERE CategoryId IS NOT NULL";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    int y = 10;
                    while (reader.Read())
                    {
                        string? category = reader["CategoryId"].ToString();
                        string? categoryName = reader["CategoryName"].ToString();
                        Button btn = new Button();
                        btn.Text = $"{categoryName}";
                        btn.Width = 120;
                        btn.Top = y;
                        btn.Left = 10;
                        //btn.Click += (s, e) => LoadProductsByCategory(category);
                        btn.Click += (s, e) => LoadCategoriesByCategoryToPanel(Convert.ToInt32(category));
                        CategoriesPanel.Controls.Add(btn);
                        y += 40;
                    }
                }
            }
        }

        private void InitializeProductTable()
        {
            if (!columnsInitialized)
            {
                dataGridView2.Columns.Add("Name", "Нэр");
                dataGridView2.Columns.Add("Price", "Үнэ");


                // + Button
                var plusColumn = new DataGridViewButtonColumn
                {
                    Name = "Plus",
                    HeaderText = "",
                    Text = "+",
                    UseColumnTextForButtonValue = true,
                    Width = 30
                };
                dataGridView2.Columns.Add(plusColumn);

                // Quantity (text)
                var quantityColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Тоо"
                };
                dataGridView2.Columns.Add(quantityColumn);

                // - Button
                var minusColumn = new DataGridViewButtonColumn
                {
                    Name = "Minus",
                    HeaderText = "",
                    Text = "-",
                    UseColumnTextForButtonValue = true,
                    Width = 30
                };
                dataGridView2.Columns.Add(minusColumn);

                dataGridView2.Columns.Add("Total", "Нийт");
                dataGridView2.Columns.Add("Discount", "Хөнгөлөлт");

                columnsInitialized = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridView2.Columns[e.ColumnIndex].Name;

            if (columnName == "Plus" || columnName == "Minus")
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value ?? 1);
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                if (columnName == "Plus")
                {
                    qty = qty + 1;
                }
                else if (columnName == "Minus" && qty > 1)
                {
                    qty = qty - 1;
                }

                row.Cells["Quantity"].Value = qty;
                row.Cells["Total"].Value = price * qty;
            }
        }



        private void LoadProductsByName(string? productName)
        {
            InitializeProductTable();

            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE Name=@Name";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", productName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string? name = reader["Name"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            string? discount = reader["Discount"]?.ToString();

                            bool found = false;

                            // Row exists?
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                if (row.Cells["Name"].Value?.ToString() == name)
                                {
                                    int currentQty = row.Cells["Quantity"].Value == null ? 1 : Convert.ToInt32(row.Cells["Quantity"].Value);
                                    currentQty++;
                                    row.Cells["Quantity"].Value = currentQty;
                                    row.Cells["Total"].Value = price * currentQty;
                                    found = true;
                                    break;
                                }
                            }

                            // Not found — add new row
                            if (!found)
                            {
                                int qty = 1;
                                decimal total = price * qty;
                                dataGridView2.Rows.Add(name, price, "+", qty, "-", total, discount);
                            }
                        }
                    }
                }
            }
        }



        private void LoadCategoriesByCategoryToPanel(int categoryId)
        {

            ProductsPanel.Controls.Clear();
            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE CategoryId=@CategoryId";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        int y = 10;
                        while (reader.Read())
                        {
                            string productName = reader["Name"].ToString();
                            string imagePath = reader["ImagePath"].ToString();
                            int barcode = Convert.ToInt32(reader["Barcode"]);

                            void panelClickHandler(object sender, EventArgs e)
                            {
                                LoadProductsByName(productName);
                            }

                            Panel panel = new Panel
                            {
                                Width = 140,
                                Height = 180,
                                Top = y,
                                Left = 10,
                                BorderStyle = BorderStyle.FixedSingle,
                                Cursor = Cursors.Hand
                            };

                            PictureBox pictureBox = new PictureBox
                            {
                                Width = 120,
                                Height = 120,
                                Top = 10,
                                Left = 10,
                                SizeMode = PictureBoxSizeMode.Zoom
                            };

                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                pictureBox.Image = Image.FromFile(imagePath);
                            }

                            Label label = new Label
                            {
                                Text = productName,
                                Top = 140,
                                Left = 10,
                                Width = 120,
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            panel.Controls.Add(pictureBox);
                            panel.Controls.Add(label);

                            panel.Click += panelClickHandler;
                            label.Click += panelClickHandler;
                            pictureBox.Click += panelClickHandler;

                            ProductsPanel.Controls.Add(panel);
                            y += 190;
                        }
                    }
                }
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CategoriesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addProductBtn_Click_1(object sender, EventArgs e)
        {
            ManageProductForm form = new ManageProductForm("Add");
            form.ShowDialog();
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadByBarcodeToPanel(int barcode)
        {
            ProductsPanel.Controls.Clear();
            using (var connection = new SQLiteConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE Barcode=@Barcode";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Barcode", barcode);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        int y = 10;
                        while (reader.Read())
                        {
                            string productName = reader["Name"].ToString();
                            string imagePath = reader["ImagePath"].ToString();
                            Panel panel = new Panel
                            {
                                Width = 140,
                                Height = 180,
                                Top = y,
                                Left = 10,
                                BorderStyle = BorderStyle.FixedSingle,
                                Cursor = Cursors.Hand
                            };
                            PictureBox pictureBox = new PictureBox
                            {
                                Width = 120,
                                Height = 120,
                                Top = 10,
                                Left = 10,
                                SizeMode = PictureBoxSizeMode.Zoom
                            };
                            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                            {
                                pictureBox.Image = Image.FromFile(imagePath);
                            }
                            Label label = new Label
                            {
                                Text = productName,
                                Top = 140,
                                Left = 10,
                                Width = 120,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            panel.Controls.Add(pictureBox);
                            panel.Controls.Add(label);


                            void panelhandlerClick(object sender, EventArgs e)
                            {
                                LoadProductsByName(productName);
                            }

                            panel.Click += panelhandlerClick;
                            label.Click += panelhandlerClick;
                            pictureBox.Click += panelhandlerClick;

                            ProductsPanel.Controls.Add(panel);
                            y += 190;

                        }
                    }
                }
            }


        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            barcode = int.Parse(productCodeTextBox.Text);
            LoadByBarcodeToPanel(barcode);
        }

   
    }
}

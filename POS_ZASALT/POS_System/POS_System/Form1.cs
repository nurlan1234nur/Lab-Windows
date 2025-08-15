using System;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Library;
using Library.model;
using Library.Repository;
using Library.Service;

namespace POS_System
{
    public partial class Form1 : Form
    {
        private AuthService _authService;
        private ProductService _productService;
        private CategoryService _categoryService;
        private OrderService _order;
        public String userRole { get; set; }

        /// <summary>
        /// Үндсэн форм үүсгэх
        /// </summary>
        public Form1(string role)
        {
            InitializeComponent();
            _productService = new ProductService();
            _authService = new AuthService();
            _categoryService = new CategoryService();
            _order = new OrderService();
            _order.OrderUpdated += Order_OrderUpdated;

            userRole = role;
            Load += Form1_Load;
        }

        /// <summary>
        /// Форм ачаалагдахад хэрэглэгчийн эрхээр товчнуудыг тохируулах
        /// </summary>
        void Form1_Load(object sender, EventArgs e)
        {
            if (userRole.ToLower() == "manager")
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
        }

        /// <summary>
        /// Бүх барааны жагсаалт харуулах
        /// </summary>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AllProducts products = new AllProducts();
            products.ShowDialog();
        }

        /// <summary>
        /// Ангилал удирдах форм харуулах
        /// </summary>
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userRole.ToLower() == "manager")
            {
                CategoryForm form = new CategoryForm();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Энэ үйлдлийг хийх эрх байхгүй байна.");
            }
        }

        /// <summary>
        /// Тусламж харуулах
        /// </summary>
        private void helpStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help!");
        }

        /// <summary>
        /// Бараа засах форм харуулах
        /// </summary>
        private void editProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var mode = editProductBtn.Text;
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Барааны код оруулна уу.");
                    return;
                }

                var barcode = int.Parse(textBox1.Text);
                Product product = _productService.GetProductByBarcode(barcode);
                if (product != null)
                {
                    ManageProductForm form = new(mode, barcode);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }
        }

        /// <summary>
        /// Бараа устгах форм харуулах
        /// </summary>
        private void deleteProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var mode = deleteProductBtn.Text;
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Барааны код оруулна уу.");
                    return;
                }

                var barcode = int.Parse(textBox1.Text);
                Product product = _productService.GetProductByBarcode(barcode);
                if (product != null)
                {
                    ManageProductForm form = new ManageProductForm(mode, barcode);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }
        }

        /// <summary>
        /// Ангилалын товчнуудыг панелд харуулах
        /// </summary>
        private void LoadCategoriesToPanel()
        {
            CategoriesPanel.Controls.Clear();

            List<Category> categories = _categoryService.GetAllCategories();
            if (categories == null || categories.Count == 0)
            {
                MessageBox.Show("No categories found.");
                return;
            }
            else
            {
                int y = 10;
                foreach (var item in categories)
                {
                    string? categoryId = item.CategoryId.ToString();
                    string? categoryName = item.CategoryName.ToString();
                    Button btn = new Button();
                    btn.Text = $"{categoryName}";
                    btn.Width = 120;
                    btn.Top = y;
                    btn.Left = 10;
                    btn.Click += (s, e) => LoadProductsByCategoryIdToPanel(Convert.ToInt32(categoryId));
                    CategoriesPanel.Controls.Add(btn);
                    y += 40;
                }
                if (categories.Count > 0)
                {
                    LoadProductsByCategoryIdToPanel(categories[0].CategoryId);
                }
            }
        }

        /// <summary>
        /// Нэрээр бараа хайх
        /// </summary>
        private void LoadProductsByName(string productName)
        {
            try
            {
                List<Product> products = _productService.GetAllProducts();
                AddProductControls(products.Where(p => p.Name.ToLower().Contains(productName.ToLower())).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Барааны мэдээлэл харуулахад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Барааны хяналтуудыг панелд харуулах
        /// </summary>
        private void AddProductControls(List<Product> products)
        {
            ProductsPanel.Controls.Clear();
            foreach (var product in products)
            {
                var productControl = new productUserControl(product);
                productControl.ProductClicked += ProductControl_ProductClicked;
                productControl.Width = 200;
                productControl.Height = 200;
                productControl.Margin = new Padding(5);
                ProductsPanel.Controls.Add(productControl);
            }
        }

        /// <summary>
        /// Бараа дээр дарахад захиалгад нэмэх
        /// </summary>
        private void ProductControl_ProductClicked(object sender, Product product)
        {
            try
            {
                _order.AddOrderItem(product.Name, product.Price, 1, product.Discount);
                RefreshOrderPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Бараа нэмэхэд алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Захиалгын панелыг шинэчлэх
        /// </summary>
        private void RefreshOrderPanel()
        {
            try
            {
                OrderPanel.Controls.Clear();
                OrderPanel.AutoScroll = true;

                var currentOrder = _order.GetCurrentOrder();
                int yPosition = 0;

                foreach (var item in currentOrder.OrderItems)
                {
                    var itemControl = new orderItem(item, _order);
                    itemControl.Location = new Point(0, yPosition);
                    itemControl.Width = OrderPanel.Width - 20;
                    itemControl.ItemUpdated += OrderItem_ItemUpdated;
                    OrderPanel.Controls.Add(itemControl);
                    yPosition += itemControl.Height + 5;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Захиалгын мэдээлэл шинэчлэхэд алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Захиалгын бараа өөрчлөгдөхөд дуудагдах
        /// </summary>
        private void OrderItem_ItemUpdated(object sender, EventArgs e)
        {
            RefreshOrderPanel();
        }

        /// <summary>
        /// Баркодоор бараа хайх
        /// </summary>
        private void LoadByBarcodeToPanel(int barcode)
        {
            try
            {
                ProductsPanel.Controls.Clear();
                Product product = _productService.GetProductByBarcode(barcode);
                if (product != null)
                {
                    AddProductControls(new List<Product> { product });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Барааны мэдээлэл харуулахад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Ангилалаар бараа харуулах
        /// </summary>
        private void LoadProductsByCategoryIdToPanel(int categoryId)
        {
            try
            {
                List<Product> products = _productService.GetProductsByCategory(categoryId);
                AddProductControls(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Барааны мэдээлэл харуулахад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Шинэ бараа нэмэх форм харуулах
        /// </summary>
        private void addProductBtn_Click_1(object sender, EventArgs e)
        {
            var mode = addProductBtn.Text;
            ManageProductForm form = new ManageProductForm(mode);
            form.ShowDialog();
        }

        /// <summary>
        /// Бараа хайх
        /// </summary>
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productCodeTextBox.Text))
            {
                MessageBox.Show("Хайх утга оруулна уу.");
                return;
            }

            LoadProductsByName(productCodeTextBox.Text);
        }

        /// <summary>
        /// Төлбөр төлөх форм харуулах
        /// </summary>
        private void payButton_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment(_order.GetCurrentOrder());
            payment.ShowDialog();
        }

        /// <summary>
        /// Захиалгыг цэвэрлэх
        /// </summary>
        private void Clear_Click(object sender, EventArgs e)
        {
            _order = new OrderService();
            _order.OrderUpdated += Order_OrderUpdated;
            RefreshOrderPanel();
        }

        /// <summary>
        /// Захиалга өөрчлөгдөхөд дуудагдах
        /// </summary>
        private void Order_OrderUpdated(object sender, EventArgs e)
        {
            RefreshOrderPanel();
        }

        /// <summary>
        /// Барааны код оруулахад дуудагдах
        /// </summary>
        private void productCodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Барааны код оруулахад дуудагдах
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void ProductsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

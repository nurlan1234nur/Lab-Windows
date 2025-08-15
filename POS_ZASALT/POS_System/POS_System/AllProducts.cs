using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Service;
using Library.Repository;
using Library.model;

namespace POS_System
{
    /// <summary>
    /// Form for displaying all products in a grid layout
    /// Бүх бүтээгдэхүүнийг сүлжээ хэлбэрээр харуулах форм
    /// </summary>
    public partial class AllProducts : Form
    {
        /// <summary>
        /// Service for handling product-related operations
        /// Бүтээгдэхүүнтэй холбоотой үйлдлүүдийг удирдах үйлчилгээ
        /// </summary>
        ProductService service;

        /// <summary>
        /// List to store all products
        /// Бүх бүтээгдэхүүнийг хадгалах жагсаалт
        /// </summary>
        List<Product> products;

        /// <summary>
        /// Number of columns in the product grid
        /// Бүтээгдэхүүний сүлжээний баганын тоо
        /// </summary>
        private const int COLUMNS = 4;

        /// <summary>
        /// Margin between product items
        /// Бүтээгдэхүүний хоорондын зай
        /// </summary>
        private const int MARGIN = 10;

        /// <summary>
        /// Бүх бүтээгдэхүүний форм үүсгэх
        /// </summary>
        public AllProducts()
        {
            InitializeComponent();
            service = new ProductService();
            SetupPanel();
            LoadProductsToPanel();
        }

        /// <summary>
        /// Панелийн тохиргоо хийх
        /// </summary>
        private void SetupPanel()
        {
            ProductsPanel.AutoScroll = true;
            ProductsPanel.WrapContents = true;
            ProductsPanel.FlowDirection = FlowDirection.LeftToRight;
        }

        /// <summary>
        /// Бүх бүтээгдэхүүнийг ачаалж панелд харуулах
        /// </summary>
        private void LoadProductsToPanel()
        {
            try
            {
                ProductsPanel.Controls.Clear();
                List<Product> products = service.GetAllProducts();
                AddProductControls(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Барааны мэдээлэл ачаалахад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Бүтээгдэхүүний удирдлагыг панелд нэмэх
        /// </summary>
        private void AddProductControls(List<Product> products)
        {
            try
            {
                int itemWidth = (ProductsPanel.Width - (MARGIN * (COLUMNS + 1))) / COLUMNS;

                foreach (var product in products)
                {
                    var productControl = new productUserControl(product);
                    productControl.Width = itemWidth;
                    productControl.Height = 200; 
                    productControl.Margin = new Padding(MARGIN);
                    ProductsPanel.Controls.Add(productControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Бүтээгдэхүүн нэмэхэд алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Панел дээр зурж эхлэх үед
        /// </summary>
        private void ProductsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Форм ачаалагдахад
        /// </summary>
        private void AllProducts_Load(object sender, EventArgs e)
        {

        }
    }
}

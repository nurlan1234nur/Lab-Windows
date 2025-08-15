using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.model;
using Library.Repository;
using Library.Service;

namespace POS_System
{
    /// <summary>
    /// Бүтээгдэхүүн харуулах хяналт
    /// </summary>
    public partial class productUserControl : UserControl
    {
        /// <summary>
        /// Бүтээгдэхүүн дээр дарахад гарах
        /// </summary>
        public event EventHandler<Product> ProductClicked;


        private Product _product;

        /// <summary>
        /// Бүтээгдэхүүний хяналтыг үүсгэх
        /// </summary>
        /// <param name="product">Бүтээгдэхүүний мэдээлэл</param>
        public productUserControl(Product product)
        {
            InitializeComponent();
            _product = product;

            try
            {
                string imageName = string.IsNullOrEmpty(product.ImagePath) ? "default.jpg" : product.ImagePath;
                string fullPath = Path.Combine(Application.StartupPath, "Images", imageName);

                if (File.Exists(fullPath))
                {
                    ProductPictureBox.Image = Image.FromFile(fullPath);
                    ProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    ProductPictureBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "default.png"));
                    ProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }

                ProductNameLabel.Text = product.Name;
                ProductPriceLabel.Text = product.Price.ToString() + "$";


                this.Click += ProductUserControl_Click;
                ProductPictureBox.Click += ProductUserControl_Click;
                ProductNameLabel.Click += ProductUserControl_Click;
                ProductPriceLabel.Click += ProductUserControl_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Барааны мэдээлэл харуулахад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Бүтээгдэхүүн дээр дарахад дуудагдах функц
        /// </summary>
        private void ProductUserControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (_product != null)
                {
                    ProductClicked?.Invoke(this, _product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Бараа сонгоход алдаа гарлаа: {ex.Message}");
            }
        }

        private void productUserControl_Load(object sender, EventArgs e)
        {

        }

        private void ProductPriceLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

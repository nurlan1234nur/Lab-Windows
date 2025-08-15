using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Library.Service;
using Library.model;

namespace POS_System
{
    public partial class ManageProductForm : Form
    {
        ProductService productService;
        private string mode;
        private int? barcode;

        public ManageProductForm(string mode, int? name = null)
        {
            InitializeComponent();
            productService = new ProductService();
            this.mode = mode;
            this.barcode = name;
            Load += ManageProductForm_Load;
        }

        private void ManageProductForm_Load(object sender, EventArgs e)
        {
            Text = mode + " Product";

            if (mode == "Edit" || mode == "Delete")
            {
                LoadProductDetails(barcode);
            }
        }

        private void LoadProductDetails(int? name)
        {
            if(name == null)
            {
                return;
            }
            Product product = productService.GetProductByBarcode((int)name);
            nameTextBox.Text = product.Name.ToString();
            priceTextBox.Text = product.Price.ToString();
            CategoryIdTextBox.Text = product.CategoryId.ToString();
            ImagePathTextBox.Text = product.ImagePath.ToString();
            DiscountTextBox.Text = product.Discount.ToString();
            barcodeTextBox.Text = product.Barcode.ToString();
            if (mode == "Delete")
            {
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



        private void barcodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click_1(object sender, EventArgs e) {
            
            Product product = new Product();
            product.Name = nameTextBox.Text;
            product.Price = double.Parse(priceTextBox.Text.Trim());
            product.Discount = int.Parse(DiscountTextBox.Text.Trim());
            product.ImagePath = ImagePathTextBox.Text.Trim();
            product.CategoryId = int.Parse(CategoryIdTextBox.Text.Trim());
            product.Barcode = int.Parse(barcodeTextBox.Text.Trim());

            if (mode == "Add")
            {
                productService.AddProduct(product);
            }
            else if (mode == "Edit")
            {
                productService.UpdateProduct(product);
            }
            else if (mode == "Delete")
            {
                productService.DeleteProduct(product);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }

}

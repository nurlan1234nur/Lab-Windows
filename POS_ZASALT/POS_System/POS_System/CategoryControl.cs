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

namespace POS_System
{
    public partial class CategoryControl : UserControl
    {
        public event EventHandler<Category> CategoryClicked;
        private Category _category;

        public CategoryControl(Category category)
        {
            InitializeComponent();
            _category = category;
            SetupControl();
        }

        private void SetupControl()
        {
            try
            {
                categoryIdLabel.Text = $"ID: {_category.CategoryId}";
                categoryNameLabel.Text = _category.CategoryName;

                this.Click += CategoryControl_Click;
                categoryIdLabel.Click += CategoryControl_Click;
                categoryNameLabel.Click += CategoryControl_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ангилалын мэдээлэл харуулахад алдаа гарлаа: {ex.Message}");
            }
        }

        private void CategoryControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (_category != null)
                {
                    CategoryClicked?.Invoke(this, _category);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ангилал сонгоход алдаа гарлаа: {ex.Message}");
            }
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {

        }
    }
} 
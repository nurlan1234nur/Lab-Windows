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
using Library.model;

namespace POS_System
{
    
    public partial class CategoryForm : Form
    {
        private CategoryService _categoryService;
        private int? _categoryId;

        public CategoryForm()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            Load += CategoryForm_Load;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            Text = "Ангилал удирдах";
            LoadCategories();
        }

        /// <summary>
        /// Бүх ангиллыг ачаалж панелд харуулах
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                CategoriesPanel.Controls.Clear();
                List<Category> categories = _categoryService.GetAllCategories();

                if (categories == null || categories.Count == 0)
                {
                    MessageBox.Show("Ангилал олдсонгүй.");
                    return;
                }

                foreach (var category in categories)
                {
                    var categoryControl = new CategoryControl(category);
                    categoryControl.CategoryClicked += CategoryControl_CategoryClicked;
                    categoryControl.Width = CategoriesPanel.Width - 20;
                    categoryControl.Margin = new Padding(5);
                    CategoriesPanel.Controls.Add(categoryControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ангилалын мэдээлэл харуулахад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Ангилал дээр дарахад нэрийг текстбокс руу оруулах
        /// </summary>
        private void CategoryControl_CategoryClicked(object sender, Category category)
        {
            categoryNameTextBox.Text = category.CategoryName;
        }

        /// <summary>
        /// Ангилал хайх товч дарахад
        /// </summary>
        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriesPanel.Controls.Clear();
                if (searchTextBox.Text == "" || searchTextBox == null)
                {
                    LoadCategories();
                    return;
                }
                string searchText = searchTextBox.Text;
                if (_categoryService.GetCategoryByName(searchText) == null)
                {
                    MessageBox.Show("Ангилал олдсонгүй.");
                    return;
                }
                var category = _categoryService.GetCategoryByName(searchText);
                var categoryControl = new CategoryControl(category);
                categoryControl.CategoryClicked += CategoryControl_CategoryClicked;
                categoryControl.Width = CategoriesPanel.Width - 20;
                categoryControl.Margin = new Padding(5);
                CategoriesPanel.Controls.Add(categoryControl);
                categoryNameTextBox.Text = searchText;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Хайхад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Ангилалын нэр хадгалах товч дарахад
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(categoryNameTextBox.Text))
                {
                    MessageBox.Show("Ангилалын нэр оруулна уу.");
                    return;
                }

                String saveText = searchTextBox.Text;
                String newProducName = categoryNameTextBox.Text;
                int id = _categoryService.GetCategoryByName(saveText).CategoryId;
                Category category = new Category(id, newProducName);

                _categoryService.UpdateCategory(category);
                MessageBox.Show("Ангилалын нэр амжилттай өөрчлөгдлөө.");
                categoryNameTextBox.Clear();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ангилал хадгалахад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Ангилал устгах товч дарахад
        /// </summary>
        private void clearButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoryNameTextBox == null)
                {
                    MessageBox.Show("Ангилалын нэр оруулна уу.");
                    return;
                }
                String categoryName = categoryNameTextBox.Text;
                var category = _categoryService.GetCategoryByName(categoryName);
                _categoryService.DeleteCategory(category);
                categoryNameTextBox.Clear();
                searchTextBox.Clear();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void categoryIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CategoryForm_Load_1(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Ангилал нэмэх товч дарахад
        /// </summary>
        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(AddCategoryTextBox.Text))
                {
                    MessageBox.Show("Ангилалын нэр оруулна уу.");
                    return;
                }

                Category category = new Category();
                {
                    category.CategoryName = AddCategoryTextBox.Text;
                }
                ;
                if (_categoryService.GetCategoryByName(category.CategoryName) != null)
                {
                    MessageBox.Show("Ангилалын нэр давхцаж байна.");
                    return;
                }
                _categoryService.AddCategory(category);
                MessageBox.Show("Ангилал амжилттай хадгалагдлаа.");
                categoryNameTextBox.Clear();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ангилал нэмэхэд алдаа гарлаа: {ex.Message}");
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

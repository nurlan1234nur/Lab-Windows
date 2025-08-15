using System;
using System.Collections.Generic;
using System.Linq;
using Library.Service;
using Library.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class CategoryTests
    {
        private CategoryService _categoryService;
        private List<Category> _originalCategories;

        [TestInitialize]
        public void Setup()
        {
            _categoryService = new CategoryService();
            _originalCategories = _categoryService.GetAllCategories().ToList();
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean up test data
            var currentCategories = _categoryService.GetAllCategories();
            foreach (var category in currentCategories)
            {
                if (!_originalCategories.Any(c => c.CategoryId == category.CategoryId))
                {
                    _categoryService.DeleteCategory(category);
                }
            }
        }

        [TestMethod]
        public void GetAllCategories_ShouldReturnListOfCategories()
        {
            // Act
            var categories = _categoryService.GetAllCategories();

            // Assert
            Assert.IsNotNull(categories);
            Assert.IsInstanceOfType(categories, typeof(List<Category>));
            Assert.IsTrue(categories.Count >= 0);
        }

        [TestMethod]
        public void AddCategory_WithValidName_ShouldAddCategory()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };

            // Act
            _categoryService.AddCategory(category);

            // Assert
            var categories = _categoryService.GetAllCategories();
            var addedCategory = categories.FirstOrDefault(c => c.CategoryName == "Test Category");
            Assert.IsNotNull(addedCategory);
            Assert.IsTrue(addedCategory.CategoryId > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCategory_WithEmptyName_ShouldThrowException()
        {
            // Arrange
            var category = new Category { CategoryName = "" };
            _categoryService.AddCategory(category);
        }

        [TestMethod]
        public void UpdateCategory_WithValidData_ShouldUpdateCategory()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");
            addedCategory.CategoryName = "Updated Category";

            // Act
            _categoryService.UpdateCategory(addedCategory);

            // Assert
            var categories = _categoryService.GetAllCategories();
            var updatedCategory = categories.FirstOrDefault(c => c.CategoryId == addedCategory.CategoryId);
            Assert.IsNotNull(updatedCategory);
            Assert.AreEqual("Updated Category", updatedCategory.CategoryName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateCategory_WithEmptyName_ShouldThrowException()
        {
            // Arrange
            var category = new Category { CategoryName = "" };

            // Act
            _categoryService.UpdateCategory(category);
        }

        [TestMethod]
        public void DeleteCategory_WithValidCategory_ShouldDeleteCategory()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            // Act
            _categoryService.DeleteCategory(addedCategory);

            // Assert
            var categories = _categoryService.GetAllCategories();
            var deletedCategory = categories.FirstOrDefault(c => c.CategoryId == addedCategory.CategoryId);
            Assert.IsNull(deletedCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteCategory_WithNullCategory_ShouldThrowException()
        {
            // Act
            _categoryService.DeleteCategory(null);
        }
    }
} 

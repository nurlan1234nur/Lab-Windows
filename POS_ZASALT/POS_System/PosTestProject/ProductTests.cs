using System;
using System.Collections.Generic;
using System.Linq;
using Library.Service;
using Library.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ProductTests
    {
        private ProductService _productService;
        private CategoryService _categoryService;
        private List<Product> _originalProducts;
        private List<Category> _originalCategories;

        [TestInitialize]
        public void Setup()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
            _originalProducts = _productService.GetAllProducts().ToList();
            _originalCategories = _categoryService.GetAllCategories().ToList();
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean up test data
            var currentProducts = _productService.GetAllProducts();
            foreach (var product in currentProducts)
            {
                if (!_originalProducts.Any(p => p.Barcode == product.Barcode))
                {
                    _productService.DeleteProduct(product);
                }
            }

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
        public void GetAllProducts_ShouldReturnListOfProducts()
        {
            // Act
            var products = _productService.GetAllProducts();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsInstanceOfType(products, typeof(List<Product>));
            Assert.IsTrue(products.Count >= 0);
        }

        [TestMethod]
        public void GetProductByBarcode_WithValidBarcode_ShouldReturnProduct()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath= "default.png"
            };
            _productService.AddProduct(product);

            // Act
            var foundProduct = _productService.GetProductByBarcode(123456);

            // Assert
            Assert.IsNotNull(foundProduct);
            Assert.AreEqual("Test Product", foundProduct.Name);
            Assert.AreEqual(100, foundProduct.Price);
            Assert.AreEqual(addedCategory.CategoryId, foundProduct.CategoryId);
        }

        [TestMethod]
        public void GetProductByBarcode_WithInvalidBarcode_ShouldReturnNull()
        {
            // Act
            var foundProduct = _productService.GetProductByBarcode(0);

            // Assert
            Assert.IsNull(foundProduct);
        }

        [TestMethod]
        public void GetProductsByCategory_WithValidCategoryId_ShouldReturnProducts()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath = "default.png"
            };
            _productService.AddProduct(product);

            // Act
            var products = _productService.GetProductsByCategory(addedCategory.CategoryId);

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual("Test Product", products[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetProductsByCategory_WithInvalidCategoryId_ShouldThrowException()
        {
            // Act
            _productService.GetProductsByCategory(0);
        }

        [TestMethod]
        public void AddProduct_WithValidData_ShouldAddProduct()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath = "default.png"
            };

            // Act
            _productService.AddProduct(product);

            // Assert
            var addedProduct = _productService.GetProductByBarcode(123456);
            Assert.IsNotNull(addedProduct);
            Assert.AreEqual("Test Product", addedProduct.Name);
            Assert.AreEqual(100, addedProduct.Price);
            Assert.AreEqual(addedCategory.CategoryId, addedProduct.CategoryId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProduct_WithEmptyName_ShouldThrowException()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "",
                Price = 100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath = "default.png"
            };

            // Act
            _productService.AddProduct(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProduct_WithNegativePrice_ShouldThrowException()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "Test Product",
                Price = -100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath = "default.png"
            };

            // Act
            _productService.AddProduct(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddProduct_WithInvalidCategoryId_ShouldThrowException()
        {
            // Arrange
            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Barcode = 123456,
                CategoryId = 0,
                Discount = 0,
                ImagePath = "default.png"
            };

            // Act
            _productService.AddProduct(product);
        }

        [TestMethod]
        public void UpdateProduct_WithValidData_ShouldUpdateProduct()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath = "default.png"
            };
            _productService.AddProduct(product);

            var addedProduct = _productService.GetProductByBarcode(123456);
            addedProduct.Name = "Updated Product";
            addedProduct.Price = 200;

            Console.WriteLine(product.Name);
            Console.WriteLine(addedProduct.Name);
            // Act
            _productService.UpdateProduct(addedProduct);
            Console.WriteLine(product.Name);
            Console.WriteLine(addedProduct.Name);

            // Assert
            var updatedProduct = _productService.GetProductByBarcode(123456);
            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual("Updated Product", updatedProduct.Name);
            Assert.AreEqual(200, updatedProduct.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateProduct_WithEmptyName_ShouldThrowException()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath = "default.png"
            };
            _productService.AddProduct(product);

            var addedProduct = _productService.GetProductByBarcode(123456);
            addedProduct.Name = "";

            // Act
            _productService.UpdateProduct(addedProduct);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateProduct_WithNegativePrice_ShouldThrowException()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath = "default.png"
            };
            _productService.AddProduct(product);

            var addedProduct = _productService.GetProductByBarcode(123456);
            addedProduct.Price = -200;

            // Act
            _productService.UpdateProduct(addedProduct);
        }


        [TestMethod]
        public void ProductChangerByMode_WithAddMode_ShouldAddProduct()
        {
            // Arrange
            var category = new Category { CategoryName = "Test Category" };
            _categoryService.AddCategory(category);
            var addedCategory = _categoryService.GetAllCategories().First(c => c.CategoryName == "Test Category");

            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Barcode = 123456,
                CategoryId = addedCategory.CategoryId,
                Discount = 0,
                ImagePath = "default.png"
            };

            // Act
            _productService.ProductChangerByMode("add", product);

            // Assert
            var addedProduct = _productService.GetProductByBarcode(123456);
            Assert.IsNotNull(addedProduct);
            Assert.AreEqual("Test Product", addedProduct.Name);
        }
    }
} 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository;
using Library.model;

namespace Library.Service
{
    /// <summary>
    /// Бүтээгдэхүүнтэй холбоотой үйлдлүүдийг удирдах үйлчилгээ
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// Бүтээгдэхүүний мэдээллийг хадгалах сангийн үйлчилгээ
        /// </summary>
        private readonly ProductRepository _productRepository;

        /// <summary>
        /// Бүтээгдэхүүний үйлчилгээг үүсгэх
        /// </summary>
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        /// <summary>
        /// Бүх бүтээгдэхүүний мэдээллийг авах
        /// </summary>
        /// <returns>Бүтээгдэхүүний жагсаалт</returns>
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Баркодоор бүтээгдэхүүний мэдээллийг хайх
        /// </summary>
        /// <param name="barcode">Бүтээгдэхүүний баркод</param>
        /// <returns>Бүтээгдэхүүний мэдээлэл</returns>
        public Product GetProductByBarcode(int barcode)
        {
            if (barcode <= 0)
            {
                throw new ArgumentException("Барааны код 0-ээс их байх ёстой");
            }
            var product = _productRepository.GetProductByBarcode(barcode);
            if (product == null)
            {
                throw new Exception("Бараа олдсонгүй");
            }
            return product;
        }

        /// <summary>
        /// Ангилалаар бүтээгдэхүүний жагсаалтыг авах
        /// </summary>
        /// <param name="categoryId">Ангилалын дугаар</param>
        /// <returns>Бүтээгдэхүүний жагсаалт</returns>
        public List<Product> GetProductsByCategory(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("Ангилалын ID 0-ээс их байх ёстой");

            return _productRepository.GetProductsByCategoryId(categoryId);
        }

        /// <summary>
        /// Нэрээр бүтээгдэхүүний мэдээллийг хайх
        /// </summary>
        /// <param name="name">Бүтээгдэхүүний нэр</param>
        /// <returns>Бүтээгдэхүүний мэдээлэл</returns>
        public Product GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Барааны нэр хоосон байж болохгүй");
                
            var product = _productRepository.GetProductByName(name);
            if (product == null)
                throw new Exception("Бараа олдсонгүй");
                
            return product;
        }

        /// <summary>
        /// Шинэ бүтээгдэхүүн нэмэх
        /// </summary>
        /// <param name="product">Нэмэх бүтээгдэхүүний мэдээлэл</param>
        public void AddProduct(Product product)
        {
            ValidateProduct(product);
            if (product.ImagePath == "")
            {
                product.ImagePath = "default.png";
            }
            _productRepository.AddProduct(product);
        }

        /// <summary>
        /// Бүтээгдэхүүний мэдээллийг шинэчлэх
        /// </summary>
        /// <param name="product">Шинэчлэх бүтээгдэхүүний мэдээлэл</param>
        public void UpdateProduct(Product product)
        {
            ValidateProduct(product);
            _productRepository.UpdateProduct(product);
        }

        /// <summary>
        /// Бүтээгдэхүүнийг устгах
        /// </summary>
        /// <param name="product">Устгах бүтээгдэхүүний мэдээлэл</param>
        public void DeleteProduct(Product product)
        {
            if (product == null)
                throw new ArgumentException("Бараа хоосон байж болохгүй");

            _productRepository.DeleteProduct(product);
        }

        /// <summary>
        /// Бүтээгдэхүүний мэдээллийг горимоор өөрчлөх
        /// </summary>
        /// <param name="mode">Горим (add/edit/delete)</param>
        /// <param name="product">Бүтээгдэхүүний мэдээлэл</param>
        public void ProductChangerByMode(string mode, Product product)
        {
            switch (mode.ToLower())
            {
                case "add":
                    AddProduct(product);
                    break;
                case "edit":
                    UpdateProduct(product);
                    break;
                case "delete":
                    DeleteProduct(product);
                    break;
                default:
                    throw new ArgumentException($"Буруу горим: {mode}");
            }
        }

        /// <summary>
        /// Бүтээгдэхүүний мэдээллийг шалгах
        /// </summary>
        /// <param name="product">Шалгах бүтээгдэхүүний мэдээлэл</param>
        private void ValidateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentException("Бараа хоосон байж болохгүй");

            if (string.IsNullOrEmpty(product.Name))
                throw new ArgumentException("Барааны нэр хоосон байж болохгүй");

            if (product.Price < 0)
                throw new ArgumentException("Барааны үнэ сөрөг байж болохгүй");

            if (product.CategoryId <= 0)
                throw new ArgumentException("Ангилалын ID 0-ээс их байх ёстой");
        }
    }
}

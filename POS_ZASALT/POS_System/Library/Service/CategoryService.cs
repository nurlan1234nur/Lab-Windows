using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.model;
using Library.Repository;

namespace Library.Service
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ProductRepository _productRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
            _productRepository = new ProductRepository();
        }

        /// <summary>
        /// Бүх ангилалыг авах
        /// </summary>
        public List<Category> GetAllCategories()
        {
                return _categoryRepository.GetAllCategories();
        }

        /// <summary>
        /// ID-аар ангилал хайх
        /// </summary>
        public Category GetCategory(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Ангилалын ID 0-ээс их байх ёстой");
                }
                var category = _categoryRepository.GetCategory(id);
                if (category == null)
                    throw new Exception("Ангилал олдсонгүй");

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ангилалын мэдээлэл авахад алдаа гарлаа: {ex.Message}");
            }
        }

        /// <summary>
        /// Нэрээр ангилал хайх
        /// </summary>
        public Category GetCategoryByName(string name)
        {
                if(name == "")
                {
                    throw new ArgumentException("category name hooson baina");
                }
                var category = _categoryRepository.GetCategoryByName(name);
                if (category == null)
                return null;
                    
            return category;
        }

        /// <summary>
        /// Шинэ ангилал нэмэх
        /// </summary>
        public void AddCategory(Category category)
        {
            ValidateCategory(category);
            _categoryRepository.AddCategory(category);
        }

        /// <summary>
        /// Ангилалын мэдээлэл засах
        /// </summary>
        public void UpdateCategory(Category category)
        {
               if (category == null)
                    throw new ArgumentException("Ангилал хоосон байж болохгүй");
                if(category.CategoryName == "")
                {
                    throw new ArgumentException("shine categoriin ner ni hooson baij bolohgui");
                }
                ValidateCategory(category);
                _categoryRepository.UpdateCategory(category);
        }

        /// <summary>
        /// Ангилал устгах
        /// </summary>
        public void DeleteCategory(Category category)
        {
                if (category == null)
                    throw new ArgumentException("Ангилал олдсонгүй");

                var products = _productRepository.GetProductsByCategoryId(category.CategoryId);
                if (products != null && products.Any())
                    throw new Exception("Энэ ангилалд бараа байгаа учраас устгах боломжгүй");
                _categoryRepository.DeleteCategory(category);
            
        }

        /// <summary>
        /// Ангилалын мэдээлэл шалгах
        /// </summary>
        private void ValidateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentException("Ангилал хоосон байж болохгүй");

            if (string.IsNullOrEmpty(category.CategoryName))
                throw new ArgumentException("Ангилалын нэр хоосон байж болохгүй");
        }
    }
}


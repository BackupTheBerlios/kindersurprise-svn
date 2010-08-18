using System.Collections.Generic;
using KinderSurprise.DTO;
using KinderSurprise.DAL.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.DAL.Test
{
    [TestFixture]
	public class TestCategoryRepository
    {
        [Test]
        public void Test_ExistCategoryId_Exist()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            const int categoryId = 1;

            Assert.IsTrue(categoryRepository.HasId(categoryId));
        }

        [Test]
        public void Test_ExistCategoryId_DoesntExist()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            const int categoryId = -1;

            Assert.IsFalse(categoryRepository.HasId(categoryId));
        }

        [Test]
        public void Test_GetAllCategories()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            List<CategoryDto> categories = categoryRepository.GetAll();

            Assert.AreEqual(3, categories.Count);

            Assert.AreEqual(1, categories[0].CategoryId);
            Assert.AreEqual("Plastik", categories[0].CategoryName);
            Assert.AreEqual("Alles was plaste ist", categories[0].Description);

            Assert.AreEqual(2, categories[1].CategoryId);
            Assert.AreEqual("Figur", categories[1].CategoryName);
            Assert.AreEqual("Alle Figuren", categories[1].Description);

            Assert.AreEqual(3, categories[2].CategoryId);
            Assert.AreEqual("Zinn", categories[2].CategoryName);
            Assert.AreEqual("Zinnfiguren", categories[2].Description);
        }

        [Test]
        public void Test_GetCategoryById_ValidId()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            
            const int categoryId = 1;

            CategoryDto category = categoryRepository.GetById(categoryId);

            Assert.AreEqual(categoryId, category.CategoryId);
            Assert.AreEqual("Plastik", category.CategoryName);
            Assert.AreEqual("Alles was plaste ist", category.Description);
        }

        [Test]
        public void Test_GetCategoryById_NotValidId()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            const int categoryId = -1;

            CategoryDto category = categoryRepository.GetById(categoryId);

            Assert.IsNull(category);
        }

        [Test]
        public void Test_AddCategory()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            CategoryDto categoryDto = new CategoryDto(0, "Test", "Test");

            categoryRepository.Add(categoryDto);

            int categoryId = categoryRepository.GetAll().FindLast(x => x.CategoryId > 0).CategoryId;
            CategoryDto newCategoryDto = categoryRepository.GetById(categoryId);

            Assert.IsNotNull(newCategoryDto);
            Assert.AreEqual(categoryId, newCategoryDto.CategoryId);
            Assert.AreEqual("Test", newCategoryDto.CategoryName);
            Assert.AreEqual("Test", newCategoryDto.Description);

            int categoryIdToDelete = categoryRepository.GetAll().FindLast(x => x.CategoryId > 0).CategoryId;

            categoryRepository.DeleteById(categoryIdToDelete);

        }

        [Test]
        public void Test_UpdateCategory()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            CategoryDto categoryDto = new CategoryDto(0, "Figur", "Alle Figuren");
            categoryRepository.Add(categoryDto);
            
            int categoryId = categoryRepository.GetAll().FindLast(x => x.CategoryId > 0).CategoryId;
            categoryDto = categoryRepository.GetById(categoryId);
            categoryDto.CategoryName = "Test";
            categoryDto.Description = "Test";
            
            categoryRepository.Update(categoryDto);

            CategoryDto newCategoryDto = categoryRepository.GetById(categoryId);

            Assert.IsNotNull(newCategoryDto);
            Assert.AreEqual(categoryId, newCategoryDto.CategoryId);
            Assert.AreEqual("Test", newCategoryDto.CategoryName);
            Assert.AreEqual("Test", newCategoryDto.Description);

            categoryRepository.DeleteById(categoryId);

            Assert.IsFalse(categoryRepository.HasId(categoryId));
        }

        [Test]
        public void Test_DeleteCategoryById()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            CategoryDto categoryDto = new CategoryDto(0, "Test", "Test");
            categoryRepository.Add(categoryDto);

            int categoryId = categoryRepository.GetAll().FindLast(x => x.CategoryId > 0).CategoryId;
            
            categoryRepository.DeleteById(categoryId);

            Assert.IsFalse(categoryRepository.HasId(categoryId));
        }
    }
}

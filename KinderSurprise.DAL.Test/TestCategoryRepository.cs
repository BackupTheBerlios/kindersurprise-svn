using System.Collections.Generic;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
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

            List<Category> categories = categoryRepository.GetAll();

            Assert.AreEqual(3, categories.Count);

            Assert.AreEqual(1, categories[0].Id);
            Assert.AreEqual("Plastik", categories[0].Name);
            Assert.AreEqual("Alles was plaste ist", categories[0].Description);

            Assert.AreEqual(2, categories[1].Id);
            Assert.AreEqual("Figur", categories[1].Name);
            Assert.AreEqual("Alle Figuren", categories[1].Description);

            Assert.AreEqual(3, categories[2].Id);
            Assert.AreEqual("Zinn", categories[2].Name);
            Assert.AreEqual("Zinnfiguren", categories[2].Description);
        }

        [Test]
        public void Test_GetCategoryById_ValidId()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            
            const int categoryId = 1;

            Category category = categoryRepository.GetById(categoryId);

            Assert.AreEqual(categoryId, category.Id);
            Assert.AreEqual("Plastik", category.Name);
            Assert.AreEqual("Alles was plaste ist", category.Description);
        }

        [Test]
        public void Test_GetCategoryById_NotValidId()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            const int categoryId = -1;

            Category category = categoryRepository.GetById(categoryId);

            Assert.IsNull(category);
        }

        [Test]
        public void Test_AddCategory()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            Category category = new Category 
			{ 
				Id = 0, 
				Name = "Test", 
				Description = "Test" 
			};
            categoryRepository.Add(category);

            int categoryId = categoryRepository.GetAll().FindLast(x => x.Id > 0).Id;
            Category newCategory = categoryRepository.GetById(categoryId);

            Assert.IsNotNull(newCategory);
            Assert.AreEqual(categoryId, newCategory.Id);
            Assert.AreEqual("Test", newCategory.Name);
            Assert.AreEqual("Test", newCategory.Description);

            int categoryIdToDelete = categoryRepository.GetAll().FindLast(x => x.Id > 0).Id;

            categoryRepository.DeleteById(categoryIdToDelete);

        }

        [Test]
        public void Test_UpdateCategory()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            Category category = new Category { Id = 0, Name = "Figur", Description = "Alle Figuren" };
            categoryRepository.Add(category);
            
            int categoryId = categoryRepository.GetAll().FindLast(x => x.Id > 0).Id;
            category = categoryRepository.GetById(categoryId);
            category.Name = "Test";
            category.Description = "Test";
            
            categoryRepository.Update(category);

            Category newCategory = categoryRepository.GetById(categoryId);

            Assert.IsNotNull(newCategory);
            Assert.AreEqual(categoryId, newCategory.Id);
            Assert.AreEqual("Test", newCategory.Name);
            Assert.AreEqual("Test", newCategory.Description);

            categoryRepository.DeleteById(categoryId);

            Assert.IsFalse(categoryRepository.HasId(categoryId));
        }

        [Test]
        public void Test_DeleteCategoryById()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            Category category = new Category { Id = 0, Name = "Test", Description = "Test" };
            categoryRepository.Add(category);

            int categoryId = categoryRepository.GetAll().FindLast(x => x.Id > 0).Id;
            
            categoryRepository.DeleteById(categoryId);

            Assert.IsFalse(categoryRepository.HasId(categoryId));
        }
    }
}

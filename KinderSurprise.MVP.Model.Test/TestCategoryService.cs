using System.Collections.Generic;
using System.Linq;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.MVP.Model.Test
{
	[TestFixture]
    public class TestCategoryService
    {
		[SetUp]
		public void Initialize()
		{
			Testing.Initialize();
		}
		
        [Test]
        public void Test_GetAll()
        {
            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
            var categories = categoryService.GetAll();

            Assert.AreEqual(3, categories.Count);
        }

        [Test]
        public void Test_GetById_NotValidId()
        {
            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
            var category = categoryService.GetById(-1);

            Assert.IsNull(category);
        }

        [Test]
        public void Test_GetById_ValidId()
        {
            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
            var category = categoryService.GetById(1);

            Assert.IsNotNull(category);
            Assert.AreEqual(1, category.Id);
            Assert.AreEqual("Plastik", category.Name);
            Assert.AreEqual("Alles was plaste ist", category.Description);
        }

        [Test]
        public void Test_SaveNewCategory()
        {
            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
            Category category = new Category { Id = 0, Name = "New", Description = "Desc" };

            categoryService.SaveOrUpdate(category);

            var theNewCategory = categoryService.GetAll().LastOrDefault();

            Assert.AreEqual("New", theNewCategory.Name);
            Assert.AreEqual("Desc", theNewCategory.Description);

            categoryService.DeleteById(theNewCategory.Id);

            Assert.IsNull(categoryService.GetById(theNewCategory.Id));
        }

        [Test]
        public void Test_UpdateExistingCategory()
        {
            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
            Category category = categoryService.GetById(1);

            Assert.AreEqual("Plastik", category.Name);

            category.Name = "Plastik overwritten";

            categoryService.SaveOrUpdate(category);

            Assert.AreEqual("Plastik overwritten", category.Name);

            category.Name = "Plastik";

            categoryService.SaveOrUpdate(category);

            Assert.AreEqual("Plastik", category.Name);
        }

        [Test]
        public void Test_DeleteCategory()
        {
            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
            Category category = new Category{ Id = 0, Name = "New", Description = "Desc" };

            categoryService.SaveOrUpdate(category);

            var newCategory = categoryService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newCategory.Name);
            Assert.AreEqual("Desc", newCategory.Description);

            categoryService.DeleteById(newCategory.Id);

            Assert.IsNull(categoryService.GetById(newCategory.Id));
        }
    }
}

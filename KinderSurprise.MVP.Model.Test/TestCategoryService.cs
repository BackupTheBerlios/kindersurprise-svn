using System.Linq;
using KinderSurprise.Model;
using NUnit.Framework;

namespace KinderSurprise.MVP.Model.Test
{
	[TestFixture]
    public class TestCategoryService
    {
        [Test]
        public void Test_GetAll()
        {
            CategoryService categoryService = new CategoryService();
            var categories = categoryService.GetAll();

            Assert.AreEqual(3, categories.Count);
        }

        [Test]
        public void Test_GetById_NotValidId()
        {
            CategoryService categoryService = new CategoryService();
            var category = categoryService.GetById(-1);

            Assert.IsNull(category);
        }

        [Test]
        public void Test_GetById_ValidId()
        {
            CategoryService categoryService = new CategoryService();
            var category = categoryService.GetById(1);

            Assert.IsNotNull(category);
            Assert.AreEqual(1, category.Id);
            Assert.AreEqual("Plastik", category.Name);
            Assert.AreEqual("Alles was plaste ist", category.Description);
        }

        [Test]
        public void Test_SaveNewCategoryDto()
        {
            CategoryService categoryService = new CategoryService();
            Category category = new Category { Id = 0, Name = "New", Description = "Desc" };

            categoryService.SaveOrUpdate(category);

            var theNewCategoryDto = categoryService.GetAll().LastOrDefault();

            Assert.AreEqual("New", theNewCategoryDto.Name);
            Assert.AreEqual("Desc", theNewCategoryDto.Description);

            categoryService.DeleteById(theNewCategoryDto.Id);

            Assert.IsNull(categoryService.GetById(theNewCategoryDto.Id));
        }

        [Test]
        public void Test_UpdateExistingDto()
        {
            CategoryService categoryService = new CategoryService();
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
        public void Test_DeleteCategoryDto()
        {
            CategoryService categoryService = new CategoryService();
            Category category = new Category{ Id = 0, Name = "New", Description = "Desc" };

            categoryService.SaveOrUpdate(category);

            var newCategoryDto = categoryService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newCategoryDto.Name);
            Assert.AreEqual("Desc", newCategoryDto.Description);

            categoryService.DeleteById(newCategoryDto.Id);

            Assert.IsNull(categoryService.GetById(newCategoryDto.Id));
        }
    }
}

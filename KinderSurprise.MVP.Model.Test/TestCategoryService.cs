using System.Linq;
using KinderSurprise.DTO;
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
            Assert.AreEqual(1, category.CategoryId);
            Assert.AreEqual("Plastik", category.CategoryName);
            Assert.AreEqual("Alles was plaste ist", category.Description);
        }

        [Test]
        public void Test_SaveNewCategoryDto()
        {
            CategoryService categoryService = new CategoryService();
            CategoryDto categoryDto = new CategoryDto(0,"New","Desc");

            categoryService.SaveOrUpdate(categoryDto);

            var theNewCategoryDto = categoryService.GetAll().LastOrDefault();

            Assert.AreEqual("New", theNewCategoryDto.CategoryName);
            Assert.AreEqual("Desc", theNewCategoryDto.Description);

            categoryService.DeleteById(theNewCategoryDto.CategoryId);

            Assert.IsNull(categoryService.GetById(theNewCategoryDto.CategoryId));
        }

        [Test]
        public void Test_UpdateExistingDto()
        {
            CategoryService categoryService = new CategoryService();
            CategoryDto categoryDto = categoryService.GetById(1);

            Assert.AreEqual("Plastik", categoryDto.CategoryName);

            categoryDto.CategoryName = "Plastik overwritten";

            categoryService.SaveOrUpdate(categoryDto);

            Assert.AreEqual("Plastik overwritten", categoryDto.CategoryName);

            categoryDto.CategoryName = "Plastik";

            categoryService.SaveOrUpdate(categoryDto);

            Assert.AreEqual("Plastik", categoryDto.CategoryName);
        }

        [Test]
        public void Test_DeleteCategoryDto()
        {
            CategoryService categoryService = new CategoryService();
            CategoryDto categoryDto = new CategoryDto(0, "New", "Desc");

            categoryService.SaveOrUpdate(categoryDto);

            var newCategoryDto = categoryService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newCategoryDto.CategoryName);
            Assert.AreEqual("Desc", newCategoryDto.Description);

            categoryService.DeleteById(newCategoryDto.CategoryId);

            Assert.IsNull(categoryService.GetById(newCategoryDto.CategoryId));
        }
    }
}

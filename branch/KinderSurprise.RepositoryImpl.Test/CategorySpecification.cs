using System.Collections.Generic;
using KinderSurprise.Model;
using KinderSurprise.Repository;
using KinderSurprise.RepositoryImpl.Test;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.RepositoryImpl.TestCategoryRepos
{
	[TestFixture]
	public class WhenCheckingIfValidCategoryExist : RepositoryFixture
    {
		private const int CategoryId = 1;
		private ICategoryRepository m_CategoryRepository;
		private bool m_ReturnValue;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
		}
		
		protected override void Because()
		{
			m_ReturnValue = m_CategoryRepository.HasId(CategoryId);
		}
		
		[Test]
		public void ShouldReturnTrue()
		{
			Assert.IsTrue(m_ReturnValue);
		}
	}
	
	[TestFixture]
	public class WhenCheckingIfInvalidCategoryExist : RepositoryFixture
    {
		private const int CategoryId = -1;
		private ICategoryRepository m_CategoryRepository;
		private bool m_ReturnValue;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
		}
		
		protected override void Because()
		{
			m_ReturnValue = m_CategoryRepository.HasId(CategoryId);
		}
		
		[Test]
		public void ShouldReturnFalse()
		{
			Assert.IsFalse(m_ReturnValue);
		}
	}
	
	[TestFixture]
	public class WhenRequestingAllCategories : RepositoryFixture
    {
		private ICategoryRepository m_CategoryRepository;
		private List<Category> m_Categories;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
		}
		
		protected override void Because()
		{
			m_Categories = m_CategoryRepository.GetAll();
		}
		
		[Test]
		public void ShouldContainAllData()
		{
			Assert.AreEqual(3, m_Categories.Count);

            Assert.AreEqual(1, m_Categories[0].Id);
            Assert.AreEqual("Plastik", m_Categories[0].Name);
            Assert.AreEqual("Alles was plaste ist", m_Categories[0].Description);

            Assert.AreEqual(2, m_Categories[1].Id);
            Assert.AreEqual("Figur", m_Categories[1].Name);
            Assert.AreEqual("Alle Figuren", m_Categories[1].Description);

            Assert.AreEqual(3, m_Categories[2].Id);
            Assert.AreEqual("Zinn", m_Categories[2].Name);
            Assert.AreEqual("Zinnfiguren", m_Categories[2].Description);
		}
	}
	
	[TestFixture]
	public class WhenRequestingValidCategoryById : RepositoryFixture
    {
		private const int CategoryId = 1;
		private ICategoryRepository m_CategoryRepository;
		private Category m_ReturnValue;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
		}
		
		protected override void Because()
		{
			m_ReturnValue = m_CategoryRepository.GetById(CategoryId);
		}
		
		[Test]
		public void ShouldReturnTheCategory()
		{
			Assert.AreEqual(CategoryId, m_ReturnValue.Id);
            Assert.AreEqual("Plastik", m_ReturnValue.Name);
            Assert.AreEqual("Alles was plaste ist", m_ReturnValue.Description);
		}
	}
	
	[TestFixture]
	public class WhenRequestingInvalidCategoryById : RepositoryFixture
    {
		private const int CategoryId = -1;
		private ICategoryRepository m_CategoryRepository;
		private Category m_ReturnValue;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
		}
		
		protected override void Because()
		{
			m_ReturnValue = m_CategoryRepository.GetById(CategoryId);
		}
		
        [Test]
		public void ShouldReturnNullObject()
		{
			Assert.IsNull(m_ReturnValue);
		}
	}
	
	[TestFixture]
	public class WhenAddingCategory : RepositoryFixture
    {
		private ICategoryRepository m_CategoryRepository;
		private Category m_Category;
		private int m_Id;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
			m_Category = new Category 
			{ 
				Id = 0, 
				Name = "Test", 
				Description = "Test" 
			};
		}
		
		protected override void Because()
		{
			m_Id = m_CategoryRepository.Add(m_Category);
		}
		
		protected override void TearDownContext()
		{
			m_CategoryRepository.DeleteById(m_Id);
		}
		
        [Test]
		public void CategoryShouldBeAddedToTheDatabase()
		{
			Category newCategory = m_CategoryRepository.GetById(m_Id);

            Assert.IsNotNull(newCategory);
            Assert.AreEqual(m_Id, newCategory.Id);
            Assert.AreEqual("Test", newCategory.Name);
            Assert.AreEqual("Test", newCategory.Description);
		}
	}
	
	[TestFixture]
	public class WhenUpdatingCategory : RepositoryFixture
    {
		private ICategoryRepository m_CategoryRepository;
		private Category m_Category;
		private int m_Id;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
			m_Category = new Category { Id = 0, Name = "Figur", Description = "Alle Figuren" };
			m_Id = m_CategoryRepository.Add(m_Category);
			m_Category = m_CategoryRepository.GetById(m_Id);
            m_Category.Name = "Test";
            m_Category.Description = "Test";
		}
		
		protected override void Because()
		{
			m_CategoryRepository.Update(m_Category);
		}
		
		protected override void TearDownContext()
		{
			m_CategoryRepository.DeleteById(m_Id);
		}
		
		[Test]
		public void CategoryShouldContainTheNewData()
		{
			Category category = m_CategoryRepository.GetById(m_Id);

            Assert.IsNotNull(category);
            Assert.AreEqual(m_Id, category.Id);
            Assert.AreEqual("Test", category.Name);
            Assert.AreEqual("Test", category.Description);
		}
	}
	
	[TestFixture]
	public class WhenDeletingCategory : RepositoryFixture
    {
		private ICategoryRepository m_CategoryRepository;
		private Category m_Category;
		private int m_Id;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
			m_Category = new Category { Id = 0, Name = "Test", Description = "Test" };
			m_Id = m_CategoryRepository.Add(m_Category);
		}
		
		protected override void Because ()
		{
			m_CategoryRepository.DeleteById(m_Id);
		}
		
		protected override void TearDownContext()
		{
		}
		
		[Test]
		public void CategoryShouldContainTheNewData()
		{
			Assert.IsFalse(m_CategoryRepository.HasId(m_Id));
		}
	}
}

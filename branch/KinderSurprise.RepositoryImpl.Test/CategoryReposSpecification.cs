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
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_CategoryRepository.HasId(CategoryId);
			}
		}
		
		protected override void TearDownContext()
		{}
		
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
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_CategoryRepository.HasId(CategoryId);
		
			}
		}
		
		protected override void TearDownContext()
		{}
		
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
			using (UnitOfWork.Start())
			{
				m_Categories = m_CategoryRepository.GetAll();
			}
		}
		
		protected override void TearDownContext()
		{}
		
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
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_CategoryRepository.GetById(CategoryId);
			}
		}
		
		protected override void TearDownContext()
		{}
		
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
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_CategoryRepository.GetById(CategoryId);
			}
		}
		
		protected override void TearDownContext()
		{}
		
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
		private Category m_NewCategory;
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
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_Id = m_CategoryRepository.Add(m_Category);
					m_NewCategory = m_CategoryRepository.GetById(m_Id);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{}
		
        [Test]
		public void CategoryShouldBeAddedToTheDatabase()
		{
            Assert.IsNotNull(m_NewCategory);
            Assert.AreEqual(m_Id, m_NewCategory.Id);
            Assert.AreEqual("Test", m_NewCategory.Name);
            Assert.AreEqual("Test", m_NewCategory.Description);
		}
	}
	
	[TestFixture]
	public class WhenUpdatingCategory : RepositoryFixture
    {
		private ICategoryRepository m_CategoryRepository;
		private Category m_Category;
		private Category m_NewCategory;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
			m_Category = new Category { Id = 2, Name = "Test", Description = "Test" };
		}
		
		protected override void Because()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_CategoryRepository.Update(m_Category);
					m_NewCategory = m_CategoryRepository.GetById(2);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{
		}
		
		[Test]
		public void CategoryShouldContainTheNewData()
		{
			Assert.IsNotNull(m_NewCategory);
            Assert.AreEqual(2, m_NewCategory.Id);
            Assert.AreEqual("Test", m_NewCategory.Name);
            Assert.AreEqual("Test", m_NewCategory.Description);
		}
	}
	
	[TestFixture]
	public class WhenDeletingCategory : RepositoryFixture
    {
		private ICategoryRepository m_CategoryRepository;
		private Category m_Category;
		
		protected override void Context()
		{
			m_CategoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
		}
		
		protected override void Because ()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_CategoryRepository.DeleteById(1);
					m_Category = m_CategoryRepository.GetById(1);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{
		}
		
		[Test]
		public void CategoryShouldNotExistAnymore()
		{
			Assert.IsNull(m_Category);
		}
	}
}

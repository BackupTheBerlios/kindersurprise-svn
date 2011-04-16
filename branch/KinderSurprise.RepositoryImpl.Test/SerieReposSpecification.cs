using System;
using System.Collections.Generic;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.Repository;
using NUnit.Framework;
using StructureMap;
using KinderSurprise.RepositoryImpl.Test;

namespace KinderSurprise.RepositoryImpl.TestSerieRepos
{
	[TestFixture]
	public class WhenCheckingIfValidSerieExist : RepositoryFixture
    {
		private const int SerieId = 1;
		private ISerieRepository m_SerieRepository;
		private bool m_ReturnValue;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_SerieRepository.HasId(SerieId);
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
	public class WhenCheckingIfInvalidSerieExist : RepositoryFixture
    {
		private const int SerieId = 6;
		private ISerieRepository m_SerieRepository;
		private bool m_ReturnValue;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_SerieRepository.HasId(SerieId);
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
	public class WhenRequestingAllSeries : RepositoryFixture
    {
		private ISerieRepository m_SerieRepository;
		private List<Serie> m_Series;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_Series = m_SerieRepository.GetAll();
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldContainAllData()
		{
			Assert.AreEqual(5, m_Series.Count);

            Assert.AreEqual(1, m_Series[0].Id);
            Assert.AreEqual("Plaste1", m_Series[0].Name);
            Assert.AreEqual("Plasteserie 1", m_Series[0].Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), m_Series[0].PublicationYear);
            Assert.AreEqual(1, m_Series[0].Category.Id);

            Assert.AreEqual(2, m_Series[1].Id);
            Assert.AreEqual("Plaste2", m_Series[1].Name);
            Assert.AreEqual("Plasteserie 2", m_Series[1].Description);
            Assert.AreEqual(new DateTime(2008, 1, 2), m_Series[1].PublicationYear);
            Assert.AreEqual(1, m_Series[1].Category.Id);

            Assert.AreEqual(3, m_Series[2].Id);
            Assert.AreEqual("Figuren1", m_Series[2].Name);
            Assert.AreEqual("Figurenserie 1", m_Series[2].Description);
            Assert.AreEqual(new DateTime(2008, 1, 3), m_Series[2].PublicationYear);
            Assert.AreEqual(2, m_Series[2].Category.Id);

            Assert.AreEqual(4, m_Series[3].Id);
            Assert.AreEqual("Figuren2", m_Series[3].Name);
            Assert.AreEqual("Figurenserie 2", m_Series[3].Description);
            Assert.AreEqual(new DateTime(2008, 1, 4), m_Series[3].PublicationYear);
            Assert.AreEqual(2, m_Series[3].Category.Id);

            Assert.AreEqual(5, m_Series[4].Id);
            Assert.AreEqual("Zinnfiguren", m_Series[4].Name);
            Assert.AreEqual("Zinnserie", m_Series[4].Description);
            Assert.AreEqual(new DateTime(2008, 1, 5), m_Series[4].PublicationYear);
            Assert.AreEqual(3, m_Series[4].Category.Id);
		}
	}
	
	[TestFixture]
	public class WhenRequestingValidSerieById : RepositoryFixture
    {
		private const int SerieId = 1;
		private ISerieRepository m_SerieRepository;
		private Serie m_ReturnValue;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_SerieRepository.GetById(SerieId);
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldReturnTheSerie()
		{
			Assert.AreEqual(SerieId, m_ReturnValue.Id);
            Assert.AreEqual("Plaste1", m_ReturnValue.Name);
            Assert.AreEqual("Plasteserie 1", m_ReturnValue.Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), m_ReturnValue.PublicationYear);
            Assert.AreEqual(1, m_ReturnValue.Category.Id);
		}
	}

	[TestFixture]
	public class WhenRequestingInvalidSerieById : RepositoryFixture
    {
		private const int SerieId = -1;
		private ISerieRepository m_SerieRepository;
		private Serie m_ReturnValue;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_SerieRepository.GetById(SerieId);
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldReturnNull()
		{
			Assert.IsNull(m_ReturnValue);
		}
	}
	
	[TestFixture]
	public class WhenAddingSerie : RepositoryFixture
    {
		private ISerieRepository m_SerieRepository;
		private Serie m_Serie;
		private Serie m_NewSerie;
		private int m_Id;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
			m_Serie = new Serie { Id = 1, Name = "Name", Description = "Test", PublicationYear =  new DateTime(2000,1,1), 
                                             Category = new Category
                                                 {
                                                     Id = 1,
                                                     Name = "TestCategory",
                                                     Description = "TestDesc"
                                                 } 
								};
		}
		
		protected override void Because()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_Id = m_SerieRepository.Add(m_Serie);
					m_NewSerie = m_SerieRepository.GetById(m_Id);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{
		}
		
        [Test]
		public void SerieShouldBeAddedToTheDatabase()
		{
            Assert.IsNotNull(m_NewSerie);
            Assert.AreEqual(m_Id, m_NewSerie.Id);
            Assert.AreEqual("Name", m_NewSerie.Name);
            Assert.AreEqual("Test", m_NewSerie.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), m_NewSerie.PublicationYear);

            Assert.IsNotNull(m_NewSerie.Category);
            Assert.AreEqual(1, m_NewSerie.Category.Id);
		}
	}
	
	[TestFixture]
	public class WhenUpdatingSerie : RepositoryFixture
    {
		private ISerieRepository m_SerieRepository;
		private Serie m_Serie;
		private Serie m_NewSerie;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
			m_Serie = new Serie { Id = 2, Name = "TestSerie", Description = "TestDesc", PublicationYear = new DateTime(2000,1,1), 
                                             Category = new Category
                                                 {
                                                     Id = 1,
                                                     Name = "TestCategory",
                                                     Description = "TestDescCat"
                                                 } 
								};
		}
		
		protected override void Because()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_SerieRepository.Update(m_Serie);
					m_NewSerie = m_SerieRepository.GetById(2);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void SerieShouldContainTheNewData()
		{
			Assert.IsNotNull(m_NewSerie);
            Assert.AreEqual(2, m_NewSerie.Id);
            Assert.AreEqual("TestSerie", m_NewSerie.Name);
            Assert.AreEqual("TestDesc", m_NewSerie.Description);
            Assert.AreEqual(new DateTime(2000,1,1), m_NewSerie.PublicationYear);
                
            Assert.IsNotNull(m_NewSerie.Category);
		}
	}
	
	[TestFixture]
	public class WhenDeletingSerie : RepositoryFixture
    {
		private ISerieRepository m_SerieRepository;
		private Serie m_Serie;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
		}
		
		protected override void Because ()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_SerieRepository.DeleteById(1);
					m_Serie = m_SerieRepository.GetById(1);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{
		}
		
		[Test]
		public void SerieShouldNotExistAnymore()
		{
			Assert.IsNull(m_Serie);
		}
	}
	
	[TestFixture]
	public class WhenRequestingSerieByCategory : RepositoryFixture
    {
		private ISerieRepository m_SerieRepository;
		private List<Serie> m_SerieList;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
		}
		
		protected override void Because ()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				m_SerieList = m_SerieRepository.GetAllByCategoryId(1);
			}
		}
		
		protected override void TearDownContext()
		{
		}
		
		[Test]
		public void ContainsExpectedElements()
		{
			Assert.IsNotNull(m_SerieList);
			Assert.AreEqual(2, m_SerieList.Count);
			Assert.AreEqual(1, m_SerieList[0].Id);
			Assert.AreEqual(2, m_SerieList[1].Id);
		}
	}
	
	[TestFixture]
	public class WhenCheckingConstraintException : RepositoryFixture
    {
		private ISerieRepository m_SerieRepository;
		private Exception m_Exception;
		private Serie m_Serie;
		
		protected override void Context()
		{
			m_SerieRepository = ObjectFactory.GetInstance<ISerieRepository>();
			m_Serie = new Serie { Id = 1, Name = "Name", Description = "Test", PublicationYear =  new DateTime(2000,1,1), 
                                             Category = new Category
                                                 {
                                                     Id = 0,
                                                     Name = "TestCategory",
                                                     Description = "TestDesc"
                                                 } 
								};
		}
		
		protected override void Because()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				try
				{
					m_SerieRepository.Add(m_Serie);	
				}
				catch(NHibernate.Exceptions.GenericADOException ex)
				{
					m_Exception = ex;
				}
			}
		}
		
		protected override void TearDownContext()
		{
		}
		
		[Test]
		public void ConstraintShouldThrowException()
		{
			Assert.IsInstanceOf<NHibernate.Exceptions.GenericADOException>(m_Exception);
		}
	}
}

using System.Collections.Generic;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.Repository;
using NUnit.Framework;
using StructureMap;
using System;
using KinderSurprise.RepositoryImpl.Test;

namespace KinderSurprise.RepositoryImpl.TestFigurRepos
{
	[TestFixture]
	public class WhenCheckingIfValidFigurExist : RepositoryFixture
    {
		private const int FigurId = 1;
		private IFigurRepository m_FigurRepository;
		private bool m_ReturnValue;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_FigurRepository.HasId(FigurId);
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
	public class WhenCheckingIfInvalidFigurExist : RepositoryFixture
    {
		private const int SerieId = 20;
		private IFigurRepository m_FigurRepository;
		private bool m_ReturnValue;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_FigurRepository.HasId(SerieId);
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
	public class WhenRequestingAllFigurs : RepositoryFixture
    {
		private IFigurRepository m_FigurRepository;
		private List<Figur> m_Figurs;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_Figurs = m_FigurRepository.GetAll();
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldContainAllData()
		{
			Assert.AreEqual(9, m_Figurs.Count);

            Assert.AreEqual(1, m_Figurs[0].Id);
            Assert.AreEqual("PlasteFigur1", m_Figurs[0].Name);
            Assert.AreEqual("Plastefigur Serie1", m_Figurs[0].Description);
            Assert.AreEqual(18.00, m_Figurs[0].Price);
            Assert.AreEqual(1, m_Figurs[0].Serie.Id);

            Assert.AreEqual(2, m_Figurs[1].Id);
            Assert.AreEqual("PlasteFigur2", m_Figurs[1].Name);
            Assert.AreEqual("Plastefigur Serie1", m_Figurs[1].Description);
            Assert.AreEqual(9.25, m_Figurs[1].Price);
            Assert.AreEqual(1, m_Figurs[1].Serie.Id);

            Assert.AreEqual(3, m_Figurs[2].Id);
            Assert.AreEqual("PlasteFigur1", m_Figurs[2].Name);
            Assert.AreEqual("Plastefigur Serie2", m_Figurs[2].Description);
            Assert.AreEqual(11.00, m_Figurs[2].Price);
            Assert.AreEqual(2, m_Figurs[2].Serie.Id);

            Assert.AreEqual(4, m_Figurs[3].Id);
            Assert.AreEqual("PlasteFigur2", m_Figurs[3].Name);
            Assert.AreEqual("Plastefigur Serie2", m_Figurs[3].Description);
            Assert.AreEqual(4.75, m_Figurs[3].Price);
            Assert.AreEqual(2, m_Figurs[3].Serie.Id);
			
            Assert.AreEqual(5, m_Figurs[4].Id);
            Assert.AreEqual("Happy Hippo1", m_Figurs[4].Name);
            Assert.AreEqual("Figur", m_Figurs[4].Description);
            Assert.AreEqual(5.11, m_Figurs[4].Price);
            Assert.AreEqual(3, m_Figurs[4].Serie.Id);

            Assert.AreEqual(6, m_Figurs[5].Id);
            Assert.AreEqual("Happy Hippo2", m_Figurs[5].Name);
            Assert.AreEqual("Figur", m_Figurs[5].Description);
            Assert.AreEqual(5.00, m_Figurs[5].Price);
            Assert.AreEqual(3, m_Figurs[5].Serie.Id);

            Assert.AreEqual(7, m_Figurs[6].Id);
            Assert.AreEqual("Happy Hippo3", m_Figurs[6].Name);
            Assert.AreEqual("Figur", m_Figurs[6].Description);
            Assert.AreEqual(5.11, m_Figurs[6].Price);
            Assert.AreEqual(3, m_Figurs[6].Serie.Id);

            Assert.AreEqual(8, m_Figurs[7].Id);
            Assert.AreEqual("Mr. Sonnenschein", m_Figurs[7].Name);
            Assert.AreEqual("Figur", m_Figurs[7].Description);
            Assert.AreEqual(11.00, m_Figurs[7].Price);
            Assert.AreEqual(4, m_Figurs[7].Serie.Id);

            Assert.AreEqual(9, m_Figurs[8].Id);
            Assert.AreEqual("Zinnsoldat", m_Figurs[8].Name);
            Assert.AreEqual("Zinnfigur", m_Figurs[8].Description);
            Assert.AreEqual(0.77, m_Figurs[8].Price);
            Assert.AreEqual(5, m_Figurs[8].Serie.Id);
		}
	}
	
	[TestFixture]
	public class WhenRequestingValidFigurById : RepositoryFixture
    {
		private const int FigurId = 1;
		private IFigurRepository m_FigurRepository;
		private Figur m_ReturnValue;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_FigurRepository.GetById(FigurId);
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldReturnTheFigur()
		{
			Assert.AreEqual(FigurId, m_ReturnValue.Id);
            Assert.AreEqual("PlasteFigur1", m_ReturnValue.Name);
            Assert.AreEqual("Plastefigur Serie1", m_ReturnValue.Description);
            Assert.AreEqual(18.00, m_ReturnValue.Price);
            Assert.AreEqual(1, m_ReturnValue.Serie.Id);
		}
	}

	[TestFixture]
	public class WhenRequestingInvalidFigurById : RepositoryFixture
    {
		private const int FigurId = -1;
		private IFigurRepository m_FigurRepository;
		private Figur m_ReturnValue;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
		}
		
		protected override void Because()
		{
			using (UnitOfWork.Start())
			{
				m_ReturnValue = m_FigurRepository.GetById(FigurId);
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
	public class WhenAddingFigur : RepositoryFixture
    {
		private IFigurRepository m_FigurRepository;
		private Figur m_Figur;
		private Figur m_NewFigur;
		private int m_Id;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
			m_Figur = new Figur { Id = 1, Name = "Name", Description = "Test", Price = (decimal) 1.11, Serie = new Serie { Id = 1} };
		}
		
		protected override void Because()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_Id = m_FigurRepository.Add(m_Figur);
					m_NewFigur = m_FigurRepository.GetById(m_Id);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{}
		
        [Test]
		public void FigurShouldBeAddedToTheDatabase()
		{
            Assert.IsNotNull(m_NewFigur);
            Assert.AreEqual(m_Id, m_NewFigur.Id);
            Assert.AreEqual("Name", m_NewFigur.Name);
            Assert.AreEqual("Test", m_NewFigur.Description);
            Assert.AreEqual(1.11, m_NewFigur.Price);
            Assert.AreEqual(1, m_NewFigur.Serie.Id);
		}
	}
	
	[TestFixture]
	public class WhenUpdatingFigur : RepositoryFixture
    {
		private IFigurRepository m_FigurRepository;
		private Figur m_Figur;
		private Figur m_NewFigur;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
			m_Figur = new Figur { Id = 1, Name = "TestFigur", Description = "TestDesc", Price = (decimal) 1.11, Serie = new Serie { Id = 1} };
		}
		
		protected override void Because()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_FigurRepository.Update(m_Figur);
					m_NewFigur = m_FigurRepository.GetById(1);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void FigurShouldContainTheNewData()
		{
			Assert.IsNotNull(m_NewFigur);
            Assert.AreEqual(1, m_NewFigur.Id);
            Assert.AreEqual("TestFigur", m_NewFigur.Name);
            Assert.AreEqual("TestDesc", m_NewFigur.Description);
            Assert.AreEqual((decimal) 1.11, m_NewFigur.Price);
                
            Assert.IsNotNull(m_NewFigur.Serie);
		}
	}
	
	[TestFixture]
	public class WhenDeletingFigur : RepositoryFixture
    {
		private IFigurRepository m_FigurRepository;
		private Figur m_Figur;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
		}
		
		protected override void Because ()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					m_FigurRepository.DeleteById(1);
					m_Figur = m_FigurRepository.GetById(1);
					transaction.Rollback();
				}
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void FigurShouldNotExistAnymore()
		{
			Assert.IsNull(m_Figur);
		}
	}
	
	[TestFixture]
	public class WhenRequestingFigurBySerie : RepositoryFixture
    {
		private IFigurRepository m_FigurRepository;
		private List<Figur> m_FigurList;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
		}
		
		protected override void Because ()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				m_FigurList = m_FigurRepository.GetAllBySerieId(1);
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ContainsExpectedElements()
		{
			Assert.IsNotNull(m_FigurList);
			Assert.AreEqual(2, m_FigurList.Count);
			Assert.AreEqual(1, m_FigurList[0].Id);
			Assert.AreEqual(2, m_FigurList[1].Id);
		}
	}
	
	[TestFixture]
	public class WhenCheckingConstraintException : RepositoryFixture
    {
		private IFigurRepository m_FigurRepository;
		private Exception m_Exception;
		private Figur m_Figur;
		
		protected override void Context()
		{
			m_FigurRepository = ObjectFactory.GetInstance<IFigurRepository>();
			m_Figur = new Figur { Id = 0, Name = "test", Description = "desc", Price = (decimal)1.67, Serie = new Serie { Id = 15 } };
		}
		
		protected override void Because()
		{
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				try
				{
					m_FigurRepository.Add(m_Figur);	
				}
				catch(NHibernate.Exceptions.GenericADOException ex)
				{
					m_Exception = ex;
				}
			}
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ConstraintShouldThrowException()
		{
			Assert.IsInstanceOf<NHibernate.Exceptions.GenericADOException>(m_Exception);
		}
	}
}

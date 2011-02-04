using System.Collections.Generic;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NUnit.Framework;

namespace KinderSurprise.DAL.Test
{
    [TestFixture]
    public class TestFigurRepository
    {
        [Test]
        public void Test_ExistFigurId_Exist()
        {
            IFigurRepository figurRepository = new FigurRepository();
            const int figurId = 1;

            Assert.IsTrue(figurRepository.HasId(figurId));
        }

        [Test]
        public void Test_ExistFigurId_ExistNot()
        {
            IFigurRepository figurRepository = new FigurRepository();
            const int figurId = -1;

            Assert.IsFalse(figurRepository.HasId(figurId));
        }

        [Test]
        public void Test_GetAllFigurs()
        {
            IFigurRepository figurRepository = new FigurRepository();

            List<Figur> figurs = figurRepository.GetAll();

            Assert.AreEqual(9, figurs.Count);

            Assert.AreEqual(1, figurs[0].Id);
            Assert.AreEqual("PlasteFigur1", figurs[0].Name);
            Assert.AreEqual("Plastefigur Serie1", figurs[0].Description);
            Assert.AreEqual(18.00, figurs[0].Price);
            Assert.AreEqual(1, figurs[0].Serie.Id);

            Assert.AreEqual(2, figurs[1].Id);
            Assert.AreEqual("PlasteFigur2", figurs[1].Name);
            Assert.AreEqual("Plastefigur Serie1", figurs[1].Description);
            Assert.AreEqual(9.25, figurs[1].Price);
            Assert.AreEqual(1, figurs[1].Serie.Id);

            Assert.AreEqual(3, figurs[2].Id);
            Assert.AreEqual("PlasteFigur1", figurs[2].Name);
            Assert.AreEqual("Plastefigur Serie2", figurs[2].Description);
            Assert.AreEqual(11.00, figurs[2].Price);
            Assert.AreEqual(2, figurs[2].Serie.Id);

            Assert.AreEqual(4, figurs[3].Id);
            Assert.AreEqual("PlasteFigur2", figurs[3].Name);
            Assert.AreEqual("Plastefigur Serie2", figurs[3].Description);
            Assert.AreEqual(4.75, figurs[3].Price);
            Assert.AreEqual(2, figurs[3].Serie.Id);
			
            Assert.AreEqual(5, figurs[4].Id);
            Assert.AreEqual("Happy Hippo1", figurs[4].Name);
            Assert.AreEqual("Figur", figurs[4].Description);
            Assert.AreEqual(5.11, figurs[4].Price);
            Assert.AreEqual(3, figurs[4].Serie.Id);

            Assert.AreEqual(6, figurs[5].Id);
            Assert.AreEqual("Happy Hippo2", figurs[5].Name);
            Assert.AreEqual("Figur", figurs[5].Description);
            Assert.AreEqual(5.00, figurs[5].Price);
            Assert.AreEqual(3, figurs[5].Serie.Id);

            Assert.AreEqual(7, figurs[6].Id);
            Assert.AreEqual("Happy Hippo3", figurs[6].Name);
            Assert.AreEqual("Figur", figurs[6].Description);
            Assert.AreEqual(5.11, figurs[6].Price);
            Assert.AreEqual(3, figurs[6].Serie.Id);

            Assert.AreEqual(8, figurs[7].Id);
            Assert.AreEqual("Mr. Sonnenschein", figurs[7].Name);
            Assert.AreEqual("Figur", figurs[7].Description);
            Assert.AreEqual(11.00, figurs[7].Price);
            Assert.AreEqual(4, figurs[7].Serie.Id);

            Assert.AreEqual(9, figurs[8].Id);
            Assert.AreEqual("Zinnsoldat", figurs[8].Name);
            Assert.AreEqual("Zinnfigur", figurs[8].Description);
            Assert.AreEqual(0.77, figurs[8].Price);
            Assert.AreEqual(5, figurs[8].Serie.Id);
        }

        [Test]
        public void Test_GetFigurById_ValidId()
        {
            IFigurRepository figurRepository = new FigurRepository();

            const int figurId = 1;

            Figur figur = figurRepository.GetById(figurId);

            Assert.AreEqual(figurId, figur.Id);
            Assert.AreEqual("PlasteFigur1", figur.Name);
            Assert.AreEqual("Plastefigur Serie1", figur.Description);
            Assert.AreEqual(18.00, figur.Price);
            Assert.AreEqual(1, figur.Serie.Id);
        }

        [Test]
        public void Test_GetFigurById_NotValidId()
        {
            IFigurRepository figurRepository = new FigurRepository();

            const int figurId = -1;

            Assert.IsNull(figurRepository.GetById(figurId));
        }

        [Test]
        public void Test_DeleteFigurById()
        {
            IFigurRepository figurRepository = new FigurRepository();

            Figur newFigur = figurRepository.GetById(1);
            newFigur.Name = "Plaste5";
            figurRepository.Add(newFigur);
            int figurId = figurRepository.GetAll().FindLast(x => x.Id > 0).Id;
            
            Assert.IsTrue(figurRepository.HasId(figurId));

            figurRepository.DeleteById(figurId);

            Assert.IsFalse(figurRepository.HasId(figurId));
        }

        [Test]
        public void Test_AddFigur()
        {
            IFigurRepository figurRepository = new FigurRepository();

            Figur figur = new Figur { Id = 1, Name = "Name", Description = "Test", Price = (decimal) 1.11, Serie = new Serie { Id = 1} };

            figurRepository.Add(figur);

            int figurId = figurRepository.GetAll().FindLast(x => x.Id > 0).Id;

            Figur newFigur = figurRepository.GetById(figurId);
            
            Assert.IsNotNull(newFigur);
            Assert.AreEqual(figurId, newFigur.Id);
            Assert.AreEqual("Name", newFigur.Name);
            Assert.AreEqual("Test", newFigur.Description);
            Assert.AreEqual(1.11, newFigur.Price);
            Assert.AreEqual(1, newFigur.Serie.Id);

            figurRepository.DeleteById(figurId);

            Assert.IsFalse(figurRepository.HasId(figurId));
        }

        [Test]
        public void Test_UpdateFigur()
        {
            IFigurRepository figurRepository = new FigurRepository();

            Figur figur = new Figur { Id = 1, Name = "TestFigur", Description = "TestDesc", Price = (decimal) 1.11, Serie = new Serie { Id = 1} };

            figurRepository.Add(figur);
            int figurId = figurRepository.GetAll().FindLast(x => x.Id > 0).Id;

            figur = figurRepository.GetById(figurId);
            Assert.AreEqual(figurId, figur.Id);
            Assert.AreEqual("TestFigur", figur.Name);
            Assert.AreEqual("TestDesc", figur.Description);
            Assert.AreEqual(1.11, figur.Price);
            Assert.AreEqual(1, figur.Serie.Id);

            figur.Name = "TestFigurOverwritten";
            figur.Description = "TestDescOverwritten";

            figurRepository.Update(figur);

            Figur newFigur = figurRepository.GetById(figurId);

            Assert.IsNotNull(newFigur);
            Assert.AreEqual(figurId, newFigur.Id);
            Assert.AreEqual("TestFigurOverwritten", newFigur.Name);
            Assert.AreEqual("TestDescOverwritten", newFigur.Description);
            Assert.AreEqual(1.11, newFigur.Price);
            Assert.AreEqual(1, figur.Serie.Id);

            Assert.IsNotNull(newFigur.Serie);

            figurRepository.DeleteById(figurId);

            Assert.IsFalse(figurRepository.HasId(figurId));
        }
		
		[Test]
		[ExpectedException(typeof (NHibernate.Exceptions.GenericADOException))]
		public void Test_TryInsertFigurWithWrongConstraint_ShouldFail()
		{
			IFigurRepository figurRepository = new FigurRepository();
			
			Figur figur = new Figur { Id = 0, Name = "test", Description = "desc", Price = (decimal)1.67, Serie = new Serie { Id = 15 } };
			figurRepository.Add(figur);	
		}

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs1()
        {
            IFigurRepository figurRepository = new FigurRepository();
            List<Figur> figurs = figurRepository.GetAllBySerieId(1);

            Assert.AreEqual(2, figurs.Count);
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs3()
        {
            IFigurRepository figurRepository = new FigurRepository();
            List<Figur> figurs = figurRepository.GetAllBySerieId(3);

            Assert.AreEqual(3, figurs.Count);
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs4()
        {
            IFigurRepository figurRepository = new FigurRepository();
            List<Figur> figurs = figurRepository.GetAllBySerieId(4);

            Assert.AreEqual(1, figurs.Count);
        }
    }
}

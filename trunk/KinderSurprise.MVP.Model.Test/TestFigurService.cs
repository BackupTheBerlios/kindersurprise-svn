using System.Linq;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.MVP.Model.Test
{
    [TestFixture]
    public class TestFigurService
    {
		[SetUp]
		public void Setup()
		{
			Testing.Initialize();
		}
		
        [Test]
        public void Test_GetAll()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            var figurs = figurService.GetAll();

            Assert.AreEqual(9, figurs.Count);
        }

        [Test]
        public void Test_GetById_NotValidId()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            var figur = figurService.GetById(-1);

            Assert.IsNull(figur);
        }

        [Test]
        public void Test_GetById_ValidId()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            var figur = figurService.GetById(1);

            Assert.IsNotNull(figur);
            Assert.AreEqual(1, figur.Id);
            Assert.AreEqual("PlasteFigur1", figur.Name);
            Assert.AreEqual("Plastefigur Serie1", figur.Description);
            Assert.AreEqual(18.00, figur.Price);
            Assert.AreEqual(1, figur.Serie.Id);
        }

        [Test]
        public void Test_SaveNewFigur()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            Figur figur = new Figur{ Id = 0, Name = "New", Description = "Desc", Price = (decimal)1.11, Serie = new Serie { Id = 1 }};

            figurService.SaveOrUpdate(figur);

            var newFigur = figurService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newFigur.Name);
            Assert.AreEqual("Desc", newFigur.Description);
            Assert.AreEqual(1.11, newFigur.Price);
            Assert.AreEqual(1, newFigur.Serie.Id);

            figurService.DeleteById(newFigur.Id);

            Assert.IsNull(figurService.GetById(newFigur.Id));
        }

        [Test]
        public void Test_UpdateExistingFigur()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            Figur figur = figurService.GetById(1);

            Assert.AreEqual("PlasteFigur1", figur.Name);

            figur.Name = "PlasteFigur1 overwritten";

            figurService.SaveOrUpdate(figur);

            Assert.AreEqual("PlasteFigur1 overwritten", figur.Name);

            figur.Name = "PlasteFigur1";

            figurService.SaveOrUpdate(figur);

            Assert.AreEqual("PlasteFigur1", figur.Name);
        }

        [Test]
        public void Test_DeleteFigur()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            Figur figur = new Figur { Id = 0, Name = "New", Description = "Desc", Price = (decimal)1.11, Serie = new Serie { Id = 1 }};

            figurService.SaveOrUpdate(figur);

            var newSerie = figurService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newSerie.Name);
            Assert.AreEqual("Desc", newSerie.Description);
            Assert.AreEqual(1.11, newSerie.Price);
            Assert.AreEqual(1, newSerie.Serie.Id);

            figurService.DeleteById(newSerie.Id);

            Assert.IsNull(figurService.GetById(newSerie.Id));
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs1()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            var figurs = figurService.GetAllBySerieId(1);

            Assert.AreEqual(2, figurs.Count);
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs3()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            var figurs = figurService.GetAllBySerieId(3);

            Assert.AreEqual(3, figurs.Count);
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs5()
        {
            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            var figurs = figurService.GetAllBySerieId(5);

            Assert.AreEqual(1, figurs.Count);
        }
    }
}

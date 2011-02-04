using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;
using NUnit.Framework;

namespace KinderSurprise.MVP.Model.Test
{
    [TestFixture]
    public class TestFigurService
    {
        [Test]
        public void Test_GetAll()
        {
            FigurService figurService = new FigurService();
            var figurs = figurService.GetAll();

            Assert.AreEqual(9, figurs.Count);
        }

        [Test]
        public void Test_GetById_NotValidId()
        {
            FigurService figurService = new FigurService();
            var figur = figurService.GetById(-1);

            Assert.IsNull(figur);
        }

        [Test]
        public void Test_GetById_ValidId()
        {
            FigurService figurService = new FigurService();
            var figur = figurService.GetById(1);

            Assert.IsNotNull(figur);
            Assert.AreEqual(1, figur.Id);
            Assert.AreEqual("PlasteFigur1", figur.Name);
            Assert.AreEqual("Plastefigur Serie1", figur.Description);
            Assert.AreEqual(18.00, figur.Price);
            Assert.AreEqual(1, figur.Serie.Id);
        }

        [Test]
        public void Test_SaveNewFigurDto()
        {
            FigurService figurService = new FigurService();
            Figur figur = new Figur{ Id = 0, Name = "New", Description = "Desc", Price = (decimal)1.11, Serie = new Serie { Id = 1 }};

            figurService.SaveOrUpdate(figur);

            var newFigurDto = figurService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newFigurDto.Name);
            Assert.AreEqual("Desc", newFigurDto.Description);
            Assert.AreEqual(1.11, newFigurDto.Price);
            Assert.AreEqual(1, newFigurDto.Serie.Id);

            figurService.DeleteById(newFigurDto.Id);

            Assert.IsNull(figurService.GetById(newFigurDto.Id));
        }

        [Test]
        public void Test_UpdateExistingFigurDto()
        {
            FigurService figurService = new FigurService();
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
        public void Test_DeleteFigurDto()
        {
            FigurService figurService = new FigurService();
            Figur figur = new Figur { Id = 0, Name = "New", Description = "Desc", Price = (decimal)1.11, Serie = new Serie { Id = 1 }};

            figurService.SaveOrUpdate(figur);

            var newSerieDto = figurService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newSerieDto.Name);
            Assert.AreEqual("Desc", newSerieDto.Description);
            Assert.AreEqual(1.11, newSerieDto.Price);
            Assert.AreEqual(1, newSerieDto.Serie.Id);

            figurService.DeleteById(newSerieDto.Id);

            Assert.IsNull(figurService.GetById(newSerieDto.Id));
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs1()
        {
            FigurService figurService = new FigurService();
            var figurs = figurService.GetAllBySerieId(1);

            Assert.AreEqual(2, figurs.Count);
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs3()
        {
            FigurService figurService = new FigurService();
            var figurs = figurService.GetAllBySerieId(3);

            Assert.AreEqual(3, figurs.Count);
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs5()
        {
            FigurService figurService = new FigurService();
            var figurs = figurService.GetAllBySerieId(5);

            Assert.AreEqual(1, figurs.Count);
        }
    }
}

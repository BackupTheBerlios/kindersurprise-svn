using System.Linq;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
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
            Assert.AreEqual(1, figur.FigurId);
            Assert.AreEqual("PlasteFigur1", figur.FigurName);
            Assert.AreEqual("Plastefigur Serie1", figur.Description);
            Assert.AreEqual(18.00, figur.Price);
            Assert.AreEqual(1, figur.Serie.SerieId);
        }

        [Test]
        public void Test_SaveNewFigurDto()
        {
            FigurService figurService = new FigurService();
            FigurDto figurDto = new FigurDto(0, "New", "Desc", (decimal)1.11, new Serie { SerieId = 1 });

            figurService.SaveOrUpdate(figurDto);

            var newFigurDto = figurService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newFigurDto.FigurName);
            Assert.AreEqual("Desc", newFigurDto.Description);
            Assert.AreEqual(1.11, newFigurDto.Price);
            Assert.AreEqual(1, newFigurDto.Serie.SerieId);

            figurService.DeleteById(newFigurDto.FigurId);

            Assert.IsNull(figurService.GetById(newFigurDto.FigurId));
        }

        [Test]
        public void Test_UpdateExistingFigurDto()
        {
            FigurService figurService = new FigurService();
            FigurDto figurDto = figurService.GetById(1);

            Assert.AreEqual("PlasteFigur1", figurDto.FigurName);

            figurDto.FigurName = "PlasteFigur1 overwritten";

            figurService.SaveOrUpdate(figurDto);

            Assert.AreEqual("PlasteFigur1 overwritten", figurDto.FigurName);

            figurDto.FigurName = "PlasteFigur1";

            figurService.SaveOrUpdate(figurDto);

            Assert.AreEqual("PlasteFigur1", figurDto.FigurName);
        }

        [Test]
        public void Test_DeleteFigurDto()
        {
            FigurService figurService = new FigurService();
            FigurDto figurDto = new FigurDto(0, "New", "Desc", (decimal)1.11, new Serie{ SerieId = 1 });

            figurService.SaveOrUpdate(figurDto);

            var newSerieDto = figurService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newSerieDto.FigurName);
            Assert.AreEqual("Desc", newSerieDto.Description);
            Assert.AreEqual(1.11, newSerieDto.Price);
            Assert.AreEqual(1, newSerieDto.Serie.SerieId);

            figurService.DeleteById(newSerieDto.FigurId);

            Assert.IsNull(figurService.GetById(newSerieDto.FigurId));
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

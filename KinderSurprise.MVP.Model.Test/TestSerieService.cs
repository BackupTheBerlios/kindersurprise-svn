using System;
using System.Linq;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using NUnit.Framework;

namespace KinderSurprise.MVP.Model.Test
{
    [TestFixture]
    public class TestSerieService
    {
        [Test]
        public void Test_GetAll()
        {
            SerieService serieService = new SerieService();
            var series = serieService.GetAll();

            Assert.AreEqual(5, series.Count);
        }

        [Test]
        public void Test_GetById_NotValidId()
        {
            SerieService serieService = new SerieService();
            var serie = serieService.GetById(-1);

            Assert.IsNull(serie);
        }

        [Test]
        public void Test_GetById_ValidId()
        {
            SerieService serieService = new SerieService();
            var serie = serieService.GetById(1);

            Assert.IsNotNull(serie);
            Assert.AreEqual(1, serie.SerieId);
            Assert.AreEqual("Plaste1", serie.SerieName);
            Assert.AreEqual("Plasteserie 1", serie.Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), serie.PublicationYear);
            Assert.AreEqual(1, serie.Category.CategoryId);
        }

        [Test]
        public void Test_SaveNewSerieDto()
        {
            SerieService serieService = new SerieService();
            SerieDto serieDto = new SerieDto(0, "New", "Desc", new DateTime(2000,1,1), new Category { CategoryId  = 1} );

            serieService.SaveOrUpdate(serieDto);

            var theNewSerieDto = serieService.GetAll().LastOrDefault();

            Assert.AreEqual("New", theNewSerieDto.SerieName);
            Assert.AreEqual("Desc", theNewSerieDto.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), theNewSerieDto.PublicationYear);
            Assert.AreEqual(1, theNewSerieDto.Category.CategoryId);

            serieService.DeleteById(theNewSerieDto.SerieId);

            Assert.IsNull(serieService.GetById(theNewSerieDto.SerieId));
        }

        [Test]
        public void Test_UpdateExistingSerieDto()
        {
            SerieService serieService = new SerieService();
            SerieDto serieDto = serieService.GetById(1);

            Assert.AreEqual("Plaste1", serieDto.SerieName);

            serieDto.SerieName = "Plaste1 overwritten";

            serieService.SaveOrUpdate(serieDto);

            Assert.AreEqual("Plaste1 overwritten", serieDto.SerieName);

            serieDto.SerieName = "Plaste1";

            serieService.SaveOrUpdate(serieDto);

            Assert.AreEqual("Plaste1", serieDto.SerieName);
        }

        [Test]
        public void Test_DeleteSerieDto()
        {
            SerieService serieService = new SerieService();
            SerieDto serieDto = new SerieDto(0, "New", "Desc", new DateTime(2000, 1,1), new Category{CategoryId = 1} );

            serieService.SaveOrUpdate(serieDto);

            var newSerieDto = serieService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newSerieDto.SerieName);
            Assert.AreEqual("Desc", newSerieDto.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), newSerieDto.PublicationYear);
            Assert.AreEqual(1, newSerieDto.Category.CategoryId);

            serieService.DeleteById(newSerieDto.SerieId);

            Assert.IsNull(serieService.GetById(newSerieDto.SerieId));
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_IdIs1()
        {
            SerieService serieService = new SerieService();
            var series = serieService.GetAllByCategoryId(1);

            Assert.AreEqual(2, series.Count);
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_IdIs2()
        {
            SerieService serieService = new SerieService();
            var series = serieService.GetAllByCategoryId(2);

            Assert.AreEqual(2, series.Count);
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_IdIs3()
        {
            SerieService serieService = new SerieService();
            var series = serieService.GetAllByCategoryId(3);

            Assert.AreEqual(1, series.Count);
        }
    }
}

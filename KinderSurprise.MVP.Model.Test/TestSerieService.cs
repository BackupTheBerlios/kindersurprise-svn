using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;
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
            Assert.AreEqual(1, serie.Id);
            Assert.AreEqual("Plaste1", serie.Name);
            Assert.AreEqual("Plasteserie 1", serie.Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), serie.PublicationYear);
            Assert.AreEqual(1, serie.Category.Id);
        }

        [Test]
        public void Test_SaveNewSerieDto()
        {
            SerieService serieService = new SerieService();
            Serie serie = new Serie { Id = 0, Name = "New", Description = "Desc", PublicationYear = new DateTime(2000,1,1), Category = new Category { Id  = 1}};

            serieService.SaveOrUpdate(serie);

            var theNewSerieDto = serieService.GetAll().LastOrDefault();

            Assert.AreEqual("New", theNewSerieDto.Name);
            Assert.AreEqual("Desc", theNewSerieDto.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), theNewSerieDto.PublicationYear);
            Assert.AreEqual(1, theNewSerieDto.Category.Id);

            serieService.DeleteById(theNewSerieDto.Id);

            Assert.IsNull(serieService.GetById(theNewSerieDto.Id));
        }

        [Test]
        public void Test_UpdateExistingSerieDto()
        {
            SerieService serieService = new SerieService();
            Serie serie = serieService.GetById(1);

            Assert.AreEqual("Plaste1", serie.Name);

            serie.Name = "Plaste1 overwritten";

            serieService.SaveOrUpdate(serie);

            Assert.AreEqual("Plaste1 overwritten", serie.Name);

            serie.Name = "Plaste1";

            serieService.SaveOrUpdate(serie);

            Assert.AreEqual("Plaste1", serie.Name);
        }

        [Test]
        public void Test_DeleteSerieDto()
        {
            SerieService serieService = new SerieService();
            Serie serie = new Serie{ Id = 0, Name = "New", Description = "Desc", PublicationYear = new DateTime(2000, 1,1), Category = new Category{Id = 1}};

            serieService.SaveOrUpdate(serie);

            var newSerieDto = serieService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newSerieDto.Name);
            Assert.AreEqual("Desc", newSerieDto.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), newSerieDto.PublicationYear);
            Assert.AreEqual(1, newSerieDto.Category.Id);

            serieService.DeleteById(newSerieDto.Id);

            Assert.IsNull(serieService.GetById(newSerieDto.Id));
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

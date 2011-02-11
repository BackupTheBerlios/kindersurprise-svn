using System;
using System.Linq;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.MVP.Model.Test
{
    [TestFixture]
    public class TestSerieService
    {
        [Test]
        public void Test_GetAll()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            var series = serieService.GetAll();

            Assert.AreEqual(5, series.Count);
        }

        [Test]
        public void Test_GetById_NotValidId()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            var serie = serieService.GetById(-1);

            Assert.IsNull(serie);
        }

        [Test]
        public void Test_GetById_ValidId()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            var serie = serieService.GetById(1);

            Assert.IsNotNull(serie);
            Assert.AreEqual(1, serie.Id);
            Assert.AreEqual("Plaste1", serie.Name);
            Assert.AreEqual("Plasteserie 1", serie.Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), serie.PublicationYear);
            Assert.AreEqual(1, serie.Category.Id);
        }

        [Test]
        public void Test_SaveNewSerie()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            Serie serie = new Serie { Id = 0, Name = "New", Description = "Desc", PublicationYear = new DateTime(2000,1,1), Category = new Category { Id  = 1}};

            serieService.SaveOrUpdate(serie);

            var theNewSerie = serieService.GetAll().LastOrDefault();

            Assert.AreEqual("New", theNewSerie.Name);
            Assert.AreEqual("Desc", theNewSerie.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), theNewSerie.PublicationYear);
            Assert.AreEqual(1, theNewSerie.Category.Id);

            serieService.DeleteById(theNewSerie.Id);

            Assert.IsNull(serieService.GetById(theNewSerie.Id));
        }

        [Test]
        public void Test_UpdateExistingSerie()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
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
        public void Test_DeleteSerie()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            Serie serie = new Serie{ Id = 0, Name = "New", Description = "Desc", PublicationYear = new DateTime(2000, 1,1), Category = new Category{Id = 1}};

            serieService.SaveOrUpdate(serie);

            var newSerie = serieService.GetAll().LastOrDefault();

            Assert.AreEqual("New", newSerie.Name);
            Assert.AreEqual("Desc", newSerie.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), newSerie.PublicationYear);
            Assert.AreEqual(1, newSerie.Category.Id);

            serieService.DeleteById(newSerie.Id);

            Assert.IsNull(serieService.GetById(newSerie.Id));
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_IdIs1()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            var series = serieService.GetAllByCategoryId(1);

            Assert.AreEqual(2, series.Count);
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_IdIs2()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            var series = serieService.GetAllByCategoryId(2);

            Assert.AreEqual(2, series.Count);
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_IdIs3()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            var series = serieService.GetAllByCategoryId(3);

            Assert.AreEqual(1, series.Count);
        }
    }
}

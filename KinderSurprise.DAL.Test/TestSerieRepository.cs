using System;
using System.Collections.Generic;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NUnit.Framework;
using MySql.Data;

namespace KinderSurprise.DAL.Test
{
    [TestFixture]
    public class TestSerieRepository
    {
        [Test]
        public void Test_ExistSerieId_DoesntExist()
        {
            ISerieRepository serieRepository = new SerieRepository();
            const int serieId = 1;

            Assert.IsTrue(serieRepository.HasId(serieId));
        }

        [Test]
        public void Test_ExistSerieId_DoesExist()
        {
            ISerieRepository serieRepository = new SerieRepository();
            const int serieId = -1;

            Assert.IsFalse(serieRepository.HasId(serieId));
        }

        [Test]
        public void Test_GetAllSeries()
        {
            ISerieRepository serieRepository = new SerieRepository();

            List<Serie> series = serieRepository.GetAll();

            Assert.AreEqual(5, series.Count);

            Assert.AreEqual(1, series[0].Id);
            Assert.AreEqual("Plaste1", series[0].Name);
            Assert.AreEqual("Plasteserie 1",series[0].Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), series[0].PublicationYear);
            Assert.AreEqual(1,series[0].Category.Id);

            Assert.AreEqual(2, series[1].Id);
            Assert.AreEqual("Plaste2", series[1].Name);
            Assert.AreEqual("Plasteserie 2", series[1].Description);
            Assert.AreEqual(new DateTime(2008, 1, 2), series[1].PublicationYear);
            Assert.AreEqual(1, series[1].Category.Id);

            Assert.AreEqual(3, series[2].Id);
            Assert.AreEqual("Figuren1", series[2].Name);
            Assert.AreEqual("Figurenserie 1", series[2].Description);
            Assert.AreEqual(new DateTime(2008, 1, 3), series[2].PublicationYear);
            Assert.AreEqual(2, series[2].Category.Id);

            Assert.AreEqual(4, series[3].Id);
            Assert.AreEqual("Figuren2", series[3].Name);
            Assert.AreEqual("Figurenserie 2", series[3].Description);
            Assert.AreEqual(new DateTime(2008, 1, 4), series[3].PublicationYear);
            Assert.AreEqual(2, series[3].Category.Id);

            Assert.AreEqual(5, series[4].Id);
            Assert.AreEqual("Zinnfiguren", series[4].Name);
            Assert.AreEqual("Zinnserie", series[4].Description);
            Assert.AreEqual(new DateTime(2008, 1, 5), series[4].PublicationYear);
            Assert.AreEqual(3, series[4].Category.Id);
        }

        [Test]
        public void Test_GetSerieById_ValidId()
        {
            ISerieRepository serieRepository = new SerieRepository();

            const int serieId = 1;

            Serie serie = serieRepository.GetById(serieId);

            Assert.AreEqual(serieId, serie.Id);
            Assert.AreEqual("Plaste1", serie.Name);
            Assert.AreEqual("Plasteserie 1", serie.Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), serie.PublicationYear);
            Assert.AreEqual(1, serie.Category.Id);
        }

        [Test]
        public void Test_GetSerieById_NotValidId()
        {
            ISerieRepository serieRepository = new SerieRepository();

            const int serieId = -1;

            Serie serie = serieRepository.GetById(serieId);

            Assert.IsNull(serie);
        }

        [Test]
        public void Test_DeleteSerieById()
        {
            ISerieRepository serieRepository = new SerieRepository();

            Assert.IsTrue(serieRepository.HasId(1));

            Serie oldSerie = serieRepository.GetById(1);
            oldSerie.Name = "Plaste5";
            serieRepository.Add(oldSerie);
            int serieId = serieRepository.GetAll().FindLast(x => x.Id > 0).Id;

            serieRepository.DeleteById(serieId);

            Assert.IsFalse(serieRepository.HasId(serieId));
        }

        [Test]
        public void Test_UpdateSerie()
        {
            ISerieRepository serieRepository = new SerieRepository();

            Serie serie = new Serie { Id = 0, Name = "TestSerie", Description = "TestDesc", PublicationYear = new DateTime(2000,1,1), 
                                             Category = new Category
                                                 {
                                                     Id = 1,
                                                     Name = "TestCategory",
                                                     Description = "TestDescCat"
                                                 } };
            serieRepository.Add(serie);
            int serieId = serieRepository.GetAll().FindLast(x => x.Id > 0).Id;

            serie = serieRepository.GetById(serieId);
            serie.Name = "TestSerieOverwritten";
            serie.Description = "TestDescOverwritten";

            serieRepository.Update(serie);
            
            Serie newSerie = serieRepository.GetById(serieId);

            Assert.IsNotNull(newSerie);
            Assert.AreEqual(serieId, newSerie.Id);
            Assert.AreEqual("TestSerieOverwritten", newSerie.Name);
            Assert.AreEqual("TestDescOverwritten", newSerie.Description);
            Assert.AreEqual(new DateTime(2000,1,1), newSerie.PublicationYear);
                
            Assert.IsNotNull(newSerie.Category);

            serieRepository.DeleteById(serieId);

            Assert.IsFalse(serieRepository.HasId(serieId));
        }

        [Test]
        public void Test_AddSerie()
        {
            ISerieRepository serieRepository = new SerieRepository();

            Serie serie = new Serie { Id = 1, Name = "Name", Description = "Test", PublicationYear =  new DateTime(2000,1,1), 
                                             Category = new Category
                                                 {
                                                     Id = 1,
                                                     Name = "TestCategory",
                                                     Description = "TestDesc"
                                                 } };

            serieRepository.Add(serie);

            int serieId = serieRepository.GetAll().FindLast(x => x.Id > 0).Id;

            Serie newSerie = serieRepository.GetById(serieId);
            
            Assert.IsNotNull(newSerie);
            Assert.AreEqual(serieId, newSerie.Id);
            Assert.AreEqual("Name", newSerie.Name);
            Assert.AreEqual("Test", newSerie.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), newSerie.PublicationYear);

            Assert.IsNotNull(newSerie.Category);
            Assert.AreEqual(1, newSerie.Category.Id);
            //Assert.AreEqual("TestCategory", newSerieDto.FK_Category_ID.CategoryName);
            //Assert.AreEqual("TestDesc", newSerieDto.FK_Category_ID.Description);

            serieRepository.DeleteById(newSerie.Id);

            Assert.IsFalse(serieRepository.HasId(newSerie.Id));
        }
        
		[Test]
		[ExpectedException(typeof (NHibernate.Exceptions.GenericADOException))]
		public void Test_TryInsertSerieWithWrongConstraint_ShouldFail()
		{
			ISerieRepository serieRepository = new SerieRepository();
			
			Serie serie = new Serie { Id = 1, Name = "Name", Description = "Test", PublicationYear = new DateTime(2000,1,1), 
                                             Category = new Category { Id = 10 } };
			serieRepository.Add(serie);	
		}
		
		[Test]
        public void Test_GetAllSeriesByCategoryId_CategoryIs1()
        {
            ISerieRepository serieRepository = new SerieRepository();
            var series = serieRepository.GetAllByCategoryId(1);

            Assert.AreEqual(2, series.Count);
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_CategoryIs2()
        {
            ISerieRepository serieRepository = new SerieRepository();
            var series = serieRepository.GetAllByCategoryId(2);

            Assert.AreEqual(2, series.Count);
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_CategoryIs3()
        {
            ISerieRepository serieRepository = new SerieRepository();
            var series = serieRepository.GetAllByCategoryId(3);

            Assert.AreEqual(1, series.Count);
        }
    }
}

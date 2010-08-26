using System;
using System.Collections.Generic;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using KinderSurprise.DAL.Interfaces;
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

            List<SerieDto> series = serieRepository.GetAll();

            Assert.AreEqual(5, series.Count);

            Assert.AreEqual(1, series[0].SerieId);
            Assert.AreEqual("Plaste1", series[0].SerieName);
            Assert.AreEqual("Plasteserie 1",series[0].Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), series[0].PublicationYear);
            Assert.AreEqual(1,series[0].Category.CategoryId);

            Assert.AreEqual(2, series[1].SerieId);
            Assert.AreEqual("Plaste2", series[1].SerieName);
            Assert.AreEqual("Plasteserie 2", series[1].Description);
            Assert.AreEqual(new DateTime(2008, 1, 2), series[1].PublicationYear);
            Assert.AreEqual(1, series[1].Category.CategoryId);

            Assert.AreEqual(3, series[2].SerieId);
            Assert.AreEqual("Figuren1", series[2].SerieName);
            Assert.AreEqual("Figurenserie 1", series[2].Description);
            Assert.AreEqual(new DateTime(2008, 1, 3), series[2].PublicationYear);
            Assert.AreEqual(2, series[2].Category.CategoryId);

            Assert.AreEqual(4, series[3].SerieId);
            Assert.AreEqual("Figuren2", series[3].SerieName);
            Assert.AreEqual("Figurenserie 2", series[3].Description);
            Assert.AreEqual(new DateTime(2008, 1, 4), series[3].PublicationYear);
            Assert.AreEqual(2, series[3].Category.CategoryId);

            Assert.AreEqual(5, series[4].SerieId);
            Assert.AreEqual("Zinnfiguren", series[4].SerieName);
            Assert.AreEqual("Zinnserie", series[4].Description);
            Assert.AreEqual(new DateTime(2008, 1, 5), series[4].PublicationYear);
            Assert.AreEqual(3, series[4].Category.CategoryId);
        }

        [Test]
        public void Test_GetSerieById_ValidId()
        {
            ISerieRepository serieRepository = new SerieRepository();

            const int serieId = 1;

            SerieDto serieDto = serieRepository.GetById(serieId);

            Assert.AreEqual(serieId, serieDto.SerieId);
            Assert.AreEqual("Plaste1", serieDto.SerieName);
            Assert.AreEqual("Plasteserie 1", serieDto.Description);
            Assert.AreEqual(new DateTime(2008, 1, 1), serieDto.PublicationYear);
            Assert.AreEqual(1, serieDto.Category.CategoryId);
        }

        [Test]
        public void Test_GetSerieById_NotValidId()
        {
            ISerieRepository serieRepository = new SerieRepository();

            const int serieId = -1;

            SerieDto serieDto = serieRepository.GetById(serieId);

            Assert.IsNull(serieDto);
        }

        [Test]
        public void Test_DeleteSerieById()
        {
            ISerieRepository serieRepository = new SerieRepository();

            Assert.IsTrue(serieRepository.HasId(1));

            SerieDto oldSerieDto = serieRepository.GetById(1);
            oldSerieDto.SerieName = "Plaste5";
            serieRepository.Add(oldSerieDto);
            int serieId = serieRepository.GetAll().FindLast(x => x.SerieId > 0).SerieId;

            serieRepository.DeleteById(serieId);

            Assert.IsFalse(serieRepository.HasId(serieId));
        }

        [Test]
        public void Test_UpdateSerie()
        {
            ISerieRepository serieRepository = new SerieRepository();

            SerieDto serieDto = new SerieDto(0, "TestSerie", "TestDesc", new DateTime(2000,1,1), 
                                             new Category
                                                 {
                                                     CategoryId = 1,
                                                     CategoryName = "TestCategory",
                                                     Description = "TestDescCat"
                                                 });
            serieRepository.Add(serieDto);
            int serieId = serieRepository.GetAll().FindLast(x => x.SerieId > 0).SerieId;

            serieDto = serieRepository.GetById(serieId);
            serieDto.SerieName = "TestSerieOverwritten";
            serieDto.Description = "TestDescOverwritten";

            serieRepository.Update(serieDto);
            
            SerieDto newSerieDto = serieRepository.GetById(serieId);

            Assert.IsNotNull(newSerieDto);
            Assert.AreEqual(serieId, newSerieDto.SerieId);
            Assert.AreEqual("TestSerieOverwritten", newSerieDto.SerieName);
            Assert.AreEqual("TestDescOverwritten", newSerieDto.Description);
            Assert.AreEqual(new DateTime(2000,1,1), newSerieDto.PublicationYear);
                
            Assert.IsNotNull(newSerieDto.Category);

            serieRepository.DeleteById(serieId);

            Assert.IsFalse(serieRepository.HasId(serieId));
        }

        [Test]
        public void Test_AddSerie()
        {
            ISerieRepository serieRepository = new SerieRepository();

            SerieDto serieDto = new SerieDto(1, "Name", "Test", new DateTime(2000,1,1), 
                                             new Category
                                                 {
                                                     CategoryId = 1,
                                                     CategoryName = "TestCategory",
                                                     Description = "TestDesc"
                                                 });

            serieRepository.Add(serieDto);

            int serieId = serieRepository.GetAll().FindLast(x => x.SerieId > 0).SerieId;

            SerieDto newSerieDto = serieRepository.GetById(serieId);
            
            Assert.IsNotNull(newSerieDto);
            Assert.AreEqual(serieId, newSerieDto.SerieId);
            Assert.AreEqual("Name", newSerieDto.SerieName);
            Assert.AreEqual("Test", newSerieDto.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), newSerieDto.PublicationYear);

            Assert.IsNotNull(newSerieDto.Category);
            Assert.AreEqual(1, newSerieDto.Category.CategoryId);
            //Assert.AreEqual("TestCategory", newSerieDto.FK_Category_ID.CategoryName);
            //Assert.AreEqual("TestDesc", newSerieDto.FK_Category_ID.Description);

            serieRepository.DeleteById(newSerieDto.SerieId);

            Assert.IsFalse(serieRepository.HasId(newSerieDto.SerieId));
        }
        
		[Test]
		[ExpectedException(typeof (NHibernate.Exceptions.GenericADOException))]
		public void Test_TryInsertSerieWithWrongConstraint_ShouldFail()
		{
			ISerieRepository serieRepository = new SerieRepository();
			
			SerieDto serieDto = new SerieDto(1, "Name", "Test", new DateTime(2000,1,1), 
                                             new Category { CategoryId = 10 });
			serieRepository.Add(serieDto);	
		}
		
		[Test]
        public void Test_GetAllSeriesByCategoryId_CategoryIs1()
        {
            ISerieRepository serieRepository = new SerieRepository();
            var serieDtos = serieRepository.GetAllByCategoryId(1);

            Assert.AreEqual(2, serieDtos.Count);
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_CategoryIs2()
        {
            ISerieRepository serieRepository = new SerieRepository();
            var serieDtos = serieRepository.GetAllByCategoryId(2);

            Assert.AreEqual(2, serieDtos.Count);
        }

        [Test]
        public void Test_GetAllSeriesByCategoryId_CategoryIs3()
        {
            ISerieRepository serieRepository = new SerieRepository();
            var serieDtos = serieRepository.GetAllByCategoryId(3);

            Assert.AreEqual(1, serieDtos.Count);
        }
    }
}

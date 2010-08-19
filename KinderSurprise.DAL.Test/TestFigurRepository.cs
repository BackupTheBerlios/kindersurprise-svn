using System.Collections.Generic;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using KinderSurprise.DAL.Interfaces;
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

            List<FigurDto> figurs = figurRepository.GetAll();

            Assert.AreEqual(9, figurs.Count);

            Assert.AreEqual(1, figurs[0].FigurId);
            Assert.AreEqual("PlasteFigur1", figurs[0].FigurName);
            Assert.AreEqual("Plastefigur Serie1", figurs[0].Description);
            Assert.AreEqual(18.00, figurs[0].Price);
            Assert.AreEqual(1, figurs[0].Serie.SerieId);

            Assert.AreEqual(2, figurs[1].FigurId);
            Assert.AreEqual("PlasteFigur2", figurs[1].FigurName);
            Assert.AreEqual("Plastefigur Serie1", figurs[1].Description);
            Assert.AreEqual(9.25, figurs[1].Price);
            Assert.AreEqual(1, figurs[1].Serie.SerieId);

            Assert.AreEqual(3, figurs[2].FigurId);
            Assert.AreEqual("PlasteFigur1", figurs[2].FigurName);
            Assert.AreEqual("Plastefigur Serie2", figurs[2].Description);
            Assert.AreEqual(11.00, figurs[2].Price);
            Assert.AreEqual(2, figurs[2].Serie.SerieId);

            Assert.AreEqual(4, figurs[3].FigurId);
            Assert.AreEqual("PlasteFigur2", figurs[3].FigurName);
            Assert.AreEqual("Plastefigur Serie2", figurs[3].Description);
            Assert.AreEqual(4.75, figurs[3].Price);
            Assert.AreEqual(2, figurs[3].Serie.SerieId);

            Assert.AreEqual(5, figurs[4].FigurId);
            Assert.AreEqual("Happy Hippo1", figurs[4].FigurName);
            Assert.AreEqual("Figur", figurs[4].Description);
            Assert.AreEqual(5.11, figurs[4].Price);
            Assert.AreEqual(3, figurs[4].Serie.SerieId);

            Assert.AreEqual(6, figurs[5].FigurId);
            Assert.AreEqual("Happy Hippo2", figurs[5].FigurName);
            Assert.AreEqual("Figur", figurs[5].Description);
            Assert.AreEqual(5.00, figurs[5].Price);
            Assert.AreEqual(3, figurs[5].Serie.SerieId);

            Assert.AreEqual(7, figurs[6].FigurId);
            Assert.AreEqual("Happy Hippo3", figurs[6].FigurName);
            Assert.AreEqual("Figur", figurs[6].Description);
            Assert.AreEqual(5.11, figurs[6].Price);
            Assert.AreEqual(3, figurs[6].Serie.SerieId);

            Assert.AreEqual(8, figurs[7].FigurId);
            Assert.AreEqual("Mr. Sonnenschein", figurs[7].FigurName);
            Assert.AreEqual("Figur", figurs[7].Description);
            Assert.AreEqual(11.00, figurs[7].Price);
            Assert.AreEqual(4, figurs[7].Serie.SerieId);

            Assert.AreEqual(9, figurs[8].FigurId);
            Assert.AreEqual("Zinnsoldat", figurs[8].FigurName);
            Assert.AreEqual("Zinnfigur", figurs[8].Description);
            Assert.AreEqual(0.77, figurs[8].Price);
            Assert.AreEqual(5, figurs[8].Serie.SerieId);
        }

        [Test]
        public void Test_GetFigurById_ValidId()
        {
            IFigurRepository figurRepository = new FigurRepository();

            const int figurId = 1;

            FigurDto figur = figurRepository.GetById(figurId);

            Assert.AreEqual(figurId, figur.FigurId);
            Assert.AreEqual("PlasteFigur1", figur.FigurName);
            Assert.AreEqual("Plastefigur Serie1", figur.Description);
            Assert.AreEqual(18.00, figur.Price);
            Assert.AreEqual(1, figur.Serie.SerieId);
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

            FigurDto newFigurDto = figurRepository.GetById(1);
            newFigurDto.FigurName = "Plaste5";
            figurRepository.Add(newFigurDto);
            int figurId = figurRepository.GetAll().FindLast(x => x.FigurId > 0).FigurId;
            
            Assert.IsTrue(figurRepository.HasId(figurId));

            figurRepository.DeleteById(figurId);

            Assert.IsFalse(figurRepository.HasId(figurId));
        }

        [Test]
        public void Test_AddFigur()
        {
            IFigurRepository figurRepository = new FigurRepository();

            FigurDto figurDto = new FigurDto(1,"Name","Test",(decimal) 1.11,new Serie{ SerieId = 1});

            figurRepository.Add(figurDto);

            int figurId = figurRepository.GetAll().FindLast(x => x.FigurId > 0).FigurId;

            FigurDto newFigurDto = figurRepository.GetById(figurId);
            
            Assert.IsNotNull(newFigurDto);
            Assert.AreEqual(figurId, newFigurDto.FigurId);
            Assert.AreEqual("Name", newFigurDto.FigurName);
            Assert.AreEqual("Test", newFigurDto.Description);
            Assert.AreEqual(1.11, newFigurDto.Price);
            Assert.AreEqual(1, newFigurDto.Serie.SerieId);

            figurRepository.DeleteById(figurId);

            Assert.IsFalse(figurRepository.HasId(figurId));
        }

        [Test]
        public void Test_UpdateFigur()
        {
            IFigurRepository figurRepository = new FigurRepository();

            FigurDto figurDto = new FigurDto(1, "TestFigur", "TestDesc", (decimal) 1.11, new Serie {SerieId = 1});

            figurRepository.Add(figurDto);
            int figurId = figurRepository.GetAll().FindLast(x => x.FigurId > 0).FigurId;

            figurDto = figurRepository.GetById(figurId);
            Assert.AreEqual(figurId, figurDto.FigurId);
            Assert.AreEqual("TestFigur", figurDto.FigurName);
            Assert.AreEqual("TestDesc", figurDto.Description);
            Assert.AreEqual(1.11, figurDto.Price);
            Assert.AreEqual(1, figurDto.Serie.SerieId);

            figurDto.FigurName = "TestFigurOverwritten";
            figurDto.Description = "TestDescOverwritten";

            figurRepository.Update(figurDto);

            FigurDto newFigurDto = figurRepository.GetById(figurId);

            Assert.IsNotNull(newFigurDto);
            Assert.AreEqual(figurId, newFigurDto.FigurId);
            Assert.AreEqual("TestFigurOverwritten", newFigurDto.FigurName);
            Assert.AreEqual("TestDescOverwritten", newFigurDto.Description);
            Assert.AreEqual(1.11, newFigurDto.Price);
            Assert.AreEqual(1, figurDto.Serie.SerieId);

            Assert.IsNotNull(newFigurDto.Serie);

            figurRepository.DeleteById(figurId);

            Assert.IsFalse(figurRepository.HasId(figurId));
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs1()
        {
            IFigurRepository figurRepository = new FigurRepository();
            List<FigurDto> figurDtos = figurRepository.GetAllBySerieId(1);

            Assert.AreEqual(2, figurDtos.Count);
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs3()
        {
            IFigurRepository figurRepository = new FigurRepository();
            List<FigurDto> figurDtos = figurRepository.GetAllBySerieId(3);

            Assert.AreEqual(3, figurDtos.Count);
        }

        [Test]
        public void Test_GetAllFigursBySerieId_IdIs4()
        {
            IFigurRepository figurRepository = new FigurRepository();
            List<FigurDto> figurDtos = figurRepository.GetAllBySerieId(4);

            Assert.AreEqual(1, figurDtos.Count);
        }
    }
}

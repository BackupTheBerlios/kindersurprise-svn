using System;
using System.Collections.Generic;
using KinderSurprise.DTO;
using KinderSurprise.Repository;
using NUnit.Framework;

namespace KinderSurprise.RepositoryEF.Test
{
    [TestFixture]
    class TestFgurRepository
    {
        [Test]
        public void Test_ExistFigurId_DoesntExist()
        {
            IFigurRepository figurRepository = new FigurRepository();
            const int figurId = 1;

            Assert.IsTrue(figurRepository.HasId(figurId));
        }

        public void Test_ExistFigurId_DoesExist()
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

            //check the content
        }

        [Test]
        public void Test_GetFigurById_ValidId()
        {
            IFigurRepository figurRepository = new FigurRepository();

            const int figurId = 1;

            FigurDto figur = figurRepository.GetById(figurId);

            Assert.AreEqual(figurId, figur.FigurId);
            Assert.AreEqual("PlasteFigur1", figur.FigurName);
            Assert.AreEqual("Test", figur.Description);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_GetFigurById_NotValidId()
        {
            IFigurRepository figurRepository = new FigurRepository();

            const int figurId = -1;

            FigurDto figur = figurRepository.GetById(figurId);

            Assert.IsNull(figur);
        }

        [Test]
        [Ignore]
        public void Test_DeleteFigurById()
        {
            IFigurRepository figurRepository = new FigurRepository();

            const int figurId = 1;

            Assert.IsTrue(figurRepository.HasId(figurId));

            figurRepository.DeleteById(figurId);

            Assert.IsFalse(figurRepository.HasId(figurId));

            FigurDto figur = new FigurDto(figurId, "Plastik", "Alles was plaste ist",(decimal) 1.00,1);

            figurRepository.Add(figur);

            Assert.IsTrue(figurRepository.HasId(figurId));
            Assert.AreEqual(figurId, figur.FigurId);
            Assert.AreEqual("Plastik", figur.FigurName);
            Assert.AreEqual("Alles was plaste ist", figur.Description);
        }

        [Test]
        [Ignore]
        public void Test_AddFigur()
        {
            IFigurRepository figurRepository = new FigurRepository();

            FigurDto figurDto = new FigurDto(1,string.Empty,string.Empty,(decimal) 0.00,1);

            figurRepository.Add(figurDto);

            const int figurId = 4;

            FigurDto newFigurDto = figurRepository.GetById(figurId);
            
            Assert.IsNotNull(newFigurDto);
            Assert.AreEqual(4, newFigurDto.FigurId);
            Assert.AreEqual("Name", newFigurDto.FigurName);
            Assert.AreEqual("Test", newFigurDto.Description);

            figurRepository.DeleteById(figurId);

            Assert.IsTrue(figurRepository.HasId(figurId));
        }
    }
}

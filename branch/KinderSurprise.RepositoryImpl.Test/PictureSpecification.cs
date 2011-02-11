using System.Collections.Generic;
using KinderSurprise.Model;
using KinderSurprise.Repository;
using KinderSurprise.RepositoryImpl.Test;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.RepositoryImpl.TestPictureRepos
{
    [TestFixture]
    public class WhenGettingNonExistingPictureOfFigur : RepositoryFixture
    {
        private const EType Type = EType.Figur;
        private const int Id = 0;
        private IPictureRepository m_PictureRepository;
        private List<Picture> m_ReturnValue;

        protected override void Context()
        {
            m_PictureRepository = ObjectFactory.GetInstance<IPictureRepository>();
        }

        protected override void Because()
        {
            m_ReturnValue = m_PictureRepository.GetById(Id, Type);
        }

        [Test]
        public void ListShouldBeEmpty()
        {
            Assert.AreEqual(0, m_ReturnValue.Count);
        }
    }

    [TestFixture]
    public class WhenGettingNonExistingPictureOfSerie : RepositoryFixture
    {
        private const EType Type = EType.Serie;
        private const int Id = 0;
        private IPictureRepository m_PictureRepository;
        private List<Picture> m_ReturnValue;

        protected override void Context()
        {
            m_PictureRepository = ObjectFactory.GetInstance<IPictureRepository>();
        }

        protected override void Because()
        {
            m_ReturnValue = m_PictureRepository.GetById(Id, Type);
        }

        [Test]
        public void ListShouldBeEmpty()
        {
            Assert.AreEqual(0, m_ReturnValue.Count);
        }
    }

    [TestFixture]
    public class WhenGettingNonExistingPictureOfInstructions : RepositoryFixture
    {
        private const EType Type = EType.Instructions;
        private const int Id = 0;
        private IPictureRepository m_PictureRepository;
        private List<Picture> m_ReturnValue;

        protected override void Context()
        {
            m_PictureRepository = ObjectFactory.GetInstance<IPictureRepository>();
        }

        protected override void Because()
        {
            m_ReturnValue = m_PictureRepository.GetById(Id, Type);
        }

        [Test]
        public void ListShouldBeEmpty()
        {
            Assert.AreEqual(0, m_ReturnValue.Count);
        }
    }

    [TestFixture]
    public class WhenGettingExistingPictureOfInstructions : RepositoryFixture
    {
        private const EType Type = EType.Instructions;
        private const int Id = 2;
        private IPictureRepository m_PictureRepository;
        private List<Picture> m_ReturnValue;

        protected override void Context()
        {
            m_PictureRepository = ObjectFactory.GetInstance<IPictureRepository>();
        }

        protected override void Because()
        {
            m_ReturnValue = m_PictureRepository.GetById(Id, Type);
        }

        [Test]
        public void ListShouldContainOneElement()
        {
            Assert.AreEqual(1, m_ReturnValue.Count);
        }

        [Test]
        public void ElementShouldContainExpectedValues()
        {
            Assert.AreEqual(6, m_ReturnValue[0].Id);
            Assert.AreEqual("instructions2.png", m_ReturnValue[0].Path);
            Assert.IsNotNull(m_ReturnValue[0].Fk_Instructions_Id);
            Assert.IsNull(m_ReturnValue[0].Fk_Figur_Id);
            Assert.IsNull(m_ReturnValue[0].Fk_Serie_Id);
        }
    }

    [TestFixture]
    public class WhenGettingExistingPictureOfSerie : RepositoryFixture
    {
        private const EType Type = EType.Serie;
        private const int Id = 5;
        private IPictureRepository m_PictureRepository;
        private List<Picture> m_ReturnValue;

        protected override void Context()
        {
            m_PictureRepository = ObjectFactory.GetInstance<IPictureRepository>();
        }

        protected override void Because()
        {
            m_ReturnValue = m_PictureRepository.GetById(Id, Type);
        }

        [Test]
        public void ListShouldContainOneElement()
        {
            Assert.AreEqual(1, m_ReturnValue.Count);
        }

        [Test]
        public void ElementShouldContainExpectedValues()
        {
            Assert.AreEqual("1.jpg", m_ReturnValue[0].Path);
            Assert.IsNull(m_ReturnValue[0].Fk_Instructions_Id);
            Assert.IsNull(m_ReturnValue[0].Fk_Figur_Id);
            Assert.IsNotNull(m_ReturnValue[0].Fk_Serie_Id);
        }
    }

    [TestFixture]
    public class WhenGettingExistingPictureOfFigur : RepositoryFixture
    {
        private const EType Type = EType.Figur;
        private const int Id = 5;
        private IPictureRepository m_PictureRepository;
        private List<Picture> m_ReturnValue;

        protected override void Context()
        {
            m_PictureRepository = ObjectFactory.GetInstance<IPictureRepository>();
        }

        protected override void Because()
        {
            m_ReturnValue = m_PictureRepository.GetById(Id, Type);
        }

        [Test]
        public void ListShouldContainTwoElements()
        {
            Assert.AreEqual(2, m_ReturnValue.Count);
        }

        [Test]
        public void ElementsShouldContainExpectedValues()
        {
            Assert.AreEqual("3.jpg", m_ReturnValue[0].Path);
            Assert.IsNull(m_ReturnValue[0].Fk_Instructions_Id);
            Assert.IsNotNull(m_ReturnValue[0].Fk_Figur_Id);
            Assert.IsNull(m_ReturnValue[0].Fk_Serie_Id);

            Assert.AreEqual("4.jpg", m_ReturnValue[1].Path);
            Assert.IsNull(m_ReturnValue[1].Fk_Instructions_Id);
            Assert.IsNotNull(m_ReturnValue[1].Fk_Figur_Id);
            Assert.IsNull(m_ReturnValue[1].Fk_Serie_Id);
        }
    }
}

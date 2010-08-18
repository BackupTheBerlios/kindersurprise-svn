using System;
using System.Web.UI.WebControls;
using KinderSurprise.DAL;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.MVP.Presenter.Test
{
    [TestFixture]
    public class TestSeriePropertyPresenter
    {
        #region MockObjectWithInitializationAndDispose

        private class MockSerieProperty : ISeriePropertyPresenter
        {
            private Button m_NewSerieButton = new Button();
            private Button m_NewFigurButton = new Button();
            private Button m_SaveButton = new Button();
            private Button m_DeleteButton = new Button();
            private Button m_CancelButton = new Button();
            private Label m_ErrorMessage = new Label();
            private TextBox m_Name = new TextBox();
            private TextBox m_Description = new TextBox();
            private TextBox m_PublicationYear = new TextBox();
            private DropDownList m_ChooseCategory = new DropDownList();
            private SerieDto m_SerieDto;
            
            public Button NewSerieButton
            {
                get { return m_NewSerieButton; }
                set { m_NewSerieButton = value; }
            }

            public Button NewFigurButton
            {
                get { return m_NewFigurButton; }
                set { m_NewFigurButton = value; }
            }

            public Button SaveButton
            {
                get { return m_SaveButton; }
                set { m_SaveButton = value; }
            }

            public Button DeleteButton
            {
                get { return m_DeleteButton; }
                set { m_DeleteButton = value; }
            }

            public Button CancelButton
            {
                get { return m_CancelButton; }
                set { m_CancelButton = value; }
            }

            public Label ErrorMessage
            {
                get { return m_ErrorMessage; }
                set { m_ErrorMessage = value; }
            }

            public TextBox Name
            {
                get { return m_Name; }
                set { m_Name = value; }
            }

            public TextBox Description
            {
                get { return m_Description; }
                set { m_Description = value; }
            }

            public TextBox PublicationYear
            {
                get { return m_PublicationYear; }
                set { m_PublicationYear = value; }
            }

            public DropDownList ChooseCategory
            {
                get { return m_ChooseCategory; }
                set { m_ChooseCategory = value; }
            }

            public SerieDto SerieDto
            {
                get { return m_SerieDto; }
                set { m_SerieDto = value; }
            }
        }

        private MockSerieProperty m_MockSerieProperty;

        [SetUp]
        public void Setup()
        {
            m_MockSerieProperty = new MockSerieProperty();
        }

        [TearDown]
        public void Teardown()
        {
            m_MockSerieProperty = null;
        }

        #endregion

        [Test]
        public void Test_SetToEditMode()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyService.SetToViewMode();

            Assert.IsTrue(m_MockSerieProperty.NewSerieButton.Visible);
            Assert.IsTrue(m_MockSerieProperty.NewFigurButton.Visible);
            Assert.IsTrue(m_MockSerieProperty.SaveButton.Visible);
            Assert.IsTrue(m_MockSerieProperty.DeleteButton.Visible);
            Assert.IsFalse(m_MockSerieProperty.CancelButton.Visible);
        }

        [Test]
        public void Test_SetToViewMode()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyService.SetToEditMode();

            Assert.IsFalse(m_MockSerieProperty.NewSerieButton.Visible);
            Assert.IsFalse(m_MockSerieProperty.NewFigurButton.Visible);
            Assert.IsTrue(m_MockSerieProperty.SaveButton.Visible);
            Assert.IsFalse(m_MockSerieProperty.DeleteButton.Visible);
            Assert.IsTrue(m_MockSerieProperty.CancelButton.Visible);
        }

        [Test]
        public void Test_SetFields_CateogryDtoIsNotNull()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            m_MockSerieProperty.SerieDto = new SerieDto(0, "Test", "Desc", new DateTime(2000, 1, 1),
                                                        new Mapper.Category {CategoryId = 1});
            seriePropertyService.SetFields();

            Assert.AreEqual("Test", m_MockSerieProperty.Name.Text);
            Assert.AreEqual("Desc", m_MockSerieProperty.Description.Text);
            Assert.AreEqual("2000", m_MockSerieProperty.PublicationYear.Text);

            ICategoryService categoryService = new CategoryService();
            var categoryDto = categoryService.GetById(1);

            Assert.AreEqual(categoryDto.CategoryId.ToString(), m_MockSerieProperty.ChooseCategory.SelectedItem.Value);
            Assert.AreEqual(categoryDto.CategoryName, m_MockSerieProperty.ChooseCategory.SelectedItem.Text);
        }

        [Test]
        public void Test_SetFields_CategoryDtoIsNull()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            m_MockSerieProperty.SerieDto = null;
            seriePropertyService.SetFields();

            Assert.AreEqual(string.Empty, m_MockSerieProperty.Name.Text);
            Assert.AreEqual(string.Empty, m_MockSerieProperty.Description.Text);
            Assert.AreEqual(string.Empty, m_MockSerieProperty.PublicationYear.Text);

            ICategoryService categoryService = new CategoryService();
            var categoryDto = categoryService.GetById(1);

            Assert.AreEqual(categoryDto.CategoryId.ToString(), m_MockSerieProperty.ChooseCategory.SelectedItem.Value);
            Assert.AreEqual(categoryDto.CategoryName, m_MockSerieProperty.ChooseCategory.SelectedItem.Text);
        }

        [Test]
        public void Test_SetFieldsEmpty()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyService.SetFieldsEmpty();

            Assert.AreEqual(string.Empty, m_MockSerieProperty.Name.Text);
            Assert.AreEqual(string.Empty, m_MockSerieProperty.Description.Text);
            Assert.AreEqual(string.Empty, m_MockSerieProperty.PublicationYear.Text);
            
            ICategoryService categoryService = new CategoryService();
            var categoryDto = categoryService.GetById(1);

            Assert.AreEqual(categoryDto.CategoryId.ToString(), m_MockSerieProperty.ChooseCategory.SelectedItem.Value);
            Assert.AreEqual(categoryDto.CategoryName, m_MockSerieProperty.ChooseCategory.SelectedItem.Text);
        }

        [Test]
        public void Test_Update_IfNameIsNotValid()
        {
            m_MockSerieProperty.SerieDto = new SerieDto(0, string.Empty, "desc", new DateTime(2001, 1, 1), new Category { CategoryId = 1 });

            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyService.SetFields();

            Assert.IsFalse(seriePropertyService.Update());

            Assert.IsTrue(m_MockSerieProperty.ErrorMessage.Visible);
            string expected = "Bitte geben Sie einen Namen für die Serie ein!" + Environment.NewLine;
            Assert.AreEqual(expected, m_MockSerieProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfYearIsNotValid()
        {
            m_MockSerieProperty.SerieDto = new SerieDto(0, "name", "desc", new DateTime(1700, 1, 1), new Mapper.Category { CategoryId = 1 });

            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyService.SetFields();

            Assert.IsFalse(seriePropertyService.Update());

            Assert.IsTrue(m_MockSerieProperty.ErrorMessage.Visible);
            string expected = "Bitte geben Sie ein gültiges Jahr ein!" + Environment.NewLine;
            Assert.AreEqual(expected, m_MockSerieProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfYearAndNameAreNotValid()
        {
            m_MockSerieProperty.SerieDto = new SerieDto(0, string.Empty, "desc", new DateTime(1700, 1, 1), new Category { CategoryId = 1 });

            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyService.SetFields();
            
            Assert.IsFalse(seriePropertyService.Update());

            string expected = "Bitte geben Sie einen Namen für die Serie ein!" + Environment.NewLine + "Bitte geben Sie ein gültiges Jahr ein!" + Environment.NewLine;

            Assert.IsTrue(m_MockSerieProperty.ErrorMessage.Visible);
            Assert.AreEqual(expected, m_MockSerieProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfNameAndYearAreValid()
        {
            m_MockSerieProperty.SerieDto = new SerieDto(0, "test serie update", "desc serie update", new DateTime(1981, 1, 1), new Mapper.Category { CategoryId = 1 });

            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyService.SetFields();

            Assert.IsTrue(seriePropertyService.Update());

            Assert.IsFalse(m_MockSerieProperty.ErrorMessage.Visible);
            Assert.AreEqual(string.Empty, m_MockSerieProperty.ErrorMessage.Text);

            //Revert saving
            ISerieService serieService = new SerieService();
            var series = serieService.GetAll();
            serieService.DeleteById(series[series.Count - 1].SerieId);
        }

        [Test]
        public void Test_Delete_IfSerieDtoIsNull()
        {
            m_MockSerieProperty.SerieDto = null;

            ISerieService serieService = new SerieService();
            var serieDtos = serieService.GetAll();

            SeriePropertyPresenter seriePropertyPresenter = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyPresenter.Delete();

            Assert.AreEqual(serieDtos.Count, serieService.GetAll().Count);
        }

        [Test]
        [Ignore]
        public void Test_Delete_IfSerieDtoIsNotNull()
        {
            ISerieService serieService = new SerieService();
            m_MockSerieProperty.SerieDto = serieService.GetById(1);

            var serieDtos = serieService.GetAll();

            SeriePropertyPresenter seriePropertyPresenter = new SeriePropertyPresenter(m_MockSerieProperty);
            seriePropertyPresenter.Delete();

            Assert.AreEqual(serieDtos.Count-1, serieService.GetAll().Count);
			/*
            using(ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(new Serie
                                     {
                                         SerieId = 1,
                                         SerieName = "Plaste1",
                                         Description = "Plasteserie 1",
                                         PublicationYear = new DateTime(2008, 1, 1),
                                         Category = new Category {CategoryId = 1}
                                     });
                    transaction.Commit();
                }
            }
            */
            Assert.AreEqual(serieDtos.Count, serieService.GetAll().Count);
        }
    }
}

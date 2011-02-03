using System;
using System.Linq;
using System.Web.UI.WebControls;
using KinderSurprise.DAL;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;
using NHibernate;

namespace KinderSurprise.MVP.Presenter.Test
{
    [TestFixture]
    public class TestSeriePropertyPresenter
    {
        #region MockObjectWithInitializationAndDispose

        private ISeriePropertyPresenter m_MockSeriePropertyPresenter = null;

        [SetUp]
        public void Setup()
        {
            Moq.Mock<ISeriePropertyPresenter> mockSeriePropertyPresenter = new Moq.Mock<ISeriePropertyPresenter>();
			mockSeriePropertyPresenter.SetupAllProperties();
			m_MockSeriePropertyPresenter = mockSeriePropertyPresenter.Object;
			m_MockSeriePropertyPresenter.NewSerieButton = new Button();
            m_MockSeriePropertyPresenter.NewFigurButton = new Button();
            m_MockSeriePropertyPresenter.SaveButton = new Button();
            m_MockSeriePropertyPresenter.DeleteButton = new Button();
            m_MockSeriePropertyPresenter.CancelButton = new Button();
            m_MockSeriePropertyPresenter.ErrorMessage = new Label();
            m_MockSeriePropertyPresenter.Name = new TextBox();
            m_MockSeriePropertyPresenter.Description = new TextBox();
            m_MockSeriePropertyPresenter.PublicationYear = new TextBox();
            m_MockSeriePropertyPresenter.ChooseCategory = new DropDownList();
        }

        [TearDown]
        public void Teardown()
        {
            m_MockSeriePropertyPresenter = null;
        }

        #endregion

        [Test]
        public void Test_SetToEditMode()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyService.SetToViewMode();

            Assert.IsTrue(m_MockSeriePropertyPresenter.NewSerieButton.Visible);
            Assert.IsTrue(m_MockSeriePropertyPresenter.NewFigurButton.Visible);
            Assert.IsTrue(m_MockSeriePropertyPresenter.SaveButton.Visible);
            Assert.IsTrue(m_MockSeriePropertyPresenter.DeleteButton.Visible);
            Assert.IsFalse(m_MockSeriePropertyPresenter.CancelButton.Visible);
        }

        [Test]
        public void Test_SetToViewMode()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyService.SetToEditMode();

            Assert.IsFalse(m_MockSeriePropertyPresenter.NewSerieButton.Visible);
            Assert.IsFalse(m_MockSeriePropertyPresenter.NewFigurButton.Visible);
            Assert.IsTrue(m_MockSeriePropertyPresenter.SaveButton.Visible);
            Assert.IsFalse(m_MockSeriePropertyPresenter.DeleteButton.Visible);
            Assert.IsTrue(m_MockSeriePropertyPresenter.CancelButton.Visible);
        }

        [Test]
        public void Test_SetFields_CateogryDtoIsNotNull()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            m_MockSeriePropertyPresenter.Serie = new Serie{ SerieId = 0, SerieName = "Test", Description = "Desc", PublicationYear = new DateTime(2000, 1, 1),
                                                        Category = new Category {CategoryId = 1}};
            seriePropertyService.SetFields();

            Assert.AreEqual("Test", m_MockSeriePropertyPresenter.Name.Text);
            Assert.AreEqual("Desc", m_MockSeriePropertyPresenter.Description.Text);
            Assert.AreEqual("2000", m_MockSeriePropertyPresenter.PublicationYear.Text);

            ICategoryService categoryService = new CategoryService();
            var categoryDto = categoryService.GetById(1);

            Assert.AreEqual(categoryDto.CategoryId.ToString(), m_MockSeriePropertyPresenter.ChooseCategory.SelectedItem.Value);
            Assert.AreEqual(categoryDto.CategoryName, m_MockSeriePropertyPresenter.ChooseCategory.SelectedItem.Text);
        }

        [Test]
        public void Test_SetFields_CategoryDtoIsNull()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            m_MockSeriePropertyPresenter.Serie = null;
            seriePropertyService.SetFields();

            Assert.AreEqual(string.Empty, m_MockSeriePropertyPresenter.Name.Text);
            Assert.AreEqual(string.Empty, m_MockSeriePropertyPresenter.Description.Text);
            Assert.AreEqual(string.Empty, m_MockSeriePropertyPresenter.PublicationYear.Text);

            ICategoryService categoryService = new CategoryService();
            var categoryDto = categoryService.GetById(1);

            Assert.AreEqual(categoryDto.CategoryId.ToString(), m_MockSeriePropertyPresenter.ChooseCategory.SelectedItem.Value);
            Assert.AreEqual(categoryDto.CategoryName, m_MockSeriePropertyPresenter.ChooseCategory.SelectedItem.Text);
        }

        [Test]
        public void Test_SetFieldsEmpty()
        {
            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyService.SetFieldsEmpty();

            Assert.AreEqual(string.Empty, m_MockSeriePropertyPresenter.Name.Text);
            Assert.AreEqual(string.Empty, m_MockSeriePropertyPresenter.Description.Text);
            Assert.AreEqual(string.Empty, m_MockSeriePropertyPresenter.PublicationYear.Text);
            
            ICategoryService categoryService = new CategoryService();
            var categoryDto = categoryService.GetById(1);

            Assert.AreEqual(categoryDto.CategoryId.ToString(), m_MockSeriePropertyPresenter.ChooseCategory.SelectedItem.Value);
            Assert.AreEqual(categoryDto.CategoryName, m_MockSeriePropertyPresenter.ChooseCategory.SelectedItem.Text);
        }

        [Test]
        public void Test_Update_IfNameIsNotValid()
        {
            m_MockSeriePropertyPresenter.Serie = new Serie { SerieId = 0, SerieName = string.Empty, Description = "desc", PublicationYear = new DateTime(2001, 1, 1), Category = new Category { CategoryId = 1 }};

            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyService.SetFields();

            Assert.IsFalse(seriePropertyService.Update());

            Assert.IsTrue(m_MockSeriePropertyPresenter.ErrorMessage.Visible);
            string expected = "Bitte geben Sie einen Namen für die Serie ein!" + Environment.NewLine;
            Assert.AreEqual(expected, m_MockSeriePropertyPresenter.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfYearIsNotValid()
        {
            m_MockSeriePropertyPresenter.Serie = new Serie{ SerieId = 0, SerieName = "name", Description = "desc", PublicationYear = new DateTime(1700, 1, 1), Category = new Category { CategoryId = 1 }};

            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyService.SetFields();

            Assert.IsFalse(seriePropertyService.Update());

            Assert.IsTrue(m_MockSeriePropertyPresenter.ErrorMessage.Visible);
            string expected = "Bitte geben Sie ein gültiges Jahr ein!" + Environment.NewLine;
            Assert.AreEqual(expected, m_MockSeriePropertyPresenter.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfYearAndNameAreNotValid()
        {
            m_MockSeriePropertyPresenter.Serie = new Serie  { SerieId = 0, SerieName = string.Empty, Description = "desc", PublicationYear = new DateTime(1700, 1, 1), Category = new Category { CategoryId = 1 }};

            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyService.SetFields();
            
            Assert.IsFalse(seriePropertyService.Update());

            string expected = "Bitte geben Sie einen Namen für die Serie ein!" + Environment.NewLine + "Bitte geben Sie ein gültiges Jahr ein!" + Environment.NewLine;

            Assert.IsTrue(m_MockSeriePropertyPresenter.ErrorMessage.Visible);
            Assert.AreEqual(expected, m_MockSeriePropertyPresenter.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfNameAndYearAreValid()
        {
            m_MockSeriePropertyPresenter.Serie = new Serie{ SerieId = 0, SerieName = "test serie update", Description = "desc serie update", PublicationYear = new DateTime(1981, 1, 1), Category = new Category { CategoryId = 1 }};

            SeriePropertyPresenter seriePropertyService = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyService.SetFields();

            Assert.IsTrue(seriePropertyService.Update());

            Assert.IsFalse(m_MockSeriePropertyPresenter.ErrorMessage.Visible);
            Assert.AreEqual(string.Empty, m_MockSeriePropertyPresenter.ErrorMessage.Text);

            //Revert saving
            ISerieService serieService = new SerieService();
            var series = serieService.GetAll();
            serieService.DeleteById(series[series.Count - 1].SerieId);
        }

        [Test]
        public void Test_Delete_IfSerieDtoIsNull()
        {
            m_MockSeriePropertyPresenter.Serie = null;

            ISerieService serieService = new SerieService();
            var serieDtos = serieService.GetAll();

            SeriePropertyPresenter seriePropertyPresenter = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyPresenter.Delete();

            Assert.AreEqual(serieDtos.Count, serieService.GetAll().Count);
        }

        [Test]
        public void Test_Delete_IfSerieDtoIsNotNull()
        {
            ISerieService serieService = new SerieService();
			int oldSerieCount = serieService.GetAll().Count;
			serieService.SaveOrUpdate(new Serie{ SerieId = 0, SerieName = "Test", Description = "test", PublicationYear = DateTime.Today, Category = new Category { CategoryId = 1}}); 
            
			var serieDtos = serieService.GetAll();
			
			Assert.AreEqual(oldSerieCount + 1, serieDtos.Count);
			m_MockSeriePropertyPresenter.Serie = serieDtos.OrderBy(x => x.SerieId).LastOrDefault();

            

            SeriePropertyPresenter seriePropertyPresenter = new SeriePropertyPresenter(m_MockSeriePropertyPresenter);
            seriePropertyPresenter.Delete();

            Assert.AreEqual(serieDtos.Count-1, serieService.GetAll().Count);
        }
    }
}
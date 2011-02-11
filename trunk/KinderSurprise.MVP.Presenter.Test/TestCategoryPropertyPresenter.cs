using System.Web.UI.WebControls;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.MVP.Presenter.Test
{

    [TestFixture]
    public class TestCategoryPropertyPresenter
    {
        #region MockObjectWithInitializationAndDispose

        private ICategoryPropertyPresenter m_MockCategoryProperty;

        [SetUp]
        public void Setup()
        {
			Testing.Initialize();
			
			Moq.Mock<ICategoryPropertyPresenter> mockCategoryProperty = new Moq.Mock<ICategoryPropertyPresenter>();
			mockCategoryProperty.SetupAllProperties();
			m_MockCategoryProperty = mockCategoryProperty.Object;
			m_MockCategoryProperty.ErrorLabel = new Label();
            m_MockCategoryProperty.NameTextBox = new TextBox();
            m_MockCategoryProperty.DescriptionTextBox = new TextBox();
            m_MockCategoryProperty.NewSerie = new Button();
            m_MockCategoryProperty.NewCategory = new Button();
            m_MockCategoryProperty.Cancel = new Button();
            m_MockCategoryProperty.Delete = new Button();
            m_MockCategoryProperty.Update = new Button();
        }

        [TearDown]
        public void Teardown()
        {
            m_MockCategoryProperty = null;
        }

        #endregion

        [Test]
        public void InitializeErroLabel()
        {
            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyPresenter.InitErrorLabel();

            Assert.IsFalse(m_MockCategoryProperty.ErrorLabel.Visible);
            Assert.AreEqual(string.Empty, m_MockCategoryProperty.ErrorLabel.Text);
        }

        [Test]
        public void Test_SetButtonsToViewMode()
        {
            var categoryPropertyService = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyService.SetButtonToViewMode();

            Assert.IsTrue(m_MockCategoryProperty.NewCategory.Visible);
            Assert.IsTrue(m_MockCategoryProperty.NewSerie.Visible);
            Assert.IsTrue(m_MockCategoryProperty.Update.Visible);
            Assert.IsTrue(m_MockCategoryProperty.Delete.Visible);
            Assert.IsFalse(m_MockCategoryProperty.Cancel.Visible);
        }

        [Test]
        public void Test_SetButtonsToEditMode()
        {
            var categoryPropertyService = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyService.SetButtonToEditMode();

            Assert.IsFalse(m_MockCategoryProperty.NewCategory.Visible);
            Assert.IsFalse(m_MockCategoryProperty.NewSerie.Visible);
            Assert.IsTrue(m_MockCategoryProperty.Update.Visible);
            Assert.IsFalse(m_MockCategoryProperty.Delete.Visible);
            Assert.IsTrue(m_MockCategoryProperty.Cancel.Visible);
        }

        [Test]
        public void Test_SetFields_CategoryIsNotNull()
        {
            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            m_MockCategoryProperty.Category = new Category { Id = 0, Name = "Test", Description = "Desc"};

            categoryPropertyPresenter.SetFields();  
            
            Assert.AreEqual("Test", m_MockCategoryProperty.NameTextBox.Text);
            Assert.AreEqual("Desc", m_MockCategoryProperty.DescriptionTextBox.Text);
        }

        [Test]
        public void Test_SetFields_CategoryIsNull()
        {
            m_MockCategoryProperty.Category = null;
            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            
            categoryPropertyPresenter.SetFields();

            Assert.AreEqual(string.Empty, m_MockCategoryProperty.NameTextBox.Text);
            Assert.AreEqual(string.Empty, m_MockCategoryProperty.DescriptionTextBox.Text);
        }




        [Test]
        public void Test_SetFieldsEmpty()
        {
            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyPresenter.SetFieldsEmpty();
            

            Assert.AreEqual(string.Empty, m_MockCategoryProperty.NameTextBox.Text);
            Assert.AreEqual(string.Empty, m_MockCategoryProperty.DescriptionTextBox.Text);
        }

        [Test]
        public void Test_Update_IfNameIsNotValid()
        {
            m_MockCategoryProperty.Category = new Category{ Id = 0, Name = string.Empty, Description = "desc"};
            
            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyPresenter.SetFields();
            Assert.IsFalse(categoryPropertyPresenter.Update(m_MockCategoryProperty.Category));

            Assert.IsTrue(m_MockCategoryProperty.ErrorLabel.Visible);
            Assert.AreEqual("Bitte geben Sie der Kategorie einen Namen!", m_MockCategoryProperty.ErrorLabel.Text);
        }

        [Test]
        public void Test_Update_IfNameIsValid()
        {
            m_MockCategoryProperty.Category = new Category{ Id = 0, Name = "test", Description = "desc"};

            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyPresenter.SetFields();
            Assert.IsTrue(categoryPropertyPresenter.Update(m_MockCategoryProperty.Category));

            Assert.IsFalse(m_MockCategoryProperty.ErrorLabel.Visible);
            Assert.AreEqual(string.Empty, m_MockCategoryProperty.ErrorLabel.Text);

            //Revert saving
            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
            var categories = categoryService.GetAll();
            categoryService.DeleteById(categories[categories.Count - 1].Id);
        }

        [Test]
        public void Test_Delete_IfCategoryIsNull()
        {
            m_MockCategoryProperty.Category = null;

            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();

            var categories = categoryService.GetAll();
            
            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyPresenter.Delete(m_MockCategoryProperty.Category);

            Assert.AreEqual(categories.Count, categoryService.GetAll().Count);
        }
    }
}
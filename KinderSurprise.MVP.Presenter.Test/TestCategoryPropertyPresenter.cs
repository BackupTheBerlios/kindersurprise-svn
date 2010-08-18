using System.Web.UI.WebControls;
using KinderSurprise.DTO;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.MVP.Presenter.Test
{
		/*
    [TestFixture]

    public class TestCategoryPropertyPresenter
    {
        #region MockObjectWithInitializationAndDispose

        private class MockCategoryProperty : ICategoryPropertyPresenter
        {
            private CategoryDto m_CategoryDto = null;
            private Label m_ErrorLabel = new Label();
            private TextBox m_NameTextBox = new TextBox();
            private TextBox m_DescriptionTextBox = new TextBox();
            private Button m_NewSerie = new Button();
            private Button m_NewCategory = new Button();
            private Button m_Cancel = new Button();
            private Button m_Delete = new Button();
            private Button m_Update = new Button();
            
            public Label ErrorLabel
            {
                get { return m_ErrorLabel; }
                set { m_ErrorLabel = value; }
            }

            public TextBox NameTextBox
            {
                get { return m_NameTextBox; }
                set { m_NameTextBox = value; }
            }

            public TextBox DescriptionTextBox
            {
                get { return m_DescriptionTextBox; }
                set { m_DescriptionTextBox = value; }
            }

            public Button NewSerie
            {
                get { return m_NewSerie; }
                set { m_NewSerie = value; }
            }

            public Button NewCategory
            {
                get { return m_NewCategory; }
                set { m_NewCategory = value; }
            }

            public Button Cancel
            {
                get { return m_Cancel; }
                set { m_Cancel = value; }
            }

            public Button Delete
            {
                get { return m_Delete; }
                set { m_Delete = value; }
            }

            public Button Update
            {
                get { return m_Update; }
                set { m_Update = value; }
            }

            public CategoryDto CategoryDto
            {
                get { return m_CategoryDto; }
                set { m_CategoryDto = value; }
            }
        }

        private MockCategoryProperty m_MockCategoryProperty;

        [SetUp]
        public void Setup()
        {
            m_MockCategoryProperty = new MockCategoryProperty();
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
        public void Test_SetFields_CategoryDtoIsNotNull()
        {
            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            m_MockCategoryProperty.CategoryDto = new CategoryDto(0, "Test", "Desc");

            categoryPropertyPresenter.SetFields();  
            
            Assert.AreEqual("Test", m_MockCategoryProperty.NameTextBox.Text);
            Assert.AreEqual("Desc", m_MockCategoryProperty.DescriptionTextBox.Text);
        }

        [Test]
        public void Test_SetFields_CategoryDtoIsNull()
        {
            m_MockCategoryProperty.CategoryDto = null;
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
            m_MockCategoryProperty.CategoryDto = new CategoryDto(0, string.Empty, "desc");
            
            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyPresenter.SetFields();
            Assert.IsFalse(categoryPropertyPresenter.Update(m_MockCategoryProperty.CategoryDto));

            Assert.IsTrue(m_MockCategoryProperty.ErrorLabel.Visible);
            Assert.AreEqual("Bitte geben Sie der Kategorie einen Namen!", m_MockCategoryProperty.ErrorLabel.Text);
        }

        [Test]
        public void Test_Update_IfNameIsValid()
        {
            m_MockCategoryProperty.CategoryDto = new CategoryDto(0, "test", "desc");

            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyPresenter.SetFields();
            Assert.IsTrue(categoryPropertyPresenter.Update(m_MockCategoryProperty.CategoryDto));

            Assert.IsFalse(m_MockCategoryProperty.ErrorLabel.Visible);
            Assert.AreEqual(string.Empty, m_MockCategoryProperty.ErrorLabel.Text);

            //Revert saving
            ICategoryService categoryService = new CategoryService();
            var categories = categoryService.GetAll();
            categoryService.DeleteById(categories[categories.Count - 1].CategoryId);
        }

        [Test]
        public void Test_Delete_IfCategoryDtoIsNull()
        {
            m_MockCategoryProperty.CategoryDto = null;

            ICategoryService categoryService = new CategoryService();

            var categoryDtos = categoryService.GetAll();
            
            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
            categoryPropertyPresenter.Delete(m_MockCategoryProperty.CategoryDto);

            Assert.AreEqual(categoryDtos.Count, categoryService.GetAll().Count);
        }
    }
    */
}

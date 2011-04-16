using System.Web.UI.WebControls;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;
using StructureMap;
using KinderSurprise.MVP.Presenter.Test;

namespace KinderSurprise.MVP.Presenter.TestCategoryPresenter
{
	[TestFixture]
	public class WhenInitializeErrorLabel : PresenterFixture
	{
		private CategoryPropertyPresenter m_CategoryPropertyPresenter;
		
		protected override void Context()
		{
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
		}
		
		protected override void Because()
		{
			m_CategoryPropertyPresenter.InitErrorLabel();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldBeInvisible()
		{
			Assert.IsFalse(MockCategoryProperty.ErrorLabel.Visible);
		}
		
		[Test]
		public void ShouldContainNoText()
		{
			Assert.AreEqual(string.Empty, MockCategoryProperty.ErrorLabel.Text);
		}
	}
	
	[TestFixture]
	public class WhenSettingViewMode : PresenterFixture
	{
		CategoryPropertyPresenter m_CategoryPropertyPresenter;
		
		protected override void Context()
		{
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
		}
		
		protected override void Because()
		{
			m_CategoryPropertyPresenter.SetButtonToViewMode();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void AllButtonsButCancelAreActivated()
		{
			Assert.IsTrue(MockCategoryProperty.NewCategory.Visible);
            Assert.IsTrue(MockCategoryProperty.NewSerie.Visible);
            Assert.IsTrue(MockCategoryProperty.Update.Visible);
            Assert.IsTrue(MockCategoryProperty.Delete.Visible);
            Assert.IsFalse(MockCategoryProperty.Cancel.Visible);
		}
	}
	
	[TestFixture]
	public class WhenSettingEditMode : PresenterFixture
	{
		CategoryPropertyPresenter m_CategoryPropertyPresenter;
		
		protected override void Context()
		{
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
		}
		
		protected override void Because()
		{
			m_CategoryPropertyPresenter.SetButtonToEditMode();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void AllButtonsButCancelAreActivated()
		{
			Assert.IsFalse(MockCategoryProperty.NewCategory.Visible);
            Assert.IsFalse(MockCategoryProperty.NewSerie.Visible);
            Assert.IsTrue(MockCategoryProperty.Update.Visible);
            Assert.IsFalse(MockCategoryProperty.Delete.Visible);
            Assert.IsTrue(MockCategoryProperty.Cancel.Visible);
		}
	}

	
	
    [TestFixture]
    public class TestCategoryPropertyPresenter
    {
//        [Test]
//        public void Test_SetFields_CategoryIsNotNull()
//        {
//            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
//            m_MockCategoryProperty.Category = new Category { Id = 0, Name = "Test", Description = "Desc"};
//
//            categoryPropertyPresenter.SetFields();  
//            
//            Assert.AreEqual("Test", m_MockCategoryProperty.NameTextBox.Text);
//            Assert.AreEqual("Desc", m_MockCategoryProperty.DescriptionTextBox.Text);
//        }
//
//        [Test]
//        public void Test_SetFields_CategoryIsNull()
//        {
//            m_MockCategoryProperty.Category = null;
//            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
//            
//            categoryPropertyPresenter.SetFields();
//
//            Assert.AreEqual(string.Empty, m_MockCategoryProperty.NameTextBox.Text);
//            Assert.AreEqual(string.Empty, m_MockCategoryProperty.DescriptionTextBox.Text);
//        }
//
//
//
//
//        [Test]
//        public void Test_SetFieldsEmpty()
//        {
//            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
//            categoryPropertyPresenter.SetFieldsEmpty();
//            
//
//            Assert.AreEqual(string.Empty, m_MockCategoryProperty.NameTextBox.Text);
//            Assert.AreEqual(string.Empty, m_MockCategoryProperty.DescriptionTextBox.Text);
//        }
//
//        [Test]
//        public void Test_Update_IfNameIsNotValid()
//        {
//            m_MockCategoryProperty.Category = new Category{ Id = 0, Name = string.Empty, Description = "desc"};
//            
//            var categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
//            categoryPropertyPresenter.SetFields();
//            Assert.IsFalse(categoryPropertyPresenter.Update(m_MockCategoryProperty.Category));
//
//            Assert.IsTrue(m_MockCategoryProperty.ErrorLabel.Visible);
//            Assert.AreEqual("Bitte geben Sie der Kategorie einen Namen!", m_MockCategoryProperty.ErrorLabel.Text);
//        }
//
//        [Test]
//        public void Test_Update_IfNameIsValid()
//        {
//            m_MockCategoryProperty.Category = new Category{ Id = 0, Name = "test", Description = "desc"};
//
//            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
//            categoryPropertyPresenter.SetFields();
//            Assert.IsTrue(categoryPropertyPresenter.Update(m_MockCategoryProperty.Category));
//
//            Assert.IsFalse(m_MockCategoryProperty.ErrorLabel.Visible);
//            Assert.AreEqual(string.Empty, m_MockCategoryProperty.ErrorLabel.Text);
//
//            //Revert saving
//            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
//            var categories = categoryService.GetAll();
//            categoryService.DeleteById(categories[categories.Count - 1].Id);
//        }
//
//        [Test]
//        public void Test_Delete_IfCategoryIsNull()
//        {
//            m_MockCategoryProperty.Category = null;
//
//            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
//
//            var categories = categoryService.GetAll();
//            
//            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(m_MockCategoryProperty);
//            categoryPropertyPresenter.Delete(m_MockCategoryProperty.Category);
//
//            Assert.AreEqual(categories.Count, categoryService.GetAll().Count);
//        }
    }
}
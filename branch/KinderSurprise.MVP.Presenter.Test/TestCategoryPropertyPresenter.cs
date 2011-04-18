using System;
using System.Web.UI.WebControls;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using KinderSurprise.MVP.Presenter.Test;
using NUnit.Framework;
using StructureMap;
using Moq;

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
	public class WhenSettingCategoryLabelWithValues : PresenterFixture
	{
		CategoryPropertyPresenter m_CategoryPropertyPresenter;
		
		protected override void Context()
		{
			MockCategoryProperty.Category = new Category { Id = 0, Name = "Test", Description = "Desc"};
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
		}
		
		protected override void Because()
		{
			m_CategoryPropertyPresenter.SetFields();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void LabelShouldContainExpectedValues()
		{
			Assert.AreEqual("Test", MockCategoryProperty.NameTextBox.Text);
			Assert.AreEqual("Desc", MockCategoryProperty.DescriptionTextBox.Text);
		}
	}
	
	[TestFixture]
	public class WhenSettingCategoryLabelWithoutValues : PresenterFixture
	{
		CategoryPropertyPresenter m_CategoryPropertyPresenter;
		Exception m_Exception = null; 
		
		protected override void Context()
		{
			MockCategoryProperty.Category = null;
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
		}
		
		protected override void Because()
		{
			try
			{
				m_CategoryPropertyPresenter.SetFields();	
			}
			catch(Exception ex)
			{
				m_Exception = ex;
			}
			
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void LabelShouldSetEmpty()
		{
			Assert.AreEqual(string.Empty, MockCategoryProperty.NameTextBox.Text);
			Assert.AreEqual(string.Empty, MockCategoryProperty.DescriptionTextBox.Text);
		}
		
		[Test]
		public void NoExceptionShouldBeThrown()
		{
			Assert.IsNull(m_Exception);
		}
	}
	
	[TestFixture]
	public class WhenSettingLabelsEmpty : PresenterFixture
	{
		CategoryPropertyPresenter m_CategoryPropertyPresenter;
		
		protected override void Context()
		{
			MockCategoryProperty.Category = null;
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
		}
		
		protected override void Because()
		{
			m_CategoryPropertyPresenter.SetFields();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void LabelShouldContainExpectedValues()
		{
			Assert.AreEqual(string.Empty, MockCategoryProperty.NameTextBox.Text);
			Assert.AreEqual(string.Empty, MockCategoryProperty.DescriptionTextBox.Text);
		}
	}
	
	[TestFixture]
	public class WhenDeletingCategory : PresenterFixture
	{
		private CategoryPropertyPresenter m_CategoryPropertyPresenter;
		
		protected override void Context()
		{
			MockCategoryProperty.Category = new Category { Id = 1 };
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
		}
		
		protected override void Because()
		{
			m_CategoryPropertyPresenter.Delete(MockCategoryProperty.Category);
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldCallCategoryServiceDelete()
		{
			BootStrap.Testing.MockCategoryService
				.Verify(v => v.DeleteById(It.Is<int>(p => p == MockCategoryProperty.Category.Id)), Times.Once());
		}
	}
	
	[TestFixture]
	public class WhenUpdatingCategoryWithInvalidValues : PresenterFixture
	{
		private CategoryPropertyPresenter m_CategoryPropertyPresenter;
		
		protected override void Context()
		{
			MockCategoryProperty.Category = new Category { Id = 1, Name = string.Empty, Description = "desc" };
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
			m_CategoryPropertyPresenter.SetFieldsEmpty();
		}
		
		protected override void Because()
		{
			m_CategoryPropertyPresenter.Update(MockCategoryProperty.Category);
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldNotCallCategoryServiceUpdate()
		{
			BootStrap.Testing.MockCategoryService
				.Verify(v => v.SaveOrUpdate(It.Is<Category>(p => p == MockCategoryProperty.Category)), Times.Never());
		}
		
		[Test]
		public void ShouldShowErrorMessageToUser()
		{
			Assert.IsTrue(MockCategoryProperty.ErrorLabel.Visible);
			Assert.AreEqual("Bitte geben Sie der Kategorie einen Namen!", MockCategoryProperty.ErrorLabel.Text);
		}
	}
	
	[TestFixture]
	public class WhenUpdatingCategoryWithValidValues : PresenterFixture
	{
		private CategoryPropertyPresenter m_CategoryPropertyPresenter;
		
		protected override void Context()
		{
			MockCategoryProperty.Category = new Category { Id = 1, Name = "test", Description = "desc" };
			m_CategoryPropertyPresenter = new CategoryPropertyPresenter(MockCategoryProperty);
			m_CategoryPropertyPresenter.SetFields();
		}
		
		protected override void Because()
		{
			m_CategoryPropertyPresenter.Update(MockCategoryProperty.Category);
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldCallCategoryServiceUpdate()
		{
			BootStrap.Testing.MockCategoryService
				.Verify(v => v.SaveOrUpdate(It.IsAny<Category>()), Times.Once());
		}
		
		[Test]
		public void ShouldNotShowAnyError()
		{
			Assert.IsFalse(MockCategoryProperty.ErrorLabel.Visible);
			Assert.AreEqual(string.Empty, MockCategoryProperty.ErrorLabel.Text);
		}
	}
}

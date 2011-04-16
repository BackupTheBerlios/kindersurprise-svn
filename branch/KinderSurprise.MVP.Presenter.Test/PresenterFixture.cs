using KinderSurprise.BootStrap;
using NUnit.Framework;
using KinderSurprise.MVP.Presenter.Interfaces;
using System.Web.UI.WebControls;

namespace KinderSurprise.MVP.Presenter.Test
{
	public abstract class PresenterFixture
	{
		protected ICategoryPropertyPresenter MockCategoryProperty;
		
        [SetUp]
		public void FixtureSetupContext()
		{
			Testing.Initialize();
			SetMocks();
            Context();
            Because();
		}

        [TearDown]
        public void FixtureTearDown()
        {
			CleanMocks();
        }

        protected abstract void Context();
        protected abstract void Because();
	    protected abstract void TearDownContext();
		
		private void SetMocks()
		{
			Moq.Mock<ICategoryPropertyPresenter> mockCategoryProperty = new Moq.Mock<ICategoryPropertyPresenter>();
			mockCategoryProperty.SetupAllProperties();
			MockCategoryProperty = mockCategoryProperty.Object;
			MockCategoryProperty.ErrorLabel = new Label();
            MockCategoryProperty.NameTextBox = new TextBox();
            MockCategoryProperty.DescriptionTextBox = new TextBox();
            MockCategoryProperty.NewSerie = new Button();
            MockCategoryProperty.NewCategory = new Button();
            MockCategoryProperty.Cancel = new Button();
            MockCategoryProperty.Delete = new Button();
            MockCategoryProperty.Update = new Button();
		}
		
		private void CleanMocks()
		{
			MockCategoryProperty = null;
		}
	}
}


using KinderSurprise.BootStrap;
using NUnit.Framework;
using KinderSurprise.MVP.Presenter.Interfaces;
using System.Web.UI.WebControls;

namespace KinderSurprise.MVP.Presenter.Test
{
	public abstract class PresenterFixture
	{
		protected ICategoryPropertyPresenter MockCategoryProperty;
		protected IMultiView MockMultiView;
		protected ITreeView MockTreeView;
		
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
			Testing.ResetMocks();
        }

        protected abstract void Context();
        protected abstract void Because();
	    protected abstract void TearDownContext();
		
		private void SetMocks()
		{
			Moq.Mock<ICategoryPropertyPresenter> mockCategoryProperty = new Moq.Mock<ICategoryPropertyPresenter>();
			Moq.Mock<IMultiView> mockMultiView = new Moq.Mock<IMultiView>();
			Moq.Mock<ITreeView> mockTreeView = new Moq.Mock<ITreeView>();
			
			mockCategoryProperty.SetupAllProperties();
			mockMultiView.SetupAllProperties();
			mockTreeView.SetupAllProperties();
			
			MockCategoryProperty = mockCategoryProperty.Object;
			MockMultiView = mockMultiView.Object;
			MockTreeView = mockTreeView.Object;
			
			MockCategoryProperty.ErrorLabel = new Label();
            MockCategoryProperty.NameTextBox = new TextBox();
            MockCategoryProperty.DescriptionTextBox = new TextBox();
            MockCategoryProperty.NewSerie = new Button();
            MockCategoryProperty.NewCategory = new Button();
            MockCategoryProperty.Cancel = new Button();
            MockCategoryProperty.Delete = new Button();
            MockCategoryProperty.Update = new Button();
			
			MockMultiView.MultiViewCategory = new MultiView();
			MockMultiView.MultiViewFigur = new MultiView();
			MockMultiView.MultiViewSerie = new MultiView();
			MockMultiView.ViewCategoryProperty = new View();
			MockMultiView.ViewFigurProperty = new View();
			MockMultiView.ViewFigurStore = new View();
			MockMultiView.ViewSerieProperty = new View();
			MockMultiView.ViewSerieStore = new View();
			MockMultiView.MultiViewCategory.Views.Add(MockMultiView.ViewCategoryProperty);
            MockMultiView.MultiViewSerie.Views.Add(MockMultiView.ViewSerieProperty);
            MockMultiView.MultiViewSerie.Views.Add(MockMultiView.ViewSerieStore);
            MockMultiView.MultiViewFigur.Views.Add(MockMultiView.ViewFigurProperty);
            MockMultiView.MultiViewFigur.Views.Add(MockMultiView.ViewFigurStore);
			
			MockTreeView.Menu = new Menu();
			MockTreeView.OverviewTreeView = new TreeView();
            MockTreeView.Menu.Items.Add(new MenuItem("Eigenschaft", "1"));
            MockTreeView.Menu.Items.Add(new MenuItem("Lager", "2"));
		}
		
		private void CleanMocks()
		{
			MockCategoryProperty = null;
			MockMultiView = null;
			MockTreeView = null;
		}
	}
}


using System;
using System.Web.UI.WebControls;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter;
using KinderSurprise.MVP.Presenter.Interfaces;

namespace KinderSurprise.MVP.View
{
    public partial class Default : System.Web.UI.Page, ITreeView, IMultiView
    {
        #region Page Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                InitializeControlElements();
        }

        protected override void OnInit(EventArgs eventArgs)
        {
            TV_Overview.DataBinding += TV_Overview_DataBinding;
            TV_Overview.SelectedNodeChanged += TV_Overview_SelectedNodeChanged;
        }

        #endregion

        # region PresenterProperties

        public TreeView OverviewTreeView
        {
            get { return TV_Overview; }
            set { OverviewTreeView = TV_Overview; }
        }

        public Menu Menu
        {
            get { return Menu_TabMenu; }
            set { Menu = Menu_TabMenu; }
        }

        public MultiView MultiViewCategory
        {
            get { return MV_Category; }
            set { MultiViewCategory = MV_Category; }
        }
        public System.Web.UI.WebControls.View ViewCategoryProperty
        {
            get { return MV_Category_Properties; }
            set { ViewCategoryProperty = MV_Category_Properties; }
        }
        public MultiView MultiViewSerie
        {
            get { return MV_Serie;}
            set { MultiViewSerie = MV_Serie; }
        }
        public System.Web.UI.WebControls.View ViewSerieProperty
        {
            get { return MV_Serie_Properties; }
            set { ViewSerieProperty = MV_Serie_Properties; }
        }
        public System.Web.UI.WebControls.View ViewSerieStore
        {
            get { return MV_Serie_Store; }
            set { ViewSerieStore = MV_Serie_Store; }
        }
        public MultiView MultiViewFigur
        {
            get { return MV_Figur; }
            set { MultiViewFigur = MV_Figur; }
        }
        public System.Web.UI.WebControls.View ViewFigurProperty
        {
            get { return MV_Figur_Properties; }
            set { ViewFigurProperty = MV_Figur_Properties; }
        }
        public System.Web.UI.WebControls.View ViewFigurStore
        {
            get { return MV_Figur_Store; }
            set { ViewFigurStore = MV_Figur_Store; }
        }

        #endregion

        private void InitializeControlElements()
        {
            DataBindTreeView();
            ActivateMultiView();
        }

        public void DataBindTreeView()
        {
            TreeViewPresenter treeViewPresenter = new TreeViewPresenter(this);
            treeViewPresenter.ClearTreeView();
            treeViewPresenter.FillTreeView();
        }

        public void ActivateMultiView()
        {
            MultiViewPresenter multiViewPresenter = new MultiViewPresenter(this);
            TreeViewPresenter treeViewPresenter = new TreeViewPresenter(this);
            UserControlPresenter userControlPresenter = new UserControlPresenter(UC_CategoryProperty, UC_SerieProperty, UC_FigurProperty);

            var category = treeViewPresenter.GetSelectedNodeDepth();
            multiViewPresenter.ActivateView(category);
            userControlPresenter.ActivateModeOneView(treeViewPresenter.GetSelectedNodeId(), category, EMode.View);
        }

        public void ActivateViewInCreateMode(ETabActivity tabActivity)
        {
            MultiViewPresenter multiViewPresenter = new MultiViewPresenter(this);
            UserControlPresenter userControlPresenter = new UserControlPresenter(UC_CategoryProperty, UC_SerieProperty, UC_FigurProperty);
            multiViewPresenter.ActivateView(tabActivity);

            userControlPresenter.ActivateModeOneView(0, tabActivity, EMode.New);
        }

        #region TreeView Event Handling

        private void TV_Overview_DataBinding(object sender, EventArgs eventArgs)
        {
            DataBindTreeView();
        }

        private void TV_Overview_SelectedNodeChanged(object sender, EventArgs eventArgs)
        {
            ActivateMultiView();
        }

        #endregion
    }
}

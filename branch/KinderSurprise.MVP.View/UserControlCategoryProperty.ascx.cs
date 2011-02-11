using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter;
using KinderSurprise.MVP.Presenter.Interfaces;

namespace KinderSurprise.MVP.View
{
    public partial class UserControlCategoryProperty : UserControl, ICategoryPropertyPresenter, ICategoryControl
    {
        #region Page Properties

        public Label ErrorLabel
        {
            get { return LblErrorLabel; }
            set { LblErrorLabel = ErrorLabel; }
        }

        public TextBox NameTextBox
        {
            get { return TbNameTextBox; }
            set { TbNameTextBox = NameTextBox; }
        }

        public TextBox DescriptionTextBox
        {
            get { return TbDescriptionTextBox; }
            set { TbDescriptionTextBox = DescriptionTextBox; }
        }

        public Button NewSerie
        {
            get { return BTN_NewSerie; }
            set { BTN_NewSerie = value; }
        }

        public Button NewCategory
        {
            get { return BTN_NewCategory; }
            set { BTN_NewCategory = value; }
        }

        public Button Cancel
        {
            get { return BTN_CategoryCancel; }
            set { BTN_CategoryCancel = value; }
        }

        public Button Delete
        {
            get { return BTN_CategoryDelete; }
            set { BTN_CategoryDelete = value; }
        }

        public Button Update
        {
            get { return BTN_CategoryUpdate; }
            set { BTN_CategoryUpdate = value; }
        }

        #endregion

        #region Properties

        public Category Category
        {
            get { return (Category) Session["Category"]; }
            set { Session["Category"] = value; }
        }

        #endregion Properties

        #region PageMethods

        protected void Page_Load(object sender, EventArgs e)
        {
            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(this);
            categoryPropertyPresenter.InitErrorLabel();
        }

        protected override void OnInit(EventArgs eventArgs)
        {
            BTN_NewCategory.Click += BtnCategoryAddClick;
            BTN_CategoryDelete.Click += BtnCategoryDeleteClick;
            BTN_CategoryUpdate.Click += BtnCategoryUpdateClick;
            BTN_CategoryCancel.Click += BtnCategoryCancelClick;
            BTN_NewSerie.Click += BtnNewSerieClick;
            base.OnInit(eventArgs);
        }

        #endregion

        #region Button Click Methods

        private void BtnNewSerieClick(object sender, EventArgs e)
        {
            Default page = (Default)Page;
            page.ActivateViewInCreateMode(ETabActivity.Serie);

        }

        private void BtnCategoryCancelClick(object sender, EventArgs e)
        {
            InitializeViewMode();
        }

        private void BtnCategoryUpdateClick(object sender, EventArgs e)
        {
            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(this);

            if (categoryPropertyPresenter.Update(Category))
                ReloadTreeView();
        }

        private void BtnCategoryDeleteClick(object sender, EventArgs e)
        {
            //ToDo Ask if the user really wants to delete
            
            CategoryPropertyPresenter categoryPropertyPresenter = new CategoryPropertyPresenter(this);
            categoryPropertyPresenter.Delete(Category);

            ReloadTreeView();
        }

        private void BtnCategoryAddClick(object sender, EventArgs eventArgs)
        {
            InitializeEditMode();
        }

        #endregion

        #region Mode Methods

        public void InitializeViewMode()
        {
            var categoryPropertyPresenter = new CategoryPropertyPresenter(this);
            categoryPropertyPresenter.SetButtonToViewMode();
            categoryPropertyPresenter.SetFields();
        }

        public void InitializeEditMode()
        {
            Category = null;
            var categoryPropertyPresenter = new CategoryPropertyPresenter(this);
            
            categoryPropertyPresenter.SetButtonToEditMode();
            categoryPropertyPresenter.SetFieldsEmpty();
        }

        public void InitializeViewMode(Category category)
        {
            Category = category;
            var categoryPropertyPresenter = new CategoryPropertyPresenter(this);

            categoryPropertyPresenter.SetButtonToViewMode();
            categoryPropertyPresenter.SetFields();
        }

        #endregion

        #region Default Page Methods

        private void ReloadTreeView()
        {
            Default page = (Default)Page;
            page.DataBindTreeView();
            page.ActivateMultiView();
        }

        #endregion
    }
}
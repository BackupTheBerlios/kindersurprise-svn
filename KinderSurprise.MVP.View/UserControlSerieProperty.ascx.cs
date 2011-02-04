using System;
using System.Web.UI.WebControls;
using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter;
using KinderSurprise.MVP.Presenter.Interfaces;

namespace KinderSurprise.MVP.View
{
    public partial class UserControlSerieProperty : System.Web.UI.UserControl, ISeriePropertyPresenter, ISerieControl
    {
        #region Model Properties

        public Button NewSerieButton
        {
            get { return BTN_NewSerie; }
            set { BTN_NewSerie = value; }
        }

        public Button NewFigurButton
        {
            get { return BTN_NewFigur; }
            set { BTN_NewFigur = value; }
        }

        public Button SaveButton
        {
            get { return BTN_Save; }
            set { BTN_Save = value; }
        }

        public Button DeleteButton
        {
            get { return BTN_Delete; }
            set { BTN_Delete = value; }
        }

        public Button CancelButton
        {
            get { return BTN_Cancel; }
            set { BTN_Cancel = value; }
        }

        public Label ErrorMessage
        {
            get { return LBL_ErrorMessage; }
            set { LBL_ErrorMessage = value; }
        }

        public TextBox Name
        {
            get { return TB_Serie_Name; }
            set { TB_Serie_Name = value; }
        }

        public TextBox Description
        {
            get { return TB_Serie_Description; }
            set { TB_Serie_Description = value; }
        }

        public TextBox PublicationYear
        {
            get { return TB_PubYear; }
            set { TB_PubYear = value; }
        }

        public DropDownList ChooseCategory
        {
            get { return DDL_Serie_Choose_Category; }
            set { DDL_Serie_Choose_Category = value; }
        }

        #endregion

        #region Properties

        public Serie Serie 
        {
            get { return (Serie) Session["SerieDto"]; }
            set { Session["SerieDto"] = value; }
        }

        #endregion

        #region Page Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            LBL_ErrorMessage.Visible = false;
            LBL_ErrorMessage.Text = string.Empty;
        }

        protected override void OnInit(EventArgs eventArgs)
        {
            BTN_NewSerie.Click += BtnNewSerieClick;
            BTN_NewFigur.Click += BtnNewFigurClick;
            BTN_Save.Click += BTN_Save_Click;
            BTN_Delete.Click += BtnDeleteClick;
            BTN_Cancel.Click += BtnCancelClick;
            base.OnInit(eventArgs);
        }

        #endregion

        #region Button Methods

        private void BtnNewFigurClick(object sender, EventArgs e)
        {
            Default page = (Default)Page;
            page.ActivateViewInCreateMode(ETabActivity.Figur);
        }

        private void BtnNewSerieClick(object sender, EventArgs e)
        {
            InitializeEditMode();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            InitializeViewMode();
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            //ToDo Ask if the user really wants to delete

            var seriePropertyPresenter = new SeriePropertyPresenter(this);
            seriePropertyPresenter.Delete();
            
            ReloadTreeView();
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            SeriePropertyPresenter seriePropertyPresenter = new SeriePropertyPresenter(this);
            
            if (seriePropertyPresenter.Update())
                ReloadTreeView();
        }

        #endregion

        #region Views Methods

        public void InitializeEditMode()
        {
            Serie = null;
            SeriePropertyPresenter seriePropertyPresenter = new SeriePropertyPresenter(this);
            seriePropertyPresenter.SetToEditMode();
            seriePropertyPresenter.SetFieldsEmpty();
        }

        public void InitializeViewMode()
        {
            SeriePropertyPresenter seriePropertyPresenter = new SeriePropertyPresenter(this);
            seriePropertyPresenter.SetToViewMode();
            seriePropertyPresenter.SetFields();
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
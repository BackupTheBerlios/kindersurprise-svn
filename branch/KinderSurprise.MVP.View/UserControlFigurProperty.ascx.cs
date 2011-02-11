using System;
using System.Web.UI.WebControls;
using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter;
using KinderSurprise.MVP.Presenter.Interfaces;

namespace KinderSurprise.MVP.View
{
    public partial class UserControlFigurProperty : System.Web.UI.UserControl, IFigurPropertyPresenter, IFigurControl
    {
        #region Model Properties

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

        public TextBox Name
        {
            get { return TB_Figur_Name; }
            set { TB_Figur_Name = value; }
        }

        public TextBox Description
        {
            get { return TB_Figur_Description; }
            set { TB_Figur_Description = value; }
        }

        public TextBox Price
        {
            get { return TB_Figur_Price; }
            set { TB_Figur_Price = value; }
        }

        public DropDownList ChooseSerie
        {
            get { return DDL_Figur_Choose_Serie; }
            set { DDL_Figur_Choose_Serie = value; }
        }

        public Label ErrorMessage
        {
            get { return LBL_ErrorMessage; }
            set { LBL_ErrorMessage = value; }
        }

        #endregion

        #region Property

        public Figur Figur
        {
            get { return (Figur) Session["Figur"]; }
            set { Session["Figur"] = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs eventArgs)
        {
            BTN_NewFigur.Click += BtnNewFigurClick;
            BTN_Save.Click += BtnSaveClick;
            BTN_Delete.Click += BtnDeleteClick;
            BTN_Cancel.Click += BtnCancelClick;
            base.OnInit(eventArgs);
        }

        private void BtnNewFigurClick(object sender, EventArgs e)
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

            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(this);
            figurPropertyPresenter.Delete(Figur);

            ReloadTreeView();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(this);

            if(figurPropertyPresenter.Update(Figur))
                ReloadTreeView();
        }

        #region Default Page Methods

        public void InitializeEditMode()
        {
            Figur = null;
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(this);
            
            figurPropertyPresenter.SetToEditMode();
            figurPropertyPresenter.SetFieldsEmpty();
        }

        public void InitializeViewMode()
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(this);
            
            figurPropertyPresenter.SetToViewMode();
            figurPropertyPresenter.SetFields();
        }
        
        private void ReloadTreeView()
        {
            Default page = (Default)Page;
            page.DataBindTreeView();
            page.ActivateMultiView();
        }

        #endregion
    }
}
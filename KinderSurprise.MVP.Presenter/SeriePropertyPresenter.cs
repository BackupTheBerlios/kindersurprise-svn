using System;
using System.Collections.Generic;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Presenter
{
    public class SeriePropertyPresenter
    {
        private readonly ISeriePropertyPresenter m_SeriePropertyPresenter;
        
        public SeriePropertyPresenter(ISeriePropertyPresenter seriePropertyPresenter)
        {
            m_SeriePropertyPresenter = seriePropertyPresenter;
        }

        public void SetToEditMode()
        {
            m_SeriePropertyPresenter.NewFigurButton.Visible = false;
            m_SeriePropertyPresenter.DeleteButton.Visible = false;
            m_SeriePropertyPresenter.CancelButton.Visible = true;
            m_SeriePropertyPresenter.SaveButton.Visible = true;
            m_SeriePropertyPresenter.NewSerieButton.Visible = false;
        }

        public void SetToViewMode()
        {
            m_SeriePropertyPresenter.NewFigurButton.Visible = true;
            m_SeriePropertyPresenter.DeleteButton.Visible = true;
            m_SeriePropertyPresenter.CancelButton.Visible = false;
            m_SeriePropertyPresenter.SaveButton.Visible = true;
            m_SeriePropertyPresenter.NewSerieButton.Visible = true;
        }

        public void SetFields()
        {
            if (m_SeriePropertyPresenter.Serie != null)
            {
                m_SeriePropertyPresenter.Name.Text = m_SeriePropertyPresenter.Serie.Name;
                m_SeriePropertyPresenter.Description.Text = m_SeriePropertyPresenter.Serie.Description;
                m_SeriePropertyPresenter.PublicationYear.Text =
                m_SeriePropertyPresenter.Serie.PublicationYear.Year.ToString();
            }

            InitializeCategoryDropDownList();
        }

        public void SetFieldsEmpty()
        {
            m_SeriePropertyPresenter.Name.Text = string.Empty;
            m_SeriePropertyPresenter.Description.Text = string.Empty;
            m_SeriePropertyPresenter.PublicationYear.Text = string.Empty;
            InitializeCategoryDropDownList();
        }

        private void InitializeCategoryDropDownList()
        {
            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
            List<Category> categories = categoryService.GetAll();
            
            //ToDo Select the Category which the serie belongs to
            //if(m_SeriePropertyPresenter.SerieDto == null)

            const string dataValueField = "Id";
            const string dataTextField = "Name";

            m_SeriePropertyPresenter.ChooseCategory.DataSource = categories;
            m_SeriePropertyPresenter.ChooseCategory.DataValueField = dataValueField;
            m_SeriePropertyPresenter.ChooseCategory.DataTextField = dataTextField;
            m_SeriePropertyPresenter.ChooseCategory.DataBind();    
        }

        public void Delete()
        {
            if (m_SeriePropertyPresenter.Serie == null)
                return;

            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            serieService.DeleteById(m_SeriePropertyPresenter.Serie.Id);
        }

        public bool Update()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            bool notValid = false;


            if (!validator.IsValidString(m_SeriePropertyPresenter.Name.Text))
            {
                m_SeriePropertyPresenter.ErrorMessage.Visible = true;
                m_SeriePropertyPresenter.ErrorMessage.Text = "Bitte geben Sie einen Namen für die Serie ein!" + Environment.NewLine;
                notValid = true;
            }
            if (!validator.IsValidYear(m_SeriePropertyPresenter.PublicationYear.Text))
            {
                m_SeriePropertyPresenter.ErrorMessage.Visible = true;
                m_SeriePropertyPresenter.ErrorMessage.Text += "Bitte geben Sie ein gültiges Jahr ein!" + Environment.NewLine;
                notValid = true;
            }

            if (notValid)
                return false;

            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            serieService.SaveOrUpdate(
                new Serie{ Id = m_SeriePropertyPresenter.Serie == null ? 0 : m_SeriePropertyPresenter.Serie.Id,
                             Name = m_SeriePropertyPresenter.Name.Text,
                             Description = m_SeriePropertyPresenter.Description.Text,
                             PublicationYear = new DateTime(Convert.ToInt32(m_SeriePropertyPresenter.PublicationYear.Text), 1, 1),
                             Category = new Category
                                 {
                                     Id =
                                         Convert.ToInt32(m_SeriePropertyPresenter.ChooseCategory.SelectedValue)
                                 } });
            m_SeriePropertyPresenter.ErrorMessage.Visible = false;
            return true;
        }
    }
}
			                          
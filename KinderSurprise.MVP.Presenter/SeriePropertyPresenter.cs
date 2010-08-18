using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using KinderSurprise.DTO;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;

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
            if (m_SeriePropertyPresenter.SerieDto != null)
            {
                m_SeriePropertyPresenter.Name.Text = m_SeriePropertyPresenter.SerieDto.SerieName;
                m_SeriePropertyPresenter.Description.Text = m_SeriePropertyPresenter.SerieDto.Description;
                m_SeriePropertyPresenter.PublicationYear.Text =
                m_SeriePropertyPresenter.SerieDto.PublicationYear.Year.ToString();
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
            ICategoryService categoryService = new CategoryService();
            List<CategoryDto> categoryDtos = categoryService.GetAll();
            
            //ToDo Select the Category which the serie belongs to
            //if(m_SeriePropertyPresenter.SerieDto == null)

            const string dataValueField = "CategoryId";
            const string dataTextField = "CategoryName";

            m_SeriePropertyPresenter.ChooseCategory.DataSource = categoryDtos;
            m_SeriePropertyPresenter.ChooseCategory.DataValueField = dataValueField;
            m_SeriePropertyPresenter.ChooseCategory.DataTextField = dataTextField;
            m_SeriePropertyPresenter.ChooseCategory.DataBind();    
        }

        public void Delete()
        {
            if (m_SeriePropertyPresenter.SerieDto == null)
                return;

            ISerieService serieService = new SerieService();
            serieService.DeleteById(m_SeriePropertyPresenter.SerieDto.SerieId);
        }

        public bool Update()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            bool notValid = false;


            if (!validationHandling.IsValidString(m_SeriePropertyPresenter.Name.Text))
            {
                m_SeriePropertyPresenter.ErrorMessage.Visible = true;
                m_SeriePropertyPresenter.ErrorMessage.Text = "Bitte geben Sie einen Namen für die Serie ein!" + Environment.NewLine;
                notValid = true;
            }
            if (!validationHandling.IsValidYear(m_SeriePropertyPresenter.PublicationYear.Text))
            {
                m_SeriePropertyPresenter.ErrorMessage.Visible = true;
                m_SeriePropertyPresenter.ErrorMessage.Text += "Bitte geben Sie ein gültiges Jahr ein!" + Environment.NewLine;
                notValid = true;
            }

            if (notValid)
                return false;

            ISerieService serieService = new SerieService();
            serieService.SaveOrUpdate(
                new SerieDto(m_SeriePropertyPresenter.SerieDto == null ? 0 : m_SeriePropertyPresenter.SerieDto.SerieId,
                             m_SeriePropertyPresenter.Name.Text,
                             m_SeriePropertyPresenter.Description.Text,
                             new DateTime(Convert.ToInt32(m_SeriePropertyPresenter.PublicationYear.Text), 1, 1),
                             new Mapper.Category
                                 {
                                     CategoryId =
                                         Convert.ToInt32(m_SeriePropertyPresenter.ChooseCategory.SelectedValue)
                                 }));
            m_SeriePropertyPresenter.ErrorMessage.Visible = false;
            return true;
        }
    }
}

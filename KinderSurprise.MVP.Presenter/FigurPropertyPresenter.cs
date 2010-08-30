using System;
using System.Collections.Generic;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;

namespace KinderSurprise.MVP.Presenter
{
    public class FigurPropertyPresenter
    {
        private readonly IFigurPropertyPresenter m_FigurPropertyPresenter;

        public FigurPropertyPresenter(IFigurPropertyPresenter figurPropertyPresenter)
        {
            m_FigurPropertyPresenter = figurPropertyPresenter;
        }

        public void SetToEditMode()
        {
            m_FigurPropertyPresenter.NewFigurButton.Visible = false;
            m_FigurPropertyPresenter.DeleteButton.Visible = false;
            m_FigurPropertyPresenter.CancelButton.Visible = true;
            m_FigurPropertyPresenter.SaveButton.Visible = true;
        }

        public void SetToViewMode()
        {
            m_FigurPropertyPresenter.CancelButton.Visible = false;
            m_FigurPropertyPresenter.SaveButton.Visible = true;
            m_FigurPropertyPresenter.NewFigurButton.Visible = true;
            m_FigurPropertyPresenter.DeleteButton.Visible = true;
        }

        public void SetFields()
        {
            if (m_FigurPropertyPresenter.FigurDto != null)
            {
                m_FigurPropertyPresenter.FigurName.Text = m_FigurPropertyPresenter.FigurDto.FigurName;
                m_FigurPropertyPresenter.FigurDescription.Text = m_FigurPropertyPresenter.FigurDto.Description;
                m_FigurPropertyPresenter.FigurPrice.Text = m_FigurPropertyPresenter.FigurDto.Price.ToString();
            }
            InitializeCategoryDropDownList();
        }

        public void SetFieldsEmpty()
        {
            m_FigurPropertyPresenter.FigurName.Text = string.Empty;
            m_FigurPropertyPresenter.FigurDescription.Text = string.Empty;
            m_FigurPropertyPresenter.FigurPrice.Text = string.Empty;
            InitializeCategoryDropDownList();
        }

        private void InitializeCategoryDropDownList()
        {
            ISerieService serieService = new SerieService();
            List<SerieDto> serieDtos = serieService.GetAll();

            /*if (m_FigurPropertyPresenter.FigurDto == null)
                serieDtos = serieService.GetAll();
            else
                serieDtos =
                    serieService.GetAllByCategoryId( new Category { CategoryId = new Serie {SerieId = figurDto.Serie.SerieId}.Category.CategoryId}.CategoryId);*/

            //ToDo Select the Category which the serie belongs to

            const string dataValueField = "SerieId";
            const string dataTextField = "SerieName";

            m_FigurPropertyPresenter.ChooseSerie.DataSource = serieDtos;
            m_FigurPropertyPresenter.ChooseSerie.DataValueField = dataValueField;
            m_FigurPropertyPresenter.ChooseSerie.DataTextField = dataTextField;
            m_FigurPropertyPresenter.ChooseSerie.DataBind();
        }

        public bool Update(FigurDto figurDto)
        {
            ValidationHandling validationHandling = new ValidationHandling();
            bool isValid = true;

            if (!validationHandling.IsValidString(m_FigurPropertyPresenter.FigurName.Text))
            {
                m_FigurPropertyPresenter.ErrorMessage.Text = "Bitte geben Sie einen Namen für die Figur ein!" + Environment.NewLine;
                m_FigurPropertyPresenter.ErrorMessage.Visible = true;
                isValid = false;
            }
            if (!validationHandling.IsValidPrice(m_FigurPropertyPresenter.FigurPrice.Text))
            {
                m_FigurPropertyPresenter.ErrorMessage.Text += "Bitte geben Sie einen gültigen Preis ein!" + Environment.NewLine;
                m_FigurPropertyPresenter.ErrorMessage.Visible = true;
                isValid = false;
            }

            if (!isValid)
                return false;

            IFigurService figurService = new FigurService();
            figurService.SaveOrUpdate(new FigurDto(figurDto == null ? 0 : figurDto.FigurId, m_FigurPropertyPresenter.FigurName.Text,
                                                   m_FigurPropertyPresenter.FigurDescription.Text,
                                                  Convert.ToDecimal(m_FigurPropertyPresenter.FigurPrice.Text),
                                                   new Serie { SerieId = Convert.ToInt32(m_FigurPropertyPresenter.ChooseSerie.SelectedValue) }));
            
            m_FigurPropertyPresenter.ErrorMessage.Visible = false;
            return true;
        }

        public void Delete(FigurDto figurDto)
        {
            if (figurDto == null)
                return;

            IFigurService figurService = new FigurService();
            figurService.DeleteById(figurDto.FigurId);

        }
    }
}

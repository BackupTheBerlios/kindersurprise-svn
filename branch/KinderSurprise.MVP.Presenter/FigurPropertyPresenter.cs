using System;
using System.Collections.Generic;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using StructureMap;

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
            if (m_FigurPropertyPresenter.Figur != null)
            {
                m_FigurPropertyPresenter.Name.Text = m_FigurPropertyPresenter.Figur.Name;
                m_FigurPropertyPresenter.Description.Text = m_FigurPropertyPresenter.Figur.Description;
                m_FigurPropertyPresenter.Price.Text = m_FigurPropertyPresenter.Figur.Price.ToString();
            }
            InitializeCategoryDropDownList();
        }

        public void SetFieldsEmpty()
        {
            m_FigurPropertyPresenter.Name.Text = string.Empty;
            m_FigurPropertyPresenter.Description.Text = string.Empty;
            m_FigurPropertyPresenter.Price.Text = string.Empty;
            InitializeCategoryDropDownList();
        }

        private void InitializeCategoryDropDownList()
        {
            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
            List<Serie> series = serieService.GetAll();

            /*if (m_FigurPropertyPresenter.Figur == null)
                series = serieService.GetAll();
            else
                series =
                    serieService.GetAllByCategoryId( new Category { CategoryId = new Serie {SerieId = figurDto.Serie.SerieId}.Category.CategoryId}.CategoryId);*/

            //ToDo Select the Category which the serie belongs to

            const string dataValueField = "Id";
            const string dataTextField = "Name";

            m_FigurPropertyPresenter.ChooseSerie.DataSource = series;
            m_FigurPropertyPresenter.ChooseSerie.DataValueField = dataValueField;
            m_FigurPropertyPresenter.ChooseSerie.DataTextField = dataTextField;
            m_FigurPropertyPresenter.ChooseSerie.DataBind();
        }

        public bool Update(Figur figur)
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            bool isValid = true;

            if (!validator.IsValidString(m_FigurPropertyPresenter.Name.Text))
            {
                m_FigurPropertyPresenter.ErrorMessage.Text = "Bitte geben Sie einen Namen für die Figur ein!" + Environment.NewLine;
                m_FigurPropertyPresenter.ErrorMessage.Visible = true;
                isValid = false;
            }
            if (!validator.IsValidPrice(m_FigurPropertyPresenter.Price.Text))
            {
                m_FigurPropertyPresenter.ErrorMessage.Text += "Bitte geben Sie einen gültigen Preis ein!" + Environment.NewLine;
                m_FigurPropertyPresenter.ErrorMessage.Visible = true;
                isValid = false;
            }

            if (!isValid)
                return false;

            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            figurService.SaveOrUpdate(new Figur { Id = figur == null ? 0 : figur.Id, Name = m_FigurPropertyPresenter.Name.Text,
                                                   Description = m_FigurPropertyPresenter.Description.Text,
                                                   Price = Convert.ToDecimal(m_FigurPropertyPresenter.Price.Text),
                                                   Serie = new Serie { Id = Convert.ToInt32(m_FigurPropertyPresenter.ChooseSerie.SelectedValue) } });
            
            m_FigurPropertyPresenter.ErrorMessage.Visible = false;
            return true;
        }

        public void Delete(Figur figur)
        {
            if (figur == null)
                return;

            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
            figurService.DeleteById(figur.Id);

        }
    }
}

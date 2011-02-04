using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;

namespace KinderSurprise.MVP.Presenter
{
    public class CategoryPropertyPresenter
    {
        private readonly ICategoryPropertyPresenter m_CategoryPropertyPresenter;

        public CategoryPropertyPresenter(ICategoryPropertyPresenter categoryPropertyPresenter)
        {
            m_CategoryPropertyPresenter = categoryPropertyPresenter;
        }

        public void SetButtonToViewMode()
        {
            m_CategoryPropertyPresenter.Cancel.Visible = false;
            m_CategoryPropertyPresenter.Update.Visible = true;
            m_CategoryPropertyPresenter.NewCategory.Visible = true;
            m_CategoryPropertyPresenter.Delete.Visible = true;
            m_CategoryPropertyPresenter.NewSerie.Visible = true;
        }

        public void SetButtonToEditMode()
        {
            m_CategoryPropertyPresenter.Cancel.Visible = true;
            m_CategoryPropertyPresenter.Update.Visible = true;
            m_CategoryPropertyPresenter.NewCategory.Visible = false;
            m_CategoryPropertyPresenter.Delete.Visible = false;
            m_CategoryPropertyPresenter.NewSerie.Visible = false;
        }

        public void SetFieldsEmpty()
        {
            m_CategoryPropertyPresenter.NameTextBox.Text = string.Empty;
            m_CategoryPropertyPresenter.DescriptionTextBox.Text = string.Empty;
        }

        public void SetFields()
        {
            if (m_CategoryPropertyPresenter.Category == null) return;

            m_CategoryPropertyPresenter.NameTextBox.Text = m_CategoryPropertyPresenter.Category.Name;
            m_CategoryPropertyPresenter.DescriptionTextBox.Text = m_CategoryPropertyPresenter.Category.Description;
        }

        public bool Update(Category category)
        {
            ValidationHandling validationHandling = new ValidationHandling();

            if (validationHandling.IsValidString(m_CategoryPropertyPresenter.NameTextBox.Text))
            {
                ICategoryService categoryService = new CategoryService();
                categoryService.SaveOrUpdate(
                    new Category { Id = category == null
                            ? 0
                            : category.Id, Name = m_CategoryPropertyPresenter.NameTextBox.Text, Description = m_CategoryPropertyPresenter.DescriptionTextBox.Text} );
                
                m_CategoryPropertyPresenter.ErrorLabel.Visible = false;

                return true;
            }

            m_CategoryPropertyPresenter.ErrorLabel.Text = "Bitte geben Sie der Kategorie einen Namen!";
            m_CategoryPropertyPresenter.ErrorLabel.Visible = true;
            return false;
        }

        public void InitErrorLabel()
        {
            m_CategoryPropertyPresenter.ErrorLabel.Visible = false;
            m_CategoryPropertyPresenter.ErrorLabel.Text = string.Empty;
        }

        public void Delete(Category category)
        {
            if (category == null)
                return;

            ICategoryService categoryService = new CategoryService();
            categoryService.DeleteById(category.Id);
        }
    }
}

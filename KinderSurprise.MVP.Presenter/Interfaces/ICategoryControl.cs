using KinderSurprise.Model;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface ICategoryControl
    {
        void InitializeViewMode();
        void InitializeEditMode();
        Category Category { get; set; }
    }
}

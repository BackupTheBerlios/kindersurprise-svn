using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface ICategoryControl
    {
        void InitializeViewMode();
        void InitializeEditMode();
        CategoryDto CategoryDto { get; set; }
    }
}

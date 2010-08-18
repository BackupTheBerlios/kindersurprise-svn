using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface IFigurControl
    {
        FigurDto FigurDto { get; set; }

        void InitializeViewMode();
        void InitializeEditMode();
    }
}

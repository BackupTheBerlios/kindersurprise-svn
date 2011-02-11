using KinderSurprise.Model;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface IFigurControl
    {
        Figur Figur { get; set; }

        void InitializeViewMode();
        void InitializeEditMode();
    }
}

using KinderSurprise.Model;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface ISerieControl
    {
        Serie Serie { get; set; }

        void InitializeViewMode();
        void InitializeEditMode();
    }
}

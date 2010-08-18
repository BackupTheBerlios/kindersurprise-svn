using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface ISerieControl
    {
        SerieDto SerieDto { get; set; }

        void InitializeViewMode();
        void InitializeEditMode();
    }
}

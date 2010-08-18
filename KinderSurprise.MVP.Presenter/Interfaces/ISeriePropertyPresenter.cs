using System.Web.UI.WebControls;
using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface ISeriePropertyPresenter
    {
        Button NewSerieButton { get; set; }
        Button NewFigurButton { get; set; }
        Button SaveButton { get; set; }
        Button DeleteButton { get; set; }
        Button CancelButton { get; set; }

        Label ErrorMessage { get; set; }

        TextBox Name { get; set; }
        TextBox Description { get; set; }
        TextBox PublicationYear { get; set; }
        DropDownList ChooseCategory { get; set; }

        SerieDto SerieDto { get; set; }
    }
}

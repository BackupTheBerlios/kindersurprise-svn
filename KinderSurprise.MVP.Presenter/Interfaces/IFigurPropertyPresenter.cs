using System.Web.UI.WebControls;
using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface IFigurPropertyPresenter
    {
        Button NewFigurButton { get; set; }
        Button SaveButton { get; set; }
        Button DeleteButton { get; set; }
        Button CancelButton { get; set; }

        TextBox FigurName { get; set; }
        TextBox FigurDescription { get; set; }
        TextBox FigurPrice { get; set; }
        DropDownList ChooseSerie { get; set; }

        Label ErrorMessage { get; set; }

        FigurDto FigurDto { get; set; }
    }
}

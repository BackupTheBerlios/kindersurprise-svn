using System.Web.UI.WebControls;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface IFigurPropertyPresenter
    {
        Button NewFigurButton { get; set; }
        Button SaveButton { get; set; }
        Button DeleteButton { get; set; }
        Button CancelButton { get; set; }

        TextBox Name { get; set; }
        TextBox Description { get; set; }
        TextBox Price { get; set; }
        DropDownList ChooseSerie { get; set; }

        Label ErrorMessage { get; set; }

        Figur Figur { get; set; }
    }
}

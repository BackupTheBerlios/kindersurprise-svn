using System.Web.UI.WebControls;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface IMultiView
    {
        MultiView MultiViewCategory { get; set; } 
        View ViewCategoryProperty { get; set; }
        MultiView MultiViewSerie { get; set; }
        View ViewSerieProperty { get; set; }
        View ViewSerieStore { get; set; }
        MultiView MultiViewFigur { get; set; }
        View ViewFigurProperty { get; set; }
        View ViewFigurStore { get; set; }
    } 
}

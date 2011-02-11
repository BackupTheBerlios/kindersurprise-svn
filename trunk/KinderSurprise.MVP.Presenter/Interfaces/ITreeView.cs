using System.Web.UI.WebControls;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface ITreeView
    {
        TreeView OverviewTreeView { set; get; }
        Menu Menu { get; set; }
    }
}

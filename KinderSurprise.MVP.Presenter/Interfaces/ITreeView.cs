using System.Collections.Generic;
using System.Web.UI.WebControls;
using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface ITreeView
    {
        TreeView OverviewTreeView { set; get; }
        Menu Menu { get; set; }
    }
}

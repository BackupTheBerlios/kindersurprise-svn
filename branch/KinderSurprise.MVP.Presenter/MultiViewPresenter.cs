using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter.Interfaces;

namespace KinderSurprise.MVP.Presenter
{
    public class MultiViewPresenter
    {
        private readonly IMultiView m_MultiView;


        public MultiViewPresenter(IMultiView multiView)
        {
            m_MultiView = multiView;
        }

        public void ActivateView(ETabActivity tabActivity)
        {
            switch (tabActivity)
            {
                case ETabActivity.Category:
                    {
                        m_MultiView.MultiViewCategory.SetActiveView(m_MultiView.ViewCategoryProperty);
                        m_MultiView.MultiViewCategory.Visible = true;
                        m_MultiView.MultiViewSerie.Visible = false;
                        m_MultiView.MultiViewFigur.Visible = false;
                        break;
                    }
                case ETabActivity.Serie:
                    {
                        m_MultiView.MultiViewSerie.SetActiveView(m_MultiView.ViewSerieProperty);
                        m_MultiView.MultiViewSerie.Visible = true;
                        m_MultiView.MultiViewCategory.Visible = false;
                        m_MultiView.MultiViewFigur.Visible = false;
                        break;
                    }
                case ETabActivity.Figur:
                    {
                        m_MultiView.MultiViewFigur.SetActiveView(m_MultiView.ViewFigurProperty);
                        m_MultiView.MultiViewFigur.Visible = true;
                        m_MultiView.MultiViewCategory.Visible = false;
                        m_MultiView.MultiViewSerie.Visible = false;
                        break;
                    }
                case ETabActivity.None:
                    {
                        m_MultiView.MultiViewCategory.Visible = false;
                        m_MultiView.MultiViewSerie.Visible = false;
                        m_MultiView.MultiViewFigur.Visible = false;
                        break;
                    }
            }
        }
    }
}

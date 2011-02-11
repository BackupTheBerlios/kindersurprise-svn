using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Presenter
{
    public class UserControlPresenter
    {
        private readonly ICategoryControl m_CategoryControl;
        private readonly ISerieControl m_SerieControl;
        private readonly IFigurControl m_FigurControl;

        public UserControlPresenter(ICategoryControl categoryControl, ISerieControl serieControl, IFigurControl figurControl)
        {
            m_CategoryControl = categoryControl;
            m_SerieControl = serieControl;
            m_FigurControl = figurControl;
        }

        public void ActivateModeOneView(int objectId, ETabActivity tabActivity, EMode mode)
        {
            switch (tabActivity)
            {
                case ETabActivity.Category:
                    {
                        if (mode == EMode.View)
                        {
                            ICategoryService categoryService = ObjectFactory.GetInstance<ICategoryService>();
                            m_CategoryControl.Category = categoryService.GetById(objectId);
                            m_CategoryControl.InitializeViewMode();
                        }
                        else if(mode == EMode.New)
                        {
                            m_CategoryControl.InitializeEditMode();
                        }
                        break;
                    }
                case ETabActivity.Serie:
                    {
                        if (mode == EMode.View)
                        {
                            ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
                            m_SerieControl.Serie = serieService.GetById(objectId);
                            m_SerieControl.InitializeViewMode();
                        }
                        else if (mode == EMode.New)
                        {
                            m_SerieControl.InitializeEditMode();
                        }
                        break;
                    }
                case ETabActivity.Figur:
                    {
                        if (mode == EMode.View)
                        {
                            IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
                            m_FigurControl.Figur = figurService.GetById(objectId);
                            m_FigurControl.InitializeViewMode();
                        }
                        else if (mode == EMode.New)
                        {
                            m_FigurControl.InitializeEditMode();
                        }
                        break;
                    }
                case ETabActivity.None:
                    {
                        break;
                    }
            }
        }
    }
}

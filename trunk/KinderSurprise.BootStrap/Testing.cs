using KinderSurprise.DAL;
using KinderSurprise.DAL.Fake;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;

namespace KinderSurprise.BootStrap
{
	public static class Testing
     {
        public static void Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
				// register repository classes
                x.For<IInstructionsRepository>().Use<InstructionsRepository>();
				x.For<IFigurRepository>().Use<FigurRepository>();
				x.For<ICategoryRepository>().Use<FakeCategoryRepository>();
				x.For<IPictureRepository>().Use<PictureRepository>();
				x.For<ISerieRepository>().Use<SerieRepository>();
				
				// register model
				x.For<ICategoryService>().Use<CategoryService>();
				x.For<IFigurService>().Use<FigurService>();
				x.For<ISerieService>().Use<SerieService>();
				x.For<IValidator>().Use<Validator>();
            });
        }
    }
}


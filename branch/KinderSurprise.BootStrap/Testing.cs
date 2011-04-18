using KinderSurprise.Repository;
using KinderSurprise.RepositoryImpl.NHImpl;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;
using KinderSurprise.RepositoryImpl.Fake;
using Moq;

namespace KinderSurprise.BootStrap
{
	public static class Testing
     {
		private static Mock<ICategoryService> m_MockCategoryService;
		public static Mock<ICategoryService> MockCategoryService
		{
			get { return m_MockCategoryService; }
			private set { m_MockCategoryService = value; }
		}
		
        public static void Initialize()
        {
			InitMocks();
            ObjectFactory.Initialize(x =>
            {
				// register repository classes
                x.For<IInstructionsRepository>().Use<InstructionsRepository>();
				x.For<IFigurRepository>().Use<FigurRepository>();
				x.For<ICategoryRepository>().Use<FakeCategoryRepository>();
				x.For<IPictureRepository>().Use<PictureRepository>();
				x.For<ISerieRepository>().Use<SerieRepository>();
				
				// register model
				//x.For<ICategoryService>().Use<CategoryService>();
				x.For<ICategoryService>().Use(() => MockCategoryService.Object);
				x.For<IFigurService>().Use<FigurService>();
				x.For<ISerieService>().Use<SerieService>();
				x.For<IValidator>().Use<Validator>();
            });
        }
		
		public static void InitMocks()
		{
			MockCategoryService = new Mock<ICategoryService>();
		}
		
		public static void ResetMocks()
		{
			MockCategoryService = null;
		}
    }
}
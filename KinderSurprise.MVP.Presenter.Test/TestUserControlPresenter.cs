using KinderSurprise.DTO;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.MVP.Presenter.Test
{
	/*
    [TestFixture]
    class TestUserControlPresenter
    {
        private Mock<ICategoryControl> m_MockCategoryControl;
        private Mock<ISerieControl> m_MockSerieControl;
        private Mock<IFigurControl> m_MockFigurControl;

        [SetUp]
        public void Setup()
        {
            m_MockCategoryControl = new Mock<ICategoryControl>();
            m_MockCategoryControl.SetupAllProperties();
            m_MockSerieControl = new Mock<ISerieControl>();
            m_MockSerieControl.SetupAllProperties();
            m_MockFigurControl = new Mock<IFigurControl>();
            m_MockFigurControl.SetupAllProperties();
        }

        [Test]
        public void Test_NoneTabIsActivated_ModeIsView()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1,ETabActivity.None, EMode.View);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.CategoryDto);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.SerieDto);

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.FigurDto);
        }

        [Test]
        public void Test_NoneTabIsActivated_ModeIsNew()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.None, EMode.New);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.CategoryDto);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.SerieDto);

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.FigurDto);
        }

        [Test]
        public void Test_CategoryIsSelected_ModeIsView()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Category, EMode.View);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Times.Exactly(1));
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNotNull(m_MockCategoryControl.Object.CategoryDto);
            //ToDo verify content of dto

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.SerieDto);

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.FigurDto);
        }

        [Test]
        public void Test_CategoryIsSelected_ModeIsNew()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Category, EMode.New);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Times.Exactly(1));
            Assert.IsNull(m_MockCategoryControl.Object.CategoryDto);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.SerieDto);

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.FigurDto);
        }

        [Test]
        public void Test_SerieIsSelected_ModeIsView()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Serie, EMode.View);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.CategoryDto);
            
            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Times.Exactly(1));
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNotNull(m_MockSerieControl.Object.SerieDto);
            //ToDo verify content of dto

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.FigurDto);
        }

        [Test]
        public void Test_SerieIsSelected_ModeIsNew()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Serie, EMode.New);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.CategoryDto);
            
            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Times.Exactly(1));
            Assert.IsNull(m_MockSerieControl.Object.SerieDto);


            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.FigurDto);
        }

        [Test]
        public void Test_FigurIsSelected_ModeIsView()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Figur, EMode.View);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.CategoryDto);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.SerieDto);
            
            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Times.Exactly(1));
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNotNull(m_MockFigurControl.Object.FigurDto);
            //ToDo verify content of dto
        }

        [Test]
        public void Test_FigurIsSelected_ModeIsNew()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Figur, EMode.New);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.CategoryDto);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.SerieDto);


            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Times.Exactly(1));
            Assert.IsNull(m_MockFigurControl.Object.FigurDto);
        }
    }
    */
}

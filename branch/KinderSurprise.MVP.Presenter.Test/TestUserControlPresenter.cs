using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.MVP.Presenter.Test
{

    [TestFixture]
    public class TestUserControlPresenter
    {
        private Moq.Mock<ICategoryControl> m_MockCategoryControl;
        private Moq.Mock<ISerieControl> m_MockSerieControl;
        private Moq.Mock<IFigurControl> m_MockFigurControl;

        [SetUp]
        public void Setup()
        {
            m_MockCategoryControl = new Moq.Mock<ICategoryControl>();
            m_MockCategoryControl.SetupAllProperties();
            m_MockSerieControl = new Moq.Mock<ISerieControl>();
            m_MockSerieControl.SetupAllProperties();
            m_MockFigurControl = new Moq.Mock<IFigurControl>();
            m_MockFigurControl.SetupAllProperties();
        }

        [Test]
        public void Test_NoneTabIsActivated_ModeIsView()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1,ETabActivity.None, EMode.View);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.Category);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.Serie);

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.Figur);
        }

        [Test]
        public void Test_NoneTabIsActivated_ModeIsNew()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.None, EMode.New);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.Category);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.Serie);

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.Figur);
        }

        [Test]
        public void Test_CategoryIsSelected_ModeIsView()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Category, EMode.View);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Exactly(1));
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNotNull(m_MockCategoryControl.Object.Category);
            //ToDo verify content of dto

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.Serie);

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.Figur);
        }

        [Test]
        public void Test_CategoryIsSelected_ModeIsNew()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Category, EMode.New);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Exactly(1));
            Assert.IsNull(m_MockCategoryControl.Object.Category);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.Serie);

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.Figur);
        }

        [Test]
        public void Test_SerieIsSelected_ModeIsView()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Serie, EMode.View);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.Category);
            
            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Exactly(1));
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNotNull(m_MockSerieControl.Object.Serie);
            //ToDo verify content of dto

            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.Figur);
        }

        [Test]
        public void Test_SerieIsSelected_ModeIsNew()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Serie, EMode.New);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.Category);
            
            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Exactly(1));
            Assert.IsNull(m_MockSerieControl.Object.Serie);


            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockFigurControl.Object.Figur);
        }

        [Test]
        public void Test_FigurIsSelected_ModeIsView()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Figur, EMode.View);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.Category);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.Serie);
            
            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Exactly(1));
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNotNull(m_MockFigurControl.Object.Figur);
            //ToDo verify content of dto
        }

        [Test]
        public void Test_FigurIsSelected_ModeIsNew()
        {
            UserControlPresenter userControlPresenter = new UserControlPresenter(m_MockCategoryControl.Object,
                                                                                 m_MockSerieControl.Object,
                                                                                 m_MockFigurControl.Object);
            userControlPresenter.ActivateModeOneView(1, ETabActivity.Figur, EMode.New);

            m_MockCategoryControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockCategoryControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockCategoryControl.Object.Category);

            m_MockSerieControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockSerieControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Never());
            Assert.IsNull(m_MockSerieControl.Object.Serie);


            m_MockFigurControl.Verify(mock => mock.InitializeViewMode(), Moq.Times.Never());
            m_MockFigurControl.Verify(mock => mock.InitializeEditMode(), Moq.Times.Exactly(1));
            Assert.IsNull(m_MockFigurControl.Object.Figur);
        }
    }
}

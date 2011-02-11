using System.Web.UI.WebControls;
using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.MVP.Presenter.Test
{
    [TestFixture]
    public class TestMultiViewPresenter
    {
		private IMultiView m_MockMultiView = null;
		
        #region MockObjectWithInitializationAndDispose
        [SetUp]
        public void Setup()
        {
            Moq.Mock<IMultiView> mockMultiView = new Moq.Mock<IMultiView>();
            mockMultiView.SetupAllProperties();
			m_MockMultiView = mockMultiView.Object;
			m_MockMultiView.MultiViewCategory = new MultiView();
			m_MockMultiView.MultiViewFigur = new MultiView();
			m_MockMultiView.MultiViewSerie = new MultiView();
			m_MockMultiView.ViewCategoryProperty = new View();
			m_MockMultiView.ViewFigurProperty = new View();
			m_MockMultiView.ViewFigurStore = new View();
			m_MockMultiView.ViewSerieProperty = new View();
			m_MockMultiView.ViewSerieStore = new View();
			m_MockMultiView.MultiViewCategory.Views.Add(m_MockMultiView.ViewCategoryProperty);
            m_MockMultiView.MultiViewSerie.Views.Add(m_MockMultiView.ViewSerieProperty);
            m_MockMultiView.MultiViewSerie.Views.Add(m_MockMultiView.ViewSerieStore);
            m_MockMultiView.MultiViewFigur.Views.Add(m_MockMultiView.ViewFigurProperty);
            m_MockMultiView.MultiViewFigur.Views.Add(m_MockMultiView.ViewFigurStore);
        }

        [TearDown]
        public void Teardown()
        {
            m_MockMultiView = null;
        }

		#endregion
        
        [Test]
        public void Test_SetViewActive_None()
        {
            MultiViewPresenter multiViewPresenter = new MultiViewPresenter(m_MockMultiView);
            multiViewPresenter.ActivateView(ETabActivity.None);

            Assert.IsFalse(m_MockMultiView.MultiViewCategory.Visible);
            Assert.IsFalse(m_MockMultiView.MultiViewSerie.Visible);
            Assert.IsFalse(m_MockMultiView.MultiViewFigur.Visible);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewCategory.ActiveViewIndex);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewSerie.ActiveViewIndex);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewFigur.ActiveViewIndex);
        }

        [Test]
        public void Test_SetViewActive_Category()
        {
            MultiViewPresenter multiViewPresenter = new MultiViewPresenter(m_MockMultiView);
            multiViewPresenter.ActivateView(ETabActivity.Category);

            Assert.IsTrue(m_MockMultiView.MultiViewCategory.Visible);
            Assert.IsFalse(m_MockMultiView.MultiViewSerie.Visible);
            Assert.IsFalse(m_MockMultiView.MultiViewFigur.Visible);
            Assert.AreEqual(0, m_MockMultiView.MultiViewCategory.ActiveViewIndex);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewSerie.ActiveViewIndex);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewFigur.ActiveViewIndex);
        }

        [Test]
        public void Test_SetViewActive_Serie()
        {
            MultiViewPresenter multiViewPresenter = new MultiViewPresenter(m_MockMultiView);
            multiViewPresenter.ActivateView(ETabActivity.Serie);

            Assert.IsFalse(m_MockMultiView.MultiViewCategory.Visible);
            Assert.IsTrue(m_MockMultiView.MultiViewSerie.Visible);
            Assert.IsFalse(m_MockMultiView.MultiViewFigur.Visible);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewCategory.ActiveViewIndex);
            Assert.AreEqual(0, m_MockMultiView.MultiViewSerie.ActiveViewIndex);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewFigur.ActiveViewIndex);
        }

        [Test]
        public void Test_SetViewActive_Figur()
        {
            MultiViewPresenter multiViewPresenter = new MultiViewPresenter(m_MockMultiView);
            multiViewPresenter.ActivateView(ETabActivity.Figur);

            Assert.IsFalse(m_MockMultiView.MultiViewCategory.Visible);
            Assert.IsFalse(m_MockMultiView.MultiViewSerie.Visible);
            Assert.IsTrue(m_MockMultiView.MultiViewFigur.Visible);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewCategory.ActiveViewIndex);
            Assert.AreEqual(-1, m_MockMultiView.MultiViewSerie.ActiveViewIndex);
            Assert.AreEqual(0, m_MockMultiView.MultiViewFigur.ActiveViewIndex);
        }
    }
}
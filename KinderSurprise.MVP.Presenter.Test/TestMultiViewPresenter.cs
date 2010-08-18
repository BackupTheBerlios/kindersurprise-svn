using System.Web.UI.WebControls;
using KinderSurprise.DTO;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.MVP.Presenter.Test
{
    [TestFixture]
    public class TestMultiViewPresenter
    {

        #region MockObjectWithInitializationAndDispose
        [SetUp]
        public void Setup()
        {
            m_MockMultiView = new MockMultiView();
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

        

        private class MockMultiView : IMultiView
        {
            private MultiView m_MVCategory = new MultiView();
            public MultiView MultiViewCategory
            {
                get { return m_MVCategory; }
                set { MultiViewCategory = m_MVCategory; }
            }

            private View m_ViewCategporyProperty = new View();
            public View ViewCategoryProperty
            {
                get { return m_ViewCategporyProperty;}
                set { ViewCategoryProperty = m_ViewCategporyProperty; }
            }

            private MultiView m_MVSerie = new MultiView();
            public MultiView MultiViewSerie
            {
                get { return m_MVSerie; }
                set { MultiViewSerie = m_MVSerie; }
            }

            private View m_ViewSerieProperty = new View();
            public View ViewSerieProperty
            {
                get { return m_ViewSerieProperty; }
                set { ViewSerieProperty = m_ViewSerieProperty; }
            }

            private View m_ViewSerieStore = new View();
            public View ViewSerieStore
            {
                get { return m_ViewSerieStore; }
                set { ViewSerieStore = m_ViewSerieStore; }
            }

            private MultiView m_MVFigur = new MultiView();
            public MultiView MultiViewFigur
            {
                get { return m_MVFigur; }
                set { MultiViewFigur = m_MVFigur; }
            }

            private View m_ViewFigureProperty = new View();
            public View ViewFigurProperty
            {
                get { return m_ViewFigureProperty; }
                set { ViewFigurProperty = m_ViewFigureProperty; }
            }

            private View m_ViewFigureStore = new View();
            public View ViewFigurStore
            {
                get { return m_ViewFigureStore; }
                set { ViewFigurStore = m_ViewFigureStore; }
            }
        }

        private MockMultiView m_MockMultiView;

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

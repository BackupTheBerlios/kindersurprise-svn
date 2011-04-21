using System.Web.UI.WebControls;
using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter.Interfaces;
using KinderSurprise.MVP.Presenter.Test;
using NUnit.Framework;


namespace KinderSurprise.MVP.Presenter.TestMultiViewPresenter
{
	[TestFixture]
	public class WhenSettingViewWithoutActiveTab : PresenterFixture
	{
		private MultiViewPresenter m_MultiViewPresenter;
		private ETabActivity m_ActiveTab;
		
		protected override void Context()
		{
			m_MultiViewPresenter = new MultiViewPresenter(MockMultiView);
			m_ActiveTab = ETabActivity.None;
		}
		
		protected override void Because()
		{
			m_MultiViewPresenter.ActivateView(m_ActiveTab);
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void AllViewsShouldBeInvisible()
		{
			Assert.IsFalse(MockMultiView.MultiViewCategory.Visible);
            Assert.IsFalse(MockMultiView.MultiViewSerie.Visible);
            Assert.IsFalse(MockMultiView.MultiViewFigur.Visible);
		}
		
		[Test]
		public void NoActiveIndexShouldBeSet()
		{
			Assert.AreEqual(-1, MockMultiView.MultiViewCategory.ActiveViewIndex);
            Assert.AreEqual(-1, MockMultiView.MultiViewSerie.ActiveViewIndex);
            Assert.AreEqual(-1, MockMultiView.MultiViewFigur.ActiveViewIndex);
		}
	}
	
	[TestFixture]
	public class WhenSettingViewWithActiveCategory : PresenterFixture
	{
		private MultiViewPresenter m_MultiViewPresenter;
		private ETabActivity m_ActiveTab;
		
		protected override void Context()
		{
			m_MultiViewPresenter = new MultiViewPresenter(MockMultiView);
			m_ActiveTab = ETabActivity.Category;
		}
		
		protected override void Because()
		{
			m_MultiViewPresenter.ActivateView(m_ActiveTab);
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void OnlyCategoryShouldBeVisible()
		{
			Assert.IsTrue(MockMultiView.MultiViewCategory.Visible);
            Assert.IsFalse(MockMultiView.MultiViewSerie.Visible);
            Assert.IsFalse(MockMultiView.MultiViewFigur.Visible);
		}
		
		[Test]
		public void CategoryViewShouldHaveActiveIndex()
		{
			Assert.AreEqual(0, MockMultiView.MultiViewCategory.ActiveViewIndex);
            Assert.AreEqual(-1, MockMultiView.MultiViewSerie.ActiveViewIndex);
            Assert.AreEqual(-1, MockMultiView.MultiViewFigur.ActiveViewIndex);
		}
	}

	[TestFixture]
	public class WhenSettingViewWithActiveSerie : PresenterFixture
	{
		private MultiViewPresenter m_MultiViewPresenter;
		private ETabActivity m_ActiveTab;
		
		protected override void Context()
		{
			m_MultiViewPresenter = new MultiViewPresenter(MockMultiView);
			m_ActiveTab = ETabActivity.Serie;
		}
		
		protected override void Because()
		{
			m_MultiViewPresenter.ActivateView(m_ActiveTab);
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void OnlySerieShouldBeVisible()
		{
			Assert.IsFalse(MockMultiView.MultiViewCategory.Visible);
            Assert.IsTrue(MockMultiView.MultiViewSerie.Visible);
            Assert.IsFalse(MockMultiView.MultiViewFigur.Visible);
		}
		
		[Test]
		public void SerieViewShouldHaveActiveIndex()
		{
			Assert.AreEqual(-1, MockMultiView.MultiViewCategory.ActiveViewIndex);
            Assert.AreEqual(0, MockMultiView.MultiViewSerie.ActiveViewIndex);
            Assert.AreEqual(-1, MockMultiView.MultiViewFigur.ActiveViewIndex);
		}
	}

	[TestFixture]
	public class WhenSettingViewWithActiveFigur : PresenterFixture
	{
		private MultiViewPresenter m_MultiViewPresenter;
		private ETabActivity m_ActiveTab;
		
		protected override void Context()
		{
			m_MultiViewPresenter = new MultiViewPresenter(MockMultiView);
			m_ActiveTab = ETabActivity.Figur;
		}
		
		protected override void Because()
		{
			m_MultiViewPresenter.ActivateView(m_ActiveTab);
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void OnlySerieShouldBeVisible()
		{
			Assert.IsFalse(MockMultiView.MultiViewCategory.Visible);
            Assert.IsFalse(MockMultiView.MultiViewSerie.Visible);
            Assert.IsTrue(MockMultiView.MultiViewFigur.Visible);
		}
		
		[Test]
		public void SerieViewShouldHaveActiveIndex()
		{
			Assert.AreEqual(-1, MockMultiView.MultiViewCategory.ActiveViewIndex);
            Assert.AreEqual(-1, MockMultiView.MultiViewSerie.ActiveViewIndex);
            Assert.AreEqual(0, MockMultiView.MultiViewFigur.ActiveViewIndex);
		}
    }
}
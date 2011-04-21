using System.Web.UI.WebControls;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using KinderSurprise.MVP.Presenter.Test;

namespace KinderSurprise.MVP.Presenter.TestTreeViewPresenter
{
	[TestFixture]
	public class WhenBindingData : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});			
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.FillTreeView();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldBindTheDataCorrectly()
		{
			Assert.IsNotNull(MockTreeView.OverviewTreeView);
            Assert.AreEqual(3, MockTreeView.OverviewTreeView.Nodes.Count);
            Assert.AreEqual(2, MockTreeView.OverviewTreeView.Nodes[0].ChildNodes.Count);
            Assert.AreEqual(2, MockTreeView.OverviewTreeView.Nodes[0].ChildNodes[0].ChildNodes.Count);
		}
		
		[Test]
		public void ShouldCallTheServices()
		{
		}
	}
	
	[TestFixture]
	public class WhenCheckingSelectionIfNothingIsSelected : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});			
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.FillTreeView();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void NothingShouldBeSelected()
		{
			Assert.AreEqual(0, m_TreeViewPresenter.GetSelectedNodeId());
		}
		
		[Test]
		public void GetTheNoneTabActivity()
		{
			Assert.AreEqual(ETabActivity.None, m_TreeViewPresenter.GetSelectedNodeDepth());
		}
	}
	
	[TestFixture]
	public class WhenCheckingSelectionIfCategoryIsSelected : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.FillTreeView();
			MockTreeView.OverviewTreeView.Nodes[0].Selected = true;
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void CategoryShouldBeSelected()
		{
			Assert.AreEqual(1, m_TreeViewPresenter.GetSelectedNodeId());
		}
		
		[Test]
		public void GetTheCategoryTabActivity()
		{
			Assert.AreEqual(ETabActivity.Category, m_TreeViewPresenter.GetSelectedNodeDepth());
		}
	}
	
	[TestFixture]
	public class WhenCheckingSelectionIfSerieIsSelected : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.FillTreeView();
			MockTreeView.OverviewTreeView.Nodes[0].ChildNodes[0].Selected = true;
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void GetFirstNodeId()
		{
			Assert.AreEqual(1, m_TreeViewPresenter.GetSelectedNodeId());
		}
		
		[Test]
		public void GetTheSerieTabActivity()
		{
			Assert.AreEqual(ETabActivity.Serie, m_TreeViewPresenter.GetSelectedNodeDepth());
		}
	}
	
	[TestFixture]
	public class WhenCheckingSelectionIfFigurIsSelected : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.FillTreeView();
			MockTreeView.OverviewTreeView.Nodes[0].ChildNodes[0].ChildNodes[0].Selected = true;
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void GetFirstNodeId()
		{
			Assert.AreEqual(1, m_TreeViewPresenter.GetSelectedNodeId());
		}
		
		[Test]
		public void GetTheFigurTabActivity()
		{
			Assert.AreEqual(ETabActivity.Figur, m_TreeViewPresenter.GetSelectedNodeDepth());
		}
	}
	
	[TestFixture]
	public class WhenClearingEmptyTreeView : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.ClearTreeView();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldContainNoElements()
		{
			Assert.AreEqual(0, MockTreeView.OverviewTreeView.Nodes.Count);
		}
	}
	
	[TestFixture]
	public class WhenClearingFilledTreeView : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});
			m_TreeViewPresenter.FillTreeView();
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.ClearTreeView();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void ShouldContainNoElements()
		{
			Assert.AreEqual(0, MockTreeView.OverviewTreeView.Nodes.Count);
		}
	}
	
	[TestFixture]
	public class WhenSettingMultiViewWithNoneSelection : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		private ETabActivity m_ActiveMenu;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});
			m_ActiveMenu = m_TreeViewPresenter.GetSelectedNodeDepth();
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.ClearTreeView();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void SelectionShouldBeNone()
		{
			Assert.AreEqual(ETabActivity.None, m_ActiveMenu);
		}
		
		[Test]
		public void MenuShouldBeInvisible()
		{
			Assert.IsFalse(MockTreeView.Menu.Visible);
		}
	}
	
	[TestFixture]
	public class WhenSettingMultiViewWithCategorySelection : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		private ETabActivity m_ActiveMenu;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});
			m_TreeViewPresenter.FillTreeView();
			MockTreeView.OverviewTreeView.Nodes[0].Selected = true;
			m_ActiveMenu = m_TreeViewPresenter.GetSelectedNodeDepth();
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.ClearTreeView();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void SelectionShouldBeCategory()
		{
			Assert.AreEqual(ETabActivity.Category, m_ActiveMenu);
		}
		
		[Test]
		public void MenuShouldBeVisible()
		{
			Assert.IsTrue(MockTreeView.Menu.Visible);
		}
		
		[Test]
		public void OnlyPropertyMenuItemShouldBeVisible()
		{
			Assert.IsTrue(MockTreeView.Menu.Items[(int)EMenuItem.Property].Enabled);
			Assert.IsFalse(MockTreeView.Menu.Items[(int)EMenuItem.Store].Enabled);
		}
	}
	
	[TestFixture]
	public class WhenSettingMultiViewWithSerieSelection : PresenterFixture
	{
		private TreeViewPresenter m_TreeViewPresenter;
		private ETabActivity m_ActiveMenu;
		
		protected override void Context()
		{
			m_TreeViewPresenter = new TreeViewPresenter(MockTreeView);
			Testing.MockCategoryService.Setup(x => x.GetAll())
				.Returns(new List<Category> { 
					new Category { Id = 1 }, 
					new Category { Id = 2 }, 
					new Category { Id = 3 }});
			m_TreeViewPresenter.FillTreeView();
			MockTreeView.OverviewTreeView.Nodes[0].ChildNodes[0].Selected = true;
			m_ActiveMenu = m_TreeViewPresenter.GetSelectedNodeDepth();
		}
		
		protected override void Because()
		{
			m_TreeViewPresenter.ClearTreeView();
		}
		
		protected override void TearDownContext()
		{}
		
		[Test]
		public void SelectionShouldBeCategory()
		{
			Assert.AreEqual(ETabActivity.Serie, m_ActiveMenu);
		}
		
		[Test]
		public void MenuShouldBeVisible()
		{
			Assert.IsTrue(MockTreeView.Menu.Visible);
		}
		
		[Test]
		public void OnlyPropertyMenuItemShouldBeVisible()
		{
			Assert.IsTrue(MockTreeView.Menu.Items[(int)EMenuItem.Property].Enabled);
			Assert.IsFalse(MockTreeView.Menu.Items[(int)EMenuItem.Store].Enabled);
		}
	}
	
//    [TestFixture]
//    public class TestTreeViewPresenter
//    {
//        [Test]
//        public void Test_GetActiveMultiMenu_FigurIsChoosen()
//        {
//            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
//            m_TreeViewPresenter.FillTreeView();
//            m_TreeView.OverviewTreeView.Nodes[0].ChildNodes[0].ChildNodes[0].Selected = true;
//
//            var activMenu = m_TreeViewPresenter.GetSelectedNodeDepth();
//
//            Assert.AreEqual(ETabActivity.Figur, activMenu);
//            Assert.IsTrue(m_TreeView.Menu.Visible);
//            Assert.IsTrue(m_TreeView.Menu.Items[(int)EMenuItem.Property].Enabled);
//            Assert.IsFalse(m_TreeView.Menu.Items[(int)EMenuItem.Store].Enabled);
//        }
//    }
}

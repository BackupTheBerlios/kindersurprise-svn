using System.Web.UI.WebControls;
using KinderSurprise.BootStrap;
using KinderSurprise.Model;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.MVP.Presenter.Test
{
    [TestFixture]
    public class TestTreeViewPresenter
    {
        #region MockObjectWithInitializationAndDispose

		private ITreeView m_TreeView;
		
        [SetUp]
        public void Setup()
        {
            Testing.Initialize();
			Moq.Mock<ITreeView> m_MockTreeView = new Moq.Mock<ITreeView>();
			m_MockTreeView.SetupAllProperties();
			m_TreeView = m_MockTreeView.Object;
			m_TreeView.Menu = new Menu();
			m_TreeView.OverviewTreeView = new TreeView();
            m_TreeView.Menu.Items.Add(new MenuItem("Eigenschaft", "1"));
            m_TreeView.Menu.Items.Add(new MenuItem("Lager", "2"));
        }

        [TearDown]
        public void Teardown()
        {
            m_TreeView = null;
        }

        #endregion

        [Test]
        public void Test_DataBind()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();

            Assert.IsNotNull(m_TreeView.OverviewTreeView);


            Assert.AreEqual(3, m_TreeView.OverviewTreeView.Nodes.Count);
            Assert.AreEqual(2, m_TreeView.OverviewTreeView.Nodes[0].ChildNodes.Count);
            Assert.AreEqual(2, m_TreeView.OverviewTreeView.Nodes[0].ChildNodes[0].ChildNodes.Count);
        }

        [Test]
        public void Test_GetSelectedNodeDepth_NoneSelected()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();
            
            Assert.AreEqual(ETabActivity.None,m_TreeViewPresenter.GetSelectedNodeDepth());
            Assert.AreEqual(0, m_TreeViewPresenter.GetSelectedNodeId());
        }

        [Test]
        public void Test_GetSelectedNodeDepth_CategorySelected()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();
			m_TreeView.OverviewTreeView.Nodes[0].Selected = true;
            
            Assert.AreEqual(ETabActivity.Category, m_TreeViewPresenter.GetSelectedNodeDepth());
            Assert.AreEqual(1, m_TreeViewPresenter.GetSelectedNodeId());
        }

        [Test]
        public void Test_GetSelectedNodeDepth_SerieSelected()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();
            m_TreeView.OverviewTreeView.Nodes[0].ChildNodes[0].Selected = true;
            
            Assert.AreEqual(ETabActivity.Serie, m_TreeViewPresenter.GetSelectedNodeDepth());
            Assert.AreEqual(1, m_TreeViewPresenter.GetSelectedNodeId());
        }

        [Test]
        public void Test_GetSelectedNodeDepth_FigurSelected()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();
            m_TreeView.OverviewTreeView.Nodes[0].ChildNodes[0].ChildNodes[0].Selected = true;
            
            Assert.AreEqual(ETabActivity.Figur, m_TreeViewPresenter.GetSelectedNodeDepth());
            Assert.AreEqual(1, m_TreeViewPresenter.GetSelectedNodeId());
        }

        [Test]
        public void Test_ClearEmptyTreeOverview()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.ClearTreeView();
            
            Assert.AreEqual(0, m_TreeView.OverviewTreeView.Nodes.Count);
        }

        [Test]
        public void Test_ClearFilledTreeOverview()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();
            m_TreeViewPresenter.ClearTreeView();

            Assert.AreEqual(0, m_TreeView.OverviewTreeView.Nodes.Count);
        }

        [Test]
        public void Test_GetActiveMultiMenu_NoneIsChoosen()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            
            var activMenu = m_TreeViewPresenter.GetSelectedNodeDepth();

            Assert.AreEqual(ETabActivity.None, activMenu);
            Assert.IsFalse(m_TreeView.Menu.Visible);
        }

        [Test]
        public void Test_GetActiveMultiMenu_CategoryIsChoosen()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();
            m_TreeView.OverviewTreeView.Nodes[0].Selected = true;

            var activMenu = m_TreeViewPresenter.GetSelectedNodeDepth();

            Assert.AreEqual(ETabActivity.Category, activMenu);
            Assert.IsTrue(m_TreeView.Menu.Visible);
            Assert.IsTrue(m_TreeView.Menu.Items[(int)EMenuItem.Property].Enabled);
            Assert.IsFalse(m_TreeView.Menu.Items[(int)EMenuItem.Store].Enabled);
        }

        [Test]
        public void Test_GetActiveMultiMenu_SerieIsChoosen()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();
            m_TreeView.OverviewTreeView.Nodes[0].ChildNodes[0].Selected = true;

            var activMenu = m_TreeViewPresenter.GetSelectedNodeDepth();

            Assert.AreEqual(ETabActivity.Serie, activMenu);
            Assert.IsTrue(m_TreeView.Menu.Visible);
            Assert.IsTrue(m_TreeView.Menu.Items[(int)EMenuItem.Property].Enabled);
            Assert.IsFalse(m_TreeView.Menu.Items[(int)EMenuItem.Store].Enabled);
        }

        [Test]
        public void Test_GetActiveMultiMenu_FigurIsChoosen()
        {
            TreeViewPresenter m_TreeViewPresenter = new TreeViewPresenter(m_TreeView);
            m_TreeViewPresenter.FillTreeView();
            m_TreeView.OverviewTreeView.Nodes[0].ChildNodes[0].ChildNodes[0].Selected = true;

            var activMenu = m_TreeViewPresenter.GetSelectedNodeDepth();

            Assert.AreEqual(ETabActivity.Figur, activMenu);
            Assert.IsTrue(m_TreeView.Menu.Visible);
            Assert.IsTrue(m_TreeView.Menu.Items[(int)EMenuItem.Property].Enabled);
            Assert.IsFalse(m_TreeView.Menu.Items[(int)EMenuItem.Store].Enabled);
        }
    }
}

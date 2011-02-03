using System;
using System.Web.UI.WebControls;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;

namespace KinderSurprise.MVP.Presenter
{
    public class TreeViewPresenter
    {
        private readonly ITreeView m_TreeView;

        public TreeViewPresenter(ITreeView treeView)
        {
            m_TreeView = treeView;
        }

        public void ClearTreeView()
        {
            m_TreeView.OverviewTreeView.Nodes.Clear();
        }

        public ETabActivity GetSelectedNodeDepth()
        {
            int selectedNode = -1;
            m_TreeView.Menu.Visible = true;

            if (m_TreeView.OverviewTreeView.SelectedNode != null)
                selectedNode = m_TreeView.OverviewTreeView.SelectedNode.Depth;

            switch (selectedNode)
            {
                case 0:
                    {
                        m_TreeView.Menu.Items[(int)EMenuItem.Store].Enabled = false;
                        return ETabActivity.Category;
                    }
                case 1:
                    {
                        m_TreeView.Menu.Items[(int)EMenuItem.Store].Enabled = false;
                        return ETabActivity.Serie;
                    }
                case 2:
                    {
                        m_TreeView.Menu.Items[(int)EMenuItem.Store].Enabled = false;
                        return ETabActivity.Figur;
                    }
                default:
                    {
                        m_TreeView.Menu.Visible = false;
                        return ETabActivity.None;
                    }
            }

        }

        public int GetSelectedNodeId()
        {
            return m_TreeView.OverviewTreeView.SelectedNode == null
                       ? 0
                       : Convert.ToInt32(m_TreeView.OverviewTreeView.SelectedNode.Value);
        }

        public void FillTreeView()
        {
            ICategoryService categoryService = new CategoryService();
            ISerieService serieService = new SerieService();
            IFigurService figurService = new FigurService();

            var categories = categoryService.GetAll();
            if(categories.Count == 0)
                categories.Add(new Category { CategoryId = 0, CategoryName = "dummy", Description = "dummy" });
            
            foreach (var categoryDto in categories)
            {
                TreeNode nodeCategory = new TreeNode
                                            {
                                                Text = categoryDto.CategoryName,
                                                ToolTip = categoryDto.Description,
                                                Value = categoryDto.CategoryId.ToString()
                                            };
                foreach (var serieDto in serieService.GetAllByCategoryId(categoryDto.CategoryId))
                {
                    TreeNode nodeSerie = new TreeNode
                                             {
                                                 Text = serieDto.SerieName,
                                                 ToolTip = serieDto.Description,
                                                 Value = serieDto.SerieId.ToString()
                                             };
                    nodeCategory.ChildNodes.Add(nodeSerie);

                    foreach (var figurDto in figurService.GetAllBySerieId(serieDto.SerieId))
                    {
                        TreeNode nodeFigur = new TreeNode
                                                 {
                                                     Text = figurDto.FigurName,
                                                     ToolTip = figurDto.Description,
                                                     Value = figurDto.FigurId.ToString()
                                                 };
                        nodeSerie.ChildNodes.Add(nodeFigur);
                    }
                }
                m_TreeView.OverviewTreeView.Nodes.Add(nodeCategory);
            }
        }
    }
}

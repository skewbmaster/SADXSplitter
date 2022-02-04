using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LiveSplit.ASL;

namespace SADXSplitter
{
    public partial class SADXSettings
    {
        private void UpdateCustomSettingsVisibility()
        {
            bool show = this.settingsTree.GetNodeCount(false) > 0;
            this.settingsTree.Visible = show;
        }
        
        private void UpdateGrayedOut(TreeNode node)
        {
            // Only change color of childnodes if this node isn't already grayed out
            if (node.ForeColor != SystemColors.GrayText)
            {
                UpdateNodesInTree(n =>
                {
                    n.ForeColor = node.Checked ? SystemColors.WindowText : SystemColors.GrayText;
                    return n.Checked || !node.Checked;
                }, node.Nodes);
            }
        }
        
        private void UpdateNodesCheckedState(IReadOnlyDictionary<string, bool> settingValues, TreeNodeCollection nodes = null)
        {
            if (settingValues == null)
                return;

            UpdateNodesCheckedState(setting =>
            {
                var id = setting.Id;

                return settingValues.ContainsKey(id) ? settingValues[id] : setting.Value;
            }, nodes);
        }
        
        private void UpdateNodesCheckedState(Func<ASLSetting, bool> func, TreeNodeCollection nodes = null)
        {
            if (nodes == null)
                nodes = this.settingsTree.Nodes;

            UpdateNodesInTree(node =>
            {
                var setting = (ASLSetting) node.Tag;
                bool check = func(setting);

                if (node.Checked != check)
                    node.Checked = check;

                return true;
            }, nodes);
        }
        
        private static void UpdateNodesInTree(Func<TreeNode, bool> func, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                bool includeChildNodes = func(node);
                if (includeChildNodes)
                    UpdateNodesInTree(func, node.Nodes);
            }
        }
        
        private static void UpdateNodeCheckedState(Func<ASLSetting, bool> func, TreeNode node)
        {
            var setting = (ASLSetting) node.Tag;
            bool check = func(setting);

            if (node.Checked != check)
                node.Checked = check;
        }
        
        // Extra stuff for context menus
        #region settings Tree Logic
        private void settingsTree_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = e.Node.ForeColor == SystemColors.GrayText;
        }
        private void settingsTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var setting = (ASLSetting) e.Node.Tag;
            setting.Value = e.Node.Checked;
            state[setting.Id] = setting.Value;
            
            UpdateGrayedOut(e.Node);
        }
        private void settingsTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Select clicked node (not only with left-click) for use with context menu
            this.settingsTree.SelectedNode = e.Node;
        }
        #endregion
        #region Context Menu Overall
        private void cmiExpandTree_Click(object sender, EventArgs e)
        {
            this.settingsTree.ExpandAll();
            this.settingsTree.SelectedNode.EnsureVisible();
        }
        private void cmiCollapseTree_Click(object sender, EventArgs e)
        {
            this.settingsTree.CollapseAll();
        }
        private void cmiCollapseTreeToSelection_Click(object sender, EventArgs e)
        {
            TreeNode selected = this.settingsTree.SelectedNode;
            this.settingsTree.CollapseAll();
            this.settingsTree.SelectedNode = selected;
            selected.EnsureVisible();
        }
        private void cmiExpandBranch_Click(object sender, EventArgs e)
        {
            this.settingsTree.SelectedNode.ExpandAll();
            this.settingsTree.SelectedNode.EnsureVisible();
        }
        private void cmiCollapseBranch_Click(object sender, EventArgs e)
        {
            this.settingsTree.SelectedNode.Collapse();
            this.settingsTree.SelectedNode.EnsureVisible();
        }
        private void cmiCheckBranch_Click(object sender, EventArgs e)
        {
            UpdateNodesCheckedState(s => true, this.settingsTree.SelectedNode.Nodes);
            UpdateNodeCheckedState(s => true, this.settingsTree.SelectedNode);
        }
        private void cmiUncheckBranch_Click(object sender, EventArgs e)
        {
            UpdateNodesCheckedState(s => false, this.settingsTree.SelectedNode.Nodes);
            UpdateNodeCheckedState(s => false, this.settingsTree.SelectedNode);
        }
        private void cmiResetBranchToDefault_Click(object sender, EventArgs e)
        {
            UpdateNodesCheckedState(s => s.DefaultValue, this.settingsTree.SelectedNode.Nodes);
            UpdateNodeCheckedState(s => s.DefaultValue, this.settingsTree.SelectedNode);
        }
        private void cmiResetSettingToDefault_Click(object sender, EventArgs e)
        {
            UpdateNodeCheckedState(s => s.DefaultValue, this.settingsTree.SelectedNode);
        }
        #endregion
        
        // For turning double clicks into a single click
        class NewTreeView : TreeView
        {
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x203) // identified double click
                {
                    Point localPos = PointToClient(Cursor.Position);
                    TreeViewHitTestInfo hitTestInfo = HitTest(localPos);

                    if (hitTestInfo.Location == TreeViewHitTestLocations.StateImage)
                    {
                        m.Msg = 0x201; // if checkbox was clicked, turn into single click
                    }

                    base.WndProc(ref m);
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
        } 
    }
}
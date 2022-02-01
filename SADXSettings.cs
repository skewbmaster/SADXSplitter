using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;
using LiveSplit.ASL;
using LiveSplit.Model.Input;
using LiveSplit.Options;
using LiveSplit.Web;

namespace SADXSplitter
{
    public partial class SADXSettings : UserControl
    {
        public SADXSettings()
        {
            InitializeComponent();
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

        private void SADXSettings_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void settingsTree_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void settingsTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var setting = (ASLSetting) e.Node.Tag;
            setting.Value = e.Node.Checked;
            
            UpdateGrayedOut(e.Node);
        }
    }
}
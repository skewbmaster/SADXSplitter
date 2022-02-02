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
        public bool start;
        public bool split;
        public bool reset;
        
        private Dictionary<string, bool> state;
        public ASLSettings settings;
        
        public SADXSettings()
        {
            InitializeComponent();
        }

        public void InitASLSettings(ASLSettings settings)
        {
            this.settings = settings;
            
            this.settingsTree.BeginUpdate();
            this.settingsTree.Nodes.Clear();

            var values = new Dictionary<string, bool>();
            var flat = new Dictionary<string, TreeNode>();

            foreach (var setting in settings.OrderedSettings)
            {
                bool value = setting.Value;


                TreeNode node = new TreeNode
                {
                    Text = setting.Label,
                    Tag = setting,
                    Checked = value,
                    //ContextMenuStrip = ,
                    ToolTipText = setting.ToolTip
                };
                setting.Value = value;

                if (setting.Parent == null)
                {
                    this.settingsTree.Nodes.Add(node);
                }
                else if (flat.ContainsKey(setting.Parent))
                {
                    flat[setting.Parent].Nodes.Add(node);
                    //flat[setting.Parent].ContextMenuStrip = this.treeContextMenu;
                }
                
                flat.Add(setting.Id, node);
                values.Add(setting.Id, value);
            }

            foreach (var node in flat.Where(item => !item.Value.Checked))
            {
                UpdateGrayedOut(node.Value);
            }

            state = values;
            
            settingsTree.ExpandAll();
            settingsTree.EndUpdate();

            if (this.settingsTree.Nodes.Count > 0)
            {
                this.settingsTree.Nodes[0].EnsureVisible();
            }

            UpdateCustomSettingsVisibility();
        }
        
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

        private void SADXSettings_Load(object sender, EventArgs e)
        {
            
        }

        private void settingsTree_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            
        }

        private void settingsTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var setting = (ASLSetting) e.Node.Tag;
            setting.Value = e.Node.Checked;
            
            UpdateGrayedOut(e.Node);
        }
    }
}
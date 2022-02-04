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
        public bool startOption { get; set; }
        public bool splitOption { get; set; }
        public bool resetOption { get; set; }
        
        private Dictionary<string, bool> state;
        private ASLSettings settings;
        
        public SADXSettings()
        {
            InitializeComponent();

            startOption = true;
            splitOption = true;
            resetOption = false;
        }

        public void InitAslSettings(ASLSettings aslSettings)
        {
            this.settings = aslSettings;
            
            this.settingsTree.BeginUpdate();
            this.settingsTree.Nodes.Clear();

            var values = new Dictionary<string, bool>();
            var flat = new Dictionary<string, TreeNode>();

            foreach (ASLSetting setting in settings.OrderedSettings)
            {
                bool value = setting.Value;


                TreeNode node = new TreeNode
                {
                    Text = setting.Label,
                    Tag = setting,
                    Checked = value,
                    ContextMenuStrip = this.treeContextMenuSmall,
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
                    flat[setting.Parent].ContextMenuStrip = this.treeContextMenu;
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
        
        private void SADXSettings_Load(object sender, EventArgs e)
        {
            startCheckBox.DataBindings.Clear();
            splitCheckBox.DataBindings.Clear();
            resetCheckBox.DataBindings.Clear();
            
            startCheckBox.DataBindings.Add("Checked", this, "startOption", false, DataSourceUpdateMode.OnPropertyChanged);
            splitCheckBox.DataBindings.Add("Checked", this, "splitOption", false, DataSourceUpdateMode.OnPropertyChanged);
            resetCheckBox.DataBindings.Add("Checked", this, "resetOption", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        #region XML Settings Code
        public void SetSettings(XmlNode node)
        {
            XmlElement element = (XmlElement) node;

            if (element.IsEmpty) return;
            
            startOption = SettingsHelper.ParseBool(element["startOption"]);
            splitOption = SettingsHelper.ParseBool(element["splitOption"]);
            resetOption = SettingsHelper.ParseBool(element["resetOption"]);

            ParseSettingsFromXml(element);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement node = document.CreateElement("Settings");

            AppendSettingsToXml(document, node);
            SettingsHelper.CreateSetting(document, node, "startOption", startOption);
            SettingsHelper.CreateSetting(document, node, "splitOption", splitOption);
            SettingsHelper.CreateSetting(document, node, "resetOption", resetOption);

            return node;
        }
        
        private void AppendSettingsToXml(XmlDocument document, XmlNode parent)
        {
            XmlElement aslParent = document.CreateElement("CustomSettings");

            foreach (var setting in state)
            {
                XmlElement element = SettingsHelper.ToElement(document, "Setting", setting.Value);
                XmlAttribute id = SettingsHelper.ToAttribute(document, "id", setting.Key);
                // In case there are other setting types in the future
                XmlAttribute type = SettingsHelper.ToAttribute(document, "type", "bool");

                element.Attributes.Append(id);
                element.Attributes.Append(type);
                aslParent.AppendChild(element);
            }

            parent.AppendChild(aslParent);
        }
        
        private void ParseSettingsFromXml(XmlElement data)
        {
            XmlElement customSettingsNode = data["CustomSettings"];

            if (customSettingsNode != null && customSettingsNode.HasChildNodes)
            {
                foreach (XmlElement element in customSettingsNode.ChildNodes)
                {
                    if (element.Name != "Setting")
                        continue;

                    string id = element.Attributes["id"].Value;
                    string type = element.Attributes["type"].Value;

                    if (id == null || type != "bool") continue;
                    bool value = SettingsHelper.ParseBool(element);
                    state[id] = value;
                }
            }

            // Update tree with loaded state (in case the tree is already populated)
            UpdateNodesCheckedState(state);
        }
        #endregion
    }
}
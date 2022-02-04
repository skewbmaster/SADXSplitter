using System;
using System.ComponentModel;
using System.Security.AccessControl;

namespace SADXSplitter
{
    partial class SADXSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.settingsTree = new SADXSettings.NewTreeView();
            this.startCheckBox = new System.Windows.Forms.CheckBox();
            this.splitCheckBox = new System.Windows.Forms.CheckBox();
            this.resetCheckBox = new System.Windows.Forms.CheckBox();
            this.installSpeedrunModButton = new System.Windows.Forms.Button();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiExpandTree = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCollapseTree = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCollapseTreeToSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiExpandBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCollapseBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiCheckBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiUncheckBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiResetBranchToDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiResetSettingToDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.treeContextMenuSmall = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiExpandTree2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCollapseTree2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCollapseTreeToSelection2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiResetSettingToDefault2 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeContextMenu.SuspendLayout();
            this.treeContextMenuSmall.SuspendLayout();
            this.SuspendLayout();
            this.settingsTree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.settingsTree.CheckBoxes = true;
            this.settingsTree.Location = new System.Drawing.Point(19, 90);
            this.settingsTree.Name = "settingsTree";
            this.settingsTree.ShowNodeToolTips = true;
            this.settingsTree.Size = new System.Drawing.Size(445, 402);
            this.settingsTree.TabIndex = 0;
            this.settingsTree.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.settingsTree_BeforeCheck);
            this.settingsTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.settingsTree_AfterCheck);
            this.settingsTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.settingsTree_NodeMouseClick);
            this.startCheckBox.AutoSize = true;
            this.startCheckBox.Location = new System.Drawing.Point(20, 60);
            this.startCheckBox.Name = "startCheckBox";
            this.startCheckBox.Size = new System.Drawing.Size(48, 17);
            this.startCheckBox.TabIndex = 1;
            this.startCheckBox.Text = "Start";
            this.startCheckBox.UseVisualStyleBackColor = true;
            this.splitCheckBox.AutoSize = true;
            this.splitCheckBox.Location = new System.Drawing.Point(80, 60);
            this.splitCheckBox.Name = "splitCheckBox";
            this.splitCheckBox.Size = new System.Drawing.Size(46, 17);
            this.splitCheckBox.TabIndex = 2;
            this.splitCheckBox.Text = "Split";
            this.splitCheckBox.UseVisualStyleBackColor = true;
            this.resetCheckBox.AutoSize = true;
            this.resetCheckBox.Location = new System.Drawing.Point(140, 60);
            this.resetCheckBox.Name = "resetCheckBox";
            this.resetCheckBox.Size = new System.Drawing.Size(54, 17);
            this.resetCheckBox.TabIndex = 3;
            this.resetCheckBox.Text = "Reset";
            this.resetCheckBox.UseVisualStyleBackColor = true;
            this.installSpeedrunModButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.installSpeedrunModButton.AutoSize = true;
            this.installSpeedrunModButton.Location = new System.Drawing.Point(347, 44);
            this.installSpeedrunModButton.Name = "installSpeedrunModButton";
            this.installSpeedrunModButton.Size = new System.Drawing.Size(117, 33);
            this.installSpeedrunModButton.TabIndex = 4;
            this.installSpeedrunModButton.Text = "Install Speedrun Mod";
            this.installSpeedrunModButton.UseVisualStyleBackColor = true;
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.cmiExpandTree, this.cmiCollapseTree, this.cmiCollapseTreeToSelection, this.toolStripSeparator1, this.cmiExpandBranch, this.cmiCollapseBranch, this.toolStripSeparator2, this.cmiCheckBranch, this.cmiUncheckBranch, this.cmiResetBranchToDefault, this.toolStripSeparator3, this.cmiResetSettingToDefault});
            this.treeContextMenu.Name = "treeContextMenu";
            this.treeContextMenu.Size = new System.Drawing.Size(210, 220);
            this.cmiExpandTree.Name = "cmiExpandTree";
            this.cmiExpandTree.Size = new System.Drawing.Size(209, 22);
            this.cmiExpandTree.Text = "Expand Tree";
            this.cmiExpandTree.Click += new System.EventHandler(this.cmiExpandTree_Click);
            this.cmiCollapseTree.Name = "cmiCollapseTree";
            this.cmiCollapseTree.Size = new System.Drawing.Size(209, 22);
            this.cmiCollapseTree.Text = "Collapse Tree";
            this.cmiCollapseTree.Click += new System.EventHandler(this.cmiCollapseTree_Click);
            this.cmiCollapseTreeToSelection.Name = "cmiCollapseTreeToSelection";
            this.cmiCollapseTreeToSelection.Size = new System.Drawing.Size(209, 22);
            this.cmiCollapseTreeToSelection.Text = "Collapse Tree To Selection";
            this.cmiCollapseTreeToSelection.Click += new System.EventHandler(this.cmiCollapseTreeToSelection_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            this.cmiExpandBranch.Name = "cmiExpandBranch";
            this.cmiExpandBranch.Size = new System.Drawing.Size(209, 22);
            this.cmiExpandBranch.Text = "Expand Branch";
            this.cmiExpandBranch.Click += new System.EventHandler(this.cmiExpandBranch_Click);
            this.cmiCollapseBranch.Name = "cmiCollapseBranch";
            this.cmiCollapseBranch.Size = new System.Drawing.Size(209, 22);
            this.cmiCollapseBranch.Text = "Collapse Branch";
            this.cmiCollapseBranch.Click += new System.EventHandler(this.cmiCollapseBranch_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            this.cmiCheckBranch.Name = "cmiCheckBranch";
            this.cmiCheckBranch.Size = new System.Drawing.Size(209, 22);
            this.cmiCheckBranch.Text = "Check Branch";
            this.cmiCheckBranch.Click += new System.EventHandler(this.cmiCheckBranch_Click);
            this.cmiUncheckBranch.Name = "cmiUncheckBranch";
            this.cmiUncheckBranch.Size = new System.Drawing.Size(209, 22);
            this.cmiUncheckBranch.Text = "Uncheck Branch";
            this.cmiUncheckBranch.Click += new System.EventHandler(this.cmiUncheckBranch_Click);
            this.cmiResetBranchToDefault.Name = "cmiResetBranchToDefault";
            this.cmiResetBranchToDefault.Size = new System.Drawing.Size(209, 22);
            this.cmiResetBranchToDefault.Text = "Reset Branch To Default";
            this.cmiResetBranchToDefault.Click += new System.EventHandler(this.cmiResetBranchToDefault_Click);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            this.cmiResetSettingToDefault.Name = "cmiResetSettingToDefault";
            this.cmiResetSettingToDefault.Size = new System.Drawing.Size(209, 22);
            this.cmiResetSettingToDefault.Text = "Reset Setting To Default";
            this.cmiResetSettingToDefault.Click += new System.EventHandler(this.cmiResetSettingToDefault_Click);
            this.treeContextMenuSmall.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.cmiExpandTree2, this.cmiCollapseTree2, this.cmiCollapseTreeToSelection2, this.toolStripSeparator4, this.cmiResetSettingToDefault2});
            this.treeContextMenuSmall.Name = "treeContextMenuSmall";
            this.treeContextMenuSmall.Size = new System.Drawing.Size(210, 98);
            this.cmiExpandTree2.Name = "cmiExpandTree2";
            this.cmiExpandTree2.Size = new System.Drawing.Size(209, 22);
            this.cmiExpandTree2.Text = "Expand Tree";
            this.cmiExpandTree2.Click += new System.EventHandler(this.cmiExpandTree_Click);
            this.cmiCollapseTree2.Name = "cmiCollapseTree2";
            this.cmiCollapseTree2.Size = new System.Drawing.Size(209, 22);
            this.cmiCollapseTree2.Text = "Collapse Tree";
            this.cmiCollapseTree2.Click += new System.EventHandler(this.cmiCollapseTree_Click);
            this.cmiCollapseTreeToSelection2.Name = "cmiCollapseTreeToSelection2";
            this.cmiCollapseTreeToSelection2.Size = new System.Drawing.Size(209, 22);
            this.cmiCollapseTreeToSelection2.Text = "Collapse Tree To Selection";
            this.cmiCollapseTreeToSelection2.Click += new System.EventHandler(this.cmiCollapseTreeToSelection_Click);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(206, 6);
            this.cmiResetSettingToDefault2.Name = "cmiResetSettingToDefault2";
            this.cmiResetSettingToDefault2.Size = new System.Drawing.Size(209, 22);
            this.cmiResetSettingToDefault2.Text = "Reset Setting To Default";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.installSpeedrunModButton);
            this.Controls.Add(this.resetCheckBox);
            this.Controls.Add(this.splitCheckBox);
            this.Controls.Add(this.startCheckBox);
            this.Controls.Add(this.settingsTree);
            this.Name = "SADXSettings";
            this.Size = new System.Drawing.Size(476, 512);
            this.Load += new System.EventHandler(this.SADXSettings_Load);
            this.treeContextMenu.ResumeLayout(false);
            this.treeContextMenuSmall.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmiExpandTree;
        private System.Windows.Forms.ToolStripMenuItem cmiCollapseTree;
        private System.Windows.Forms.ToolStripMenuItem cmiCollapseTreeToSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmiExpandBranch;
        private System.Windows.Forms.ToolStripMenuItem cmiCollapseBranch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmiCheckBranch;
        private System.Windows.Forms.ToolStripMenuItem cmiUncheckBranch;
        private System.Windows.Forms.ToolStripMenuItem cmiResetBranchToDefault;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmiResetSettingToDefault;
        
        private System.Windows.Forms.ContextMenuStrip treeContextMenuSmall;
        private System.Windows.Forms.ToolStripMenuItem cmiExpandTree2;
        private System.Windows.Forms.ToolStripMenuItem cmiCollapseTree2;
        private System.Windows.Forms.ToolStripMenuItem cmiCollapseTreeToSelection2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmiResetSettingToDefault2;
        
        private System.Windows.Forms.CheckBox startCheckBox;
        private System.Windows.Forms.CheckBox splitCheckBox;
        private System.Windows.Forms.CheckBox resetCheckBox;
        
        private System.Windows.Forms.Button installSpeedrunModButton;

        private NewTreeView settingsTree;

        #endregion
    }
}
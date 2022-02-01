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
            this.settingsTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // settingsTree
            // 
            this.settingsTree.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.settingsTree.CheckBoxes = true;
            this.settingsTree.Location = new System.Drawing.Point(10, 60);
            this.settingsTree.Name = "settingsTree";
            this.settingsTree.ShowNodeToolTips = true;
            this.settingsTree.Size = new System.Drawing.Size(400, 427);
            this.settingsTree.TabIndex = 0;
            this.settingsTree.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.settingsTree_BeforeCheck);
            this.settingsTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.settingsTree_AfterCheck);
            // 
            // SADXSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.settingsTree);
            this.Name = "SADXSettings";
            this.Size = new System.Drawing.Size(465, 490);
            this.Load += new System.EventHandler(this.SADXSettings_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TreeView settingsTree;

        #endregion
    }
}
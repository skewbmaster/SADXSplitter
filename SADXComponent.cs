using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.ASL;
using LiveSplit.Model;
using LiveSplit.Options;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace SADXSplitter
{
    public class SplitterComponent : LogicComponent
    {
        public SADXSettings Settings { get; set; }

        public LiveSplitState state;
        public TimerModel timer;

        private ASLSettings aslSettings;
        
        public override string ComponentName { get; }

        public SplitterComponent(LiveSplitState state)
        {
            Settings = new SADXSettings();
            this.state = state;

            aslSettings = new ASLSettings();
            
            aslSettings.AddSetting("splitStage", true, "Split on Stage Completion", null); // Main Branch Setting
            
            aslSettings.AddSetting("finalBossesBranch", true, "Final Bosses", null); // Final Bosses Branch
            aslSettings.AddSetting("eggViper", true, "Egg Viper", "finalBossesBranch");
            aslSettings.AddSetting("eggWalker", true, "Egg Walker", "finalBossesBranch");
            aslSettings.AddSetting("chaos6Final", true, "Chaos 6", "finalBossesBranch");
            aslSettings.AddSetting("zero", true, "ZERO", "finalBossesBranch");
            aslSettings.AddSetting("betaMk2", true, "E-101 'Beta' mkII", "finalBossesBranch");
            aslSettings.AddSetting("perfectChaos", true, "Perfect Chaos", "finalBossesBranch");
            
            aslSettings.AddSetting("characterBossesBranch", false, "Character Bosses", null); // Character Bosses Branch
            
            aslSettings.AddSetting("upgradesBranch", false, "Upgrades", null); // Upgrades Branch
            
            aslSettings.AddSetting("enterStageBranch", false, "Enter Stage", null); // Enter Stage Branch
            
            aslSettings.AddSetting("enterBossBranch", false, "Enter Boss", null); // Enter Bosses Branch
            
            aslSettings.AddSetting("miscBranch", false, "Miscellaneous", null); // Miscellaneous branch
            
            
            Settings.InitASLSettings(aslSettings);

            state.CurrentTimingMethod = TimingMethod.GameTime;
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return Settings;
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return new XmlDocument();
        }

        public override void SetSettings(XmlNode settings)
        {
            
        }


        public override void Dispose()
        {
            
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }
    }
}
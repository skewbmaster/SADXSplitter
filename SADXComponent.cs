using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.ASL;
using LiveSplit.Model;
using LiveSplit.Options;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace SADXSplitter
{
    public class SADXComponent : LogicComponent
    {
        private SADXSettings Settings { get; set; }
        private SADXSplitter splitter;

        private static Process process;
        
        private LiveSplitState state;
        public TimerModel timer;
        private Timer updateTimer;

        private ASLSettings aslSettings;

        public override string ComponentName => "SADXSplitter";

        public const string SpeedrunModZipLink =
            "https://github.com/skewbmaster/sadx-speedrun-mod/releases/latest/download/sadx-speedrun-mod.zip";

        public SADXComponent(LiveSplitState state)
        {
            Settings = new SADXSettings();
            this.state = state;

            #region aslSettings
            aslSettings = new ASLSettings();
            
            aslSettings.AddSetting("splitStage", true, "Split on Stage Completion", null); // Main Branch Setting
            
            // Final Bosses Branch
            aslSettings.AddSetting("finalBossesBranch", true, "Final Bosses", null);
            aslSettings.AddSetting("eggViper", true, "Egg Viper", "finalBossesBranch");
            aslSettings.AddSetting("eggWalker", true, "Egg Walker", "finalBossesBranch");
            aslSettings.AddSetting("chaos6Final", true, "Chaos 6", "finalBossesBranch");
            aslSettings.AddSetting("zero", true, "ZERO", "finalBossesBranch");
            aslSettings.AddSetting("betaMk2", true, "E-101 'Beta' mkII", "finalBossesBranch");
            aslSettings.AddSetting("perfectChaos", true, "Perfect Chaos", "finalBossesBranch");
            
            // Character Bosses Branch
            aslSettings.AddSetting("characterBossesBranch", false, "Character Bosses", null);
            // Sonic Bosses
            aslSettings.AddSetting("sonicBossesBranch", false, "Sonic", "characterBossesBranch");
            aslSettings.AddSetting("chaos0", false, "Chaos 0", "sonicBossesBranch");
            aslSettings.AddSetting("eggHornetSonic", false, "Egg Hornet", "sonicBossesBranch");
            aslSettings.AddSetting("knuxFightSonic", false, "Knuckles", "sonicBossesBranch");
            aslSettings.AddSetting("chaos4Sonic", false, "Chaos 4", "sonicBossesBranch");
            aslSettings.AddSetting("gammaFightSonic", false, "Gamma", "sonicBossesBranch");
            aslSettings.AddSetting("chaos6Sonic", false, "Chaos 6", "sonicBossesBranch");
            // Tails Bosses
            aslSettings.AddSetting("tailsBossesBranch", false, "Tails", "characterBossesBranch");
            aslSettings.AddSetting("eggHornetTails", false, "Egg Hornet", "tailsBossesBranch");
            aslSettings.AddSetting("knuxFightTails", false, "Knuckles", "tailsBossesBranch");
            aslSettings.AddSetting("chaos4Tails", false, "Chaos 4", "tailsBossesBranch");
            aslSettings.AddSetting("gammaFightTails", false, "Gamma", "tailsBossesBranch");
            // Knuckles Bosses
            aslSettings.AddSetting("knuxBossesBranch", false, "Knuckles", "characterBossesBranch");
            aslSettings.AddSetting("chaos2", false, "Chaos 2", "knuxBossesBranch");
            aslSettings.AddSetting("sonicFightKnux", false, "Sonic", "knuxBossesBranch");
            aslSettings.AddSetting("chaos4Knux", false, "Chaos 4", "knuxBossesBranch");
            // Gamma Bosses
            aslSettings.AddSetting("gammaBossesBranch", false, "Gamma", "characterBossesBranch");
            aslSettings.AddSetting("betaMK1", false, "E-101 'Beta' mkI", "gammaBossesBranch");
            aslSettings.AddSetting("sonicFightGamma", false, "Sonic", "gammaBossesBranch");

            // Upgrades Branch
            aslSettings.AddSetting("upgradesBranch", false, "Upgrades", null); 
            aslSettings.AddSetting("upgradeSonic1", false, "Light Speed Shoes", "upgradesBranch");
            aslSettings.AddSetting("upgradeSonic2", false, "Crystal Ring", "upgradesBranch");
            aslSettings.AddSetting("upgradeSonic3", false, "Ancient Light", "upgradesBranch");
            aslSettings.AddSetting("upgradeTails1", false, "Jet Anklet", "upgradesBranch");
            aslSettings.AddSetting("upgradeTails2", false, "Rhythm Badge", "upgradesBranch");
            aslSettings.AddSetting("upgradeKnux1", false, "Shovel Claws", "upgradesBranch");
            aslSettings.AddSetting("upgradeKnux2", false, "Fighting Gloves", "upgradesBranch");
            aslSettings.AddSetting("upgradeAmy1", false, "Warrior Feather", "upgradesBranch");
            aslSettings.AddSetting("upgradeAmy2", false, "Long Hammer", "upgradesBranch");
            aslSettings.AddSetting("upgradeBig1", false, "Life Belt", "upgradesBranch");
            aslSettings.AddSetting("upgradeBig2", false, "Power Rod", "upgradesBranch");
            aslSettings.AddSetting("upgradeBig3", false, "Lures", "upgradesBranch");
            aslSettings.AddSetting("upgradeGamma1", false, "Jet Booster", "upgradesBranch");
            aslSettings.AddSetting("upgradeGamma2", false, "Laser Blaster", "upgradesBranch");
            
            // Enter Stage Branch
            aslSettings.AddSetting("enterStageBranch", false, "Enter Stage", null);
            aslSettings.AddSetting("enterEC", false, "Emerald Coast", "enterStageBranch");
            aslSettings.AddSetting("enterWV", false, "Windy Valley", "enterStageBranch");
            aslSettings.AddSetting("enterCP", false, "Casinopolis", "enterStageBranch");
            aslSettings.AddSetting("enterIC", false, "Ice Cap", "enterStageBranch");
            aslSettings.AddSetting("enterTP", false, "Twinkle Park", "enterStageBranch");
            aslSettings.AddSetting("enterSH", false, "Speed Highway", "enterStageBranch");
            aslSettings.AddSetting("enterRM", false, "Red Mountain", "enterStageBranch");
            aslSettings.AddSetting("enterSD", false, "Sky Deck", "enterStageBranch");
            aslSettings.AddSetting("enterLW", false, "Lost World", "enterStageBranch");
            aslSettings.AddSetting("enterFE", false, "Final Egg", "enterStageBranch");
            aslSettings.AddSetting("enterHS", false, "Hot Shelter", "enterStageBranch");
            
            // Enter Bosses Branch
            aslSettings.AddSetting("enterBossBranch", false, "Enter Boss", null);
            aslSettings.AddSetting("enterEggHornet", false, "Egg Hornet", "enterBossBranch");
            aslSettings.AddSetting("enterChaos2", false, "Chaos 2", "enterBossBranch");
            aslSettings.AddSetting("enterChaos4", false, "Chaos 4", "enterBossBranch");
            aslSettings.AddSetting("enterChaos6", false, "Chaos 6", "enterBossBranch");
            aslSettings.AddSetting("enterBeta1", false, "E101 'Beta' mkI", "enterBossBranch");
            aslSettings.AddSetting("enterBeta2", false, "E101 'Beta' mkII", "enterBossBranch");
            
            // Miscellaneous branch
            aslSettings.AddSetting("miscBranch", false, "Miscellaneous", null);
            // General Misc
            aslSettings.AddSetting("generalMiscBranch", false, "General", "miscBranch");
            aslSettings.AddSetting("notSkyChase1", false, "Don't Split Sky Chase Act 1", "generalMiscBranch");
            aslSettings.AddSetting("notSkyChase2", false, "Don't Split Sky Chase Act 2", "generalMiscBranch");
            aslSettings.AddSetting("actSplit", false, "Split Between Acts", "generalMiscBranch");
            // Sonic Misc
            aslSettings.AddSetting("sonicMiscBranch", false, "Sonic", "miscBranch");
            aslSettings.AddSetting("enterSewerSonic", false, "Enter Sewers", "sonicMiscBranch");
            aslSettings.AddSetting("enterCASHubSonic", false, "Enter Casino Area (From Speed Highway)", "sonicMiscBranch");
            aslSettings.AddSetting("shipTransformSonic", false, "Ship Transformation", "sonicMiscBranch");
            aslSettings.AddSetting("backFromPastSonic", false, "Splits when coming back to present after Lost World", "sonicMiscBranch");
            aslSettings.AddSetting("enterSSSonic", false, "Enter Station Square from Train Station", "sonicMiscBranch");
            aslSettings.AddSetting("enterMRSonic", false, "Enter Mystic Ruins from Train Station", "sonicMiscBranch");
            // Knux Misc
            aslSettings.AddSetting("knuxMiscBranch", false, "Knuckles", "miscBranch");
            aslSettings.AddSetting("deathMRKnux", false, "Death Warp on Angel Island", "knuxMiscBranch");
            aslSettings.AddSetting("enterEGCKnux", false, "Enter Egg Carrier (Before Sky Deck)", "knuxMiscBranch");
            // Amy Misc
            aslSettings.AddSetting("amyMiscBranch", false, "Amy", "miscBranch");
            aslSettings.AddSetting("enterCASHubAmy", false, "Enter Casino Area", "amyMiscBranch");
            aslSettings.AddSetting("enterJungleToFEAmy", false, "Enter Jungle to Final Egg", "amyMiscBranch");
            aslSettings.AddSetting("exitJungleToEGCAmy", false, "Exit Jungle from Final Egg", "amyMiscBranch");
            aslSettings.AddSetting("enterEGCAmy", false, "Enter Egg Carrier (Before ZERO)", "amyMiscBranch");
            // Gamma Misc
            aslSettings.AddSetting("gammaMiscBranch", false, "Gamma", "miscBranch");
            aslSettings.AddSetting("deathWVGamma", false, "Death Mystic Ruins (Windy Valley Flag)", "gammaMiscBranch");
            aslSettings.AddSetting("deathRMGamma", false, "Death Mystic Ruins (Post Red Mountain)", "gammaMiscBranch");
            aslSettings.AddSetting("enterEGCGamma", false, "Enter Egg Carrier (Before MKII)", "gammaMiscBranch");
            // Super Sonic Misc
            aslSettings.AddSetting("superMiscBranch", false, "Super Sonic", "miscBranch");
            aslSettings.AddSetting("enterCaveSS", false, "Enter Cave", "superMiscBranch");
            aslSettings.AddSetting("angelIslandSS", false, "Angel Island Cutscene", "superMiscBranch");
            aslSettings.AddSetting("tikalSS", false, "Tikal Cutscene", "superMiscBranch");
            aslSettings.AddSetting("deathMRSS", false, "Death Warp post Tikal Cutscenes", "superMiscBranch");
            aslSettings.AddSetting("jungleSS", false, "Enter Jungle", "superMiscBranch");
            
            Settings.InitAslSettings(aslSettings);
            #endregion

            state.CurrentTimingMethod = TimingMethod.GameTime;

            splitter = new SADXSplitter(this);

            updateTimer = new Timer{ Interval = 64 };
            updateTimer.Tick += (sender, args) =>
            {
                try
                {
                    UpdateScript();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            };
            updateTimer.Enabled = true;
        }

        private void UpdateScript()
        {
            
        }
        
        
        
        public override Control GetSettingsControl(LayoutMode mode)
        {
            return Settings;
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public override void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }


        public override void Dispose()
        {
            updateTimer.Dispose();
        }

        public override void Update(IInvalidator invalidator, LiveSplitState stateLS, float width, float height, LayoutMode mode) { }
    }
}
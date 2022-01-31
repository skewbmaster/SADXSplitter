using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

namespace SADXSplitter
{
    public class SplitterFactory : IComponentFactory
    {
        public string ComponentName => "SADX Autosplitter v" + this.Version.ToString();
        
        public string Description => "In-game Timer and Autosplitter for SADX";
        
        public ComponentCategory Category => ComponentCategory.Control;
        public IComponent Create(LiveSplitState state) { return new SplitterComponent(state); }
        public string UpdateName => this.ComponentName;
        public string UpdateURL => "https://raw.githubusercontent.com/skewbmaster/SADXSplitter/master/";
        public string XMLURL => this.UpdateURL + "Components/Updates.xml";
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}
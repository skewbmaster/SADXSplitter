using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

namespace SADXSplitter
{
    public class SADXFactory : IComponentFactory
    {
        public string ComponentName => "SADX Autosplitter v" + Version.ToString();
        
        public string Description => "In-game Timer and Autosplitter for SADX";
        
        public ComponentCategory Category => ComponentCategory.Information;
        public IComponent Create(LiveSplitState state) { return new SplitterComponent(state); }
        public string UpdateName => ComponentName;
        public string UpdateURL => "https://raw.githubusercontent.com/skewbmaster/SADXSplitter/master/";
        public string XMLURL => UpdateURL + "Components/Updates.xml";
        public Version Version => Version.Parse("1.0.0");
    }
}
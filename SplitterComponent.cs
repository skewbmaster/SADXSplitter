﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace SADXSplitter
{
    public class SplitterComponent : LogicComponent
    {
        public SplitterComponent(LiveSplitState state)
        {
            
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            throw new NotImplementedException();
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            throw new NotImplementedException();
        }

        public override void SetSettings(XmlNode settings)
        {
            throw new NotImplementedException();
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            throw new NotImplementedException();
        }

        public override string ComponentName { get; }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
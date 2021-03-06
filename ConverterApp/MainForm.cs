﻿using LSLib.LS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConverterApp
{
    public enum DivGame
    {
        DOS = 0,
        DOSEE = 1,
        DOS2 = 2
    };

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var gr2Pane = new GR2Pane(this);
            gr2Pane.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gr2Pane.Size = this.gr2Tab.ClientSize;
            this.gr2Tab.Controls.Add(gr2Pane);

            var packagePane = new PackagePane();
            packagePane.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            packagePane.Size = this.packageTab.ClientSize;
            this.packageTab.Controls.Add(packagePane);

            var resourcePane = new ResourcePane(this);
            resourcePane.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resourcePane.Size = this.resourceTab.ClientSize;
            this.resourceTab.Controls.Add(resourcePane);

            var osirisPane = new OsirisPane();
            osirisPane.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            osirisPane.Size = this.osirisTab.ClientSize;
            this.osirisTab.Controls.Add(osirisPane);

            this.Text += String.Format(" (LSLib v{0})", Common.LibraryVersion());
            gr2Game.SelectedIndex = 1;
        }

        public DivGame GetGame()
        {
            switch (gr2Game.SelectedIndex)
            {
                case 0: return DivGame.DOS;
                case 1: return DivGame.DOSEE;
                case 2: return DivGame.DOS2;
                default: throw new InvalidOperationException();
            }
        }

        private void gr2Game_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivGame game = GetGame();
            var pane = this.gr2Tab.Controls[0] as GR2Pane;
            pane.use16bitIndex.Checked = game == DivGame.DOSEE || game == DivGame.DOS2;
        }
    }
}

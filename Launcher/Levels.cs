﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Levels : Form
    {
        public Levels()
        {
            InitializeComponent();
        }

        private void Levels_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_level1_Click(object sender, EventArgs e)
        {
            //jnkjnk
            Process.Start("..\\..\\..\\About mishutka\\bin\\Debug\\net6.0\\About mishutka.exe");
        }
    }
}

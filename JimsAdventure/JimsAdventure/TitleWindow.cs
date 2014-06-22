using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace RPG
{
    public partial class TitleWindow : Form
    {
        public TitleWindow()
        {
            InitializeComponent();
            Sound.title.PlayLooping();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Sound.title.Stop();
            GameWindow main = new GameWindow();
            main.Show();
            this.Visible = false;
        }

    }
}




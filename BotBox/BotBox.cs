using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotBox
{
    public partial class BotBox : Form
    {
        public static int ID = 1;
        public BotBox()
        {
            InitializeComponent();

        }

        private void bOXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tp = new TabPage($"BOT {ID}");
            ID++;
            var cc = new ConsoleOutput();
            tp.Controls.Add(cc);
            cc.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "HOME") return;
            if (((ConsoleOutput)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0]).Client == null) { DelBot();return; };
            ((ConsoleOutput)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0]).Client.SendText("/quit");
            ((ConsoleOutput)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0]).Client.Close();
            DelBot();
        }
        public void DelBot()
        {
            if (tabControl1.SelectedTab.Text == "HOME") return;
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BotBox
{
    public partial class BotBox : Form
    {
        public static int ID = 1;
        public static List<Macro> macros = new List<Macro>();
        public static bool exited = false;
        public static string lasttxt = "";
        public BotBox()
        {
            InitializeComponent();
            if (File.Exists("macros.bbmcc"))
            {
                var lines = File.ReadAllLines("macros.bbmcc");
                for (int i = 0; i < lines.Length; i+=2)
                {
                    var cmds = lines[i + 1].Split('!');

                    listBox1.Items.Add(lines[i]);
                    macros.Add(new Macro(lines[i], cmds.ToList()));
                }
            }
        }

        private void bOXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tp = new TabPage($"BOT {ID}");
            ID++;
            var cc = new ConsoleOutput();
            cc.comboBox1.Items.Clear();
            foreach (var item in macros)
            {
                cc.comboBox1.Items.Add(item.name);
            }

            tp.Controls.Add(cc);
            cc.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!tabControl1.SelectedTab.Text.Contains("BOT")) return;
            if (((ConsoleOutput)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0]).Client == null) { DelBot(); return; };
            ((ConsoleOutput)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0]).Client.SendText("/quit");
            ((ConsoleOutput)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0]).Client.Close();
            DelBot();
        }
        public void DelBot()
        {
            if (!tabControl1.SelectedTab.Text.Contains("BOT")) return;
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void aDDMACROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(toolStripTextBox1.Text)) return;
            if (toolStripTextBox1.Text == "") return;
            listBox1.Items.Add(toolStripTextBox1.Text);
            macros.Add(new Macro(toolStripTextBox1.Text, new List<string>()));
        }

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MacroOutput mo = new MacroOutput(macros[listBox1.SelectedIndex]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                richTextBox1.Enabled = true;
                string txt = "";
                foreach (var item in macros[listBox1.SelectedIndex].commands)
                {
                    txt+=(item + "\n");
                }
                richTextBox1.Text = txt;
            }
            else richTextBox1.Enabled = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            macros[listBox1.SelectedIndex].commands = richTextBox1.Lines.ToList();
        }

        private void rEMOVEMACRoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int i = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(i);
                macros.RemoveAt(i);
            }
        }

        private void BotBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<string> lines = new List<string>();
            foreach (var item in macros)
            {
                lines.Add(item.name);
                string cmdstext = "";
                foreach (var cmds in item.commands)
                {
                    cmdstext += cmds + "!";
                }
                cmdstext = cmdstext.Trim('!');
                lines.Add(cmdstext);
            }
            File.WriteAllLines("macros.bbmcc", lines);
            Application.ExitThread();
            Application.Exit();
            exited = true;
        }
    }

    public class Macro
    {
        public List<string> commands;
        public string name;
        public List<Region> regions;
        public List<Variable> vars;
        bool testmode = false;
        MinecraftClient mcclient;
        RichTextBox rc;

        public Macro(string name, List<string> cmds)
        {
            commands = cmds;
            this.name = name;
        }
        public void RUN(MinecraftClient client)
        {
            testmode = false;
            mcclient = client;
            RUN();
        }
        void RUN()
        {
            ThreadStart ts = new ThreadStart(RUNinAsync);
            Thread t = new Thread(ts);
            t.Start();
        }
        void RUNinAsync()
        {
            var cmds = commands;
            regions = new List<Region>();
            vars = new List<Variable>();
            for (int i = 0; i < cmds.Count; i++)
            {
                if (cmds[i] == "") cmds[i] = "null";
            }
            foreach (var item in cmds)
            {
                List<string> parts = item.Split(' ').ToList();
                if (parts[0] == "$new")
                {
                    vars.Add(new Variable(parts[1], "null"));
                }
            }
            for (int i = 0; i < cmds.Count + 1; i++)
            {
                List<string> compiledcommands = Variable.ReplaceVars(vars, cmds);
                compiledcommands.Insert(0, "#begin");
                Thread.Sleep(5);
                var item = compiledcommands[i];
                List<string> parts = item.Split(' ').ToList();
                switch (item[0])
                {
                    case '/':
                        {
                            try
                            {
                                if (!testmode)
                                {
                                    mcclient.SendText(item);
                                }
                                else
                                {
                                    if (rc.InvokeRequired) rc.Invoke((MethodInvoker)(() => rc.AppendText(item + "\n")));
                                }
                                break;
                            }
                            catch { return; }
                        }
                    case '@':
                        {
                            switch (parts[0])
                            {
                                case "@delay": { Thread.Sleep(Convert.ToInt32(parts[1])); break; }
                                case "@goto": { i = Region.RecoRegions(regions, parts[1]); break; }
                                case "@await":
                                    {
                                        while (true)
                                        {
                                            if (testmode) break;
                                            string txt = item.Remove(0, 6);
                                            txt = txt.Trim();
                                            string lasttxt = BotBox.lasttxt;
                                            if (lasttxt.Contains(txt)) break;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case '#':
                        {
                            regions.Add(new Region(parts[0].Remove(0, 1), i));
                            break;
                        }
                    case '$':
                        {
                            if (parts[0] == "$set")
                                Variable.SetValue(vars, parts[1], parts[2]);
                            break;
                        }
                    case '%':
                        {
                            if (Variable.RecoVars(vars, parts[1]) == parts[2])
                            {
                                i = Region.RecoRegions(regions, parts[3]);
                            }
                            break;
                        }
                }
            }
        }

        public void RUN(RichTextBox output)
        {
            testmode = true;
            rc = output;
            RUN();
        }
        public class Region
        {
            public int lineindex;
            public string name;
            public Region(string name, int i)
            {
                this.name = name;
                lineindex = i;
            }
            public static int RecoRegions(List<Region> regions, string name)
            {
                foreach (var item in regions)
                {
                    if (item.name == name) return item.lineindex;
                }
                return 0;
            }
        }
        public class Variable
        {
            public string value;
            public string name;
            public Variable(string name, string val)
            {
                this.name = name;
                value = val;
            }
            public static string RecoVars(List<Variable> vars, string name)
            {
                foreach (var item in vars)
                {
                    if (item.name == name) return item.value;
                }
                return "";
            }
            public static string ReplaceVars(List<Variable> vars, string text)
            {
                foreach (var item in vars)
                {
                    text = text.Replace($"$${item.name}", item.value);
                }
                return text;
            }
            public static List<string> ReplaceVars(List<Variable> vars, List<string> text)
            {
                List<string> tmp = new List<string>();
                foreach (var item in text)
                {
                    tmp.Add(ReplaceVars(vars, item));
                }
                return tmp;
            }
            public static void SetValue(List<Variable> vars, string name, string value)
            {
                foreach (var item in vars)
                {
                    if (item.name == name) item.value = value;
                }
            }
        }
        public void Write()
        {

        }
    }
}

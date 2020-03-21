using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BotBox
{
    public partial class BotBox : DarkUI.Forms.DarkForm
    {
        public static int ID = 1;
        public static List<Macro> macros = new List<Macro>();
        public static List<Thread> allthreads = new List<Thread>();
        public static List<MCCClient> clients = new List<MCCClient>();
        public static bool exited = false;
        public static List<string> log = new List<string>();
        public static List<string> autostart = new List<string>();
        public static FormWindowState state = FormWindowState.Normal;
        public BotBox()
        {
            InitializeComponent();
            var consoleOutput1 = new ConsoleOutput();
            consoleOutput1.AddBox();
            panel3.Controls.Add(consoleOutput1);
            LoadFromFIle();
            LoadMCCIni();
            timer2.Start();
            
        }
        public void LoadFromFIle()
        {
            if (File.Exists("macros.bbmcc"))
            {
                List<string> lines = new List<string>();
                List<string> settingslines = new List<string>();
                List<string> autostartlines = new List<string>();
                List<string> macrolines = new List<string>();
                lines = File.ReadAllLines("macros.bbmcc").ToList();
                int step = 0;
                foreach (var item in lines)
                {
                    if (item == ""||item.Contains("⯀⯀")) step = 0;
                    if (step == 1)
                    {
                        settingslines.Add(item);
                    }
                    if (step == 2)
                    {
                        autostartlines.Add(item);
                    }
                    if (step == 3)
                    {
                        macrolines.Add(item);
                    }
                    if (item=="⯀⯀SETTINGS⯀⯀")
                    {
                        step = 1;
                    }
                    if (item == "⯀⯀AUTOSTART⯀⯀")
                    {
                        step = 2;
                    }
                    if (item == "⯀⯀MACROS⯀⯀")
                    {
                        step = 3;
                    }
                }

                foreach (var item in settingslines)
                {
                    if (item.Contains("⯃AUTOSTART=1"))
                    {
                        darkCheckBox1.Checked = true;
                    }
                }
                foreach (var item in autostartlines)
                {
                    AddAutostart(item);
                }
                foreach (var item in macrolines)
                {
                    var items = item.Split('⯃');
                    listBox1.Items.Add(items[0]);
                    var cmds = items.ToList();
                    cmds.RemoveAt(0);
                    macros.Add(new Macro(items[0], cmds));
                }
            }
        }
        public void SaveToFIle()
        {
            List<string> lines = new List<string>();
            lines.Add("⯀⯀BOTBOX-SETTINGS-FILE⯀⯀");
            lines.Add("");
            lines.Add("⯀⯀SETTINGS⯀⯀");
            int autostartenabled = 0;
            if (darkCheckBox1.Checked) autostartenabled = 1;
            lines.Add($"⯃AUTOSTART={autostartenabled}");
            lines.Add("");
            lines.Add("⯀⯀AUTOSTART⯀⯀");
            foreach (var item in autostart)
            {
                lines.Add(item);
            }
            lines.Add("");
            lines.Add("⯀⯀MACROS⯀⯀");
            foreach (var item in macros)
            {
                string cmdstext = "";
                foreach (var cmds in item.commands)
                {
                    cmdstext += cmds + "⯃";
                }
                cmdstext = cmdstext.Trim('⯃');
                lines.Add(item.name + "⯃" + cmdstext);
            }
            lines.Add("");
            lines.Add("⯀⯀END⯀⯀");
            File.WriteAllLines("macros.bbmcc", lines);
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
            if (listBox1.SelectedIndex < 0) return;
            MacroOutput mo = new MacroOutput(macros[listBox1.SelectedIndex]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                richTextBox1.ReadOnly = false;
                string txt = "";
                foreach (var item in macros[listBox1.SelectedIndex].commands)
                {
                    txt += (item + "\n");
                }
                richTextBox1.Text = txt;
            }
            else richTextBox1.ReadOnly = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains("⯃"))
                richTextBox1.Text = richTextBox1.Text.Replace("⯃", "");
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
            e.Cancel = true;
            var tmp = MessageBox.Show("YES - EXIT \nNO - MINIMIZE", "EXIT OR MINIMIZE?", MessageBoxButtons.YesNoCancel);
            if (tmp == DialogResult.Yes)
            {
                e.Cancel = false;
                CloseBotBox();
            }
            if (tmp == DialogResult.No)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                this.WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }
        public void CloseBotBox()
        {
            if (allthreads.Count > 0)
            {
                foreach (var item in allthreads)
                {
                    if (item.IsAlive)
                        item.Abort();
                }
            }
            foreach (var item in clients)
            {
                item.Close();
            }
            SaveToFIle();

            Application.ExitThread();
            Application.Exit();
            exited = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Macro.macros.Count; i++)
            {
                if (i + 1 > Macro.macros.Count) break;
                if (!Macro.macros[i].isRunning) Macro.macros.RemoveAt(i);
            }
            int countp = listBox2.Items.Count;
            if (countp == Macro.macros.Count) return;
            listBox2.Items.Clear();
            if (Macro.macros.Count > 0)
                foreach (var item in Macro.macros)
                {
                    listBox2.Items.Add(item.description);
                }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Enabled = true;
            if (listBox2.SelectedIndex < 0) contextMenuStrip1.Enabled = false;
        }

        private void kILLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Macro.macros[listBox2.SelectedIndex].thread.Abort();
        }

        private void BotBox_Resize(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }
        public void AddAutostart(string item)
        {
            string name = item;
            name = name.Replace("⯃ON", "");
            name = name.Replace("⯃OFF", "");
            name = name.Replace("⯃", " | ");
            ListViewItem lvitem = new ListViewItem(name);
            if (item.Split('⯃')[5] == "ON") lvitem.Checked = true;
            listBox3.Items.Add(lvitem);
            autostart.Add(item);
        }
        public void DoAutostart()
        {
            foreach (var item in autostart)
            {
                DoAutostart(item);
            }
        }
        public void DoAutostart(string item,bool one=false)
        {
            var item2 = item;
            var items = item2.Split('⯃');
            if (items[5] == "ON"||one)
            {
                var tp = new TabPage($"BOT {ID}");
                ID++;
                var cc = new ConsoleOutput();
                tp.Controls.Add(cc);
                tabControl1.TabPages.Add(tp);
                cc.InitClientClick(items[0], items[1], items[2], items[3], items[4]);
                cc.Dock = DockStyle.Fill;
            }
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItems.Count <= 0) return;
            int i = listBox3.SelectedItems[0].Index;
            listBox3.Items.RemoveAt(i);
            autostart.RemoveAt(i);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (autostart.Count > 0 && darkCheckBox1.Checked) DoAutostart();
            timer2.Enabled = false;
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("MinecraftClient.ini"))
                File.WriteAllText("MinecraftClient.ini", MCCIniRTB.Text);
        }

        private void rELOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMCCIni();
        }
        public void LoadMCCIni()
        {
            if (File.Exists("MinecraftClient.ini"))
            {
                MCCIniRTB.Text = File.ReadAllText("MinecraftClient.ini");
                sAVEToolStripMenuItem.Enabled = true;
            }
            else
            {
                MCCIniRTB.Text = "MinecraftClient.ini Not Found\nRun BOT to generate it";
                sAVEToolStripMenuItem.Enabled = false;
            }
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItems.Count <= 0) return;
            int i = listBox3.SelectedItems[0].Index;
            var item = autostart[i];
            DoAutostart(item,true);
        }

        private void listBox3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var val = e.NewValue;
            string newstring = "⯃OFF";
            if ( val == CheckState.Checked)
            {
                newstring = "⯃ON";
            }
            int i = e.Index;
            string tmp = autostart[i].Replace("⯃OFF", newstring).Replace("⯃ON", newstring);
            autostart[i] = tmp;
        }
    }

    public class Macro
    {
        public List<string> commands;
        public string name;
        public List<Region> regions;
        public List<Variable> vars;
        public static List<MacroThread> macros = new List<MacroThread>();
        public Thread thread;
        bool testmode = false;

        public Macro(string name, List<string> cmds)
        {
            commands = cmds;
            this.name = name;
        }
        public static Macro GetByName(string name, List<Macro> macros)
        {
            foreach (var item in macros)
            {
                if (item.name == name) return item;
            }
            return null;
        }
        public void RUN(MCCClient client)
        {
            testmode = false;
            RUN($"BOT {client.ID}", new OutputWriter(client));
        }
        void RUN(string location, object output)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(RUNinAsync);
            Thread t = new Thread(pts);
            BotBox.allthreads.Add(t);
            macros.Add(new MacroThread(t, $"{name} in [{location}]"));
            t.Start(output);
        }
        void RUNinAsync(object output)
        {
            var outputinclass = (OutputWriter)output;
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
                                outputinclass.Write(item);
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
                                        string txt = item.Remove(0, 6);
                                        txt = txt.Trim();
                                        AwaitingEngine engine = new AwaitingEngine(txt);
                                        while (true && !BotBox.exited && !engine.IsSucces)
                                        {
                                            if (testmode) break;
                                            Thread.Sleep(100);
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
            RUN("test", new OutputWriter(output));
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
        public class OutputWriter
        {
            public static readonly int MCCWrite = 1;
            public static readonly int RTBWrite = 2;
            public RichTextBox RichTextBox;
            public MCCClient MCCClient;

            public int type;
            public OutputWriter(MCCClient mcc)
            {
                MCCClient = mcc;
            }
            public OutputWriter(RichTextBox rc)
            {
                RichTextBox = rc;
            }
            public void Write(string txt)
            {
                var rc = RichTextBox;
                if (MCCClient != null) MCCClient.SendText(txt);
                if (rc != null && rc.InvokeRequired) rc.Invoke((MethodInvoker)(() => rc.AppendText(txt + "\n")));
            }
        }
    }

    public class MacroThread
    {
        public Thread thread;
        public string description;
        public bool isRunning { get { return thread.IsAlive; } }
        public MacroThread(Thread t, string desc)
        {
            thread = t;
            description = desc;
        }
    }
    public class AwaitingEngine
    {
        public bool IsSucces = false;
        public string stringToawait;
        public static List<AwaitingEngine> engines = new List<AwaitingEngine>();
        public AwaitingEngine(string stringToawait)
        {
            this.stringToawait = stringToawait;
            engines.Add(this);
        }
        public static void SendString(string str)
        {
            var engcopy = engines.ToArray().ToList();
            if (engines.Count > 0)
                foreach (var item in engcopy)
                {
                    if (str.Contains(item.stringToawait)) { item.IsSucces = true; }
                }
        }
    }


}

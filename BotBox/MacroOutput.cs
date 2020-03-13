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
    public partial class MacroOutput : Form
    {
        public Macro macro;

        public MacroOutput()
        {
            InitializeComponent();
        }

        public MacroOutput(Macro macro)
        {
            InitializeComponent();
            this.Show();
            this.macro = macro;
            this.macro.RUN(richTextBox1);
        }
    }
}

using DarkUI.Controls;
using System.Windows.Forms;

namespace BotBox
{
    partial class ConsoleOutput
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new DarkUI.Controls.DarkLabel();
            this.comboBox1 = new DarkUI.Controls.DarkComboBox();
            this.button1 = new DarkUI.Controls.DarkButton();
            this.label4 = new DarkUI.Controls.DarkLabel();
            this.textBox4 = new DarkUI.Controls.DarkTextBox();
            this.label3 = new DarkUI.Controls.DarkLabel();
            this.label2 = new DarkUI.Controls.DarkLabel();
            this.label1 = new DarkUI.Controls.DarkLabel();
            this.box_ip = new DarkUI.Controls.DarkTextBox();
            this.box_password = new DarkUI.Controls.DarkTextBox();
            this.box_Login = new DarkUI.Controls.DarkTextBox();
            this.box_output = new System.Windows.Forms.RichTextBox();
            this.box_input = new DarkUI.Controls.DarkTextBox();
            this.button2 = new DarkUI.Controls.DarkButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.box_ip);
            this.panel1.Controls.Add(this.box_password);
            this.panel1.Controls.Add(this.box_Login);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 157);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Macro";
            // 
            // comboBox1
            // 
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(61, 108);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 131);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5);
            this.button1.Size = new System.Drawing.Size(231, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "GO!";
            this.button1.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Version";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBox4.Location = new System.Drawing.Point(61, 82);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(176, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "auto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(38, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // box_ip
            // 
            this.box_ip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.box_ip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_ip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.box_ip.Location = new System.Drawing.Point(61, 55);
            this.box_ip.Name = "box_ip";
            this.box_ip.Size = new System.Drawing.Size(176, 20);
            this.box_ip.TabIndex = 2;
            // 
            // box_password
            // 
            this.box_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.box_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.box_password.Location = new System.Drawing.Point(61, 29);
            this.box_password.Name = "box_password";
            this.box_password.Size = new System.Drawing.Size(176, 20);
            this.box_password.TabIndex = 1;
            // 
            // box_Login
            // 
            this.box_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.box_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.box_Login.Location = new System.Drawing.Point(61, 3);
            this.box_Login.Name = "box_Login";
            this.box_Login.Size = new System.Drawing.Size(176, 20);
            this.box_Login.TabIndex = 0;
            // 
            // box_output
            // 
            this.box_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.box_output.BackColor = System.Drawing.Color.Black;
            this.box_output.ForeColor = System.Drawing.Color.White;
            this.box_output.Location = new System.Drawing.Point(0, 0);
            this.box_output.Name = "box_output";
            this.box_output.ReadOnly = true;
            this.box_output.Size = new System.Drawing.Size(403, 330);
            this.box_output.TabIndex = 1;
            this.box_output.Text = "";
            // 
            // box_input
            // 
            this.box_input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.box_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.box_input.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.box_input.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.box_input.Location = new System.Drawing.Point(0, 336);
            this.box_input.Name = "box_input";
            this.box_input.Size = new System.Drawing.Size(403, 20);
            this.box_input.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(375, 335);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(5);
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = ">";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConsoleOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.button2);
            this.Controls.Add(this.box_input);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.box_output);
            this.Name = "ConsoleOutput";
            this.Size = new System.Drawing.Size(403, 356);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private RichTextBox box_output;
        private DarkButton button1;
        private DarkLabel label4;
        private DarkTextBox textBox4;
        private DarkLabel label3;
        private DarkLabel label2;
        private DarkLabel label1;
        private DarkTextBox box_ip;
        private DarkTextBox box_password;
        private DarkTextBox box_Login;
        private DarkTextBox box_input;
        private DarkButton button2;
        private DarkLabel label5;
        public DarkComboBox comboBox1;
    }
}

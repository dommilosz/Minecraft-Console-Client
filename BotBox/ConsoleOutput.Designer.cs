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
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.box_ip = new System.Windows.Forms.TextBox();
            this.box_password = new System.Windows.Forms.TextBox();
            this.box_Login = new System.Windows.Forms.TextBox();
            this.box_output = new System.Windows.Forms.RichTextBox();
            this.box_input = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
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
            this.panel1.Size = new System.Drawing.Size(240, 131);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "GO!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Version";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(61, 82);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(176, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "auto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // box_ip
            // 
            this.box_ip.Location = new System.Drawing.Point(61, 55);
            this.box_ip.Name = "box_ip";
            this.box_ip.Size = new System.Drawing.Size(176, 20);
            this.box_ip.TabIndex = 2;
            // 
            // box_password
            // 
            this.box_password.Location = new System.Drawing.Point(61, 29);
            this.box_password.Name = "box_password";
            this.box_password.Size = new System.Drawing.Size(176, 20);
            this.box_password.TabIndex = 1;
            // 
            // box_Login
            // 
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
            this.box_output.Enabled = false;
            this.box_output.ForeColor = System.Drawing.Color.White;
            this.box_output.Location = new System.Drawing.Point(0, 0);
            this.box_output.Name = "box_output";
            this.box_output.Size = new System.Drawing.Size(403, 330);
            this.box_output.TabIndex = 1;
            this.box_output.Text = "\n\n\n\n\n\n\n\n\n\n\n                     \nLOGIN TO CONTINUE";
            // 
            // box_input
            // 
            this.box_input.Dock = System.Windows.Forms.DockStyle.Bottom;
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
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConsoleOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox box_ip;
        private System.Windows.Forms.TextBox box_password;
        private System.Windows.Forms.TextBox box_Login;
        private System.Windows.Forms.RichTextBox box_output;
        private System.Windows.Forms.TextBox box_input;
        private System.Windows.Forms.Button button2;
    }
}

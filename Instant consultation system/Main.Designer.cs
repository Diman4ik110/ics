namespace Instant_consultation_system
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.materialCheckBox2 = new MaterialSkin.Controls.MaterialCheckBox();
            this.online = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(31, 16);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(128, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Личный кабинет";
            this.materialLabel1.Click += new System.EventHandler(this.MaterialLabel1_Click);
            this.materialLabel1.Enter += new System.EventHandler(this.MaterialLabel1_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.materialFlatButton2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.materialCheckBox2);
            this.panel1.Controls.Add(this.online);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 51);
            this.panel1.TabIndex = 1;
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.materialFlatButton2.Location = new System.Drawing.Point(439, 8);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(85, 36);
            this.materialFlatButton2.TabIndex = 4;
            this.materialFlatButton2.Text = "обновить";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.MaterialFlatButton2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // materialCheckBox2
            // 
            this.materialCheckBox2.AutoSize = true;
            this.materialCheckBox2.Depth = 0;
            this.materialCheckBox2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox2.Location = new System.Drawing.Point(251, 10);
            this.materialCheckBox2.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox2.Name = "materialCheckBox2";
            this.materialCheckBox2.Ripple = true;
            this.materialCheckBox2.Size = new System.Drawing.Size(134, 30);
            this.materialCheckBox2.TabIndex = 1;
            this.materialCheckBox2.Text = "Наличие курсов";
            this.materialCheckBox2.UseVisualStyleBackColor = true;
            // 
            // online
            // 
            this.online.Depth = 0;
            this.online.Font = new System.Drawing.Font("Roboto", 10F);
            this.online.Location = new System.Drawing.Point(163, 12);
            this.online.Margin = new System.Windows.Forms.Padding(0);
            this.online.MouseLocation = new System.Drawing.Point(-1, -1);
            this.online.MouseState = MaterialSkin.MouseState.HOVER;
            this.online.Name = "online";
            this.online.Ripple = true;
            this.online.Size = new System.Drawing.Size(82, 26);
            this.online.TabIndex = 0;
            this.online.Text = "В сети";
            this.online.UseVisualStyleBackColor = true;
            this.online.CheckedChanged += new System.EventHandler(this.Online_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Location = new System.Drawing.Point(593, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 51);
            this.panel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 125);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 378);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1_Paint);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(522, 35);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(266, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Ученье - свет, деньги, и не только ...";
            this.materialLabel2.Click += new System.EventHandler(this.MaterialLabel2_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(361, 35);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(108, 19);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "materialLabel3";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Система мгновенных консультаций";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox2;
        private MaterialSkin.Controls.MaterialCheckBox online;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        public MaterialSkin.Controls.MaterialLabel materialLabel3;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}
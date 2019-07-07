namespace Instant_consultation_system
{
    partial class Login
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
            this.log = new MaterialSkin.Controls.MaterialFlatButton();
            this.login_name = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.password = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.log.Depth = 0;
            this.log.Location = new System.Drawing.Point(169, 272);
            this.log.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.log.MouseState = MaterialSkin.MouseState.HOVER;
            this.log.Name = "log";
            this.log.Primary = false;
            this.log.Size = new System.Drawing.Size(76, 36);
            this.log.TabIndex = 0;
            this.log.Text = "Вход";
            this.log.UseVisualStyleBackColor = true;
            this.log.Click += new System.EventHandler(this.Log_Click);
            // 
            // login_name
            // 
            this.login_name.Depth = 0;
            this.login_name.Hint = "";
            this.login_name.Location = new System.Drawing.Point(55, 139);
            this.login_name.MouseState = MaterialSkin.MouseState.HOVER;
            this.login_name.Name = "login_name";
            this.login_name.PasswordChar = '\0';
            this.login_name.SelectedText = "";
            this.login_name.SelectionLength = 0;
            this.login_name.SelectionStart = 0;
            this.login_name.Size = new System.Drawing.Size(188, 23);
            this.login_name.TabIndex = 1;
            this.login_name.UseSystemPasswordChar = false;
            this.login_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_name_KeyDown);
            // 
            // password
            // 
            this.password.Depth = 0;
            this.password.Hint = "";
            this.password.Location = new System.Drawing.Point(55, 221);
            this.password.MouseState = MaterialSkin.MouseState.HOVER;
            this.password.Name = "password";
            this.password.PasswordChar = '\0';
            this.password.SelectedText = "";
            this.password.SelectionLength = 0;
            this.password.SelectionStart = 0;
            this.password.Size = new System.Drawing.Size(188, 23);
            this.password.TabIndex = 2;
            this.password.UseSystemPasswordChar = false;
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_name_KeyDown);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(51, 117);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(53, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Логин";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(51, 199);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(62, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Пароль";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(55, 272);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(106, 36);
            this.materialFlatButton1.TabIndex = 5;
            this.materialFlatButton1.Text = "Регистрация";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.MaterialFlatButton1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 366);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login_name);
            this.Controls.Add(this.log);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton log;
        private MaterialSkin.Controls.MaterialSingleLineTextField login_name;
        private MaterialSkin.Controls.MaterialSingleLineTextField password;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
    }
}
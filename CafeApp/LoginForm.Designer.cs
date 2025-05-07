namespace CafeApp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            usernameText = new TextBox();
            passwordText = new TextBox();
            LoginBtn = new Button();
            CancelBtn = new Button();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.BackColor = Color.Transparent;
            UsernameLabel.FlatStyle = FlatStyle.Flat;
            UsernameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            UsernameLabel.ForeColor = Color.DarkGoldenrod;
            UsernameLabel.Location = new Point(345, 300);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(126, 21);
            UsernameLabel.TabIndex = 0;
            UsernameLabel.Text = "Username:";
            UsernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            UsernameLabel.Click += UsernameLabel_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.BackColor = Color.Transparent;
            PasswordLabel.FlatStyle = FlatStyle.Flat;
            PasswordLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            PasswordLabel.ForeColor = Color.DarkGoldenrod;
            PasswordLabel.Location = new Point(345, 340);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(126, 23);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "Password:";
            PasswordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameText
            // 
            usernameText.BackColor = Color.Goldenrod;
            usernameText.BorderStyle = BorderStyle.FixedSingle;
            usernameText.Location = new Point(486, 299);
            usernameText.Name = "usernameText";
            usernameText.PlaceholderText = "Username";
            usernameText.Size = new Size(139, 23);
            usernameText.TabIndex = 2;
            usernameText.TextAlign = HorizontalAlignment.Center;
            // 
            // passwordText
            // 
            passwordText.BackColor = Color.Goldenrod;
            passwordText.BorderStyle = BorderStyle.FixedSingle;
            passwordText.Location = new Point(486, 340);
            passwordText.Name = "passwordText";
            passwordText.PlaceholderText = "Password";
            passwordText.Size = new Size(139, 23);
            passwordText.TabIndex = 3;
            passwordText.TextAlign = HorizontalAlignment.Center;
            passwordText.UseSystemPasswordChar = true;
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = Color.Lime;
            LoginBtn.BackgroundImageLayout = ImageLayout.Stretch;
            LoginBtn.FlatAppearance.BorderColor = Color.Lime;
            LoginBtn.FlatStyle = FlatStyle.Popup;
            LoginBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LoginBtn.Location = new Point(345, 384);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(126, 28);
            LoginBtn.TabIndex = 4;
            LoginBtn.Text = "Sign In";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Tomato;
            CancelBtn.FlatStyle = FlatStyle.Popup;
            CancelBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            CancelBtn.Location = new Point(486, 384);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(139, 28);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Exit";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += button1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(955, 493);
            Controls.Add(CancelBtn);
            Controls.Add(LoginBtn);
            Controls.Add(passwordText);
            Controls.Add(usernameText);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            Text = "Cafe Latte Lab";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox usernameText;
        private TextBox passwordText;
        private Button LoginBtn;
        private Button CancelBtn;
    }
}

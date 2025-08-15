namespace WorkerUI
{
    partial class LogIn
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
            pictureBox1 = new PictureBox();
            usernameTxt = new TextBox();
            passwordTxt = new TextBox();
            logInLabel = new Label();
            logInBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.sys;
            pictureBox1.Location = new Point(242, 94);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(395, 268);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // usernameTxt
            // 
            usernameTxt.BackColor = SystemColors.ScrollBar;
            usernameTxt.Location = new Point(242, 385);
            usernameTxt.Multiline = true;
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(395, 41);
            usernameTxt.TabIndex = 1;
            // 
            // passwordTxt
            // 
            passwordTxt.BackColor = SystemColors.ScrollBar;
            passwordTxt.Location = new Point(242, 432);
            passwordTxt.Multiline = true;
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(395, 41);
            passwordTxt.TabIndex = 2;
            // 
            // logInLabel
            // 
            logInLabel.AutoSize = true;
            logInLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logInLabel.ForeColor = Color.Black;
            logInLabel.Location = new Point(367, 48);
            logInLabel.Name = "logInLabel";
            logInLabel.Size = new Size(142, 25);
            logInLabel.TabIndex = 3;
            logInLabel.Text = "Нэвтрэх хуудас";
            // 
            // logInBtn
            // 
            logInBtn.BackColor = SystemColors.ControlLight;
            logInBtn.Location = new Point(367, 479);
            logInBtn.Name = "logInBtn";
            logInBtn.Size = new Size(128, 52);
            logInBtn.TabIndex = 4;
            logInBtn.Text = "Нэвтрэх";
            logInBtn.UseVisualStyleBackColor = false;
            logInBtn.Click += logInBtn_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(934, 581);
            Controls.Add(logInBtn);
            Controls.Add(logInLabel);
            Controls.Add(passwordTxt);
            Controls.Add(usernameTxt);
            Controls.Add(pictureBox1);
            ForeColor = Color.DarkBlue;
            Name = "LogIn";
            Text = "LogIn";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox usernameTxt;
        private TextBox passwordTxt;
        private Label logInLabel;
        private Button logInBtn;
    }
}

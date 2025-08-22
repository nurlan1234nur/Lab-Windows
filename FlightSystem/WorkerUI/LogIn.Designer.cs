using System.Drawing;
using System.Windows.Forms;

namespace WorkerUI
{
    partial class LogIn
    {
        private System.ComponentModel.IContainer components = null;

        // === NEW controls ===
        private TableLayoutPanel layoutRoot;
        private TableLayoutPanel contentGrid;
        private Panel headerPanel;
        private Panel panelLogin;

        private PictureBox pictureBox2;   // logo (аль хэдийн байгаа нэр)
        private Label LoginLabel;
        private TextBox textBox1;         // username/email
        private TextBox textBox2;         // password
        private Button LoginBtn;
        private LinkLabel SignUpLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            SignUpLabel = new LinkLabel();
            panelLogin = new Panel();
            LoginLabel = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            LoginBtn = new Button();
            pictureBox2 = new PictureBox();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // SignUpLabel
            // 
            SignUpLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SignUpLabel.AutoSize = true;
            SignUpLabel.LinkArea = new LinkArea(20, 7);
            SignUpLabel.Location = new Point(16, 213);
            SignUpLabel.Name = "SignUpLabel";
            SignUpLabel.Size = new Size(192, 25);
            SignUpLabel.TabIndex = 0;
            SignUpLabel.TabStop = true;
            SignUpLabel.Text = "Not registered yet? Sign up";
            SignUpLabel.UseCompatibleTextRendering = true;
            // 
            // panelLogin
            // 
            panelLogin.Anchor = AnchorStyles.None;
            panelLogin.BackColor = Color.White;
            panelLogin.BorderStyle = BorderStyle.FixedSingle;
            panelLogin.Controls.Add(SignUpLabel);
            panelLogin.Controls.Add(LoginLabel);
            panelLogin.Controls.Add(textBox1);
            panelLogin.Controls.Add(textBox2);
            panelLogin.Controls.Add(LoginBtn);
            panelLogin.Location = new Point(406, 202);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(335, 258);
            panelLogin.TabIndex = 2;
            // 
            // LoginLabel
            // 
            LoginLabel.AutoSize = true;
            LoginLabel.Font = new Font("Arial", 18F, FontStyle.Bold);
            LoginLabel.ForeColor = Color.FromArgb(0, 51, 153);
            LoginLabel.Location = new Point(16, 31);
            LoginLabel.Name = "LoginLabel";
            LoginLabel.Size = new Size(95, 35);
            LoginLabel.TabIndex = 0;
            LoginLabel.Text = "Login";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 83);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Email ";
            textBox1.Size = new Size(294, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(16, 116);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Password";
            textBox2.Size = new Size(294, 27);
            textBox2.TabIndex = 2;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // LoginBtn
            // 
            LoginBtn.BackColor = SystemColors.HotTrack;
            LoginBtn.FlatAppearance.BorderSize = 0;
            LoginBtn.FlatStyle = FlatStyle.Flat;
            LoginBtn.ForeColor = Color.White;
            LoginBtn.Location = new Point(16, 167);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(247, 40);
            LoginBtn.TabIndex = 3;
            LoginBtn.Text = "LOGIN";
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 201);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // LogIn
            // 
            AcceptButton = LoginBtn;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1162, 654);
            Controls.Add(pictureBox2);
            Controls.Add(panelLogin);
            DoubleBuffered = true;
            ForeColor = Color.DarkBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogIn";
            Text = "LogIn";
            Load += LogIn_Load_1;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

    }
}

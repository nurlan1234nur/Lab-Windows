using System.Windows.Forms;

namespace WorkerUI
{
    partial class OrderDetails
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetails));
            SearchBtn = new Button();
            UserPassportTxtBox = new TextBox();
            FlightsLabel = new LinkLabel();
            OrdersLabel = new LinkLabel();
            LogoutBtn = new Button();
            label1 = new Label();
            orderBindingSource = new BindingSource(components);
            OrdersPanel = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // SearchBtn
            // 
            SearchBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchBtn.BackColor = Color.FromArgb(0, 120, 215);
            SearchBtn.FlatAppearance.BorderSize = 0;
            SearchBtn.FlatStyle = FlatStyle.Flat;
            SearchBtn.ForeColor = Color.White;
            SearchBtn.Location = new Point(825, 110);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(110, 30);
            SearchBtn.TabIndex = 6;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = false;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // UserPassportTxtBox
            // 
            UserPassportTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserPassportTxtBox.Font = new Font("Segoe UI", 11F);
            UserPassportTxtBox.Location = new Point(140, 110);
            UserPassportTxtBox.Name = "UserPassportTxtBox";
            UserPassportTxtBox.PlaceholderText = "Enter user passport number";
            UserPassportTxtBox.Size = new Size(665, 32);
            UserPassportTxtBox.TabIndex = 5;
            // 
            // FlightsLabel
            // 
            FlightsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FlightsLabel.AutoSize = true;
            FlightsLabel.Font = new Font("Segoe UI", 12F);
            FlightsLabel.LinkColor = Color.Black;
            FlightsLabel.Location = new Point(815, 30);
            FlightsLabel.Name = "FlightsLabel";
            FlightsLabel.Size = new Size(70, 28);
            FlightsLabel.TabIndex = 2;
            FlightsLabel.TabStop = true;
            FlightsLabel.Text = "Flights";
            // 
            // OrdersLabel
            // 
            OrdersLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OrdersLabel.AutoSize = true;
            OrdersLabel.BackColor = Color.Gainsboro;
            OrdersLabel.Font = new Font("Segoe UI", 12F);
            OrdersLabel.LinkColor = Color.Black;
            OrdersLabel.Location = new Point(895, 30);
            OrdersLabel.Name = "OrdersLabel";
            OrdersLabel.Size = new Size(71, 28);
            OrdersLabel.TabIndex = 3;
            OrdersLabel.TabStop = true;
            OrdersLabel.Text = "Orders";
            // 
            // LogoutBtn
            // 
            LogoutBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LogoutBtn.BackColor = Color.FromArgb(220, 20, 60);
            LogoutBtn.FlatAppearance.BorderSize = 0;
            LogoutBtn.FlatStyle = FlatStyle.Flat;
            LogoutBtn.ForeColor = Color.White;
            LogoutBtn.Location = new Point(995, 22);
            LogoutBtn.Name = "LogoutBtn";
            LogoutBtn.Size = new Size(90, 35);
            LogoutBtn.TabIndex = 4;
            LogoutBtn.Text = "Logout";
            LogoutBtn.UseVisualStyleBackColor = false;
            LogoutBtn.Click += LogoutBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Gainsboro;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(130, 30);
            label1.Name = "label1";
            label1.Size = new Size(495, 41);
            label1.TabIndex = 1;
            label1.Text = "MonFlight Flight Booking Agency";
            // 
            // orderBindingSource
            // 
            orderBindingSource.DataSource = typeof(FlightSystem.Models.Order);
            // 
            // OrdersPanel
            // 
            OrdersPanel.BackColor = Color.WhiteSmoke;
            OrdersPanel.Location = new Point(21, 148);
            OrdersPanel.Name = "OrdersPanel";
            OrdersPanel.Size = new Size(1064, 443);
            OrdersPanel.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(122, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // OrderDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1097, 603);
            Controls.Add(pictureBox1);
            Controls.Add(OrdersPanel);
            Controls.Add(label1);
            Controls.Add(FlightsLabel);
            Controls.Add(OrdersLabel);
            Controls.Add(LogoutBtn);
            Controls.Add(UserPassportTxtBox);
            Controls.Add(SearchBtn);
            MinimumSize = new Size(900, 650);
            Name = "OrderDetails";
            Text = "MonFlight Booking System";
            Load += OrderDetails_Load;
            ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SearchBtn;
        private TextBox UserPassportTxtBox;
        private PictureBox pictureBox2;
        private LinkLabel FlightsLabel;
        private LinkLabel OrdersLabel;
        private Button LogoutBtn;
        private Label label1;
        private BindingSource orderBindingSource;
        private FlowLayoutPanel OrdersPanel;
        private PictureBox pictureBox1;
    }
}
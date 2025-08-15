namespace POS_System
{
    partial class CategoryControl
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
            categoryIdLabel = new Label();
            categoryNameLabel = new Label();
            SuspendLayout();
            // 
            // categoryIdLabel
            // 
            categoryIdLabel.AutoSize = true;
            categoryIdLabel.Location = new Point(10, 10);
            categoryIdLabel.Name = "categoryIdLabel";
            categoryIdLabel.Size = new Size(30, 15);
            categoryIdLabel.TabIndex = 0;
            categoryIdLabel.Text = "ID: 0";
            // 
            // categoryNameLabel
            // 
            categoryNameLabel.AutoSize = true;
            categoryNameLabel.Font = new Font("Segoe UI", 12F);
            categoryNameLabel.Location = new Point(10, 35);
            categoryNameLabel.Name = "categoryNameLabel";
            categoryNameLabel.Size = new Size(37, 21);
            categoryNameLabel.TabIndex = 1;
            categoryNameLabel.Text = "Нэр";
            // 
            // CategoryControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(categoryNameLabel);
            Controls.Add(categoryIdLabel);
            Name = "CategoryControl";
            Size = new Size(200, 70);
            Load += CategoryControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label categoryIdLabel;
        private Label categoryNameLabel;
    }
} 
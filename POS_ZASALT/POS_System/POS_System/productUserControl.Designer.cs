namespace POS_System
{
    partial class productUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProductPictureBox = new PictureBox();
            ProductNameLabel = new Label();
            ProductPriceLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ProductPictureBox).BeginInit();
            SuspendLayout();
            // 
            // ProductPictureBox
            // 
            ProductPictureBox.Location = new Point(20, 19);
            ProductPictureBox.Name = "ProductPictureBox";
            ProductPictureBox.Size = new Size(102, 91);
            ProductPictureBox.TabIndex = 0;
            ProductPictureBox.TabStop = false;
            // 
            // ProductNameLabel
            // 
            ProductNameLabel.AutoSize = true;
            ProductNameLabel.Location = new Point(21, 120);
            ProductNameLabel.Name = "ProductNameLabel";
            ProductNameLabel.Size = new Size(39, 15);
            ProductNameLabel.TabIndex = 1;
            ProductNameLabel.Text = "Name";
            // 
            // ProductPriceLabel
            // 
            ProductPriceLabel.AutoSize = true;
            ProductPriceLabel.Location = new Point(20, 144);
            ProductPriceLabel.Name = "ProductPriceLabel";
            ProductPriceLabel.Size = new Size(103, 15);
            ProductPriceLabel.TabIndex = 2;
            ProductPriceLabel.Text = "ProductPriceLabel";
            ProductPriceLabel.Click += ProductPriceLabel_Click;
            // 
            // productUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ProductPriceLabel);
            Controls.Add(ProductNameLabel);
            Controls.Add(ProductPictureBox);
            Name = "productUserControl";
            Size = new Size(136, 172);
            Load += productUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)ProductPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ProductPictureBox;
        private Label ProductNameLabel;
        private Label ProductPriceLabel;
    }
}

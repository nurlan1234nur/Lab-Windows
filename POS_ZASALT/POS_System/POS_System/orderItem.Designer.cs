namespace POS_System
{
    partial class orderItem
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
            ProductNameLabel = new Label();
            ProductIncreaseBtn = new Button();
            ProductDecreaseBtn = new Button();
            ProductQuantityLabel = new Label();
            ProductPricelabel = new Label();
            ProductDiscountLabel = new Label();
            ProductTotalPriceLabel = new Label();
            SuspendLayout();
            // 
            // ProductNameLabel
            // 
            ProductNameLabel.AutoSize = true;
            ProductNameLabel.Location = new Point(3, 13);
            ProductNameLabel.Name = "ProductNameLabel";
            ProductNameLabel.Size = new Size(81, 15);
            ProductNameLabel.TabIndex = 0;
            ProductNameLabel.Text = "ProductName";
            // 
            // ProductIncreaseBtn
            // 
            ProductIncreaseBtn.Location = new Point(156, 9);
            ProductIncreaseBtn.Name = "ProductIncreaseBtn";
            ProductIncreaseBtn.Size = new Size(41, 23);
            ProductIncreaseBtn.TabIndex = 1;
            ProductIncreaseBtn.Text = "+";
            ProductIncreaseBtn.UseVisualStyleBackColor = true;
            ProductIncreaseBtn.Click += ProductIncreaseBtn_Click_1;
            // 
            // ProductDecreaseBtn
            // 
            ProductDecreaseBtn.Location = new Point(262, 9);
            ProductDecreaseBtn.Name = "ProductDecreaseBtn";
            ProductDecreaseBtn.Size = new Size(41, 23);
            ProductDecreaseBtn.TabIndex = 2;
            ProductDecreaseBtn.Text = "-";
            ProductDecreaseBtn.UseVisualStyleBackColor = true;
            ProductDecreaseBtn.Click += ProductDecreaseBtn_Click_1;
            // 
            // ProductQuantityLabel
            // 
            ProductQuantityLabel.AutoSize = true;
            ProductQuantityLabel.Location = new Point(203, 13);
            ProductQuantityLabel.Name = "ProductQuantityLabel";
            ProductQuantityLabel.Size = new Size(53, 15);
            ProductQuantityLabel.TabIndex = 3;
            ProductQuantityLabel.Text = "Quantity";
            // 
            // ProductPricelabel
            // 
            ProductPricelabel.AutoSize = true;
            ProductPricelabel.Location = new Point(309, 13);
            ProductPricelabel.Name = "ProductPricelabel";
            ProductPricelabel.Size = new Size(46, 15);
            ProductPricelabel.TabIndex = 4;
            ProductPricelabel.Text = "U/Price";
            // 
            // ProductDiscountLabel
            // 
            ProductDiscountLabel.AutoSize = true;
            ProductDiscountLabel.Location = new Point(361, 13);
            ProductDiscountLabel.Name = "ProductDiscountLabel";
            ProductDiscountLabel.Size = new Size(54, 15);
            ProductDiscountLabel.TabIndex = 5;
            ProductDiscountLabel.Text = "Discount";
            // 
            // ProductTotalPriceLabel
            // 
            ProductTotalPriceLabel.AutoSize = true;
            ProductTotalPriceLabel.Location = new Point(421, 13);
            ProductTotalPriceLabel.Name = "ProductTotalPriceLabel";
            ProductTotalPriceLabel.Size = new Size(33, 15);
            ProductTotalPriceLabel.TabIndex = 6;
            ProductTotalPriceLabel.Text = "Total";
            // 
            // orderItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ProductTotalPriceLabel);
            Controls.Add(ProductDiscountLabel);
            Controls.Add(ProductPricelabel);
            Controls.Add(ProductQuantityLabel);
            Controls.Add(ProductDecreaseBtn);
            Controls.Add(ProductIncreaseBtn);
            Controls.Add(ProductNameLabel);
            Name = "orderItem";
            Size = new Size(458, 47);
            Load += orderItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProductNameLabel;
        private Button ProductIncreaseBtn;
        private Button ProductDecreaseBtn;
        private Label ProductQuantityLabel;
        private Label ProductPricelabel;
        private Label ProductDiscountLabel;
        private Label ProductTotalPriceLabel;
    }
}

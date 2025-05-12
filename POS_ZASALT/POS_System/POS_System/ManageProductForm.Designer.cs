namespace POS_System
{
    partial class ManageProductForm
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
            nameTextBox = new TextBox();
            priceTextBox = new TextBox();
            saveButton = new Button();
            barcodeTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Barcode = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ImagePathTextBox = new TextBox();
            CategoryIdTextBox = new TextBox();
            DiscountTextBox = new TextBox();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(41, 121);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 23);
            nameTextBox.TabIndex = 0;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(171, 121);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(100, 23);
            priceTextBox.TabIndex = 1;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(41, 314);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 2;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click_1;
            // 
            // barcodeTextBox
            // 
            barcodeTextBox.Location = new Point(41, 195);
            barcodeTextBox.Name = "barcodeTextBox";
            barcodeTextBox.Size = new Size(100, 23);
            barcodeTextBox.TabIndex = 3;
            barcodeTextBox.TextChanged += barcodeTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 91);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 4;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 91);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 5;
            label2.Text = "Price";
            // 
            // Barcode
            // 
            Barcode.AutoSize = true;
            Barcode.Location = new Point(47, 165);
            Barcode.Name = "Barcode";
            Barcode.Size = new Size(50, 15);
            Barcode.TabIndex = 6;
            Barcode.Text = "Barcode";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(177, 236);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 12;
            label3.Text = "Image";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(171, 165);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 11;
            label4.Text = "CategoryId";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 236);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 10;
            label5.Text = "Discount";
            // 
            // ImagePathTextBox
            // 
            ImagePathTextBox.Location = new Point(171, 266);
            ImagePathTextBox.Name = "ImagePathTextBox";
            ImagePathTextBox.Size = new Size(100, 23);
            ImagePathTextBox.TabIndex = 9;
            // 
            // CategoryIdTextBox
            // 
            CategoryIdTextBox.Location = new Point(171, 195);
            CategoryIdTextBox.Name = "CategoryIdTextBox";
            CategoryIdTextBox.Size = new Size(100, 23);
            CategoryIdTextBox.TabIndex = 8;
            // 
            // DiscountTextBox
            // 
            DiscountTextBox.Location = new Point(41, 266);
            DiscountTextBox.Name = "DiscountTextBox";
            DiscountTextBox.Size = new Size(100, 23);
            DiscountTextBox.TabIndex = 7;
            // 
            // ManageProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(ImagePathTextBox);
            Controls.Add(CategoryIdTextBox);
            Controls.Add(DiscountTextBox);
            Controls.Add(Barcode);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(barcodeTextBox);
            Controls.Add(saveButton);
            Controls.Add(priceTextBox);
            Controls.Add(nameTextBox);
            Name = "ManageProductForm";
            Text = "ManageProductForm";
            Load += ManageProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox priceTextBox;
        private Button saveButton;
        private TextBox barcodeTextBox;
        private Label label1;
        private Label label2;
        private Label Barcode;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox ImagePathTextBox;
        private TextBox CategoryIdTextBox;
        private TextBox DiscountTextBox;
    }
}
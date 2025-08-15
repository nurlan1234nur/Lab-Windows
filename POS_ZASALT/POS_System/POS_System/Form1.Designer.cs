namespace POS_System
{
    partial class Form1
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
            menuStrip1 = new MenuStrip();
            productToolStripMenuItem = new ToolStripMenuItem();
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            helpStripMenuItem1 = new ToolStripMenuItem();
            productCodeTextBox = new TextBox();
            addProductBtn = new Button();
            payButton = new Button();
            CategoriesPanel = new Panel();
            editProductBtn = new Button();
            deleteProductBtn = new Button();
            ProductsPanel = new FlowLayoutPanel();
            searchButton = new Button();
            label1 = new Label();
            Clear = new Button();
            OrderPanel = new Panel();
            textBox1 = new TextBox();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { productToolStripMenuItem, categoriesToolStripMenuItem, helpStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1524, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.Size = new Size(61, 20);
            productToolStripMenuItem.Text = "product";
            productToolStripMenuItem.Click += toolStripMenuItem1_Click;
            // 
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            categoriesToolStripMenuItem.Size = new Size(73, 20);
            categoriesToolStripMenuItem.Text = "categories";
            categoriesToolStripMenuItem.Click += categoriesToolStripMenuItem_Click;
            // 
            // helpStripMenuItem1
            // 
            helpStripMenuItem1.Name = "helpStripMenuItem1";
            helpStripMenuItem1.Size = new Size(42, 20);
            helpStripMenuItem1.Text = "help";
            helpStripMenuItem1.Click += helpStripMenuItem1_Click;
            // 
            // productCodeTextBox
            // 
            productCodeTextBox.Location = new Point(568, 57);
            productCodeTextBox.Name = "productCodeTextBox";
            productCodeTextBox.Size = new Size(117, 23);
            productCodeTextBox.TabIndex = 1;
            productCodeTextBox.TextChanged += productCodeTextBox_TextChanged;
            // 
            // addProductBtn
            // 
            addProductBtn.Location = new Point(568, 229);
            addProductBtn.Name = "addProductBtn";
            addProductBtn.Size = new Size(117, 28);
            addProductBtn.TabIndex = 3;
            addProductBtn.Text = "Add";
            addProductBtn.UseVisualStyleBackColor = true;
            addProductBtn.Click += addProductBtn_Click_1;
            // 
            // payButton
            // 
            payButton.Location = new Point(5, 411);
            payButton.Name = "payButton";
            payButton.Size = new Size(165, 46);
            payButton.TabIndex = 5;
            payButton.Text = "Pay";
            payButton.UseVisualStyleBackColor = true;
            payButton.Click += payButton_Click;
            // 
            // CategoriesPanel
            // 
            CategoriesPanel.BackColor = SystemColors.ControlLightLight;
            CategoriesPanel.Location = new Point(691, 41);
            CategoriesPanel.Name = "CategoriesPanel";
            CategoriesPanel.Size = new Size(148, 398);
            CategoriesPanel.TabIndex = 9;
            // 
            // editProductBtn
            // 
            editProductBtn.Location = new Point(568, 263);
            editProductBtn.Name = "editProductBtn";
            editProductBtn.Size = new Size(117, 28);
            editProductBtn.TabIndex = 10;
            editProductBtn.Text = "Edit";
            editProductBtn.UseVisualStyleBackColor = true;
            editProductBtn.Click += editProductBtn_Click;
            // 
            // deleteProductBtn
            // 
            deleteProductBtn.Location = new Point(568, 297);
            deleteProductBtn.Name = "deleteProductBtn";
            deleteProductBtn.Size = new Size(117, 28);
            deleteProductBtn.TabIndex = 11;
            deleteProductBtn.Text = "Delete";
            deleteProductBtn.UseVisualStyleBackColor = true;
            deleteProductBtn.Click += deleteProductBtn_Click;
            // 
            // ProductsPanel
            // 
            ProductsPanel.AutoScroll = true;
            ProductsPanel.BackColor = SystemColors.ControlLightLight;
            ProductsPanel.Location = new Point(854, 32);
            ProductsPanel.Name = "ProductsPanel";
            ProductsPanel.Size = new Size(443, 407);
            ProductsPanel.TabIndex = 14;
            ProductsPanel.Paint += ProductsPanel_Paint;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(568, 99);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(117, 25);
            searchButton.TabIndex = 15;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 16;
            label1.Text = "POS";
            // 
            // Clear
            // 
            Clear.Location = new Point(432, 411);
            Clear.Name = "Clear";
            Clear.Size = new Size(117, 28);
            Clear.TabIndex = 17;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // OrderPanel
            // 
            OrderPanel.BackColor = SystemColors.ControlLightLight;
            OrderPanel.Location = new Point(5, 52);
            OrderPanel.Name = "OrderPanel";
            OrderPanel.Size = new Size(544, 348);
            OrderPanel.TabIndex = 18;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(568, 200);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(117, 23);
            textBox1.TabIndex = 19;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(568, 182);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 20;
            label2.Text = "Barcode";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 468);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(OrderPanel);
            Controls.Add(Clear);
            Controls.Add(label1);
            Controls.Add(searchButton);
            Controls.Add(ProductsPanel);
            Controls.Add(deleteProductBtn);
            Controls.Add(editProductBtn);
            Controls.Add(CategoriesPanel);
            Controls.Add(payButton);
            Controls.Add(addProductBtn);
            Controls.Add(productCodeTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem categoriesToolStripMenuItem;
        private ToolStripMenuItem helpStripMenuItem1;
        private TextBox productCodeTextBox;
        private Button addProductBtn;
        private Button payButton;
        private Panel CategoriesPanel;
        private Button editProductBtn;
        private Button deleteProductBtn;
        private DataGridView dataGridView1;
        private FlowLayoutPanel ProductsPanel;
        private Button searchButton;
        private Label label1;
        private Button Clear;
        private Panel OrderPanel;
        private TextBox textBox1;
        private Label label2;
    }
}

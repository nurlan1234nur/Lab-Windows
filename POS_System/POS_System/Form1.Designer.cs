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
            yutyuiToolStripMenuItem = new ToolStripMenuItem();
            hjkjhlToolStripMenuItem = new ToolStripMenuItem();
            nmnlToolStripMenuItem = new ToolStripMenuItem();
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            helpStripMenuItem1 = new ToolStripMenuItem();
            productCodeTextBox = new TextBox();
            addProductBtn = new Button();
            cashPaidTextBox = new TextBox();
            payButton = new Button();
            CategoriesPanel = new Panel();
            editProductBtn = new Button();
            deleteProductBtn = new Button();
            dataGridView2 = new DataGridView();
            ProductsPanel = new Panel();
            searchButton = new Button();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            productToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { yutyuiToolStripMenuItem, hjkjhlToolStripMenuItem, nmnlToolStripMenuItem });
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.Size = new Size(61, 20);
            productToolStripMenuItem.Text = "product";
            productToolStripMenuItem.Click += toolStripMenuItem1_Click;
            // 
            // yutyuiToolStripMenuItem
            // 
            yutyuiToolStripMenuItem.Name = "yutyuiToolStripMenuItem";
            yutyuiToolStripMenuItem.Size = new Size(107, 22);
            yutyuiToolStripMenuItem.Text = "yutyui";
            // 
            // hjkjhlToolStripMenuItem
            // 
            hjkjhlToolStripMenuItem.Name = "hjkjhlToolStripMenuItem";
            hjkjhlToolStripMenuItem.Size = new Size(107, 22);
            hjkjhlToolStripMenuItem.Text = "hjkjhl";
            // 
            // nmnlToolStripMenuItem
            // 
            nmnlToolStripMenuItem.Name = "nmnlToolStripMenuItem";
            nmnlToolStripMenuItem.Size = new Size(107, 22);
            nmnlToolStripMenuItem.Text = "nm,nl";
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
            productCodeTextBox.Location = new Point(581, 52);
            productCodeTextBox.Name = "productCodeTextBox";
            productCodeTextBox.Size = new Size(138, 23);
            productCodeTextBox.TabIndex = 1;
            // 
            // addProductBtn
            // 
            addProductBtn.Location = new Point(581, 224);
            addProductBtn.Name = "addProductBtn";
            addProductBtn.Size = new Size(138, 28);
            addProductBtn.TabIndex = 3;
            addProductBtn.Text = "Add";
            addProductBtn.UseVisualStyleBackColor = true;
            addProductBtn.Click += addProductBtn_Click_1;
            // 
            // cashPaidTextBox
            // 
            cashPaidTextBox.Location = new Point(22, 463);
            cashPaidTextBox.Name = "cashPaidTextBox";
            cashPaidTextBox.Size = new Size(116, 23);
            cashPaidTextBox.TabIndex = 4;
            // 
            // payButton
            // 
            payButton.Location = new Point(22, 492);
            payButton.Name = "payButton";
            payButton.Size = new Size(91, 48);
            payButton.TabIndex = 5;
            payButton.Text = "Pay";
            payButton.UseVisualStyleBackColor = true;
            // 
            // CategoriesPanel
            // 
            CategoriesPanel.BackColor = SystemColors.ControlLightLight;
            CategoriesPanel.Location = new Point(734, 27);
            CategoriesPanel.Name = "CategoriesPanel";
            CategoriesPanel.Size = new Size(148, 513);
            CategoriesPanel.TabIndex = 9;
            CategoriesPanel.Paint += CategoriesPanel_Paint;
            // 
            // editProductBtn
            // 
            editProductBtn.Location = new Point(581, 258);
            editProductBtn.Name = "editProductBtn";
            editProductBtn.Size = new Size(138, 28);
            editProductBtn.TabIndex = 10;
            editProductBtn.Text = "Edit";
            editProductBtn.UseVisualStyleBackColor = true;
            editProductBtn.Click += editProductBtn_Click;
            // 
            // deleteProductBtn
            // 
            deleteProductBtn.Location = new Point(581, 292);
            deleteProductBtn.Name = "deleteProductBtn";
            deleteProductBtn.Size = new Size(138, 28);
            deleteProductBtn.TabIndex = 11;
            deleteProductBtn.Text = "Delete";
            deleteProductBtn.UseVisualStyleBackColor = true;
            deleteProductBtn.Click += deleteProductBtn_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 52);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(563, 368);
            dataGridView2.TabIndex = 13;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // ProductsPanel
            // 
            ProductsPanel.BackColor = SystemColors.ControlLightLight;
            ProductsPanel.Location = new Point(905, 27);
            ProductsPanel.Name = "ProductsPanel";
            ProductsPanel.Size = new Size(607, 522);
            ProductsPanel.TabIndex = 14;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(581, 94);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(138, 25);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 561);
            Controls.Add(label1);
            Controls.Add(searchButton);
            Controls.Add(ProductsPanel);
            Controls.Add(dataGridView2);
            Controls.Add(deleteProductBtn);
            Controls.Add(editProductBtn);
            Controls.Add(CategoriesPanel);
            Controls.Add(payButton);
            Controls.Add(cashPaidTextBox);
            Controls.Add(addProductBtn);
            Controls.Add(productCodeTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private TextBox cashPaidTextBox;
        private Button payButton;
        private ToolStripMenuItem yutyuiToolStripMenuItem;
        private ToolStripMenuItem hjkjhlToolStripMenuItem;
        private ToolStripMenuItem nmnlToolStripMenuItem;
        private Panel CategoriesPanel;
        private Button editProductBtn;
        private Button deleteProductBtn;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Panel ProductsPanel;
        private Button searchButton;
        private Label label1;
    }
}

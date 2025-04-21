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
            quantityTextBox = new TextBox();
            addProductButton = new Button();
            cashPaidTextBox = new TextBox();
            payButton = new Button();
            cartListView = new ListView();
            productNameTextBox = new TextBox();
            productPriceTextBox = new TextBox();
            yutyuiToolStripMenuItem = new ToolStripMenuItem();
            hjkjhlToolStripMenuItem = new ToolStripMenuItem();
            nmnlToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { productToolStripMenuItem, categoriesToolStripMenuItem, helpStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
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
            productCodeTextBox.Location = new Point(21, 146);
            productCodeTextBox.Name = "productCodeTextBox";
            productCodeTextBox.Size = new Size(100, 23);
            productCodeTextBox.TabIndex = 1;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(21, 188);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(100, 23);
            quantityTextBox.TabIndex = 2;
            // 
            // addProductButton
            // 
            addProductButton.Location = new Point(29, 231);
            addProductButton.Name = "addProductButton";
            addProductButton.Size = new Size(75, 23);
            addProductButton.TabIndex = 3;
            addProductButton.Text = "Add";
            addProductButton.UseVisualStyleBackColor = true;
            // 
            // cashPaidTextBox
            // 
            cashPaidTextBox.Location = new Point(272, 146);
            cashPaidTextBox.Name = "cashPaidTextBox";
            cashPaidTextBox.Size = new Size(100, 23);
            cashPaidTextBox.TabIndex = 4;
            // 
            // payButton
            // 
            payButton.Location = new Point(272, 187);
            payButton.Name = "payButton";
            payButton.Size = new Size(75, 23);
            payButton.TabIndex = 5;
            payButton.Text = "Pay";
            payButton.UseVisualStyleBackColor = true;
            // 
            // cartListView
            // 
            cartListView.Location = new Point(432, 27);
            cartListView.Name = "cartListView";
            cartListView.Size = new Size(356, 411);
            cartListView.TabIndex = 6;
            cartListView.UseCompatibleStateImageBehavior = false;
            // 
            // productNameTextBox
            // 
            productNameTextBox.Location = new Point(127, 146);
            productNameTextBox.Name = "productNameTextBox";
            productNameTextBox.Size = new Size(100, 23);
            productNameTextBox.TabIndex = 7;
            // 
            // productPriceTextBox
            // 
            productPriceTextBox.Location = new Point(127, 188);
            productPriceTextBox.Name = "productPriceTextBox";
            productPriceTextBox.Size = new Size(100, 23);
            productPriceTextBox.TabIndex = 8;
            // 
            // yutyuiToolStripMenuItem
            // 
            yutyuiToolStripMenuItem.Name = "yutyuiToolStripMenuItem";
            yutyuiToolStripMenuItem.Size = new Size(180, 22);
            yutyuiToolStripMenuItem.Text = "yutyui";
            // 
            // hjkjhlToolStripMenuItem
            // 
            hjkjhlToolStripMenuItem.Name = "hjkjhlToolStripMenuItem";
            hjkjhlToolStripMenuItem.Size = new Size(180, 22);
            hjkjhlToolStripMenuItem.Text = "hjkjhl";
            // 
            // nmnlToolStripMenuItem
            // 
            nmnlToolStripMenuItem.Name = "nmnlToolStripMenuItem";
            nmnlToolStripMenuItem.Size = new Size(180, 22);
            nmnlToolStripMenuItem.Text = "nm,nl";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(productPriceTextBox);
            Controls.Add(productNameTextBox);
            Controls.Add(cartListView);
            Controls.Add(payButton);
            Controls.Add(cashPaidTextBox);
            Controls.Add(addProductButton);
            Controls.Add(quantityTextBox);
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
        private TextBox quantityTextBox;
        private Button addProductButton;
        private TextBox cashPaidTextBox;
        private Button payButton;
        private ListView cartListView;
        private TextBox productNameTextBox;
        private TextBox productPriceTextBox;
        private ToolStripMenuItem yutyuiToolStripMenuItem;
        private ToolStripMenuItem hjkjhlToolStripMenuItem;
        private ToolStripMenuItem nmnlToolStripMenuItem;
    }
}

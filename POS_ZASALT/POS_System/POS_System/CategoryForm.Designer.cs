namespace POS_System
{
    partial class CategoryForm
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
            CategoriesPanel = new FlowLayoutPanel();
            searchTextBox = new TextBox();
            searchButton = new Button();
            categoryNameTextBox = new TextBox();
            saveButton = new Button();
            clearButton = new Button();
            label2 = new Label();
            addBtn = new Button();
            AddCategoryTextBox = new TextBox();
            SuspendLayout();
            // 
            // CategoriesPanel
            // 
            CategoriesPanel.AutoScroll = true;
            CategoriesPanel.BackColor = SystemColors.ControlLightLight;
            CategoriesPanel.FlowDirection = FlowDirection.TopDown;
            CategoriesPanel.Location = new Point(12, 12);
            CategoriesPanel.Name = "CategoriesPanel";
            CategoriesPanel.Size = new Size(576, 268);
            CategoriesPanel.TabIndex = 0;
            CategoriesPanel.WrapContents = false;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(12, 318);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Ангилал хайх...";
            searchTextBox.Size = new Size(200, 23);
            searchTextBox.TabIndex = 1;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(218, 318);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 2;
            searchButton.Text = "🔍 Хайх";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // categoryNameTextBox
            // 
            categoryNameTextBox.Location = new Point(12, 373);
            categoryNameTextBox.Name = "categoryNameTextBox";
            categoryNameTextBox.PlaceholderText = "Ангилалын нэр оруулах...";
            categoryNameTextBox.Size = new Size(200, 23);
            categoryNameTextBox.TabIndex = 4;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(218, 373);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 5;
            saveButton.Text = "Шинэчлэх";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(299, 373);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 23);
            clearButton.TabIndex = 6;
            clearButton.Text = "Устгах";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 355);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 8;
            label2.Text = "Ангилалын нэр";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(513, 317);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 9;
            addBtn.Text = "Нэмэх";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // AddCategoryTextBox
            // 
            AddCategoryTextBox.Location = new Point(307, 319);
            AddCategoryTextBox.Name = "AddCategoryTextBox";
            AddCategoryTextBox.PlaceholderText = "Ангилал нэмэх...";
            AddCategoryTextBox.Size = new Size(200, 23);
            AddCategoryTextBox.TabIndex = 10;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 400);
            Controls.Add(AddCategoryTextBox);
            Controls.Add(addBtn);
            Controls.Add(label2);
            Controls.Add(clearButton);
            Controls.Add(saveButton);
            Controls.Add(categoryNameTextBox);
            Controls.Add(searchButton);
            Controls.Add(searchTextBox);
            Controls.Add(CategoriesPanel);
            Name = "CategoryForm";
            Text = "Ангилал удирдах";
            Load += CategoryForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel CategoriesPanel;
        private TextBox searchTextBox;
        private Button searchButton;
        private TextBox categoryNameTextBox;
        private Button saveButton;
        private Button clearButton;
        private Label label2;
        private Button addBtn;
        private TextBox AddCategoryTextBox;
    }
}
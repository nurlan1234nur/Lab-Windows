namespace WinFormsApp2
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button0 = new Button();
            textBox1 = new TextBox();
            button10 = new Button();
            buttonPlus = new Button();
            buttonMinus = new Button();
            buttonEquals = new Button();
            buttonAddNumbertoMemory = new Button();
            AddtoMemoryItem = new Button();
            SubstractFromMemoryItem = new Button();
            buttonClearMemory = new Button();
            ResetResult = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F);
            button1.Location = new Point(12, 358);
            button1.Name = "button1";
            button1.Size = new Size(85, 95);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F);
            button2.Location = new Point(103, 358);
            button2.Name = "button2";
            button2.Size = new Size(85, 95);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14.25F);
            button3.Location = new Point(194, 358);
            button3.Name = "button3";
            button3.Size = new Size(85, 95);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 14.25F);
            button4.Location = new Point(12, 257);
            button4.Name = "button4";
            button4.Size = new Size(85, 95);
            button4.TabIndex = 3;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14.25F);
            button5.Location = new Point(103, 257);
            button5.Name = "button5";
            button5.Size = new Size(85, 95);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 14.25F);
            button6.Location = new Point(194, 257);
            button6.Name = "button6";
            button6.Size = new Size(85, 95);
            button6.TabIndex = 5;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 14.25F);
            button7.Location = new Point(12, 156);
            button7.Name = "button7";
            button7.Size = new Size(85, 95);
            button7.TabIndex = 6;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 14.25F);
            button8.Location = new Point(103, 156);
            button8.Name = "button8";
            button8.Size = new Size(85, 95);
            button8.TabIndex = 7;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 14.25F);
            button9.Location = new Point(194, 156);
            button9.Name = "button9";
            button9.Size = new Size(85, 95);
            button9.TabIndex = 8;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button0
            // 
            button0.Font = new Font("Segoe UI", 14.25F);
            button0.Location = new Point(103, 459);
            button0.Name = "button0";
            button0.Size = new Size(85, 95);
            button0.TabIndex = 9;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += button0_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(12, 40);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(449, 83);
            textBox1.TabIndex = 11;
            textBox1.TextAlign = HorizontalAlignment.Right;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 14.25F);
            button10.Location = new Point(12, 459);
            button10.Name = "button10";
            button10.Size = new Size(85, 95);
            button10.TabIndex = 12;
            button10.Text = ".";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // buttonPlus
            // 
            buttonPlus.Font = new Font("Segoe UI", 14.25F);
            buttonPlus.Location = new Point(285, 156);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(85, 95);
            buttonPlus.TabIndex = 13;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = true;
            buttonPlus.Click += buttonPlus_Click;
            // 
            // buttonMinus
            // 
            buttonMinus.Font = new Font("Segoe UI", 14.25F);
            buttonMinus.Location = new Point(285, 257);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.Size = new Size(85, 95);
            buttonMinus.TabIndex = 14;
            buttonMinus.Text = "-";
            buttonMinus.UseVisualStyleBackColor = true;
            buttonMinus.Click += buttonMinus_Click;
            // 
            // buttonEquals
            // 
            buttonEquals.Font = new Font("Segoe UI", 14.25F);
            buttonEquals.Location = new Point(285, 358);
            buttonEquals.Name = "buttonEquals";
            buttonEquals.Size = new Size(85, 95);
            buttonEquals.TabIndex = 15;
            buttonEquals.Text = "=";
            buttonEquals.UseVisualStyleBackColor = true;
            buttonEquals.Click += buttonEquals_Click;
            // 
            // buttonAddNumbertoMemory
            // 
            buttonAddNumbertoMemory.Font = new Font("Segoe UI", 14.25F);
            buttonAddNumbertoMemory.Location = new Point(376, 459);
            buttonAddNumbertoMemory.Name = "buttonAddNumbertoMemory";
            buttonAddNumbertoMemory.Size = new Size(85, 95);
            buttonAddNumbertoMemory.TabIndex = 16;
            buttonAddNumbertoMemory.Text = "MS";
            buttonAddNumbertoMemory.UseVisualStyleBackColor = true;
            buttonAddNumbertoMemory.Click += buttonAddNumbertoMemory_Click;
            // 
            // AddtoMemoryItem
            // 
            AddtoMemoryItem.Font = new Font("Segoe UI", 14.25F);
            AddtoMemoryItem.Location = new Point(376, 156);
            AddtoMemoryItem.Name = "AddtoMemoryItem";
            AddtoMemoryItem.Size = new Size(85, 95);
            AddtoMemoryItem.TabIndex = 17;
            AddtoMemoryItem.Text = "M+";
            AddtoMemoryItem.UseVisualStyleBackColor = true;
            AddtoMemoryItem.Click += AddtoMemoryItem_Click;
            // 
            // SubstractFromMemoryItem
            // 
            SubstractFromMemoryItem.Font = new Font("Segoe UI", 14.25F);
            SubstractFromMemoryItem.Location = new Point(376, 257);
            SubstractFromMemoryItem.Name = "SubstractFromMemoryItem";
            SubstractFromMemoryItem.Size = new Size(85, 95);
            SubstractFromMemoryItem.TabIndex = 18;
            SubstractFromMemoryItem.Text = "M-";
            SubstractFromMemoryItem.UseVisualStyleBackColor = true;
            SubstractFromMemoryItem.Click += SubstractFromMemoryItem_Click;
            // 
            // buttonClearMemory
            // 
            buttonClearMemory.Font = new Font("Segoe UI", 14.25F);
            buttonClearMemory.Location = new Point(376, 358);
            buttonClearMemory.Name = "buttonClearMemory";
            buttonClearMemory.Size = new Size(85, 95);
            buttonClearMemory.TabIndex = 19;
            buttonClearMemory.Text = "MC";
            buttonClearMemory.UseVisualStyleBackColor = true;
            buttonClearMemory.Click += buttonClearMemory_Click;
            // 
            // ResetResult
            // 
            ResetResult.Font = new Font("Segoe UI", 14.25F);
            ResetResult.Location = new Point(194, 459);
            ResetResult.Name = "ResetResult";
            ResetResult.Size = new Size(85, 95);
            ResetResult.TabIndex = 20;
            ResetResult.Text = "C";
            ResetResult.UseVisualStyleBackColor = true;
            ResetResult.Click += ResetResult_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(467, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(278, 527);
            panel1.TabIndex = 22;
            panel1.Paint += panel1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 601);
            Controls.Add(panel1);
            Controls.Add(ResetResult);
            Controls.Add(buttonClearMemory);
            Controls.Add(SubstractFromMemoryItem);
            Controls.Add(AddtoMemoryItem);
            Controls.Add(buttonAddNumbertoMemory);
            Controls.Add(buttonEquals);
            Controls.Add(buttonMinus);
            Controls.Add(buttonPlus);
            Controls.Add(button10);
            Controls.Add(textBox1);
            Controls.Add(button0);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button0;
        private TextBox textBox1;
        private Button button10;
        private Button buttonPlus;
        private Button buttonMinus;
        private Button buttonEquals;
        private Button buttonAddNumbertoMemory;
        private Button AddtoMemoryItem;
        private Button SubstractFromMemoryItem;
        private Button buttonClearMemory;
        private Button ResetResult;
        private Panel panel1;
    }
}

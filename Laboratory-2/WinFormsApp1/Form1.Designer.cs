using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        // Form load event
        private void Form1_Load(object sender, EventArgs e)
        {
            lblResult.Text = "0"; // Initialize the label to show 0 initially
        }

        // Button click event for numbers (0-9)
        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblResult.Text == "0" || lblResult.Text == "+" || lblResult.Text == "-")
                lblResult.Text = btn.Text;
            else
                lblResult.Text += btn.Text;
        }

        // Button click event for operations (+, -)
        private void Operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            firstNumber = Convert.ToDouble(lblResult.Text);
            operation = btn.Text;
            lblResult.Text = "0"; // Reset to 0 to input the second number
        }

        // Equals button click event
        private void btnEquals_Click(object sender, EventArgs e)
        {
            secondNumber = Convert.ToDouble(lblResult.Text);
            double result = 0;

            if (operation == "+")
                result = firstNumber + secondNumber;
            else if (operation == "-")
                result = firstNumber - secondNumber;

            lblResult.Text = result.ToString();
        }

        // Clear button click event
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
        }

        private void InitializeComponent()
        {
            lblResult = new Label();
            btn1 = new Button();
            btn0 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnClear = new Button();
            btnEquals = new Button();
            btnPlus = new Button();
            btnMinus = new Button();
            SuspendLayout();
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(109, 201);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(13, 15);
            lblResult.TabIndex = 0;
            lblResult.Text = "0";
            lblResult.Click += lblResult_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(8, 281);
            btn1.Name = "btn1";
            btn1.Size = new Size(64, 47);
            btn1.TabIndex = 1;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += Number_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(78, 431);
            btn0.Name = "btn0";
            btn0.Size = new Size(64, 47);
            btn0.TabIndex = 10;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += Number_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(78, 281);
            btn2.Name = "btn2";
            btn2.Size = new Size(64, 47);
            btn2.TabIndex = 2;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += Number_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(148, 281);
            btn3.Name = "btn3";
            btn3.Size = new Size(64, 47);
            btn3.TabIndex = 3;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += Number_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(8, 331);
            btn4.Name = "btn4";
            btn4.Size = new Size(64, 47);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += Number_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(78, 331);
            btn5.Name = "btn5";
            btn5.Size = new Size(64, 47);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += Number_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(148, 331);
            btn6.Name = "btn6";
            btn6.Size = new Size(64, 47);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += Number_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(8, 381);
            btn7.Name = "btn7";
            btn7.Size = new Size(64, 47);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += Number_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(78, 381);
            btn8.Name = "btn8";
            btn8.Size = new Size(64, 47);
            btn8.TabIndex = 8;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += Number_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(148, 381);
            btn9.Name = "btn9";
            btn9.Size = new Size(64, 47);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += Number_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(218, 281);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(64, 47);
            btnClear.TabIndex = 11;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnEquals
            // 
            btnEquals.Location = new Point(218, 331);
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(64, 47);
            btnEquals.TabIndex = 12;
            btnEquals.Text = "=";
            btnEquals.UseVisualStyleBackColor = true;
            btnEquals.Click += btnEquals_Click;
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(218, 381);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(64, 47);
            btnPlus.TabIndex = 13;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += Operation_Click;
            // 
            // btnMinus
            // 
            btnMinus.Location = new Point(218, 431);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(64, 47);
            btnMinus.TabIndex = 14;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += Operation_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(497, 486);
            Controls.Add(btnMinus);
            Controls.Add(btnPlus);
            Controls.Add(btnEquals);
            Controls.Add(btnClear);
            Controls.Add(btn0);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(lblResult);
            Name = "Form1";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblResult;
        private Button btn1;
        private Button btn0;
        private Button btn2;
        private Button btn3;

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private Button btn4;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnClear;
        private Button btnPlus;
        private Button btnMinus;
        private Button btnEquals;

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }
}

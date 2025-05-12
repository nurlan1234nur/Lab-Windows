using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace POS_System
{
    public partial class Payment : Form
    {
        public decimal TotalAmount { get; set; }
        public Payment(decimal totalAmount)
        {
            InitializeComponent();
            TotalAmount = totalAmount;
            AmountTextBox.Text = TotalAmount.ToString();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Paid_textbox.Text += button.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = Paid_textbox.Text;

            Paid_textbox.Text = text.Substring(0, text.Length - 1);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int y = int.Parse(Paid_textbox.Text);
            int x = (int)(y - TotalAmount);
            Change.Text = x.ToString();
        }
    }
}

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
        private bool isCardPayment = false;
        public List<Order> ReceiptItems;

        public Payment(decimal totalAmount, List<Order> receiptItems)
        {
            InitializeComponent();
            TotalAmount = totalAmount;
            AmountTextBox.Text = TotalAmount.ToString();
            DisableNumberButtons();
            ReceiptItems = receiptItems;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Cash button click
            isCardPayment = false;
            EnableNumberButtons();
            Paid_textbox.Text = "";
            Change.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Card button click
            isCardPayment = true;
            DisableNumberButtons();
            Paid_textbox.Text = "0";
            Change.Text = "0";
        }

        private void EnableNumberButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Tag?.ToString() == "number")
                {
                    button.Enabled = true;
                }
            }
        }

        private void DisableNumberButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Tag?.ToString() == "number")
                {
                    button.Enabled = false;
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // Confirm button click
            if (isCardPayment)
            {
            }
            else
            {
                if (decimal.TryParse(Paid_textbox.Text, out decimal paidAmount))
                {
                    if (paidAmount >= TotalAmount)
                    {
                        
                    }
                    else
                    {
                        return;
                    }
                }
            }

            // Print receipt
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Paid_textbox.Text += button.Text;
                CalculateChange();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Paid_textbox.Text.Length > 0)
            {
                string text = Paid_textbox.Text;
                Paid_textbox.Text = text.Substring(0, text.Length - 1);
                CalculateChange();
            }
        }

        private void CalculateChange()
        {
            if (decimal.TryParse(Paid_textbox.Text, out decimal paidAmount))
            {
                decimal change = paidAmount - TotalAmount;
                Change.Text = change.ToString("0.00");
            }
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
            Print print = new Print(ReceiptItems, double.Parse(Paid_textbox.Text), double.Parse(Change.Text), double.Parse(AmountTextBox.Text));
            print.PrintReceipt();
        }
    }
}

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
using Library.model;
using Library.Service;

namespace POS_System
{
    public partial class Payment : Form
    {
        public PaymentService paymentService;
        public double TotalAmount { get; set; }
        private bool isPaid = false;
        public Order orders;

        /// <summary>
        /// Төлбөр төлөх форм үүсгэх
        /// </summary>
        public Payment(Order receiptItems)
        {
            InitializeComponent();
            paymentService = new PaymentService();
            DisableNumberButtons();
            orders = receiptItems;
            TotalAmount = orders.TotalAmount;
            AmountTextBox.Text = TotalAmount.ToString();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Картаар төлөх товч дарахад
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            isPaid = true;
            DisableNumberButtons();
            Paid_textbox.Text = "0";
            Change.Text = "0";
        }

        /// <summary>
        /// Тоо оруулах товчнуудыг идэвхжүүлэх
        /// </summary>
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

        /// <summary>
        /// Тоо оруулах товчнуудыг идэвхгүй болгох
        /// </summary>
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

        /// <summary>
        /// Тоо оруулах товч дарахад
        /// </summary>
        private void button10_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Paid_textbox.Text += button.Text;
                CalculateChange();
            }
        }

        /// <summary>
        /// Устгах товч дарахад
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Paid_textbox.Text.Length > 0)
            {
                string text = Paid_textbox.Text;
                Paid_textbox.Text = text.Substring(0, text.Length - 1);
                CalculateChange();
            }
        }

        /// <summary>
        /// Үлдэгдэл мөнгийг тооцоолох
        /// </summary>
        private void CalculateChange()
        {
            if (double.TryParse(Paid_textbox.Text, out double paidAmount))
            {
                var change = paymentService.calculateChange(paidAmount, TotalAmount);
                Change.Text = change.ToString();
                isPaid = paymentService.checkIsPaid(paidAmount, TotalAmount);    
            }
        }

        /// <summary>
        /// Хаах товч дарахад
        /// </summary>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Баталгаажуулах товч дарахад
        /// </summary>
        private void button15_Click(object sender, EventArgs e)
        {
            if (isPaid)
            {
                Print print = new Print(orders, double.Parse(Paid_textbox.Text), double.Parse(Change.Text));
                print.PrintReceipt();
            }
            this.Close();
        }

        /// <summary>
        /// Бэлнээр төлөх товч дарахад
        /// </summary>
        private void cash_Click(object sender, EventArgs e)
        {
            EnableNumberButtons();
            Paid_textbox.Text = "";
            Change.Text = "";
        }

        private void card_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using Library.model;

namespace Library.Service
{
    public class Print
    {
        private Order orders;
        private double totalAmount;
        private double paidAmount;
        private double changeAmount;

        /// <summary>
        /// Баримт хэвлэх үйлчилгээг үүсгэх
        /// </summary>
        public Print(Order orders, double amount, double change)
        {
            this.orders = orders;
            totalAmount = orders.TotalAmount;
            paidAmount = amount;
            changeAmount = change;
        }

        /// <summary>
        /// Баримт хэвлэх
        /// </summary>
        public void PrintReceipt()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    printDocument.Print();
                }
            }
        }

        /// <summary>
        /// Баримтын агуулгыг хэвлэх
        /// </summary>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);
            float yPos = 10;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;
            graphics.DrawString("Receipt", font, Brushes.Black, leftMargin, yPos);
            yPos += font.GetHeight(graphics) + 10;
            var receiptItems = orders.OrderItems;
            
            // Print total amount
            graphics.DrawString($"Total: {totalAmount:C}", font, Brushes.Black, leftMargin, yPos);
            yPos += font.GetHeight(graphics);
            // Print paid amount
            graphics.DrawString($"Paid: {paidAmount:C}", font, Brushes.Black, leftMargin, yPos);
            yPos += font.GetHeight(graphics);
            // Print change amount
            graphics.DrawString($"Change: {changeAmount:C}", font, Brushes.Black, leftMargin, yPos);
        }
    }
}

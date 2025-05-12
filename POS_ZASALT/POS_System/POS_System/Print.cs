using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Drawing.Printing;

namespace POS_System
{
    internal class Print
    {
        private List<Order> receiptItems;
        private decimal totalAmount;
        private decimal paidAmount;
        private decimal changeAmount;

    public Print(List<Order> receiptItems, double amount, double change, double totalPrice)
        {
            this.receiptItems = receiptItems;
            this.totalAmount = (decimal)totalPrice;
            this.paidAmount = (decimal)amount;
            this.changeAmount = (decimal)change;
        }

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
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);
            float yPos = 10;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;
            // Print receipt header
            graphics.DrawString("Receipt", font, Brushes.Black, leftMargin, yPos);
            yPos += font.GetHeight(graphics) + 10;
            // Print receipt items
            foreach (var item in receiptItems)
            {
                string line = $"{item.ItemName} - {item.Quantity} x {item.Price:C} = {item.TotalPrice:C}";
                graphics.DrawString(line, font, Brushes.Black, leftMargin, yPos);
                yPos += font.GetHeight(graphics);
            }
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

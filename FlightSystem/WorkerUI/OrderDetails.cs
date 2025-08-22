using FlightSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkerUI.Service;

namespace WorkerUI
{
    public partial class OrderDetails : Form
    {
        private UserApiClientAdmin UserApiClient = new UserApiClientAdmin(new HttpClient());
        private OrderApiClient OrderApiClient = new OrderApiClient(new HttpClient());
        private string? CurrentUserPassportNumber;
        private User? CurrentUser = null;
        private List<Order> Orders = new List<Order>();
        public Form? PreviousForm { get; set; }

        public OrderDetails()
        {
            InitializeComponent();
            SetupUI();
        }
        private void SetupUI()
        {
            this.Text = "User Orders";
            this.MinimumSize = new Size(800, 600);
            OrdersPanel.AutoScroll = true;
            OrdersPanel.Padding = new Padding(10);
        }

        private async void SearchBtn_Click(object sender, EventArgs e)
        {
            OrdersPanel.Controls.Clear();
            CurrentUserPassportNumber = UserPassportTxtBox.Text.Trim();
            if (string.IsNullOrEmpty(CurrentUserPassportNumber))
            {
                MessageBox.Show("Please enter your passport number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Хэрэглэгчийг дуудаж авах
                CurrentUser = await UserApiClient.GetUserByPassportAsync(CurrentUserPassportNumber);
                Console.WriteLine($"Current User: {CurrentUser?.Email}"); // Debug log

                if (CurrentUser == null)
                {
                    DisplayMessage("User not found.");
                    return;
                }

                // Захиалгуудыг дуудаж авах
                Orders = await OrderApiClient.GetOrdersByCustomerIdAsync(CurrentUserPassportNumber);

                if (Orders.Count == 0)
                {
                    DisplayMessage("No orders found for this user.");
                    return;
                }

                // Panel-д харуулах
                DisplayOrdersInPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayMessage(string message)
        {
            OrdersPanel.Controls.Clear();
            Label lbl = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(10, 10)
            };
            OrdersPanel.Controls.Add(lbl);
        }

        private void DisplayOrdersInPanel()
        {
            OrdersPanel.Controls.Clear();

            foreach (var order in Orders)
            {
                Panel orderPanel = new Panel
                {
                    Width = OrdersPanel.ClientSize.Width - 25,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5),
                    BackColor = Color.White
                };

                // Shadow effect simulation
                orderPanel.Paint += (s, e) =>
                {
                    ControlPaint.DrawBorder(e.Graphics, orderPanel.ClientRectangle,
                        Color.LightGray, 1, ButtonBorderStyle.Solid,
                        Color.LightGray, 1, ButtonBorderStyle.Solid,
                        Color.LightGray, 1, ButtonBorderStyle.Solid,
                        Color.LightGray, 1, ButtonBorderStyle.Solid);
                };

                Label lblInfo = new Label
                {
                    Text = $"User Passport: {order.UserPassportNumber} | Price: {order.UnitPrice} | Status: {order.BookingStatus}",
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    AutoSize = true,
                    Location = new Point(10, 15)
                };

                Button reserveBtn = new Button
                {
                    Text = "Reserve Seat",
                    BackColor = Color.FromArgb(0, 120, 215),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(120, 35),
                    Location = new Point(orderPanel.Width - 140, 30),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Tag = order
                };
                reserveBtn.FlatAppearance.BorderSize = 0;
                reserveBtn.Click += ReserveBtn_Click;

                orderPanel.Controls.Add(lblInfo);
                orderPanel.Controls.Add(reserveBtn);
                OrdersPanel.Controls.Add(orderPanel);
            }
        }

        private void ReserveBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Order order)
            {
                MessageBox.Show($"Reserving seat for Order ID: {order.Id}");
                // энд Reserve Seat API дуудах код оруулна
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to go back?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                PreviousForm?.Show();
                this.Close();
            }
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
           
        }
    }
}

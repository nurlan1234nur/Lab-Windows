using System;
using System.Windows.Forms;
using Library.model;
using Library.Service;

namespace POS_System
{
    public partial class orderItem : UserControl
    {
        private OrderItem _orderItem;
        private OrderService _orderService;
        public event EventHandler ItemUpdated;

        public orderItem(OrderItem orderitem, OrderService orderService)
        {
            InitializeComponent();
            _orderItem = orderitem;
            _orderService = orderService;

            UpdateUI();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            ProductIncreaseBtn.Click += ProductIncreaseBtn_Click;
            ProductDecreaseBtn.Click += ProductDecreaseBtn_Click;
        }

        private void UpdateUI()
        {
            try
            {
                ProductNameLabel.Text = _orderItem.ProductName;
                ProductQuantityLabel.Text = _orderItem.Quantity.ToString();
                ProductPricelabel.Text = _orderItem.UnitPrice.ToString("C");
                ProductDiscountLabel.Text = _orderItem.Discount.ToString("P");
                ProductTotalPriceLabel.Text = _orderItem.TotalPrice.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Мэдээлэл харуулахад алдаа гарлаа: {ex.Message}");
            }
        }

        private void ProductIncreaseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _orderItem.Quantity++;
                _orderItem.TotalPrice = CalculateTotalPrice();
                UpdateUI();
                ItemUpdated?.Invoke(this, EventArgs.Empty);
                _orderService.UpdateOrderItem(_orderItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Тоо хэмжээ нэмэхэд алдаа гарлаа: {ex.Message}");
            }
        }

        private void ProductDecreaseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderItem.Quantity > 1)
                {
                    _orderItem.Quantity--;
                    _orderItem.TotalPrice = CalculateTotalPrice();
                    UpdateUI();
                    ItemUpdated?.Invoke(this, EventArgs.Empty);
                    _orderService.UpdateOrderItem(_orderItem);
                }
                else if (_orderItem.Quantity == 1)
                {
                    _orderService.RemoveOrderItem(_orderItem.ProductName);
                    ItemUpdated?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Тоо хэмжээ хасахад алдаа гарлаа: {ex.Message}");
            }
        }

        private double CalculateTotalPrice()
        {
            return _orderItem.Quantity * _orderItem.UnitPrice * (1 - _orderItem.Discount / 100);
        }

        private void orderItem_Load(object sender, EventArgs e)
        {

        }

        private void ProductDecreaseBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void ProductIncreaseBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}

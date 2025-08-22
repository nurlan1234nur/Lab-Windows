using System.Text;
using FlightWebApp.Components.Pages;
using WorkerUI.Service;
namespace WorkerUI
{
    public partial class LogIn : Form
    {
        private String UserName = "naran1@gmail.com";
        private String Password = "P@ssw0rd123";
        public LogIn()
        {
            InitializeComponent();

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogIn_Load_1(object sender, EventArgs e)
        {

        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            UserName = textBox1.Text.Trim();
            Password = textBox2.Text.Trim();
            UserName = "naran1@gmail.com";
            Password = "P@ssw0rd123";
        LoginDtoAdmin loginDto = new LoginDtoAdmin
            {
                Email = UserName,
                Password = Password
            };
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var client = new UserApiClientAdmin(new HttpClient());

            try
            {
                var user = await client.AuthUser(loginDto);
                if (user.IsSuccess)
                {
                    OrderDetails OrderForm = new OrderDetails
                    {
                        PreviousForm = this
                    };
                    OrderForm.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show(user.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while logging in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

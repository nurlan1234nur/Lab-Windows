using System.Text;
using FlightWebApp.Components.Pages;
namespace WorkerUI
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        public string? username;
        public string? password;
        private async void logInBtn_Click(object sender, EventArgs e)
        {
            username = usernameTxt.Text;
            password = passwordTxt.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Нэвтрэх нэр болон нууц үгээ бөглөнө үү.");
                return;
            }

            var client = new HttpClient();

            var loginData = new
            {
                Email = username,
                Password = password
            };

            var content = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(loginData),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                var response = await client.PostAsync("http://192.168.216.1:5000/api/auth/login", content);

                
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(responseBody);

                    // дараагийн Form-руу шилжих
                    var dashboard = new Form1(); // эсвэл main form
                    dashboard.PreviousForm = this;
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Нэвтрэх нэр эсвэл нууц үг буруу байна.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}");
            }
        }

    }
}

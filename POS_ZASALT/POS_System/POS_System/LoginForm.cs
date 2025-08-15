using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Library.Service;
using Library.Repository;
using Library.model;




namespace POS_System
{
    public partial class LoginForm : Form
    {
        public DatabaseService _databaseService;
        public AuthService _authService;
        public string role;

        /// <summary>
        /// Нэвтрэх форм үүсгэх
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            _databaseService = new DatabaseService();
            _databaseService.InitializeDatabase();
        }

        /// <summary>
        /// Нэвтрэх товч дарахад
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if(_authService.checkUsernamePassword(username, password))
            {
                var role = _authService.getUserRoleByUsername(username);
                Form1 mainform = new Form1(role);
                this.Hide();
                mainform.FormClosed += (s, args) => this.Close();
                mainform.Show();
            }
        }
        /// <summary>
        /// Форм ачаалагдахад
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}


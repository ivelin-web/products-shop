namespace App
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "Enter email:";
            txtEmail.ForeColor = Color.FromArgb(85, 172, 238);

            txtUsername.Text = "Enter username:";
            txtUsername.ForeColor = Color.FromArgb(85, 172, 238);

            txtPassword.Text = "Enter password:";
            txtPassword.ForeColor = Color.FromArgb(85, 172, 238);
            txtPassword.PasswordChar = '\0';
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter email:")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.FromArgb(85, 172, 238);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Enter email:";
                txtEmail.ForeColor = Color.FromArgb(85, 172, 238);
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter username:")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.FromArgb(85, 172, 238);
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Enter username:";
                txtUsername.ForeColor = Color.FromArgb(85, 172, 238);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter password:")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.FromArgb(85, 172, 238);
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Enter password:";
                txtPassword.ForeColor = Color.FromArgb(85, 172, 238);
                txtPassword.PasswordChar = '\0';
            }
        }
    }
}

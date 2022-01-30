namespace App
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "Enter your email:";
            txtEmail.ForeColor = Color.FromArgb(85, 172, 238);

            txtPassword.Text = "Enter your password:";
            txtPassword.ForeColor = Color.FromArgb(85, 172, 238);
            txtPassword.PasswordChar = '\0';
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter your email:")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.FromArgb(85, 172, 238);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Enter your email:";
                txtEmail.ForeColor = Color.FromArgb(85, 172, 238);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your password:")
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
                txtPassword.Text = "Enter your password:";
                txtPassword.ForeColor = Color.FromArgb(85, 172, 238);
                txtPassword.PasswordChar = '\0';
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register().Show();
        }
    }
}
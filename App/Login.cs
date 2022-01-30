namespace App
{
    using App.Configs.Databases.Interfaces;
    using App.Utils.PasswordHashes.Interfaces;

    public partial class Login : Form
    {
        private readonly IDatabase mongo;
        private readonly IPasswordHash passwordHash;

        public Login(IDatabase mongo, IPasswordHash passwordHash)
        {
            InitializeComponent();

            this.mongo = mongo;
            this.passwordHash = passwordHash;   
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "Enter your email:";
            txtPassword.Text = "Enter your password:";
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
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Enter your email:";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your password:")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Enter your password:";
                txtPassword.PasswordChar = '\0';
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register(this.mongo, this.passwordHash).Show();
        }
    }
}
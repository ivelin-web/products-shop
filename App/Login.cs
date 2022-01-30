namespace App
{
    using App.Configs.Databases.Interfaces;
    using App.Models.Users;
    using App.Utils.PasswordHashes.Interfaces;
    using MongoDB.Driver;

    public partial class Login : Form
    {
        private const string userCollectionName = "users";

        private readonly IDatabase mongo;
        private readonly IPasswordHash passwordHash;
        private readonly IMongoCollection<User> userCollection;

        public Login(IDatabase mongo, IPasswordHash passwordHash)
        {
            InitializeComponent();

            this.mongo = mongo;
            this.passwordHash = passwordHash;
            this.userCollection = this.mongo.Db.GetCollection<User>(userCollectionName);
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

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // Check for credentials
            bool isValidUser = IsValidUser();

            if (!isValidUser)
            {
                txtWrong.Visible = true;
                return;
            }

            MessageBox.Show("Welcome!");
        }

        private bool IsValidUser()
        {
            // First try to find user by given email
            var filter = Builders<User>.Filter.Eq("email", txtEmail.Text);
            var user = this.userCollection.Find(filter).FirstOrDefault();

            // Wrong email
            if (user == null)
            {
                return false;
            }

            // Wrong password
            if (user.Password != this.passwordHash.Hash(txtPassword.Text))
            {
                return false;
            }

            return true;
        }
    }
}
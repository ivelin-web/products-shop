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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

            // Close login and open main form
            this.Hide();
            new Main(this.mongo, this.passwordHash).Show();
        }

        private bool IsValidUser()
        {
            // First try to find user by given email
            var filter = Builders<User>.Filter.Eq("email", txtEmail.Text);
            User user = this.userCollection.Find(filter).FirstOrDefault();

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

            // Save user to app
            Properties.Settings.Default.username = user.Username;

            return true;
        }
    }
}
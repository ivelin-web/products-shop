namespace App
{
    using App.Configs.Databases.Interfaces;
    using App.Models.Interfaces;
    using App.Models.Users;
    using App.Utils.PasswordHashes.Interfaces;
    using MongoDB.Driver;
    using System.Net.Mail;

    public partial class Register : Form
    {
        private const string userCollectionName = "users";

        private readonly IDatabase mongo;
        private readonly IPasswordHash passwordHash;
        private readonly IMongoCollection<User> userCollection;

        public Register(IDatabase mongo, IPasswordHash passwordHash)
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

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login(this.mongo, this.passwordHash).Show();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            // First check whether all fields are valid
            bool isValid = CheckFields();

            if (!isValid)
            {
                return;
            }

            // Save user to mongodb
            SaveUserToMongo();
        }

        private async void SaveUserToMongo()
        {
            // Hash password
            string hashedPassword = this.passwordHash.Hash(txtPassword.Text);

            // Make new user
            IUser user = new User(this.txtEmail.Text, this.txtUsername.Text, hashedPassword);

            // Check whether email is already used
            var filter = Builders<User>.Filter.Eq("email", this.txtEmail.Text);
            IUser userWithUsedEmail = this.userCollection.Find(filter).FirstOrDefault();

            if (userWithUsedEmail != null)
            {
                MessageBox.Show("The email is already used. Please use another email!");
                return;
            }

            // Save user to mongo
            await this.userCollection.InsertOneAsync((User)user);

            // Show message, close register form and open login form
            MessageBox.Show("The user has been added successfully.");
            this.Hide();
            new Login(this.mongo, this.passwordHash).Show();
        }

        private bool CheckFields()
        {
            bool isValid = true;

            // Check email
            if (!MailAddress.TryCreate(this.txtEmail.Text, out MailAddress mailAddress))
            {
                this.txtEmailWrong.Visible = true;
                isValid = false;
            }
            else
            {
                this.txtEmailWrong.Visible = false;
            }

            // Check username
            if (this.txtUsername.Text.Trim().Length < 3)
            {
                this.txtUsernameWrong.Visible = true;
                isValid = false;
            }
            else
            {
                this.txtUsernameWrong.Visible = false;
            }

            // Check password
            if (this.txtPassword.Text.Length < 4)
            {
                this.txtPasswordWrong.Visible = true;
                isValid = false;
            }
            else
            {
                this.txtPasswordWrong.Visible = false;
            }

            return isValid;
        }
    }
}

using App.Configs.Databases.Interfaces;
using App.Models.Product;
using App.Utils.PasswordHashes.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Main : Form
    {
        private const string productCollectionName = "products";

        private readonly IDatabase mongo;
        private readonly IPasswordHash passwordHash;
        private readonly IMongoCollection<Product> productCollection;

        public Main(IDatabase mongo, IPasswordHash passwordHash)
        {
            InitializeComponent();

            this.mongo = mongo;
            this.passwordHash = passwordHash;
            this.productCollection = this.mongo.Db.GetCollection<Product>(productCollectionName);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Properties.Settings.Default.username;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Logout
            Logout();
        }

        private void Logout()
        {
            Properties.Settings.Default.username = "";
            this.Hide();
            new Login(this.mongo, this.passwordHash).Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Save product to mongodb
            SaveProduct();
        }

        private void SaveProduct()
        {
            Product product = new Product(Properties.Settings.Default.username, txtName.Text, Double.Parse(txtPrice.Text));
            this.productCollection.InsertOne(product);
        }
    }
}

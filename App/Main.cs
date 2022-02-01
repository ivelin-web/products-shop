namespace App
{
    using App.Configs.Databases.Interfaces;
    using App.Models.Product;
    using App.Utils.PasswordHashes.Interfaces;
    using MongoDB.Driver;

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
            this.txtUsername.Text = Properties.Settings.Default.username;

            // Load all products
            LoadProductItems();
        }

        private void LoadProductItems()
        {
            List<Product> products = this.productCollection.AsQueryable().ToList<Product>();
            List<ProductItem> productItems = new List<ProductItem>();

            foreach (var product in products)
            {
                ProductItem productItem = new ProductItem(product.OwnerUsername, product.Name, product.Price);
                productItems.Add(productItem);
            }

            this.flowLayout.Controls.AddRange(productItems.ToArray());
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
            // Validate fields
            bool isValid = ValidateFields();

            if (!isValid)
            {
                return;
            }

            // Save product to mongodb
            Product product = SaveProduct();

            // Add new product to view 
            AddProductToView(product);

            // Clear fields
            ClearFields();
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            // Validate name field
            if (this.txtName.Text.Trim().Length == 0)
            {
                isValid = false;
                this.txtNameWrong.Visible = true;
            }
            else
            {
                this.txtNameWrong.Visible = false;
            }

            // Validate price field
            if (this.txtPrice.Text.Trim().Length == 0)
            {
                isValid = false;
                this.txtPriceWrong.Visible = true;
            }
            else
            {
                this.txtPriceWrong.Visible = false;
            }

            return isValid;
        }

        private void ClearFields()
        {
            this.txtName.Text = "";
            this.txtPrice.Text = "";
        }

        private void AddProductToView(Product product)
        {
            ProductItem productItem = new ProductItem(product.OwnerUsername, product.Name, product.Price);
            this.flowLayout.Controls.Add(productItem);

            MessageBox.Show("The product has been added successfully.");
        }

        private Product SaveProduct()
        {
            Product product = new Product(Properties.Settings.Default.username, txtName.Text, Double.Parse(txtPrice.Text));
            this.productCollection.InsertOne(product);

            return product;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            string currentPriceText = this.txtPrice.ToString();

            // If symbol is backspace return
            if (symbol == '\b')
            {
                return;
            }

            // Check whether symbol is valid
            if ((symbol != ',' && !Char.IsDigit(symbol)) || (currentPriceText[currentPriceText.Length - 1] == ',' && symbol == ','))
            {
                e.Handled = true;
            }
        }
    }
}

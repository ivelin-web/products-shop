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
            // Save product to mongodb
            Product product = SaveProduct();

            // Add new product to view 
            AddProductToView(product);

            // Clear fields
            ClearFields();
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
    }
}

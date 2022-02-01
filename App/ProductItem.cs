namespace App
{
    public partial class ProductItem : UserControl
    {
        public ProductItem(string owner, string name, double price)
        {
            InitializeComponent();

            this.Owner = owner;
            this.Name = name;
            this.Price = price;

            LoadData();
        }

        private void LoadData()
        {
            this.txtOwner.Text = this.Owner;
            this.txtProductName.Text = this.Name;
            this.txtPrice.Text = this.Price.ToString("N2");
        }

        public string Owner { get; private set; }

        public string Name { get; private set; }

        public double Price { get; private set; }

    }
}

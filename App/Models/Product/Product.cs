namespace App.Models.Product
{
    using App.Models.Product.Interface;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Product : IProduct
    {
        public Product(string ownerUsername, string name, double price)
        {
            this.OwnerUsername = ownerUsername; 
            this.Name = name;
            this.Price = price;
        }

        [BsonId]
        public ObjectId Id { get; private set; }

        [BsonElement("owner")]
        public string OwnerUsername { get; private set; }

        [BsonElement("name")]
        public string Name { get; private set; }

        [BsonElement("price")]
        public double Price { get; private set; }
    }
}

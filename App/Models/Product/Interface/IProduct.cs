using MongoDB.Bson;

namespace App.Models.Product.Interface
{
    public interface IProduct
    {
        ObjectId Id { get; }

        string OwnerUsername { get; }

        string Name { get; }

        double Price { get; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Models.Interfaces
{
    public interface IUser
    {
        ObjectId Id { get; }

        string Email { get; }

        string Username { get; }

        string Password { get; }
    }
}

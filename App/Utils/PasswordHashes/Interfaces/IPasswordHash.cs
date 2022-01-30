namespace App.Utils.PasswordHashes.Interfaces
{
    public interface IPasswordHash
    {
        string Hash(string input);
    }
}

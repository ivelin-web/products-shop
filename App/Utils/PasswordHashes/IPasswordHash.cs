namespace App.Utils.PasswordHashes
{
    public interface IPasswordHash
    {
        string Hash(string input);
    }
}

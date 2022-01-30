namespace App.Utils.PasswordHashes
{
    using App.Utils.PasswordHashes.Interfaces;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordHashSha : IPasswordHash
    {
        public string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder(hash.Length * 2);

                foreach (var b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}

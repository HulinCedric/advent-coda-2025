using System.Security.Cryptography;
using System.Text;

namespace Email;

public record Configuration(string Key, string Iv);

public class Encryption(Configuration configuration)
{
    // extrait, en md puis en base, il sera parfait.
    // MD5 is imposed by the challenge: the email can only be decrypted with this exact scheme.
#pragma warning disable CA5351
    private readonly byte[] _iv = MD5.HashData(Encoding.UTF8.GetBytes(configuration.Iv));
#pragma warning restore CA5351

    // haché, transformé, en sha puis en base, soigneusement encodé.
    private readonly byte[] _key = SHA256.HashData(Encoding.UTF8.GetBytes(configuration.Key));

    public string Decrypt(string encryptedText)
    {
        // Le message secret, lui aussi, est encodé en base.
        var ciphertext = Convert.FromBase64String(encryptedText);

        using var aes = Aes.Create();
        using var decryptor = aes.CreateDecryptor(_key, _iv);
        var decryptedBytes = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
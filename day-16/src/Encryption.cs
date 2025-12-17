namespace Email;

public record Configuration(string Key, string Iv);

public class Encryption(Configuration configuration)
{
    public string Decrypt(string encryptedText) => string.Empty;
}
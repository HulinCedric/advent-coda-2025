using FluentAssertions;
using Xunit;

namespace Email.Tests;

public class EncryptionTests(ITestOutputHelper output)
{
    private readonly Encryption _encryption = new(new Configuration(Key: "???", Iv: "???"));

    [Fact]
    public void Decrypt_Email()
    {
        var decryptedContent = _encryption.Decrypt(FileUtils.GetFileContent("email"));
        decryptedContent.Should().NotBeNullOrEmpty();
        output.WriteLine(decryptedContent);
    }
}
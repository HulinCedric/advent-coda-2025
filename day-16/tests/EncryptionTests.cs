using FluentAssertions;
using Xunit;

namespace Email.Tests;

public class EncryptionTests
{
    private readonly Encryption _encryption = new(
        new Configuration(
            // L’un naît de mon nom, Indice : je suis le lieu où tu étudies ou pourrais avoir envie d’étudier !)
            Key: "Coda",
            // L’autre, de l’année en cours
            Iv: "2025"));

    [Fact]
    public void Decrypt_Email()
        => _encryption.Decrypt(FileUtils.GetFileContent("email"))
            .Should()
            .BeEquivalentTo(
                """
                De : Santa [santa@northpole.local](mailto:santa@northpole.local)
                À : Chef des Elfes [chief.elf@northpole.local](mailto:chief.elf@northpole.local)

                Objet : Urgent – Mise à jour itinéraire de livraison

                Salut l’équipe,
                La tempête au-dessus de l’Atlantique a changé de trajectoire. Nouvelle heure de décollage : 23:47 UTC.
                Itinéraire : NPT -> REI -> CHI -> GVA -> CODA.
                Gardez le traîneau au chaud et le cacao encore plus chaud.

                — Santa
                """);
}
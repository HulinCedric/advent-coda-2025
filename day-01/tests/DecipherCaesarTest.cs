using FluentAssertions;
using Xunit;

namespace Day01.Tests;

public class DecipherCaesarTest
{
    [Fact]
    public void Decipher_message_given_a_key()
        => CaesarCipher.Decipher(
                message: """
                         qjx uwjufwfynkx uwjssjsy iz wjyfwi qjx jqkjx xtsy ijgtwijx jy qf qtlnxynvzj iz ywfnsjfz jxy js ufssj.
                         qj ujwj stjq hmjwhmj zs tz zsj ija hfufgqj ij qzn uwjyjw rfns ktwyj.
                         qjx qzynsx xtsy itzjx fajh qjx otzjyx rtnsx fajh qj htij.
                         fajh hjyyj wjxtqzynts yz fx uwtzaj yf afqjzw jy jrgfwvzj ifsx hjyyj fajsyzwj !!!
                         """,
                key: "RENNE")
            .Should()
            .Be(
                """
                les preparatifs prennent du retard les elfes sont debordes et la logistique du traineau est en panne.
                le pere noel cherche un ou une dev capable de lui preter main forte.
                les lutins sont doues avec les jouets moins avec le code.
                avec cette resolution tu as prouve ta valeur et embarque dans cette aventure !!!
                """);
}
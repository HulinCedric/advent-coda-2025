# [Jour 11 - Un bug bloque la tournée...](https://coda-school.github.io/advent-2025/?day=11)

En arrivant à l’atelier ce matin, tu croises le Père Noël, l’air dépité :

> “La release d’hier a cassé la **navigation dans les bâtiments**… et un test rouge bloque tout. Peux-tu jeter un œil ?”

Le système de guidage utilise un flux de signaux `(` et `)` pour calculer l’étage courant (↑ = `(`, ↓ = `)`).

Problème : la fonction qui calcule l’étage final **retourne un mauvais résultat**… et du code “elfique” s’est glissé
dans le flux.

## Ta mission

**Corrige le bug** afin qu’il calcule l’étage final correctement :

```csharp
public static class Building
{
    public static int WhichFloor(string signalStream)
    {
        List<Tuple<char, int>> val = [];

        for (int i = 0; i < signalStream.Length; i++)
        {
            var c = signalStream[i];

            if (signalStream.Contains("🧝"))
            {
                int j;
                if (c == ')') j = 3;
                else j = -2;

                val.Add(new Tuple<char, int>(c, j));
            }
            else if (!signalStream.Contains("🧝"))
            {
                val.Add(new Tuple<char, int>(c, c == '(' ? 1 : -1));
            }
            else val.Add(new Tuple<char, int>(c, c == '(' ? 42 : -2));
        }

        int result = 0;
        foreach (var kp in val)
        {
            result += kp.Item2;
        }
        return result;
    }
}
```

## Scout Rule

Une fois le bug résolu, profite-en pour améliorer le code en appliquant la [règle du **Scout
**](https://deviq.com/principles/boy-scout-rule).

> « Laisse le code dans un état meilleur que celui dans lequel tu l’as trouvé. »

## 💡 Ressources

- [Scout Rule](https://deviq.com/principles/boy-scout-rule)
- [Catalogue de Refactoring](https://refactoring.guru/refactoring/catalog)
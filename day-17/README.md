# [Jour 17 - if... elfe... refactor](https://coda-school.github.io/advent-2025/?day=17)

Les elfes ont pondu un petit routeur logistique… qui fonctionne, mais ressemble à un plat de spaghettis bien lourd.

## Ta mission

**Refactorer** la classe `GiftRouter` fournie pour respecter les principes
d'[Object Calisthenics](https://williamdurand.fr/2013/06/03/object-calisthenics/) suivants :

- une **indentation max d’un niveau par méthode**
- **aucun `else`** (préférer des *guard clauses* / polymorphisme / micro-méthodes)

Tu devras faire attention à :

- **Conserver strictement le comportement** (tous les tests doivent rester verts).
- **Limiter la taille des méthodes** (si possible < 10 lignes).

> Le comportement attendu est figé par les **tests automatisés** fournis.

```java
public class GiftRouter {
    public String route(Gift g) {
        if (g == null) {
            return "ERROR";
        } else {
            String zone = g.getZone();
            if (zone == null || zone.isBlank()) {
                return "WORKSHOP-HOLD";
            } else {
                if (g.isFragile()) {
                    if (g.getWeightKg() <= 2.0) {
                        return "REINDEER-EXPRESS";
                    } else {
                        return "SLED";
                    }
                } else {
                    if (g.getWeightKg() > 10.0) {
                        return "SLED";
                    } else {
                        if ("EU".equals(zone) || "NA".equals(zone)) {
                            return "REINDEER-EXPRESS";
                        } else {
                            return "SLED";
                        }
                    }
                }
            }
        }
    }
}
```

## Règles métier (comportements à préserver)

`route(Gift)` doit retourner une des routes logistiques suivantes :

```text
- le cadeau est `null` -> "ERROR"
- la zone est absente ou vide -> "WORKSHOP-HOLD"
- fragile et poids ≤ 2 kg -> "REINDEER-EXPRESS"
- fragile et poids > 2 kg -> "SLED"
- non fragile et poids > 10 kg -> "SLED"
- non fragile, poids ≤ 10 kg et zone ∈ {EU, NA} -> "REINDEER-EXPRESS"
- non fragile, poids ≤ 10 kg et autre zone -> "SLED"
```

> “Au Pôle Nord, on évite les embranchements… le traîneau préfère la ligne droite.” 🚀

## 💡 Ressources

- [Object Calisthenics](https://williamdurand.fr/2013/06/03/object-calisthenics/)
- [Object Calisthenics: Elevating Code Quality with 9 Powerful Rules](https://goatreview.com/object-calisthenics-9-rules-clean-code/)
- [Exemples de refactoring](https://refactoring.guru/fr/refactoring/smells/long-method)

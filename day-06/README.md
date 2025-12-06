# [Jour 6 - Une histoire de poids](https://coda-school.github.io/advent-2025/?day=06)

L’escouade **Logistique Traîneaux** a besoin de toi.

Objectif : éviter les **traîneaux trop lourds** (et les rennes grognons 🦌).

Le Père Noël veut une estimation fiable de la **moyenne des poids** des cadeaux par lot.  
Un elfe a déjà codé une fonction… mais l’équipe remonte des résultats bizarres. On a besoin de **tests unitaires** pour sécuriser tout ça, puis de corrections (si besoin).

## Ta mission

**Écris des tests unitaires** qui décrivent le comportement attendu de la fonction `averageWeight`.

```c
double averageWeight(int weights[], int length) {
    int s = 0;
    for (int i = 0; i < length; i++) {
        s += weights[i];
    }
    return s / length;
}
```

## Cas de test fournis (Chef elfe Julian)

```text
- {2, 5, 7, 10} -> 6.00
- {2} -> 2.00
- {} -> 0.00
- {1, 2} -> 1.50
```

> ️Note du Chef Qualité : “Un test qui échoue avant la correction, c’est un cadeau : il révèle une vérité qu’on ne voyait pas.” 🎄
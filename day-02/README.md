# [Jour 2 — Compter les Rennes](https://coda-school.github.io/advent-2025/?day=02)

Félicitations, tu as su décrypter le message secret du Père Noël !
Te voilà officiellement intégré·e à l’équipe du **Pôle Nord Ops**.

Pas de répit : la grande nuit approche, et les préparatifs battent leur plein.
Le Père Noël commence à planifier la tournée du 24 décembre… mais avant de charger le traîneau, il doit vérifier si **tous ses rennes sont bien présents** à l’étable.

Problème : entre l’entraînement, les visites au vétérinaire et les séances de spa, certains manquent à l’appel !
Et comme toujours, le Père Noël n’a **pas le temps** de faire le comptage à la main — il fait donc appel à toi.

## Ta mission

Écris un petit programme pour aider le Père Noël à **compter automatiquement les rennes présents** !

- Crée une structure `Reindeer` représentant un renne (nom + présence).
- Initialise un tableau avec les **8 rennes officiels** du traîneau.
- Certains sont présents, d’autres non : ton algorithme doit compter uniquement les présents.
- Affiche le résultat dans une phrase lisible pour Santa.

```c
int countPresentReindeers(Reindeer reindeers[]);
```

## Inventaire

Voici l'inventaire des `Rennes` ce jour :

- Dasher : présent
- Dancer : vétérinaire
- Prancer : présent ? 😬
- Vixen : spa
- Comet : présent
- Cupid : parti
- Donner : présent
- Blitzen : présent

## Exemple d’exécution

```text
🎅 Santa: 6 out of 8 reindeers are present in the stable tonight.
```

> “Au Pôle Nord, on ne compte pas les problèmes… on les code !”

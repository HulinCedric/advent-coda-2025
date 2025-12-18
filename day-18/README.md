# [Jour 18 - Le mystère du GQS](https://coda-school.github.io/advent-2025/?day=18)

Les elfes ont eu une idée brillante : utiliser le **traîneau du Père Noël** lui-même pour effectuer un **relevé complet
du parcours polaire**.

Équipé du nouvel instrument de mesure de température et d’énergie magique, le `Glacial Quantifier System (GQS)`, le
traîneau a sillonné le ciel en enregistrant des milliers de données…

Mais à leur retour, stupeur : le système de mesure ne parle pas la langue des elfes (ni des humains).

Tous les relevés ont été **capturés dans le format numérique elfique** du GQS — un système ancien, presque oublié, que *
*toi seul sembles capable de déchiffrer**.

## Le système de numération GQS

Les anciens elfes n’utilisaient pas de chiffres classiques, mais une série de **symboles gravés dans la glace**, chacun
représentant une valeur spécifique :

| Symbol | Décimal |
|:------:|:-------:|
|   ☃    |   -2    |
|   ❄    |   -1    |
|   0    |    0    |
|   *    |   +1    |
|   ✦    |   +2    |

Le système GQS est basé sur des **puissances de 5**.  
Ainsi, chaque position correspond à un multiple de 1, 5, 25, 125, 625, etc., exactement comme notre système décimal
fonctionne avec les puissances de 10.

Exemple :

```text
✦*0❄  =  (✦ × 125) + (* × 25) + (0 × 5) + (❄ × 1)
       =  (2 × 125) + (1 × 25) + (0) + (-1)
       =  250 + 25 - 1 = 274
```

## Ta mission

Les elfes ont extrait du traîneau un fichier contenant **des milliers de mesures GQS**, enregistrées pendant le vol :
chaque ligne correspondant à une mesure capturée par le capteur GQS.

Ils te demandent ton aide pour **déchiffrer les données**, et calculer un indicateur clé : `la moyenne décimale` de
toutes les mesures relevées.

## Exemple

Voici un exemple de fichier d’entrée avec 5 mesures GQS :

```
✦0
*
❄
☃
✦**
```

Conversion :

| GQS | Décimal |
|:---:|:-------:|
| ✦0  |   10    |
|  *  |    1    |
|  ❄  |   -1    |
|  ☃  |   -2    |
| ✦** |   56    |

Somme = `10 + 1 - 1 - 2 + 56 = 64`  
Moyenne = `64 / 5 = 12.8`

Sortie attendue : `12.8`
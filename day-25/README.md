# [Jour 25 - L’Audit des cadeaux mécontents](https://coda-school.github.io/advent-2025/?day=25)

## *“Le Père Noël reçoit un flux de feedback… illisible !”*

C’est le 25 décembre.

Pendant que les enfants jouent avec leurs cadeaux, le Père Noël reçoit des montagnes de feedbacks.

Sauf que le réseau magique du Pôle Nord a buggé (peut-être une surcharge de guirlandes connectées)…

Résultat : les données de satisfaction sont arrivées dans un format bricolé, sans structure, avec des erreurs partout.

Exemple :

```text
France-Lucie-unhappy-7|Brazil-Antonio-happy-10|Japan-Hiro-unhappy-11|??-??-happy-?|Germany-Lena-unhappy-9|Spain--neutral-8|USA-Mike-happiness-12
```

Le Père Noël panique :

> “Je ne peux rien analyser ! Qui peut m'aider à comprendre combien d’enfants sont mécontents par pays ?!”

## Ta mission

**Compte pour chaque pays le nombre d’enfants mécontents** (`satisfaction == "unhappy"`) et affiche un **rapport final**
clair.

> ⚠️ aucun `if` ne sera autorisé dans ce programme 🤔

## Format attendu d’un enregistrement valide

Un record valide doit :

- être composé de **4 parties** : `pays`, `prénom`, `satisfaction`, `age`
- séparées par `-`
- satisfaction parmi : `happy`, `neutral`, `unhappy`
- âge = entier positif
- aucun champ vide

Exemples de données valides :

```text
France-Lucie-happy-7
Brazil-Antonio-unhappy-9
Japan-Hiro-unhappy-11
Canada-Sophie-neutral-6
```

Exemples de données invalides (à ignorer) :

```text
France--happy-7              # prénom vide
Italy-Mario-12               # champ satisfaction manquant
??-??-happy-?                # caractères invalides
Belgium-Laura-happiness-9    # satisfaction invalide
USA-Mike-neutral-            # âge vide
```

## Sortie attendue

Ton programme doit afficher un rapport de ce type :

```text
=== Rapport des Enfants Mécontents ===

France : 12 mécontents
Brazil : 8 mécontents
Japan : 3 mécontents
Germany : 4 mécontents
Poland : 5 mécontents

Total global : 32 enfants mécontents
```
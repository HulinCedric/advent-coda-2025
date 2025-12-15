# [Jour 14 - Le chemin des cadeaux](https://coda-school.github.io/advent-2025/?day=14)

Au QG du Pôle Nord, c’est la dernière ligne droite.  
Dans la War Room, des cartes sont punaisées partout, des elfes jonglent avec des mugs de cacao, et un écran géant
affiche le **rejeu des trajets de l’an dernier**.

Objectif : **optimiser la tournée à venir**. Pour ça, l’équipe Data-Elfes a exporté un **flux brut** d’instructions de
déplacement du traîneau sur l’année N-1 : chaque caractère représente un pas dans une direction (`N`, `S`, `E`, `W`).

À **chaque pas**, Santa **dépose un cadeau** sur la maison où il se trouve.

Le problème ? Personne n’a recompilé combien de **maisons distinctes** ont été livrées. Et sans ce nombre, impossible
d’estimer correctement les **stocks**, la **capacité** et les **fenêtres de livraison**.

Santa fronce les sourcils. Les elfes te regardent. C’est ton moment de gloire !!!

## Ta mission

Écris un programme qui, en **lisant le fichier d’entrée fourni**, calcule **le nombre de positions uniques** (maisons)
qui ont reçu **au moins un cadeau** pendant le trajet.

Règles :

- Le traîneau **démarre** en `(0, 0)` et **dépose un cadeau immédiatement** à la maison de départ.
- Chaque instruction déplace la position d’une **unité** dans la direction indiquée :
    - `N = (x, y+1)`
    - `S = (x, y-1)`
    - `E = (x+1, y)`
    - `W = (x-1, y)`
- **Chaque pas** dépose un cadeau sur la maison atteinte.
- On doit compter **combien de maisons différentes** ont reçu au moins un cadeau (la même maison peut être visitée
  plusieurs fois, elle ne compte qu’**une** fois).

Combien de maisons différentes ont reçu au moins un cadeau pour les instructions données dans le fichier d’entrée ?

## Quelques exemples

### Exemple 1

```ini
instructions = "NNESESW"
```

**Trajectoire** :

```scss
(0,0) → Départ, cadeau déposé.
N → (0,1)
N → (0,2)
E → (1,2)
S → (1,1)
E → (2,1)
S → (2,0)
W → (1,0)
```

**Maisons uniques** :

```scss
(0,0), (0,1), (0,2), (1,2), (1,1), (2,1), (2,0), (1,0)
```

✅ **Résultat attendu** : `8`

### Exemple 2

```ini
instructions = "NNSS"
```

**Trajectoire** :

```scss
(0,0) → Départ, cadeau déposé.
N → (0,1)
N → (0,2)
S → (0,1)
S → (0,0)
```

**Maisons uniques** :

```scss
(0,0), (0,1), (0,2)
```

✅ **Résultat attendu** : `3`

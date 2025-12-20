# [Jour 20 - Logistique Elfique](https://coda-school.github.io/advent-2025/?day=20)

Les elfes ont besoin d'un nouvel outil pour inventorier l'atelier car le dernier en place a rendu l'âme !

De plus, le système de listage classique ne leur suffisait plus avec tous ces jouets magiques.

Aidez-les à créer un "ls" amélioré avec des fonctionnalités spéciales !

## Ta mission

Les elfes ont besoin d’un outil moderne pour inventorier leur atelier, capable de gérer les jouets magiques et
d’afficher les informations de manière flexible.

Leur ancien système ne suffisait plus : il est temps de créer une commande ls améliorée, avec des options pour adapter
l’affichage à leurs besoins.

## Détails

**Fonctionnalités requises** :

- **Parsing des arguments** : Permettre aux elfes de choisir le mode d’affichage (`normal`, `compact`, `tree`, `help`).
- **Listing des objets** : Récupérer les fichiers et dossiers avec leurs métadonnées (poids, taille, magie, etc.).
- **Affichage personnalisé** :
    - **Normal** : Tableau détaillé.
    - **Compact** : Liste condensée.
    - **Arborescence** : Structure en arbre.
- **Aide intégrée** : Expliquer les options disponibles.

### 1. Mode Normal

**Commande :** `elf normal`  
**Résultat :**

```text
Nom                Type      Taille   Poids   Magie

Poupée chantante   Fichier   15cm     200g    ✨✨✨
Épée en bois       Fichier   50cm     1kg     ✨
Livre de sorts     Fichier   20cm     500g    ✨✨
Boîte à musique    Fichier   10cm     300g    ✨
Jouets             Dossier   -        -       -
```

### 2. Mode Compact

**Commande :** `elf compact`  
**Résultat :**

```text
Poupée chantante (Jouet, 200g, ✨✨✨), Épée en bois (Arme, 1kg, ✨), Livre de sorts (Livre, 500g, ✨✨), Boîte à musique (Objet, 300g, ✨), Dossier Jouets/
```

### 3. Mode Arborescence

**Commande :** `elf tree`  
**Résultat :**

```text
.
├── Poupée chantante (200g, ✨✨✨)
├── Épée en bois (1kg, ✨)
├── Livre de sorts (500g, ✨✨)
├── Boîte à musique (300g, ✨)
└── Dossier Jouets/
    ├── Boule de neige (100g, ✨)
    └── Sablier magique (300g, ✨✨)

```

### 4. Aide

**Commande :** `elf help`  
**Résultat :**

```text
Utilisation : elf [OPTIONS]

Options :
  normal    Affiche les éléments sous forme de tableau détaillé.
  compact   Affiche les éléments en une ligne compacte.
  tree      Affiche les éléments sous forme d'arborescence.
  help      Affiche cette aide.
```
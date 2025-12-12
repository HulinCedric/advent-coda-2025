# [Jour 12 - Elfe-ervescence](https://coda-school.github.io/advent-2025/?day=12)

Les préparatifs de Noël battent leur plein au Pôle Nord.  
Les petits elfes du Père Noël, débordés par la montagne de cadeaux à préparer, ont bricolé en urgence une “Super Machine
à Cadeaux” capable de fabriquer, emballer et livrer les jouets à la vitesse de l’éclair.

Mais… quelque chose a mal tourné : alors qu’ils essayaient d’envoyer le premier cadeau, la machine s’est figée et un
grand message rouge s’est mis à clignoter sur l’écran :

> “ERREUR : Merci de respecter les principes SOLID.”

Les elfes n’ont aucune idée de ce que cela signifie. Ils ont appuyé frénétiquement sur tous les boutons, ajouté des
rubans, soufflé sur les câbles, redémarré la machine… rien n’y fait.

En panique, ils ont décidé de faire appel à toi.

## S.O.L.I.D

Ce n'est pas le nom d'une nouvelle machine à cadeaux, mais bien des principes de conception théoriques permettant de
concevoir des architectures logicielles plus compréhensibles, flexibles et maintenables. Un guide est disponible à
l'adresse suivante :  
https://yoan-thirion.gitbook.io/knowledge-base/software-craftsmanship/code-katas/write-s.o.l.i.d-code

- S : Single responsibility principle
- O : Open/closed principle
- L : Liskov substitution principle
- I : Interface segregation principle
- D : Dependency inversion principle

## Ta mission

**Appliquer les principes SOLID** afin de réparer la machine et permettre aux Elfes de continuer à emballer les cadeaux
plus rapidement.

## Astuces

Pour répondre au mieux aux principes SOLID, il faut d'abord :

- Identifier les violations des principes SOLID dans le code.
- Refactorer le code pour respecter au mieux les 5 principes.
- Rendre la machine extensible pour ajouter de nouveaux types de cadeaux.

Vous trouverez dans les fichiers à télécharger, le code de la machine ainsi qu'un exemple de son utilisation.

## Exemple d'utilisation de la machine

```php
$machine = new GiftMachine();
$machine->createGift('teddy', 'Alice');
$machine->createGift('car', 'Bob');
$machine->createGift('doll', 'Chloé');
$machine->createGift('robot', 'David');
```

## Ressources

- [SOLID Principles Explained](https://www.youtube.com/watch?v=rtmFCcjEgEw)
- [Write SOLID Code](https://yoan-thirion.gitbook.io/knowledge-base/software-craftsmanship/code-katas/write-s.o.l.i.d-code)
- [SOLID Principles in Object-Oriented Design](https://stackify.com/solid-design-principles/)

# [Jour 19 - Le vrai visage du Père Noël](https://coda-school.github.io/advent-2025/?day=19)

Les elfes du **Pôle HR Department** ont découvert une anomalie troublante dans le dossier du grand patron…

Un fichier nommé `santa_cv.html` affiche un **CV irréprochable**, mais quelque chose cloche.  
Certains elfes jurent avoir vu le Père Noël… *différent*...

- `Problème` : impossible d’accéder à sa véritable identité — elle semble dissimulée derrière un mystérieux **code de
  triche**.
- `Bonne nouvelle` : tu disposes du fichier original `santa_cv.html`, et les traces du commit parlent d’un certain
  *Konami*.
- `Mauvaise nouvelle` : personne ne se souvient de ce que c’est, ni comment l’activer.

## Ta mission

Mets en place le légendaire [Konami Code](https://fr.wikipedia.org/wiki/Code_Konami) dans la page `santa_cv.html`.  
Lorsque la séquence correcte est saisie au clavier, le CV doit révéler **le vrai visage du Père Noël**.

## Indices

Les anciens dévs du Pôle Nord laissent parfois des notes dans le code source…

```javascript
// Certains secrets ne s’offrent qu’à ceux qui connaissent la séquence…
// ↑ ↑ ↓ ↓ ← → ← → B A
```

Le **Konami Code** est une suite de touches mondialement connue des gamers.

Une fois détectée, appelle la fonction magique : `revealDarkSide()`.

> Qu'est-ce que cela donne si on fait cette combinaison sur ce site web ?

## 💡 Ressources

- [Konami Code](https://konami.fandom.com/fr/wiki/Konami_Code)
- [JavaScript Keyboard Events](https://developer.mozilla.org/fr/docs/Web/API/KeyboardEvent)
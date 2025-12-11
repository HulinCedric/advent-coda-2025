# [Jour 10 - La quête du cadeau parfait](https://coda-school.github.io/advent-2025/?day=10)

Les **elfes** du Pôle Nord sont des experts en **choix de cadeaux**, mais cette année, ils veulent ajouter un peu de *
*magie** et de **créativité** à leur processus.  
Jusqu'à présent, c'était simple : le choix était basé sur le comportement de l'enfant. Mais cette routine commence à
manquer de **piment**.

Les **elfes** veulent faire évoluer l'algorithme pour le rendre plus **personnalisé** et **créatif**. C’est là que tu
interviens !

- Pour les **moins de 14 ans**, tout reste simple : le choix se fait **uniquement en fonction du comportement**.
- Mais pour les **plus de 14 ans**, les elfes veulent rendre ça un peu plus **fun** ! Le choix du cadeau doit désormais
  tenir compte de la **bienveillance envers ses camarades** (exprimée en pourcentage).

## Ta mission

Faire évoluer l'algorithme de sélection des cadeaux pour qu'il prenne en compte **deux stratégies différentes** exposées
ci-dessus.

```typescript
export function selectGiftFor(child: Child): string | null {
    if (child.behavior === "naughty") {
        return null;
    } else if (child.behavior === "normal") {
        return [...child.giftRequest]
            .reverse()
            .filter(gift => gift.isFeasible)
            .map(gift => gift.giftName)[0] ?? null;
    } else if (child.behavior === "nice") {
        return child.giftRequest
            .filter(gift => gift.isFeasible)
            .map(gift => gift.giftName)[0] ?? null;
    }
}
```

Voici les nouvelles règles de sélection des cadeaux :

`Enfants de moins de 14 ans` :

- **Sage ("nice")** : sélectionne le **premier** cadeau **faisable**
- **Normal** : sélectionne le **dernier** cadeau **faisable**
- **Mauvais ("naughty")** : retourne toujours **"Rien"**

`Enfants de 14 ans ou plus` :

- **Sage ("nice")** : si **bienveillance > 0.5**, sélectionne le **premier** cadeau **faisable**. Sinon, retourne **"
  Rien"**.
- **Normal** : si **bienveillance > 0.5**, sélectionne le **dernier** cadeau **faisable** (ordre inversé). Sinon,
  retourne **"Rien"**.
- **Mauvais ("naughty")** : retourne toujours **"Rien"**.

## Explications

- **Bienveillance** : Propriété de l’enfant (ex : `0.6` = 60%).
- **Faisabilité** : Toujours prise en compte pour tous les enfants.
- **Pour les 14+** : la bienveillance `> 0.5` est un prérequis pour sélectionner un cadeau.

À toi de jouer et de personnaliser le choix des cadeaux !
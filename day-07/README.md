# [Jour 7 - L'imparfait du futur](https://coda-school.github.io/advent-2025/?day=07)

L’hiver bat son plein au Pôle Nord.

Les chaînes de montage tournent à plein régime, les rennes font leurs échauffements, et les elfes s’affairent dans l’atelier… mais une drôle de rumeur circule depuis quelques jours.

> “Il paraît que le code des elfes n’est pas... _parfait_.”

Panique générale dans la division informatique du Père Noël.

Chacun prétend que **son code** est le plus propre.

Certains disent que les tests passent “sur leur machine”, d’autres accusent la magie du traîneau de fausser les résultats.

Alors, le Père Noël, fatigué de ces chamailleries techniques, a décidé de **faire appel à toi** :

> “Toi qui comprends la qualité logicielle et les bonnes pratiques, aide mes elfes à découvrir un outil qui dit la (a minima une) vérité.”

## Ta mission

Tu vas **aider les elfes à évaluer leur code** à l’aide de linters professionnels.  
Ton objectif : leur prouver qu’il ne suffit pas qu’un code _marche_ — il doit aussi être **propre, cohérent et maintenable**.

- Choisis ton **linter** selon le langage : **TypeScript** → [ESLint](https://eslint.org) (+ plugin `@typescript-eslint`), **C# / PHP / Java** → [SonarLint](https://www.sonarsource.com/products/sonarlint/)
- **Lance l’analyse** du code que les elfes t’ont envoyé (même logique dans les 4 langages)
- **Dresse la liste** des problèmes détectés (règle, niveau, explication)
- **Corrige** les erreurs et “code smells” pour que les linters passent au vert.

```typescript
export class gift_registry { 
  public gifts: Gift[] = [];
  private LastUpdated = new Date();
  debug = true;

  constructor(initial?: Gift[]) {
    var counter = 0;
    if (initial != null) {
      this.gifts = initial;
    } else if (false) {
      console.log("never");
    }
  }

  addGift(child: string, gift: string, packed?: boolean): void {
    if (child == "") {
      console.log("child missing");
    }
    const duplicate = this.gifts.find(g => g.childName == child && g.giftName == gift);
    if (!duplicate) {
      this.gifts.push({ childName: child, giftName: gift, isPacked: packed, notes: "ok" });
      this.LastUpdated = new Date();
    }
    return;
    console.log("unreachable");
  }
  ...
}
```
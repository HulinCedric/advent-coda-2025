# [Jour 15 - Le code parfait de Nori](https://coda-school.github.io/advent-2025/?day=15)

Depuis ton arrivée au Pôle Nord, les elfes parlent beaucoup de toi… surtout **Nori**, l’un des plus enthousiastes de
l’équipe "technique".

Hier, il est venu te voir, rayonnant :

> “J’ai codé un petit module en TypeScript pour gérer les tâches de l’atelier !  
> Franchement, il est parfait. Mais bon… j’aimerais ton avis d’expert·e. Juste pour être sûr·e.”

Tu sens dans son regard à la fois la fierté et la curiosité sincère d’un elfe qui veut apprendre.

C’est l’occasion rêvée de faire une vraie [code review](https://fr.wikipedia.org/wiki/Revue_de_code), avec bienveillance
et exigence, dans l’esprit de
l'[Egoless Programming](https://blog.codinghorror.com/the-ten-commandments-of-egoless-programming/) :

> “Critique code instead of people – be kind to the coder, not to the code.”

## Ta mission

Aujourd’hui, tu vas **faire une revue de code** sur la base du module `TypeScript` de Nori.

- **Lis** attentivement le code de Nori
- Ajoute tes **commentaires de review directement dans le code**
- Reste **bienveillant·e et précis·e** : on ne juge pas Nori, on l'aide lui et son code à grandir

## Code à reviewer (`elfWorkshop.ts` + tests)

```typescript
export class ElfWorkshop {
    taskList: string[] = [];

    addTask(task: string): void {
        if (task !== "") {
            this.taskList.push(task);
        }
    }

    completeTask(): string {
        if (this.taskList.length > 0) {
            return this.taskList.shift();
        }
        return null;
    }
}
```

> “Une bonne review, c’est comme un bon cadeau : elle doit être sincère, utile et emballée avec soin.”

## 💡 Ressources

- [Egoless Programming](https://blog.codinghorror.com/the-ten-commandments-of-egoless-programming/)
- [Code Review Pyramid](https://www.morling.dev/blog/the-code-review-pyramid/)
- [Egoless Crafting](https://egolesscrafting.org/)
- [Code Avengers - Be Better At Reviewing Code](https://github.com/ythirion/code-review)
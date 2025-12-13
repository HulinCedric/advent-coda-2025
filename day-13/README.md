# [Jour 13 - La marketplace des Elfes](https://coda-school.github.io/advent-2025/?day=13)

Bonne nouvelle au Pôle Nord : les elfes sont euphoriques !  
Ils viennent tout juste de mettre en ligne leur **toute première marketplace** pour vendre et échanger leurs jouets
magiques.

Problème : les elfes ne sont **pas vraiment développeurs**...

Ils ont **“vibe-codé”** le site à l’instinct, sans se soucier de l’éco-conception, de l’accessibilité ni des bonnes
pratiques web.

Résultat ? La page met 10 secondes à charger sur un traîneau connecté en 3G...

Le Père Noël t’a donc confié une mission d’expert·e : **auditer la plateforme** et leur proposer un plan d’action pour
la rendre **plus rapide, plus verte, et plus inclusive**.

## Ta mission

- **Auditer** le site fourni avec :
    - [Lighthouse](https://chromewebstore.google.com/detail/lighthouse/blipmdconlkpinefehnmjammfjpmpbjk?hl=fr) (
      Performance, Best Practices, SEO, Accessibility)
    - [GreenIT-Analysis](https://www.greenit.fr/2019/07/02/web-evaluez-lempreinte-dune-page-en-un-clic/) (empreinte
      environnementale)
- **Évalue** le site : donne une **note synthèse** (ex. “Rouge 🟥 / Orange 🟧 / Vert 🟩”) + un court commentaire (2–3
  phrases).
- Identifier au minimum **4 actions concrètes** pour **réduire l’empreinte** (priorisées “fort impact → faible effort”
  si possible).

## Pour lancer le site localement

```bash
npx http-server -p 8080
```

Le site sera accessible sur `http://localhost:8080`.  
Lance ensuite tes audits Lighthouse et GreenIT-Analysis directement dessus.

## Livrables attendus

- **Résumé d’audit** (5–10 lignes) : scores Lighthouse (_Performance_ au minimum), résultat GreenIT-Analysis (
  empreinte/nb points), ton **classement** (🟥 / 🟧 / 🟩) + justification rapide.
- **Tableau des 4 actions**
- **Capture(s) / export(s)** Lighthouse & GreenIT-Analysis (ou chiffres recopiés clairement).
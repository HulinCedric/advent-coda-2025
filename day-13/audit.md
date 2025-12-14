# Audit de la marketplace des elfes

## Analyse

### Lighthouse

![Lighthouse Audit Summary Report](./assets/lighthouse-audit-summary-report.pdf)

![Lighthouse Audit Full Report](./assets/lighthouse-audit-full-report.pdf)

### GreenIT-Analysis

![GreenIT-Analysis Report](./assets/greenit-analysis-report.png)

## 🧾 Résumé d’audit (synthèse)

#### Lighthouse (Desktop)

- **Performance : 38/100** ❌ (très insuffisant)
    - LCP catastrophique (**~650 s**, page incomplètement chargée)
    - **53 Mo** de payload réseau, images surdimensionnées (Unsplash), JS massif et non minifié
    - **CLS : 0,458** (instabilité visuelle importante)
- **Accessibility : 75/100** (images sans `alt`, contrastes insuffisants, vidéo sans sous-titres)
- **Best Practices : 96/100** (bon niveau global)
- **SEO : 91/100** (principalement pénalisé par les images sans `alt`)

#### GreenIT-Analysis

- **ÉcoIndex : 20,83 → Classe F** ❌
- **291 requêtes HTTP**, **DOM : 2 812 nœuds**
- **GES : ~2,58 gCO₂e / page vue**
- **Eau : ~3,88 cl / page vue**

### 🟥 Classement global : **ROUGE**

Le site est **très énergivore**, principalement à cause d’**images massives**, d’un **JavaScript excessif** (plusieurs
frameworks simultanés) et d’un **DOM trop volumineux**. Les performances dégradées impactent directement l’empreinte
environnementale.

---

## 🎯 Actions prioritaires pour réduire l’empreinte (fort impact → faible effort)

| Priorité | Action concrète                                                                             | Impact environnemental | Effort    | Justification                                                                                      |
|----------|---------------------------------------------------------------------------------------------|------------------------|-----------|----------------------------------------------------------------------------------------------------|
| 1️⃣      | **Optimiser drastiquement les images** (WebP/AVIF, compression, tailles adaptées, `srcset`) | 🔥🔥🔥 Très fort       | 🟢 Faible | > **25 Mo** d’économies potentielles identifiées par Lighthouse (images Unsplash surdimensionnées) |
| 2️⃣      | **Supprimer les frameworks JS inutiles** (React + Vue + jQuery + Three.js)                  | 🔥🔥🔥 Très fort       | 🟠 Moyen  | Réduction massive du JS, CPU, mémoire et TBT                                                       |
| 3️⃣      | **Minifier et charger en différé le JS/CSS** (`defer`, `async`, build production)           | 🔥🔥 Fort              | 🟢 Faible | ~**1,1 Mo** de JS évitable + baisse du main-thread                                                 |
| 4️⃣      | **Réduire le DOM** (simplification HTML, pagination, virtualisation)                        | 🔥 Moyen               | 🟠 Moyen  | DOM > 2 800 nœuds → coût CPU + mémoire élevé                                                       |
| 5️⃣      | Charger les vidéos **à la demande** (poster + click)                                        | 🔥 Moyen               | 🟢 Faible | Vidéo = ~16 Mo chargés inutilement                                                                 |
| 6️⃣      | Mettre en cache long terme (`cache-control`)                                                | 🔥 Faible              | 🟢 Faible | Réduction des requêtes répétées                                                                    |

---

## 📸 Éléments de preuve (extraits chiffrés)

- **Lighthouse**
    - Performance **38**, LCP **~650 s**, payload réseau **~53 Mo**
    - Économies images estimées : **~25 160 KiB**
    - JS non minifié / inutilisé : **> 1 Mo**
- **GreenIT-Analysis**
    - **ÉcoIndex F (20,83)**
    - **291 requêtes**, **DOM 2 812**, **2,58 gCO₂e**

---

## 🧠 Conclusion rapide

Le site est **fonctionnel mais écologiquement très coûteux**.  
👉 **80 % du gain environnemental** peut être obtenu rapidement en **optimisant les images** et en **allégeant
radicalement le JavaScript**. Une refonte partielle orientée _sobriété numérique_ ferait passer le site de **🟥 Rouge à
🟧 Orange**, voire **🟩 Vert**.

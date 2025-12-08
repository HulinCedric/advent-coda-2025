# [Jour 8 - Les 3 enfants les plus sages](https://coda-school.github.io/advent-2025/?day=08)

Les elfes effectuent un **travail de repérage** pour la tournée.

Ils ont, comme chaque année, collecté des données sur des milliers d’enfants partout dans le monde.

Leur besoin : identifier les **3 enfants les plus sages** (ceux qui ont le meilleur score de sagesse en 2025) ainsi que leur localisation.

## Ta mission

- Extraire le **Top 3** des enfants les plus sages (noms, prénoms).
- Récupérer la localisation et les **coordonnées** en **plan elfique** (x, y en mètres — EPSG:3857).
- Visualiser ces enfants sur une carte du monde.

Tu peux utiliser [Jupyter](https://jupyter.org/), [DB Browser for SQLite](https://sqlitebrowser.org/), [DataGrip](https://www.jetbrains.com/datagrip/), [DBeaver](https://dbeaver.io/), ou le [CLI sqlite3](https://sqlite.org/cli.html).

## Schéma de données (SQLite)

Voici les tables principales que tu vas découvrir dans la base de données `kids.db` :

- `countries(code, name)`
- `cities(id, name, country_code, lat, lon)`
- `households(id, address, city_id)`
- `children(id, first_name, last_name, birthdate, household_id)`
- `behavior(id, child_id, year, nice_score)` — scores de sagesse 2025
- `elf_plan(child_id, x_m, y_m)` — coordonnées
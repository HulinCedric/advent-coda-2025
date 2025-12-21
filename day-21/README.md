# [Jour 21 - Démasquer l’elfe malveillant](https://coda-school.github.io/advent-2025/?day=21)

## Ta mission

À l’atelier de l’École du Pôle Nord, des cadeaux disparaissent mystérieusement la nuit.  
Le Responsable Logistique soupçonne un **elfe** d’avoir manipulé le stock et les enregistrements.

Tu es missionné·e comme **Data Investigator** : à partir d’une base de données opérationnelle, **identifie l’elfe malveillant**, **prouve-le avec des requêtes SQL**.

## Ressources fournies

- Base SQLite : **`elf_challenge.db`**
- Notebook Jupyter d’accompagnement

Tu peux utiliser [Jupyter](https://jupyter.org/), [DB Browser for SQLite](https://sqlitebrowser.org/), [DataGrip](https://www.jetbrains.com/datagrip/), [DBeaver](https://dbeaver.io/), ou le [CLI sqlite3](https://sqlite.org/cli.html).

## Ta mission

- **Identifier** l’elfe malveillant : `person_id` + `full_name`.
- **Démontrer la culpabilité** avec **au moins deux requêtes SQL** (lisibles et reproductibles).

## Nos conseils

- Prendre en main la base de données (échauffement)
- Lister les tables et **compter** les lignes par table.
- Afficher **quelques lignes** de chaque table pour comprendre les colonnes.

```sql
-- Compter par table (exemple avec UNION ALL)
SELECT 'person' AS tbl, COUNT(*) AS cnt FROM person
UNION ALL SELECT 'gift', COUNT(*) FROM gift
UNION ALL SELECT 'transactions', COUNT(*) FROM transactions
UNION ALL SELECT 'access_log', COUNT(*) FROM access_log;
```

Mène l’enquête, voici quelques pistes (non exhaustives) :

- Cherche qui agit lorsqu'il y a moins de monde...
- Repère des transactions suspectes (ex. `missing`, traces d’emoji, formulations bizarres) et relie-les aux acteurs.
- Essaie de corréler certaines actions avec des accès (±2 minutes).
- Vérifie si des comptes partagent la même IP/device.
- Analyse l'état des cadeaux juste après les actions du suspect...

> Indice : un elfe qui travaille « hors horaires » est suspect.
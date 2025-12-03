# [Jour 3 — Le script fantôme](https://coda-school.github.io/advent-2025/?day=03)

À peine arrivé·e au Pôle Nord, tu commences à comprendre l’ampleur de la mission.

Entre les flux de données, les rennes à suivre et les cadeaux à planifier, **l’infrastructure informatique** du Père Noël tourne à plein régime.  
Les elfes, eux, ont un rôle crucial : ils réalisent chaque nuit des **sauvegardes** de la liste des enfants sages.

Mais ce matin, c’est la panique à l’atelier : **aucune sauvegarde n’a été effectuée**.

L’elfe responsable a beau lancer le script magique :

```bash
./backup.sh
```

… il obtient seulement :

```bash
bash: ./backup.sh: Permission denied
```

Sans ce script, **impossible de protéger la liste des enfants sages**.  
Et sans cette liste, comment savoir qui mérite un cadeau ? 🎁😱

## Ta mission

Le Père Noël compte sur toi pour remettre ce script d’aplomb.

- **Inspecte** le fichier `backup.sh` pour comprendre pourquoi il refuse de s’exécuter.
- **Corrige** le problème afin que le script puisse à nouveau fonctionner.
- **Sécurise les permissions** : seul le Père Noël (propriétaire du fichier) doit pouvoir exécuter le script. Aucun elfe curieux ne doit pouvoir le modifier ou l’exécuter.
- **Documente** les commandes que tu as utilisées et explique ce qu’elles font.

## Fichier concerné

```bash
#!/bin/bash
# Script de sauvegarde magique du Père Noël
# Sauvegarde la liste des enfants sages dans un coffre-fort sécurisé

echo "🔒 Sauvegarde en cours..."
sleep 1
echo "🎁 La liste des enfants sages a bien été sauvegardée !"
```

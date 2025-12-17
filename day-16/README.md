# [Jour 16 - Un message secret](https://coda-school.github.io/advent-2025/?day=16)

La météo tourne mal au-dessus de l’Atlantique…  
Un **message opérationnel ultra-secret** a été chiffré avant d’être envoyé par le Père Noël.

- `Problème` : seul le serveur de prod sait le déchiffrer, et il vient de rendre l'âme...
- `Bonne nouvelle` : on a récupéré **le code source de la classe `Encryption`**, et **le fichier chiffré** `email`.
- `Mauvaise nouvelle` : rien n’est implémenté pour **recharger la clé et l’IV** depuis la configuration et **décrypter** le fichier texte.

## Ta mission

**Décoder** le contenu du fichier `email` et l’afficher en clair.

L'équipe `ElfSec` a documenté le nécessaire pour décrypter les emails à l'intérieur de cette énigme :

```text
Pour accéder au trésor bien gardé,
Deux sésames tu devras forger :

L’un naît de mon nom, haché, transformé,
En sha puis en base, soigneusement encodé.

L’autre, de l’année en cours, extrait,
En md puis en base, il sera parfait.

Le message secret, lui aussi,
Est encodé en base.

Avec ces clés, le secret tu perceras,
Mais d’abord, mon nom, devine-le… qui suis-je ?

(Indice : je suis le lieu où tu étudies ou pourrais avoir envie d’étudier !)
```
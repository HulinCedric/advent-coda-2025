# [Jour 9 - Une distance en traîneau](https://coda-school.github.io/advent-2025/?day=09)

Les elfes ont enregistré le **trajet préparatoire du Père Noël**, mais les données sont **dans le désordre** et exprimées selon leur **système de coordonnées elfique** — une projection **Web Mercator** en mètres.

Ta mission : **parser**, **trier**, **convertir** et **calculer**.

## Données d’entrée

Le fichier `trace` contient des lignes sous la forme : `order,x_m,y_m` :

- `order` : l’ordre chronologique attendu
- `x_m`, `y_m` : coordonnées en **mètres** (plan elfique – Web Mercator / EPSG:3857)

## Ta mission

- **Parser** le fichier et **trier** par `order` croissant
- **Convertir** chaque paire `(x_m, y_m)` en **WGS84** *(longitude/latitude en degrés)*
- **Résultat attendu** : **la distance en kilomètres entre le 1er point et le dernier point** (en WGS84)

> Tu n’as pas besoin de calculer la longueur totale de l’itinéraire, seulement la distance *géodésique* entre le **premier** et le **dernier** point.

## Conversion EPSG:3857 → WGS84

Soit `R = 6378137` (m). Pour chaque ligne :

```javascript
lon_deg = (x_m / R) * 180/π
lat_deg = (2 * atan(exp(y_m / R)) - π/2) * 180/π
```

## Distance géodésique (Haversine)

Avec `lat1, lon1, lat2, lon2` en **radians** :

```javascript
dlat = lat2 - lat1
dlon = lon2 - lon1
a = sin²(dlat/2) + cos(lat1) * cos(lat2) * sin²(dlon/2)
c = 2 * atan2(sqrt(a), sqrt(1-a))
distance_km = 6371.0 * c
```
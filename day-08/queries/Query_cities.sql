SELECT
    c.first_name                              AS first_name,
    c.last_name                               AS last_name,
    ci.lat                                    AS city_lat,
    ci.lon                                    AS city_lon
FROM behavior b
JOIN children  c  ON c.id = b.child_id
JOIN households h ON h.id = c.household_id
JOIN cities    ci ON ci.id = h.city_id
WHERE b.year = 2025
ORDER BY b.nice_score DESC
LIMIT 3;

SELECT c.first_name,
       c.last_name,
       (
           (2 * ATAN(EXP(e.y_m / 6378137.0)) - PI() / 2)
               * (180.0 / PI())
           )                                AS latitude,
       (e.x_m / 6378137.0) * (180.0 / PI()) AS longitude
FROM behavior b
         JOIN children c ON c.id = b.child_id
         JOIN elf_plan e ON e.child_id = c.id
WHERE b.year = 2025
ORDER BY b.nice_score DESC, c.last_name, c.first_name
LIMIT 3;

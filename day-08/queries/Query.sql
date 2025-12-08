SELECT c.first_name,
       c.last_name,
       e.x_m,
       e.y_m
FROM behavior b
         JOIN children c ON c.id = b.child_id
         JOIN elf_plan e ON e.child_id = c.id
WHERE b.year = 2025
ORDER BY b.nice_score DESC, c.last_name, c.first_name
LIMIT 3;

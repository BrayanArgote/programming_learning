-- INSERT
INSERT INTO users (name, surname) 
VALUES ('Pedro', 'Garcia')


-- UPDATE
UPDATE users 
SET name = 'juan',
WHERE user_id = 20

UPDATE users 
SET name = 'Pedro', 
    init_date = '2024-09-24'
WHERE user_id = 20

-- DELETE
DELETE FROM users
WHERE user_id = 20
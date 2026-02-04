-- SELECT
SELECT * FROM users

SELECT name FROM users;
SELECT id, surname FROM users

-- DISTINCT
SELECT DISTINCT name FROM users

-- WHERE
SELECT * FROM users 
WHERE age < 18

-- ORDER BY
SELECT * FROM users
ORDER BY age ASC

SELECT * FROM users
ORDER BY age DESC

-- LIKE
SELECT * FROM users
WHERE email LIKE '%@gmail.com'

SELECT * FROM users
WHERE user_id LIKE '1_'

-- AND    OR    NOT
SELECT * FROM users
WHERE age = 17 AND email LIKE 'j%'

SELECT * FROM users
WHERE age = 17 OR email LIKE 'j%'

SELECT name, surname, age FROM users
WHERE NOT age < 18

-- LIMIT
SELECT name, email FROM users
WHERE email LIKE '%@%' LIMIT 3

-- NULL   NOT NULL
SELECT name FROM users
WHERE email IS NULL

SELECT name FROM users
WHERE init_date IS NOT NULL 

-- MIN   MAX
SELECT MIN(age) FROM users

SELECT MAX(name) FROM users

-- COUNT 
SELECT COUNT(surname) FROM users

-- SUM 
SELECT SUM(age) FROM users

-- AVG
SELECT AVG(age) FROM users

-- IN
SELECT * FROM users
WHERE name IN ('juan', 'laura')

SELECT * FROM user_id
WHERE (name, age) IN (('juan', 23), ('laura', 34))

-- BETWEEN 
SELECT * FROM users
WHERE age BETWEEN 20 AND 40

-- CONCAT
SELECT CONCAT(name, ' ', surname) FROM users

-- AS
SELECT CONCAT(name, ' ', surname) AS 'Full Name' FROM users 

-- GROUP BY 
SELECT COUNT(age), age FROM users
GROUP BY age

-- HAVING (es como el WHERE pero filtrar por grupos)
SELECT COUNT(age) FROM users
GROUP BY name
HAVING name > 'a'


-- CASE 
SELECT CONCAT(name,' ', surname) AS 'Full Name',
CASE 
WHEN age >= 18 THEN True
ELSE False
END AS 'Has legal age?'
FROM users
WHERE name IS NOT NULL AND surname IS NOT NULL









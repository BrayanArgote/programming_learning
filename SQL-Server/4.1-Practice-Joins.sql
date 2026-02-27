-- ============================================================
--  DATABASE: practice
--  PURPOSE : Practice simple and advanced SQL queries
--            (INNER JOIN, LEFT JOIN, RIGHT JOIN, UNION)
-- ============================================================

USE master;
GO

-- Drop and recreate the database
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'practice')
BEGIN
    ALTER DATABASE practice SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE practice;
END
GO

CREATE DATABASE practice;
GO

USE practice;
GO

-- ============================================================
--  TABLES
-- ============================================================

CREATE TABLE departments (
    department_id   INT           PRIMARY KEY IDENTITY(1,1),
    department_name VARCHAR(100)  NOT NULL,
    location        VARCHAR(100)  NOT NULL,
    budget          DECIMAL(15,2) NULL
);

CREATE TABLE employees (
    employee_id   INT          PRIMARY KEY IDENTITY(1,1),
    first_name    VARCHAR(50)  NOT NULL,
    last_name     VARCHAR(50)  NOT NULL,
    email         VARCHAR(100) UNIQUE NOT NULL,
    hire_date     DATE         NOT NULL,
    salary        DECIMAL(10,2) NOT NULL,
    department_id INT          NULL,  -- nullable to test LEFT/RIGHT JOINs
    manager_id    INT          NULL,  -- self-referencing FK
    CONSTRAINT fk_emp_dept    FOREIGN KEY (department_id) REFERENCES departments(department_id),
    CONSTRAINT fk_emp_manager FOREIGN KEY (manager_id)    REFERENCES employees(employee_id)
);

CREATE TABLE projects (
    project_id   INT           PRIMARY KEY IDENTITY(1,1),
    project_name VARCHAR(150)  NOT NULL,
    start_date   DATE          NOT NULL,
    end_date     DATE          NULL,
    budget       DECIMAL(15,2) NULL,
    department_id INT          NULL,  -- nullable to test LEFT/RIGHT JOINs
    CONSTRAINT fk_proj_dept FOREIGN KEY (department_id) REFERENCES departments(department_id)
);

CREATE TABLE employee_projects (
    employee_id INT NOT NULL,
    project_id  INT NOT NULL,
    role        VARCHAR(100) NOT NULL DEFAULT 'Member',
    hours_spent INT          NULL,
    PRIMARY KEY (employee_id, project_id),
    CONSTRAINT fk_ep_emp  FOREIGN KEY (employee_id) REFERENCES employees(employee_id),
    CONSTRAINT fk_ep_proj FOREIGN KEY (project_id)  REFERENCES projects(project_id)
);

CREATE TABLE clients (
    client_id   INT          PRIMARY KEY IDENTITY(1,1),
    client_name VARCHAR(150) NOT NULL,
    industry    VARCHAR(100) NULL,
    country     VARCHAR(100) NOT NULL,
    revenue     DECIMAL(15,2) NULL
);

CREATE TABLE contracts (
    contract_id   INT           PRIMARY KEY IDENTITY(1,1),
    contract_name VARCHAR(150)  NOT NULL,
    client_id     INT           NULL,   -- nullable to test LEFT/RIGHT JOINs
    project_id    INT           NULL,
    signed_date   DATE          NOT NULL,
    value         DECIMAL(15,2) NOT NULL,
    status        VARCHAR(50)   NOT NULL DEFAULT 'Active',
    CONSTRAINT fk_con_client  FOREIGN KEY (client_id)  REFERENCES clients(client_id),
    CONSTRAINT fk_con_project FOREIGN KEY (project_id) REFERENCES projects(project_id)
);

-- ============================================================
--  DATA — DEPARTMENTS
-- ============================================================

INSERT INTO departments (department_name, location, budget) VALUES
('Engineering',       'New York',     1500000.00),
('Marketing',         'Los Angeles',   800000.00),
('Human Resources',   'Chicago',       400000.00),
('Finance',           'New York',      600000.00),
('Sales',             'Miami',        1200000.00),
('Research & Dev',    'San Francisco', 950000.00),
('Legal',             'Washington DC', 350000.00),
('Operations',        'Dallas',        700000.00);
-- Department with no employees (good for RIGHT JOIN practice)

-- ============================================================
--  DATA — EMPLOYEES  (some without department → LEFT JOIN)
-- ============================================================

INSERT INTO employees (first_name, last_name, email, hire_date, salary, department_id, manager_id) VALUES
-- Top-level managers (no manager)
('Alice',   'Johnson',   'alice.johnson@practice.com',   '2015-03-10', 120000.00, 1, NULL),
('Bob',     'Williams',  'bob.williams@practice.com',    '2014-07-22', 115000.00, 2, NULL),
('Carol',   'Martinez',  'carol.martinez@practice.com',  '2016-01-15', 110000.00, 3, NULL),
('David',   'Brown',     'david.brown@practice.com',     '2013-11-05', 130000.00, 4, NULL),
('Eve',     'Davis',     'eve.davis@practice.com',       '2017-06-30', 125000.00, 5, NULL),
-- Mid-level
('Frank',   'Wilson',    'frank.wilson@practice.com',    '2018-02-14', 90000.00,  1, 1),
('Grace',   'Taylor',    'grace.taylor@practice.com',    '2019-08-20', 85000.00,  1, 1),
('Henry',   'Anderson',  'henry.anderson@practice.com',  '2018-05-11', 88000.00,  2, 2),
('Irene',   'Thomas',    'irene.thomas@practice.com',    '2020-03-03', 82000.00,  2, 2),
('Jack',    'Jackson',   'jack.jackson@practice.com',    '2019-11-18', 87000.00,  3, 3),
('Karen',   'White',     'karen.white@practice.com',     '2021-01-07', 78000.00,  4, 4),
('Liam',    'Harris',    'liam.harris@practice.com',     '2020-09-25', 80000.00,  5, 5),
('Mia',     'Clark',     'mia.clark@practice.com',       '2022-04-12', 75000.00,  6, NULL),
('Noah',    'Lewis',     'noah.lewis@practice.com',      '2021-07-19', 77000.00,  6, NULL),
('Olivia',  'Lee',       'olivia.lee@practice.com',      '2022-10-01', 73000.00,  7, NULL),
-- Junior staff
('Paul',    'Walker',    'paul.walker@practice.com',     '2023-02-28', 65000.00,  1, 6),
('Quinn',   'Hall',      'quinn.hall@practice.com',      '2023-06-15', 63000.00,  1, 6),
('Rachel',  'Allen',     'rachel.allen@practice.com',    '2023-09-10', 62000.00,  2, 8),
('Sam',     'Young',     'sam.young@practice.com',       '2024-01-20', 60000.00,  2, 8),
('Tina',    'King',      'tina.king@practice.com',       '2024-03-05', 61000.00,  3, 10),
-- Employees with NO department (useful for LEFT JOIN)
('Uma',     'Scott',     'uma.scott@practice.com',       '2024-05-15', 58000.00,  NULL, NULL),
('Victor',  'Green',     'victor.green@practice.com',    '2024-06-01', 57000.00,  NULL, NULL);

-- ============================================================
--  DATA — PROJECTS  (some without department)
-- ============================================================

INSERT INTO projects (project_name, start_date, end_date, budget, department_id) VALUES
('Website Redesign',        '2023-01-01', '2023-12-31', 200000.00, 1),
('Brand Campaign Q1',       '2023-03-01', '2023-06-30',  80000.00, 2),
('ERP Implementation',      '2022-06-01', '2024-03-31', 500000.00, 1),
('Talent Acquisition 2024', '2024-01-01', NULL,          50000.00, 3),
('Financial Audit',         '2023-10-01', '2024-02-28',  30000.00, 4),
('Market Expansion LATAM',  '2023-07-01', NULL,         150000.00, 5),
('AI Research Initiative',  '2024-02-01', NULL,         300000.00, 6),
('Compliance Review',       '2024-04-01', '2024-09-30',  40000.00, 7),
('Ops Automation',          '2024-01-15', NULL,         120000.00, 8),
-- Project with no department (orphan)
('Internal Hackathon',      '2024-05-01', '2024-05-03',  10000.00, NULL);

-- ============================================================
--  DATA — EMPLOYEE-PROJECT ASSIGNMENTS
-- ============================================================

INSERT INTO employee_projects (employee_id, project_id, role, hours_spent) VALUES
(1,  1, 'Lead',          320),
(6,  1, 'Developer',     480),
(7,  1, 'Developer',     460),
(16, 1, 'Junior Dev',    200),
(17, 1, 'Junior Dev',    180),
(1,  3, 'Architect',     150),
(6,  3, 'Developer',     600),
(7,  3, 'Developer',     580),
(2,  2, 'Lead',          200),
(8,  2, 'Designer',      350),
(9,  2, 'Analyst',       310),
(18, 2, 'Junior',        120),
(3,  4, 'Coordinator',   180),
(10, 4, 'Recruiter',     260),
(20, 4, 'Assistant',     140),
(4,  5, 'Auditor Lead',  200),
(11, 5, 'Analyst',       300),
(5,  6, 'Sales Lead',    220),
(12, 6, 'Executive',     400),
(13, 7, 'Researcher',    500),
(14, 7, 'Researcher',    480),
(15, 8, 'Legal Lead',    160),
(19, 9, 'Ops Lead',      300);
-- Some employees have NO projects (useful for LEFT JOIN)
-- Employees 21, 22 are not assigned to any project

-- ============================================================
--  DATA — CLIENTS
-- ============================================================

INSERT INTO clients (client_name, industry, country, revenue) VALUES
('Acme Corp',         'Manufacturing',  'USA',           5000000.00),
('Global Tech Ltd',   'Technology',     'UK',            8000000.00),
('Sunrise Media',     'Entertainment',  'USA',           3200000.00),
('Nordic Solutions',  'Consulting',     'Sweden',        2100000.00),
('Pacific Traders',   'Retail',         'Japan',         4500000.00),
('Alpha Finance',     'Finance',        'USA',           6700000.00),
('Beta Pharma',       'Healthcare',     'Germany',       9200000.00),
('Gamma Logistics',   'Logistics',      'Brazil',        1800000.00),
-- Client with no contracts (useful for LEFT JOIN)
('Delta Innovations', 'Startup',        'Canada',         500000.00);

-- ============================================================
--  DATA — CONTRACTS
-- ============================================================

INSERT INTO contracts (contract_name, client_id, project_id, signed_date, value, status) VALUES
('Acme Web Redesign',        1, 1, '2023-01-15', 150000.00, 'Completed'),
('GlobalTech ERP',           2, 3, '2022-07-01', 400000.00, 'Active'),
('Sunrise Brand Campaign',   3, 2, '2023-03-10',  70000.00, 'Completed'),
('Nordic HR Services',       4, 4, '2024-01-20',  45000.00, 'Active'),
('Pacific Audit',            5, 5, '2023-10-15',  25000.00, 'Completed'),
('Alpha LATAM Expansion',    6, 6, '2023-07-20', 130000.00, 'Active'),
('Beta AI Research',         7, 7, '2024-02-10', 280000.00, 'Active'),
('Gamma Ops Automation',     8, 9, '2024-02-01', 100000.00, 'Active'),
-- Contract with no client (nullable)
('Internal Compliance',     NULL, 8, '2024-04-05',  35000.00, 'Active'),
-- Contract with no project
('Acme Consulting',          1, NULL,'2024-06-01',  20000.00, 'Pending');

-- ============================================================
--  PRACTICE QUERIES (commented out — run as needed)
-- ============================================================

/*
=== SIMPLE QUERIES ===

-- 1. All employees with their department name (INNER JOIN)
SELECT e.first_name, e.last_name, d.department_name
FROM employees e
INNER JOIN departments d ON e.department_id = d.department_id;

-- 2. All employees including those without a department (LEFT JOIN)
SELECT e.first_name, e.last_name, d.department_name
FROM employees e
LEFT JOIN departments d ON e.department_id = d.department_id;

-- 3. All departments including those without employees (RIGHT JOIN)
SELECT e.first_name, e.last_name, d.department_name
FROM employees e
RIGHT JOIN departments d ON e.department_id = d.department_id;

-- 4. Employees with no department assigned
SELECT e.first_name, e.last_name
FROM employees e
LEFT JOIN departments d ON e.department_id = d.department_id
WHERE d.department_id IS NULL;

-- 5. Departments with no employees
SELECT d.department_name
FROM employees e
RIGHT JOIN departments d ON e.department_id = d.department_id
WHERE e.employee_id IS NULL;


=== INTERMEDIATE QUERIES ===

-- 6. Employees and their projects (INNER JOIN through bridge table)
SELECT e.first_name, e.last_name, p.project_name, ep.role, ep.hours_spent
FROM employees e
INNER JOIN employee_projects ep ON e.employee_id = ep.employee_id
INNER JOIN projects p           ON ep.project_id  = p.project_id
ORDER BY e.last_name;

-- 7. Employees who have NO project assigned (LEFT JOIN + NULL check)
SELECT e.first_name, e.last_name
FROM employees e
LEFT JOIN employee_projects ep ON e.employee_id = ep.employee_id
WHERE ep.project_id IS NULL;

-- 8. Projects with no employees assigned
SELECT p.project_name
FROM projects p
LEFT JOIN employee_projects ep ON p.project_id = ep.project_id
WHERE ep.employee_id IS NULL;

-- 9. Clients and their contracts (LEFT JOIN to include client with no contract)
SELECT c.client_name, c.industry, co.contract_name, co.value, co.status
FROM clients c
LEFT JOIN contracts co ON c.client_id = co.client_id
ORDER BY c.client_name;

-- 10. Contracts with no client (orphan contracts)
SELECT co.contract_name, co.value, co.status
FROM contracts co
LEFT JOIN clients c ON co.client_id = c.client_id
WHERE c.client_id IS NULL;

-- 11. Employees and their managers (self-join)
SELECT  e.first_name + ' ' + e.last_name AS employee,
        m.first_name + ' ' + m.last_name AS manager
FROM employees e
LEFT JOIN employees m ON e.manager_id = m.employee_id
ORDER BY manager;


=== ADVANCED QUERIES ===

-- 12. Full picture: Employee → Department → Projects → Contracts → Clients
SELECT  e.first_name + ' ' + e.last_name   AS employee,
        d.department_name,
        p.project_name,
        co.contract_name,
        c.client_name,
        co.value                            AS contract_value
FROM employees e
LEFT JOIN departments      d  ON e.department_id  = d.department_id
LEFT JOIN employee_projects ep ON e.employee_id   = ep.employee_id
LEFT JOIN projects          p  ON ep.project_id   = p.project_id
LEFT JOIN contracts         co ON p.project_id    = co.project_id
LEFT JOIN clients           c  ON co.client_id    = c.client_id
ORDER BY e.last_name;

-- 13. Department salary summary (GROUP BY + JOIN)
SELECT  d.department_name,
        COUNT(e.employee_id)    AS headcount,
        AVG(e.salary)           AS avg_salary,
        SUM(e.salary)           AS total_salary,
        MIN(e.salary)           AS min_salary,
        MAX(e.salary)           AS max_salary
FROM departments d
LEFT JOIN employees e ON d.department_id = e.department_id
GROUP BY d.department_name
ORDER BY total_salary DESC;

-- 14. Top employees by total hours on projects
SELECT  e.first_name + ' ' + e.last_name AS employee,
        d.department_name,
        COUNT(ep.project_id)             AS num_projects,
        SUM(ep.hours_spent)              AS total_hours
FROM employees e
INNER JOIN employee_projects ep ON e.employee_id  = ep.employee_id
LEFT JOIN  departments d        ON e.department_id = d.department_id
GROUP BY e.employee_id, e.first_name, e.last_name, d.department_name
ORDER BY total_hours DESC;

-- 15. UNION: combine employees from Engineering and Marketing
SELECT first_name, last_name, 'Engineering' AS source_dept
FROM employees e
INNER JOIN departments d ON e.department_id = d.department_id
WHERE d.department_name = 'Engineering'
UNION
SELECT first_name, last_name, 'Marketing'
FROM employees e
INNER JOIN departments d ON e.department_id = d.department_id
WHERE d.department_name = 'Marketing';

-- 16. UNION ALL: list all people (employees) + all clients in one result set
SELECT first_name + ' ' + last_name AS name, 'Employee' AS type, email AS contact
FROM employees
UNION ALL
SELECT client_name, 'Client', industry
FROM clients
ORDER BY type, name;

-- 17. Employees who are ALSO listed as managers (INTERSECT-style with INNER JOIN)
SELECT DISTINCT m.employee_id, m.first_name, m.last_name
FROM employees e
INNER JOIN employees m ON e.manager_id = m.employee_id;

-- 18. Projects over budget compared to average project budget
SELECT  p.project_name,
        p.budget,
        d.department_name,
        (SELECT AVG(budget) FROM projects WHERE budget IS NOT NULL) AS avg_budget
FROM projects p
LEFT JOIN departments d ON p.department_id = d.department_id
WHERE p.budget > (SELECT AVG(budget) FROM projects WHERE budget IS NOT NULL)
ORDER BY p.budget DESC;

-- 19. Contracts value per client (RIGHT JOIN to include clients with no contracts)
SELECT  c.client_name,
        COUNT(co.contract_id)   AS num_contracts,
        COALESCE(SUM(co.value), 0) AS total_value
FROM contracts co
RIGHT JOIN clients c ON co.client_id = c.client_id
GROUP BY c.client_name
ORDER BY total_value DESC;

-- 20. Employees with salary above department average
SELECT  e.first_name, e.last_name, e.salary, d.department_name, da.avg_salary
FROM employees e
INNER JOIN departments d ON e.department_id = d.department_id
INNER JOIN (
    SELECT department_id, AVG(salary) AS avg_salary
    FROM employees
    GROUP BY department_id
) da ON e.department_id = da.department_id
WHERE e.salary > da.avg_salary
ORDER BY d.department_name, e.salary DESC;

-- 21. UNION: Active vs Completed contracts summary
SELECT 'Active'    AS status_group, COUNT(*) AS total, SUM(value) AS total_value FROM contracts WHERE status = 'Active'
UNION
SELECT 'Completed' AS status_group, COUNT(*) AS total, SUM(value) AS total_value FROM contracts WHERE status = 'Completed'
UNION
SELECT 'Pending'   AS status_group, COUNT(*) AS total, SUM(value) AS total_value FROM contracts WHERE status = 'Pending';

-- 22. Full outer join simulation (employees <-> departments)
SELECT e.first_name, e.last_name, d.department_name
FROM employees e
LEFT JOIN departments d ON e.department_id = d.department_id
UNION
SELECT e.first_name, e.last_name, d.department_name
FROM employees e
RIGHT JOIN departments d ON e.department_id = d.department_id;

*/
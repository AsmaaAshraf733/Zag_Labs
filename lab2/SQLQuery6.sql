/* problem 5 */
SELECT*
from Employees;
SELECT*
from Departments;

SELECT 
    e.emp_name,
    ISNULL(d.dept_name, 'Unassigned') AS dept_name
FROM Employees e
LEFT JOIN Departments d
    ON e.dept_id = d.dept_id;

    /* problem 6 */

SELECT *
From Products ;
select *
from Suppliers;

SELECT p.product_name,s.supplier_name
FROM Products p
LEFT JOIN Suppliers s
    ON p.supplier_id = s.supplier_id
WHERE p.product_name LIKE '%Phone%';

/* problem 7 */
select *
from Orders;
select *
from Customers;


SELECT
    COALESCE(c.first_name, '') + ' ' + COALESCE(c.last_name, '') AS full_name,
    o.order_id,
    o.amount
FROM Customers c
FULL OUTER JOIN Orders o
    ON c.customer_id = o.customer_id;

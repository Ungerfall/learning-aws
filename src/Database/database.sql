CREATE TABLE IF NOT EXISTS Products(
    ProductId INTEGER PRIMARY KEY AUTOINCREMENT
    ,ProductName TEXT NOT NULL
    ,UnitPrice DECIMAL(10, 2) NOT NULL
    ,Quantity INTEGER NOT NULL
);

INSERT INTO Products(ProductName, UnitPrice, Quantity)
SELECT 'Icecream', 2.20, 100
WHERE NOT EXISTS (SELECT 1 FROM Products WHERE ProductId = 1)
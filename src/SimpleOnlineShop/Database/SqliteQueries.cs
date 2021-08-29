using Dapper;
using SimpleOnlineShop.Model;
using System.Data.SQLite;
using System.Linq;

namespace SimpleOnlineShop.Database
{
    public class SqliteQueries
    {
        public static Product[] GetProducts(SQLiteConnection con, int id)
        {
            return con.Query<Product>(
                    "SELECT ProductId, ProductName, UnitPrice, Quantity FROM Products WHERE ProductId = @Id;", new { Id = id })
                .ToArray();
        }

        public static void InsertProduct(SQLiteConnection con, Product product)
        {
            con.Query(
                "INSERT INTO Products(ProductName, UnitPrice, Quantity) VALUES (@ProductName, @UnitPrice, @Quantity);",
                new { product.ProductName, product.UnitPrice, product.Quantity });
        }
    }
}
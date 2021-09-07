using Dapper;
using Npgsql;
using SimpleShoppingCart.Model;
using System;
using System.Linq;

namespace SimpleShoppingCart.DataAccess
{
    public class Queries
    {
        public static ShoppingCart? SelectCartWithProducts(NpgsqlConnection con, long id)
        {
            var sql = @"SELECT o.ShoppingCartId, p.ProductId, p.ProductName, p.UnitPrice, p.Quantity
                        FROM Orders o
                        INNER JOIN Products p ON p.ProductId = o.ProductId
                        WHERE ShoppingCartId = @Id;";
            var order = con.Query<OrderDto>(sql, new { Id = id }).ToArray();

            return order
                .GroupBy(
                    x => x.ShoppingCartId,
                    s => new Product {
                        ProductId = s.ProductId,
                        ProductName = s.ProductName,
                        UnitPrice = s.UnitPrice,
                        Quantity = s.Quantity
                    })
                .Select(x => new ShoppingCart {
                    ShoppingCartId = x.Key,
                    Products = x.ToList()
                })
                .FirstOrDefault();
        }

        public static long InsertShoppingCart(NpgsqlConnection con)
        {
            var sql = @"INSERT INTO ShoppingCarts DEFAULT VALUES RETURNING ShoppingCartId;";

            var id = con.QuerySingleOrDefault<long?>(sql);
            if (id == null) {
                throw new Exception("Cannot insert shopping cart.");
            }

            return id.Value;
        }

        public static void DeleteShoppingCart(NpgsqlConnection con, long id)
        {
            var sql = @"DELETE FROM ShoppingCarts WHERE ShoppingCartId = @Id;";
            con.Execute(sql, new { Id = id });
        }

        public static void InsertDefaultProductInShoppingCart(NpgsqlConnection con, long id)
        {
            var sql = @"INSERT INTO Orders(ShoppingCartId, ProductId) VALUES(@Id, 1);";
            con.Execute(sql, new { Id = id });
        }
    }
}
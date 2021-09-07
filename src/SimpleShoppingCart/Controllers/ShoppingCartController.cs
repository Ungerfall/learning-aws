using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SimpleShoppingCart.DataAccess;

namespace SimpleShoppingCart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController
    {
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            using var con = new NpgsqlConnection(ConnectionString.Value);

            var cart = Queries.SelectCartWithProducts(con, id);
            if (cart == null) {
                return new OkObjectResult(Queries.InsertShoppingCart(con));
            }

            return new JsonResult(cart);
        }

        [HttpPost("{id}")]
        public ActionResult AddProduct(long id)
        {
            using var con = new NpgsqlConnection(ConnectionString.Value);

            Queries.InsertDefaultProductInShoppingCart(con, id);

            return new OkResult();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCart(long id)
        {
            using var con = new NpgsqlConnection(ConnectionString.Value);

            Queries.DeleteShoppingCart(con, id);

            return new OkResult();
        }
    }
}
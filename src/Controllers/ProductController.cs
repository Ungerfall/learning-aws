using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleOnlineShop.Database;
using SimpleOnlineShop.Model;
using System.Data.SQLite;
using System.Linq;

namespace SimpleOnlineShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            using var con = new SQLiteConnection(ConnectionString.Value);

            var products = con.Query<Product>(
                    "SELECT ProductId, ProductName, UnitPrice, Quantity FROM Products WHERE ProductId = @Id;", new { Id = id })
                .ToArray();

            if (!products.Any()) {
                return NotFound();
            }

            return products.First();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Product productInput)
        {
            using var con = new SQLiteConnection(ConnectionString.Value);
            con.Query(
                "INSERT INTO Products(ProductName, UnitPrice, Quantity) VALUES (@ProductName, @UnitPrice, @Quantity);",
                new { productInput.ProductName, productInput.UnitPrice, productInput.Quantity });

            return Ok();
        }
    }
}

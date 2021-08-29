using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleOnlineShop.Model;
using System;
using System.Threading.Tasks;

namespace SimpleOnlineShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IAmazonDynamoDB _db;

        public ProductController(ILogger<ProductController> logger, IAmazonDynamoDB db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var productTable = Table.LoadTable(_db, "Products");
            var item = await productTable.GetItemAsync(id);

            if (item == null) {
                return NotFound();
            }

            var product = new Product {
                ProductId = item[nameof(Product.ProductId)].AsInt(),
                ProductName = item[nameof(Product.ProductName)].AsString(),
                Quantity = item[nameof(Product.Quantity)].AsInt(),
                UnitPrice = item[nameof(Product.UnitPrice)].AsDecimal()
            };
            return product;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Product productInput)
        {
            var productTable = Table.LoadTable(_db, "Products");
            var item = new Document();

            var id = DateTime.Now.Ticks;
            item[nameof(Product.ProductId)] = id;
            item[nameof(Product.ProductName)] = productInput.ProductName;
            item[nameof(Product.Quantity)] = productInput.Quantity;
            item[nameof(Product.UnitPrice)] = productInput.UnitPrice;

            return Ok(await productTable.PutItemAsync(item));
        }
    }
}
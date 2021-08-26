using Amazon.Lambda.Core;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SimpleOnlineShop.AwsLambda
{
    public class ProductGet
    {
        public string FunctionHandler(string id, ILambdaContext context)
        {
            return JsonSerializer.Serialize(new {
                ProductId = 1,
                ProductName = "Ice Cream",
                UnitPrice = 100m,
                Quantity = 1000,
            });
        }
    }
}
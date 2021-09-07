using Amazon.Lambda.Core;
using SimpleShoppingCart.Model;
using System;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SimpleShoppingCart.AwsLambda
{
    public class Checkout
    {
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(ShoppingCart cart, ILambdaContext context)
        {
            if (cart == null) {
                throw new ArgumentException("Empty cart", nameof(cart));
            }

            var sqsClient = new Amazon.SQS.AmazonSQSClient();
            var serializedCart = System.Text.Json.JsonSerializer.Serialize(cart);
            await sqsClient.SendMessageAsync(
                "https://sqs.us-east-1.amazonaws.com/566445353632/SimpleShoppingCartCheckout",
                serializedCart);

            return await Task.FromResult("OK");
        }
    }
}
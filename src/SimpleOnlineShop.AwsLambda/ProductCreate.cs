using Amazon.Lambda.Core;
using System;

namespace SimpleOnlineShop.AwsLambda
{
    public class ProductCreate
    {
        public int FunctionHandler(ILambdaContext context)
        {
            return new Random().Next();
        }
    }
}
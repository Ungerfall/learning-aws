using System.IO;

namespace SimpleOnlineShop.Database
{
    public class ConnectionString
    {
        public static readonly string Value
            = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "database", "simple-online-shop.sqlite");
    }
}
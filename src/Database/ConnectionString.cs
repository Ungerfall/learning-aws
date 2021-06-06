using System.IO;

namespace SimpleOnlineShop.Database
{
    public class ConnectionString
    {
        public static readonly string Value
            = "Data Source=" + Path.Combine("Database", "simple-online-shop.sqlite");
    }
}
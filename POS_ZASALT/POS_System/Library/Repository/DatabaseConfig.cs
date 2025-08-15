using System;
using System.IO;

namespace Library.Repository
{
    public static class DatabaseConfig
    {
        public static string DbPath = @"C:\Users\USER\Documents\002 HICHEELUUD\windows\Lab-Windows\POS_ZASALT\POS_System\Library\Database\Database.db";
        public static string ConnectionString = $"Data Source={DbPath};";
    }

}

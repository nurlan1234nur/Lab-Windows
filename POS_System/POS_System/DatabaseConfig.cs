using System;
using System.IO;
using System.Windows.Forms;

namespace POS_System
{
    public static class DatabaseConfig
    {
        public static string DbPath = @"C:\Users\USER\Documents\002 HICHEELUUD\windows\Lab-Windows\POS_System\POS_System\Database.db";
        public static string ConnectionString = $"Data Source={DbPath};Version=3;";
    }

}

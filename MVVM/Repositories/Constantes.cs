using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.MVVM.Repositories
{
    internal class Constantes
    {
        private const string DBFilename = "SQLite.db3";
        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFilename);
            }
        }
        public static string ERROR_MESSAGE { 
            get 
            {
                return "Se ha producido un error";
            }
            set { } }
    }
}

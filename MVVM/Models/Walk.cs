using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.MVVM.Models
{
    internal class Walk
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public int PerroID { get; set; }
        [NotNull]
        public DateTime Fecha {  get; set; }
        [NotNull]
        public TimeSpan Inicio { get; set; }
        [NotNull]
        public TimeSpan Fin { get; set; }
    }
}

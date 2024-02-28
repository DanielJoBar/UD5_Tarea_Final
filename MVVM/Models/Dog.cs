using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.MVVM.Models
{
    /// <summary>
    /// Clase que representa a un perro.
    /// </summary>
    public class Dog
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; } 
        [NotNull]
        [MaxLength(20)]
        public string Nombre { get; set; } 
        [NotNull]
        [MaxLength(20)]
        public string Raza { get; set; } 
    }
}

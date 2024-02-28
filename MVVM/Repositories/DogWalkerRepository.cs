using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DogWalker.MVVM.Models;
using SQLite;

namespace DogWalker.MVVM.Repositories
{
    /// <summary>
    /// Clase que gestiona la persistencia de perros y paseos.
    /// </summary>
    public class DogWalkerRepository
    {
        SQLiteConnection connection; 
        public string StatusMessages { get; set; }
        public string TypeMessages { get; set; } 

        /// <summary>
        /// Enumeración para los tipos de mensajes.
        /// </summary>
        private enum STATES
        {
            INFORMATION, ///< Información.
            ERROR ///< Error.
        }

        /// <summary>
        /// Constructor de la clase DogWalkerRepository.
        /// </summary>
        public DogWalkerRepository()
        {
            connection = new SQLiteConnection(Constantes.DatabasePath, Constantes.Flags);
            connection.CreateTable<Dog>();
            connection.CreateTable<Walk>();
        }

        /// <summary>
        /// Añade un perro a la base de datos.
        /// </summary>
        /// <param name="perro">Perro a añadir.</param>
        public void AddDog(Dog perro)
        {
            try
            {
                var message = connection.Insert(perro);
                StatusMessages = $"¡Bienvenido  {perro.Nombre}!";
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
        }

        /// <summary>
        /// Obtiene todos los perros de la base de datos.
        /// </summary>
        /// <returns>Lista de perros.</returns>
        public List<Dog> GetAllDogs()
        {
            List<Dog> lista = new List<Dog>();
            try
            {
                lista = connection.Table<Dog>().ToList();
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
            return lista;
        }

        /// <summary>
        /// Obtiene un perro por su identificador.
        /// </summary>
        /// <param name="id">Identificador del perro.</param>
        /// <returns>Perro encontrado.</returns>
        public Dog GetDog(int id)
        {
            Dog currentDog = new Dog();
            try
            {
                currentDog = connection.Get<Dog>(id);
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }

            return currentDog;
        }

        /// <summary>
        /// Elimina un perro de la base de datos.
        /// </summary>
        /// <param name="id">Identificador del perro a eliminar.</param>
        public void DeleteDog(int id)
        {
            try
            {
                var dog = GetDog(id);
                connection.Delete(GetDog(id));
                StatusMessages = $"¡Adiós {dog.Nombre}!";
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
        }

        /// <summary>
        /// Añade un paseo a la base de datos.
        /// </summary>
        /// <param name="paseo">Paseo a añadir.</param>
        public void AddWalk(Walk paseo)
        {
            Dog currentDog=GetDog(paseo.PerroID);
            try
            {
                connection.Insert(paseo);
                StatusMessages = $"{currentDog.Nombre} va a pasear el { paseo.Fecha.ToString("dd/MM/yyyy")} de { paseo.Inicio.ToString("hh\\:mm")} a { paseo.Fin.ToString("hh\\:mm")}";
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }

        }

        /// <summary>
        /// Obtiene todos los paseos de un perro por su identificador.
        /// </summary>
        /// <param name="id">Identificador del perro.</param>
        /// <returns>Lista de paseos del perro.</returns>
        public List<Walk> GetWalks(int id)
        {
            List<Walk> lista = null;
            try
            {
                lista = connection.Table<Walk>().Where(x => x.PerroID == id).ToList();
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex) 
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
            return lista;
        }

        /// <summary>
        /// Obtiene un paseo por su identificador.
        /// </summary>
        /// <param name="id">Identificador del paseo.</param>
        /// <returns>Paseo encontrado.</returns>
        public Walk GetWalk(int id)
        {
            Walk walk = new Walk();
            try
            {
                walk = connection.Get<Walk>(id);
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
            return walk;
        }

        /// <summary>
        /// Elimina un paseo de la base de datos por su identificador.
        /// </summary>
        /// <param name="id">Identificador del paseo a eliminar.</param>
        public void DeleteWalk(int id)
        {
            Walk currentWalk = GetWalk(id);
            try
            {
                connection.Delete<Walk>(id);
                StatusMessages = $"Se ha eliminado el paseo del día {currentWalk.Fecha.ToString("dd/MM/yyyy")} de {currentWalk.Inicio.ToString("hh\\:mm")} a {currentWalk.Fin.ToString("hh\\:mm")}";
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
        }


        /// <summary>
        /// Elimina todos los paseos de un perro por su identificador.
        /// </summary>
        /// <param name="id">Identificador del perro.</param>
        public void DeleteWalks(int id)
        {
            try
            {
                connection.Delete<Walk>(id);
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
        }
    }
}

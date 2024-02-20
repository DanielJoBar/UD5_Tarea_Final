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
    internal class DogWalkerRepository 
    {
        SQLiteConnection connection;
        public string StatusMessages { get; set; }
        public Dog CurrentDog { get; set; } = null;
        public Walk CurrentWalk { get; set; } = null;
        public string TypeMessages { get; set; }
        private enum STATES
        {
            INFORMATION,
            ERROR
        }
        public DogWalkerRepository()
        {
            connection = new SQLiteConnection(Constantes.DatabasePath, Constantes.Flags);
            connection.CreateTable<Dog>();
            connection.CreateTable<Walk>();
        }
        public void AddDog(Dog perro)
        {
            try
            {
                var message = connection.Insert(perro);
                StatusMessages = $"¡Bienvenido  { perro.Nombre}!";
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
        }

        public List<Dog> GetAllDogs()
        {
            List<Dog> lista = null;
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

        public Dog GetDog(int id)
        {
            try
            {
                CurrentDog = connection.Get<Dog>(id);
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }

            return CurrentDog;
        }

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

        public void AddWalk(Walk paseo)
        {
            try
            {
                connection.Insert(paseo);
                StatusMessages = $"{CurrentDog.Nombre} va a pasear el { paseo.Fecha.ToString("dd/MM/yyyy")} de { paseo.Inicio.ToString("hh\\:mm")} a { paseo.Fin.ToString("hh\\:mm")}";
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }

        }

        public List <Walk> GetWalks(int id) 
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

        public Walk GetWalk(int id)
        {
            Walk walk = null;
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
        
        public void DeleteWalk(int id)
        {
            try
            {
                connection.Delete<Walk>(id);
                StatusMessages = $"Se ha eliminado el paseo del día {CurrentWalk.Fecha.ToString("dd/MM/yyyy")} de {CurrentWalk.Inicio.ToString("hh\\:mm")} a {CurrentWalk.Fin.ToString("hh\\:mm")}";
                TypeMessages = STATES.INFORMATION.ToString();
            }
            catch (Exception ex)
            {
                StatusMessages = $"¡ERROR  {ex.Message}!";
                TypeMessages = STATES.ERROR.ToString();
            }
        }

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

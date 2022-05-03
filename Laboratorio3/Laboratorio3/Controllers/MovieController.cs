using Laboratorio3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index() 
        /*permite devolver diferentes acciones incluyendo
        redirigir a la vista deseada con modelos calculados, también puede
        devolver BadRequest entre otras acciones.*/
        {
            var movies = GetListOfMovies();
            ViewBag.MainTitle = "List of my favorite films";
            /*viewBag se utiliza para poder transferir información del controlador
            a la vista que no es parte del modelo.*/
            return View(movies);
        }

        private List<MovieModel> GetListOfMovies()
        {
            List<MovieModel> movies = new List<MovieModel>();
            /*Los list en C# al igual que en otros lenguajes son estructuras de datos
            que nos permiten tener un conjunto de elementos, las cuales se les
            pueden hacer una serie de operaciones.*/
            movies.Add(new MovieModel
            {
                Id = 1,
                Nombre = "Pulp Fiction",
                Genero = "Crime/Drama",
                Anio = new DateTime(1994, 10, 14)
            });
            movies.Add(new MovieModel
            {
                Id = 2,
                Nombre = "Toy Story",
                Genero = "Family/Comedy",
                Anio = new DateTime(1995, 11, 22)
            });

            movies.Add(new MovieModel
            {
                Id = 3,
                Nombre = "Mulan",
                Genero = "Family/Comedy",
                Anio = new DateTime(1995, 06, 19)
            });
            return movies;
        }
    }
}

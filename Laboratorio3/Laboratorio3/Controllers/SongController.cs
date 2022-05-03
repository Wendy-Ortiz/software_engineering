using Laboratorio3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index()
        /*permite devolver diferentes acciones incluyendo
        redirigir a la vista deseada con modelos calculados, también puede
        devolver BadRequest entre otras acciones.*/
        {
            var song = GetSongs();
            ViewBag.MainTitle = "My favorite Song";
            /*viewBag se utiliza para poder transferir información del controlador
            a la vista que no es parte del modelo.*/
            return View(song);
        }

        private SongModel GetSongs()
        {
            SongModel song = new SongModel();
            /*Los list en C# al igual que en otros lenguajes son estructuras de datos
            que nos permiten tener un conjunto de elementos, las cuales se les
            pueden hacer una serie de operaciones.*/
            song.Id = 1;
            song.Nombre = "Bohemian Rhapsody";
            song.Autor = "Queen";
            song.Genero = "Rock/Alternative/independent";
            song.Album = "A Night at the Opera";
            song.Anio = new DateTime(1975, 10, 31);
            return song;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3.Models
{
    public class SongModel
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Album { get; set; }
        public DateTime Anio { get; set; }
        
    }
}

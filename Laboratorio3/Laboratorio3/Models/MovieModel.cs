using System; /*permite utilizar las funcionalidades y tipos
de datos que provee la librería o clase que se llama*/
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3.Models /* Namespace es un conjunto clases, 
                               * delegados, objetos relaciones.
                               * Estos ayudan a organizar el código*/
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public DateTime Anio { get; set; }
    }
}

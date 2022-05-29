using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; //permiten utilizar los elementos Requiered

namespace Laboratorio5.Models
{
    public class PaisModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = " Debe proporcionar un nombre" )]
        //sirven para hacer el binding de las propiedades del modelo en la vista 
        [DisplayName(" Nombre del país : ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un continente")]
        [DisplayName(" Continente : " )]
        public string Continente { get; set; }
        [Required(ErrorMessage = " Debe ingresar el idioma ")]
        [DisplayName(" Idioma : ")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage= " No puede ingresar numeros " ) ]
        public string Idioma { get; set; }
    }
}

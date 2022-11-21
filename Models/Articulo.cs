using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Articulo
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Debe Completar este campo")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public Marca Marca { get; set; }

        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }

        [DisplayName("Imagen")]
        public string ImagenUrl { get; set; }

        public decimal Precio { get; set; }


    }
}

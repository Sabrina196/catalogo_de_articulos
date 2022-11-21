using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        //Sobreescritura del Método ToString() para que devuelva el valor en
        //formato texto a la columna 
        public override string ToString()
        {
            return Descripcion.ToString();
        }

    }
}

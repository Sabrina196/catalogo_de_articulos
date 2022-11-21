using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Models
{
    public class ValidarImagenUrl
    {
        public void CargarImagen(string imagen, PictureBox CajaImagen) 
        {
            try
            {
                CajaImagen.Load(imagen);
            }
            catch (Exception)
            {

                CajaImagen.Load("https://media.istockphoto.com/vectors/thumbnail-image-vector-graphic-vector-id1147544807?k=20&m=1147544807&s=612x612&w=0&h=pBhz1dkwsCMq37Udtp9sfxbjaMl27JUapoyYpQm0anc=");
            }
        }

    }
}

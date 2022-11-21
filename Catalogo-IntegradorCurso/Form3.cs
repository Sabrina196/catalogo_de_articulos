using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Catalogo_IntegradorCurso
{
    public partial class Form3 : Form
    {
        Articulo artDetalle;
        ValidarImagenUrl imagenDetalle = new ValidarImagenUrl();

        public Form3(Articulo RecibidoDetalles)
        {
            InitializeComponent();
            artDetalle = RecibidoDetalles;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblDetCod.Text= $"Código:  {artDetalle.Codigo}";
            lblDetNombre.Text= $"Nombre:  {artDetalle.Nombre}";
            lblDetDesc.Text= $"Descripción: \n{artDetalle.Descripcion}";
            imagenDetalle.CargarImagen(artDetalle.ImagenUrl, pbxDetImag);
            lblDetMarca.Text = $"Marca:  {artDetalle.Marca.Descripcion}";
            lblDetCateg.Text = $"Categoria:  {artDetalle.Categoria.Descripcion}";
            lblDetPrecio.Text= $"Precio:  ${artDetalle.Precio}";
            

        }
    }
}

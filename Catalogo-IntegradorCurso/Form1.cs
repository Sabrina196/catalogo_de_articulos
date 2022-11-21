using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio_DB;

namespace Catalogo_IntegradorCurso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnArticulo_Click(null, e);
        }

        //Método para las Ventanas en el panel de Control
        public void AbrirVentanaSeleccion(Form formSeleccionado)
        {
            //Si existe algun control en el panel, lo eliminamos
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            //Cambiamos sus propiedades y agregamos al panel
            formSeleccionado.TopLevel = false;
            formSeleccionado.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(formSeleccionado);
            //Y lo mostramos 
            this.panelContenedor.Tag = formSeleccionado;
            formSeleccionado.Show();
        }

        //Abrir Form2: Artículos
        private void btnArticulo_Click(object sender, EventArgs e)
        {
            Form2 FormArticulo = new Form2();
            AbrirVentanaSeleccion(FormArticulo);
        }

        //Abrir Form5: Categoría/Marca
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            string tituloCat = "Categoria";
            Form5 FormCategoria = new Form5(tituloCat);
            AbrirVentanaSeleccion(FormCategoria);
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            string tituloMar = "Marca";
            Form5 FormMarcas = new Form5(tituloMar);
            AbrirVentanaSeleccion(FormMarcas);
        }

    }
}

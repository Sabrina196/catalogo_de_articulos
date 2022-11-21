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
using Negocio_DB;

namespace Catalogo_IntegradorCurso
{
    public partial class Form6 : Form
    {
        Categoria categoria = null;
        Marca marca = null;
        string seccion;

        public Form6(string titulo)
        {
            InitializeComponent();

            seccion = titulo;
            if (seccion == "Categoria")
            {
                Text = "Agregar Categoria";
            }
            else
            {
                Text = "Agregar Marca";
            }
        }

        public Form6(object ObjAModificar, string tipoObj)
        {
            InitializeComponent();

            seccion = tipoObj;
            if (seccion == "Categoria")
            {
                categoria = (Categoria)ObjAModificar;
                Text = "Modificar Categoria";

            }
            else
            {
                marca = (Marca)ObjAModificar;
                Text = "Modificar Marca";
            }

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            if (seccion == "Categoria")
            {
                try
                {
                    if ( categoria != null)
                    {
                        txtDescripCM.Text = categoria.Descripcion;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    if (marca != null)
                    {
                        txtDescripCM.Text = marca.Descripcion;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }

        //Evento para Agregar/Modificar
        private void btnAceptarCM_Click(object sender, EventArgs e)
        {
            //Validar que no este vacio el campo
            if (textoDescripcion(txtDescripCM.Text))
            {
                return;
            } 

            if (seccion == "Categoria")
            {
                CategoriaNegocio negocioC = new CategoriaNegocio();

                if (categoria == null)
                {
                    categoria = new Categoria();
                }

                categoria.Descripcion = txtDescripCM.Text;

                if (categoria.Id != 0)
                {
                    negocioC.Modificar(categoria);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocioC.Agregar(categoria);
                    MessageBox.Show("Agregado exitosamente");
                }
 
            }
            else
            {
                MarcaNegocio negocioM = new MarcaNegocio();

                if (marca == null)
                {
                    marca = new Marca();
                }

                marca.Descripcion = txtDescripCM.Text;


                if (marca.Id != 0)
                {
                    negocioM.Modificar(marca);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocioM.Agregar(marca);
                    MessageBox.Show("Agregado exitosamente");
                }
            }

            this.Close();
        }

        //Evento para cancelar Agregar/Modificar
        private void btnCancelarCM_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //**MÉTODO INTERNO**//
        //Valida que no se carguen descripciones vacias 
        public bool textoDescripcion(string datoIntroducido)
        {
            if (datoIntroducido == "")
            {
                MessageBox.Show("Introduzca un dato para este Campo");
                return true;
            }
            return false;
        }
    }


}


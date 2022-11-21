using Models;
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
    public partial class Form5 : Form
    {
        private List<Categoria> listaCategoria;
        private List<Marca> listaMarca;
        private string tipoElemento;
        private object tipoDeObjeto;

        public Form5(string nombreObjeto)
        {
            InitializeComponent();
            tipoElemento = nombreObjeto;
            lblTituloPestaña.Text = tipoElemento.ToUpper();
            Actualizar(tipoElemento);
        } 

        private void Form5_Load(object sender, EventArgs e)
        {
            
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tipoDeObjeto = dgvDatos.CurrentRow.DataBoundItem.GetType();       
        }

        //Evento para el Filtro Rápido
        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroRapido.Text.ToUpper();
            if (tipoElemento == "Categoria")
            {
                List<Categoria> listaFiltrada;
                if (filtro.Length > 2)
                {
                    listaFiltrada = listaCategoria.FindAll(x => x.Descripcion.ToUpper().Contains(filtro));
                }
                else
                {
                    listaFiltrada = listaCategoria;
                }
                dgvDatos.DataSource = null;
                dgvDatos.DataSource = listaFiltrada;
            }
            else
            {
                List<Marca> listaFiltradaM;

                if (filtro.Length > 2)
                {
                    listaFiltradaM = listaMarca.FindAll(x => x.Descripcion.ToUpper().Contains(filtro));
                }
                else
                {
                    listaFiltradaM = listaMarca;
                }
                dgvDatos.DataSource = null;
                dgvDatos.DataSource = listaFiltradaM;


            }

            dgvDatos.Columns["Id"].Visible = false;
        }

        //Evento Para ir al Form6: "Agregar"
        private void btnAgregarA_Click(object sender, EventArgs e)
        {
            irAForm6(tipoElemento);           
        }

        //Evento para ir al Form6: "Modificar"
        private void btnModificarA_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                if (tipoDeObjeto.ToString() == "Models.Categoria")
                {
                    Categoria seleccionado = (Categoria)dgvDatos.CurrentRow.DataBoundItem;
                    irAForm6(seleccionado, tipoElemento);
                }
                else if (tipoDeObjeto.ToString() == "Models.Marca")
                {
                    Marca seleccionado = (Marca)dgvDatos.CurrentRow.DataBoundItem;
                    irAForm6(seleccionado, tipoElemento);
                }
                Actualizar(tipoElemento);
            }
        }

        //Evento para eliminar un registro
        private void btnEliminarA_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                if (tipoElemento == "Categoria")
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria seleccionado;
                    try
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro de Eliminar esta Categoria?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (respuesta == DialogResult.Yes)
                        {
                            seleccionado = (Categoria)dgvDatos.CurrentRow.DataBoundItem;
                            negocio.Eliminar(seleccionado.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca seleccionado;
                    try
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro de Eliminar esta Marca?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (respuesta == DialogResult.Yes)
                        {
                            seleccionado = (Marca)dgvDatos.CurrentRow.DataBoundItem;
                            negocio.Eliminar(seleccionado.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                Actualizar(tipoElemento);
            }
        }

   
        /***MÉTODOS INTERNOS***/
        //Método para Actualizar Lista
        private void Actualizar(string tipo)
        {
            if (tipo == "Categoria")
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                listaCategoria = negocio.Listar();
                dgvDatos.DataSource = listaCategoria;
                dgvDatos.Columns["Id"].Visible = false;                
            }
            else
            {
                MarcaNegocio negocioM = new MarcaNegocio();
                listaMarca = negocioM.Listar();
                dgvDatos.DataSource = listaMarca;
                dgvDatos.Columns["Id"].Visible = false;

            } 

        }

        //Metodo Agregar Dinámico
        private void irAForm6(string nombreObjeto) 
        {
            Form6 FormAgregar = new Form6(nombreObjeto);
            FormAgregar.ShowDialog();
            Actualizar(tipoElemento);
        }
        
        //Método Modificar Dinámico
        private void irAForm6(object objeto,string nombreObjeto)
        {
            Form6 FormModificar = new Form6(objeto, nombreObjeto);
            FormModificar.ShowDialog();
        }

    }
}

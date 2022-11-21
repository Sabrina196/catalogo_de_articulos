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
    public partial class Form2 : Form
    {
        //Lista Que va almacenar lo que extraiga de la DB para su manipulación
        private List<Articulo> listaArticulo;
        //Objeto para utilizar el metodo "CargarImagen"
        ValidarImagenUrl imagen = new ValidarImagenUrl();
        //Objeto para validar campo Númerico
        ValidarNumero campoEsNum = new ValidarNumero();

        public Form2()
        {
            InitializeComponent();
            Actualizar();
            cboColumna.Items.Add("Precio");
            cboColumna.Items.Add("Marca");
            cboColumna.Items.Add("Categoria");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        //Evento para cambiar imagen según la fila seleccionada
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                imagen.CargarImagen(seleccionado.ImagenUrl, pbImagenA);
            }
        }

        //Evento para el Filtro Rápido
        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> ListaFiltrada;
            string filtro = txtFiltroRapido.Text.ToUpper();

            if (filtro.Length >= 2)
            {
                ListaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro) || x.Descripcion.ToUpper().Contains(filtro) || x.Codigo.ToUpper().Contains(filtro) || x.Marca.Descripcion.ToUpper().Contains(filtro) || x.Categoria.Descripcion.ToUpper().Contains(filtro));
            }
            else
            {
                ListaFiltrada = listaArticulo;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = ListaFiltrada;
            OcultarColumnas();
        }

        //Evento para agregar un nuevo registro 
        private void btnAgregarA_Click(object sender, EventArgs e)
        {
            Form4 agregarArticulo = new Form4();
            agregarArticulo.ShowDialog();
            Actualizar();

        }

        //Evento para ver detalles de un registro 
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo detalles = new Articulo();
                detalles = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                Form3 detallesArticulo = new Form3(detalles);
                detallesArticulo.ShowDialog();
            }     
        }

        //Evento para modificar un registro seleccionado
        private void btnModificarA_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado;
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                Form4 editarArticulo = new Form4(seleccionado);
                editarArticulo.ShowDialog();
                Actualizar();
            }
        }

        //Evento para eliminar un registro seleccionado
        private void btnEliminarA_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            if (dgvArticulos.CurrentRow != null)
            {
                try
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de que quiere eliminar el Artículo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                        negocio.Eliminar(seleccionado.Id);
                    }

                    Actualizar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }

        //Evento para cargar ComboBox del Filtro Avanzado
        private void cboColumna_SelectedIndexChanged(object sender, EventArgs e)
        {
            BorrarMensajes();

            string opcion = cboColumna.SelectedItem.ToString();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Menor a ");
                cboCriterio.Items.Add("Igual a ");
                cboCriterio.Items.Add("Mayor a ");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comience con ");
                cboCriterio.Items.Add("Contiene ");
                cboCriterio.Items.Add("Termina con ");
            }

        }

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            BorrarMensajes();
        }   

        //Evento para Filtro Avanzado
        private void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocioFiltro = new ArticuloNegocio();

            try 
            {
                BorrarMensajes();
                
                if (validarfiltro())
                {
                    return;
                }

                string ColumnaSelect = cboColumna.SelectedItem.ToString();
                string CriterioSelect = cboCriterio.SelectedItem.ToString();
                string FiltroSelect = txtFiltroAvanz.Text;

                dgvArticulos.DataSource = negocioFiltro.Filtrar(ColumnaSelect, CriterioSelect, FiltroSelect);
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

       
        /***MÉTODOS INTERNOS***/
        //Método para Actualizar Vista
        private void Actualizar()
        {
            //Accedemos a los datos
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.Listar();
            dgvArticulos.DataSource = listaArticulo;
            imagen.CargarImagen(listaArticulo[0].ImagenUrl, pbImagenA);

            OcultarColumnas();

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }

        //Método validar Filtro Avanzado
        private bool validarfiltro()
        {
            if (cboColumna.SelectedIndex < 0)
            {
                lblMensaje1.Text = "Por favor, seleccione una columna";
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                lblMensaje2.Text = "Por favor, seleccione un criterio";
                return true;
            }
            if (cboColumna.SelectedItem.ToString() == "Precio")
            {
                if (!(campoEsNum.EsNumero(txtFiltroAvanz.Text)))
                {
                    lblMensaje3.Text = "Por favor, ingrese un nùmero";
                    return true;
                }

            }
            return false;
        }

        //Borrar Mensajes de Validaciones
        private void BorrarMensajes()
        {
            lblMensaje1.Text = "";
            lblMensaje2.Text = "";
            lblMensaje3.Text = "";
        }


    }
}

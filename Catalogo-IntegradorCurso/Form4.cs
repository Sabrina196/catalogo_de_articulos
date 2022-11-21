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
using System.Configuration;
using System.IO;

namespace Catalogo_IntegradorCurso
{
    public partial class Form4 : Form
    {
        //Atributo Artículo
        private Articulo articulo = null;
        private ValidarImagenUrl imagen = new ValidarImagenUrl();
        private OpenFileDialog archivo = null;
        private ValidarNumero campo = new ValidarNumero();

        public Form4()
        {
            InitializeComponent();    
        }

        public Form4(Articulo artRecibido)
        {
            InitializeComponent();
            articulo = artRecibido;
            Text = "Modificar Artículo";
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.tlInfoBoton.SetToolTip(this.btnImagenLocal, "Ingresar una imagen local");
            this.tlInfoSeparadorDecimales.SetToolTip(this.txtPrecio,"Para separar decimales utilice un punto");
            


            MarcaNegocio Marca_Negocio = new MarcaNegocio();
            CategoriaNegocio Categ_Negocio = new CategoriaNegocio();

            try
            {
                //Cargamos datos a los combobox
                cboMarca.DataSource = Marca_Negocio.Listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = Categ_Negocio.Listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagen.Text = articulo.ImagenUrl;
                    imagen.CargarImagen(txtImagen.Text, pbxImagenform4);
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;                    
                    txtPrecio.Text = articulo.Precio.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        //Evento para Agregar/Modificar elemento a la DB
        private void btnAceptarNuevo_Click(object sender, EventArgs e)
        {

            if (ValidarCampos())
            {
                return;
            }
            
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (articulo == null)
            {
                articulo = new Articulo();
            }

            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            articulo.ImagenUrl = txtImagen.Text;
            articulo.Marca = (Marca)cboMarca.SelectedItem;
            articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
            articulo.Precio = decimal.Parse(txtPrecio.Text);

            if (articulo.Id != 0)
            {
                negocio.Modificar(articulo);
                MessageBox.Show("Modificado exitosamente");
            }
            else
            {
                negocio.Agregar(articulo);
                MessageBox.Show("Agregado exitosamente");
            }

            if (archivo != null && !(txtImagen.Text.ToUpper().Contains("HTTP")))
            {
                //guardo imagen local
                File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-catal"] + archivo.SafeFileName);
            }

            this.Close();

        }

        //Evento para cancelar el Modificar/Agregar
        private void btnCancelarNuevo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Muestre Imagen en la caja al momento de leer la ruta
        private void txtImagen_Leave(object sender, EventArgs e)
        {
            imagen.CargarImagen(txtImagen.Text, pbxImagenform4);
        }

        //Método para cargar una imagen local
        private void btnImagenLocal_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg; | png|*.png";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = archivo.FileName;
                imagen.CargarImagen(archivo.FileName, pbxImagenform4);
            }
        }


        //***MÉTODO INTERNO***//
        //Método para validar Campos
        public bool ValidarCampos()
        {
            bool bandera;
            //Limpio los Msjs de Validación
            lblMessageCod.Text = "";
            lblMessageName.Text = "";
            lblMessagePrecio.Text = "";

            if (txtCodigo.Text == "" || txtNombre.Text == "" || (campo.EsNumero(txtPrecio.Text)) == false)
            {
                bandera = true;
            }
            else
            {
                bandera = false;
            }

            if (bandera)
            {
                if (txtCodigo.Text == "")
                {
                    lblMessageCod.Text = "Debe completar este campo";
                }
                if (txtNombre.Text == "")
                {
                    lblMessageName.Text = "Debe completar este campo";                   
                }
                if (!(campo.EsNumero(txtPrecio.Text)))
                {
                    lblMessagePrecio.Text = "Escriba un valor Númerico";
                }
                return true;
                                   
            }           
            else 
            {
                return false;
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Negocio_DB
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> ListaC = new List<Categoria>();
            AccesoDatos DatosC = new AccesoDatos();
            try
            {
                DatosC.SetQuery("Select Id, Descripcion from CATEGORIAS");
                DatosC.EjecutarLectura();

                while (DatosC.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)DatosC.Lector["Id"];
                    aux.Descripcion = (string)DatosC.Lector["Descripcion"];

                    ListaC.Add(aux);

                }
                return ListaC;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                DatosC.CerrarConexion();
            }
      
            
        }
        
        public void Agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetQuery($"Insert into CATEGORIAS values('{nuevo.Descripcion}')");
                datos.EjecutarAcción();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.CerrarConexion();
            }
        }
        
        public void Modificar(Categoria modificado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetQuery($"Update CATEGORIAS set Descripcion= '{modificado.Descripcion}' where Id={modificado.Id}");
                datos.EjecutarAcción();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.CerrarConexion();
            }

        }
        
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetQuery($"Delete CATEGORIAS WHERE Id= {id}");
                datos.EjecutarAcción();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    
    }
}

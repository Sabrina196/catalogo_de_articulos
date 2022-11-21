using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_DB
{
    public class MarcaNegocio
    {
        public List<Marca> Listar() 
        {
            List<Marca> ListaM = new List<Marca>();
            AccesoDatos datosM = new AccesoDatos();

            try
            {
                datosM.SetQuery("Select Id, Descripcion from MARCAS");
                datosM.EjecutarLectura();

                while (datosM.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datosM.Lector["Id"];
                    aux.Descripcion = (string)datosM.Lector["Descripcion"];

                    ListaM.Add(aux);
                }

                return ListaM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosM.CerrarConexion();
            }
            
        
        }

        public void Agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetQuery($"Insert into MARCAS values('{nuevo.Descripcion}')");
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

        public void Modificar(Marca modificado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetQuery($"Update MARCAS set Descripcion= '{modificado.Descripcion}' where Id={modificado.Id}");
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
                datos.SetQuery($"DELETE MARCAS WHERE Id={id}");
                datos.EjecutarAcción();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}

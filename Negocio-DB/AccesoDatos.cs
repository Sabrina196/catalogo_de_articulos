using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio_DB
{
    public class AccesoDatos
    {
        //Atributos para la conexión: Conexión, Comando y Lector
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader _lector;

        //Método de Lectura para "lector"
        public SqlDataReader Lector 
        {
            get { return _lector; }
        }

        //Constructor para comando y cadena de conexión
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=(local)\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        //Método para establecer el tipo de comando a ejecutar
        //y recibir por parámetro la consulta sql
        public void SetQuery(string consulta) 
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Método para establecer al comando la conexión de datos, ejecutar 
        //el ExecuteReader y almacenar dichos datos en la variable lector
        public void EjecutarLectura() 
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                _lector = comando.ExecuteReader();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //Método para insertar Datos
        public void EjecutarAcción()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //Método para enlazar los elementos seleccionados con su Id
        public void SetearParametros(string nombre, object valor) 
        {
            comando.Parameters.AddWithValue(nombre, valor);        
        }

        //Método para cerrar la conexión
        public void CerrarConexion()
        {
            //Si hay un lector abierto, lo cierra 
            if (_lector != null)
            {
                _lector.Close();
            }
            conexion.Close();
        }

    }
}

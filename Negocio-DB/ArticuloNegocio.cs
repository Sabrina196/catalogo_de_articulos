using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;


namespace Negocio_DB
{
    public class ArticuloNegocio
    {
        ////Atributo privado que voy a utilizar en cada Método
        //private AccesoDatos datos;

        ////Método de Lectura de "datos"
        //public AccesoDatos Datos
        //{
        //    get { return datos; }
        //}

        ////Constructor para datos
        //public ArticuloNegocio()
        //{
        //    datos = new AccesoDatos();
        //}

        //Método listar
        public List<Articulo> Listar()
        {
            List<Articulo> listaA = new List<Articulo>();
            AccesoDatos DatosA = new AccesoDatos(); 

            try
            {
                //Realizo la consulta y ejecuto la lectura
                DatosA.SetQuery("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                DatosA.EjecutarLectura();

                while (DatosA.Lector.Read())
                {
                    //Objeto que va ir almacenando en cada vuelta la lectura de datos
                    Articulo aux = new Articulo();

                    //En cada vuelta se almacena EN "ListaA" un registro de la DB
                    aux.Id = (int)DatosA.Lector["Id"];
                    aux.Codigo = (string)DatosA.Lector["Codigo"];
                    aux.Nombre = (string)DatosA.Lector["Nombre"];
                    aux.Descripcion = (string)DatosA.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)DatosA.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)DatosA.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)DatosA.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)DatosA.Lector["Categoria"];
                    if (!(DatosA.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)DatosA.Lector["ImagenUrl"];
                    }
                    
                    aux.Precio = Math.Round((decimal)DatosA.Lector["Precio"], 2); 
                    


                    listaA.Add(aux);
                } 
                return listaA;
            }

            //Me muestre el error
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                DatosA.CerrarConexion();
            }
        }

        //Método agregar datos a la DB 
        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetQuery($"Insert Into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio ) VALUES('{nuevo.Codigo}','{nuevo.Nombre}', '{nuevo.Descripcion}', @IdMarca, @IdCateg, '{nuevo.ImagenUrl}', {nuevo.Precio})");
                datos.SetearParametros("@IdMarca", nuevo.Marca.Id);
                datos.SetearParametros("@IdCateg", nuevo.Categoria.Id);
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

        //Método modificar datos de la DB
        public void Modificar(Articulo modificar) 
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetQuery($"Update ARTICULOS set Codigo='{modificar.Codigo}', Nombre='{modificar.Nombre}', Descripcion='{modificar.Descripcion}', IdMarca=@idMarca, IdCategoria=@IdCateg, ImagenUrl='{modificar.ImagenUrl}', Precio={modificar.Precio} WHERE id={modificar.Id}");
                Datos.SetearParametros("IdMarca", modificar.Categoria.Id);
                Datos.SetearParametros("IdCateg", modificar.Marca.Id);
                Datos.EjecutarAcción();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                Datos.CerrarConexion();
            }

        }

        //Método eliminar datos de la DB
        public void Eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetQuery($"DELETE ARTICULOS WHERE Id={Id}");
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

        //Método Filtrar datos 
        public List<Articulo> Filtrar(string columna, string criterio, string filtro) 
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> listaFiltro = new List<Articulo>();
            
            try
            {
                string query = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE ";
                
                if (columna == "Precio")
                {
                    switch (criterio)
                    {
                        case "Menor a ":
                            query += $"A.Precio < {filtro}";                    
                            break;

                        case "Mayor a ":
                            query += $"A.Precio > {filtro}";
                            break;

                        default:
                            query += $"A.Precio = {filtro}";
                            break;
                    }
                }
                else  
                {
                    string parte2;
                    if (columna == "Marca")
                    {
                        parte2= CompletarQuery('M', criterio, filtro);
                        
                    }
                    else
                    {
                        parte2= CompletarQuery('C', criterio, filtro);  
                    }                    
                    query += parte2;
                }

                datos.SetQuery(query);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    
                    Articulo auxFiltro = new Articulo();
                    auxFiltro.Id = (int)datos.Lector["Id"];
                    auxFiltro.Codigo = (string)datos.Lector["Codigo"];
                    auxFiltro.Nombre = (string)datos.Lector["Nombre"];
                    auxFiltro.Descripcion = (string)datos.Lector["Descripcion"];
                    auxFiltro.Marca = new Marca();
                    auxFiltro.Marca.Id = (int)datos.Lector["IdMarca"];
                    auxFiltro.Marca.Descripcion = (string)datos.Lector["Marca"];
                    auxFiltro.Categoria = new Categoria();
                    auxFiltro.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    auxFiltro.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        auxFiltro.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }

                    auxFiltro.Precio = (decimal)datos.Lector["Precio"];



                    listaFiltro.Add(auxFiltro);
                }

                return listaFiltro;
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
        
        //***Método para Switch***
        private string CompletarQuery(char Inicial, string criter, string filt)
        {
            string parte;
            switch (criter)
            {
                case "Comience con":
                    parte= $"{Inicial}.Descripcion like'{filt}%'";
                    break;

                case "Termine con":
                    parte= $"{Inicial}.Descripcion like '%{filt}'";
                    break;

                default: 
                    parte= $"{Inicial}.Descripcion like '%{filt}%'";
                    break;                    
            }
            return parte;
            
        }
    }
}

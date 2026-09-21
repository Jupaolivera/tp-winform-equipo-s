using System;
using System.Collections.Generic;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.setearConsulta(
                    "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, " +
                    "       A.IdMarca, M.Descripcion AS MarcaDescripcion, " +
                    "       A.IdCategoria, C.Descripcion AS CategoriaDescripcion " +
                    "FROM ARTICULOS A " +
                    "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                    "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(mapearArticulo(datos));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.setearConsulta(
                    "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, " +
                    "       A.IdMarca, M.Descripcion AS MarcaDescripcion, " +
                    "       A.IdCategoria, C.Descripcion AS CategoriaDescripcion " +
                    "FROM ARTICULOS A " +
                    "INNER JOIN MARCAS M ON A.IdMarca = M.Id " +
                    "INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id " +
                    "WHERE A.Nombre LIKE @Nombre");
                datos.setearParametro("@Nombre", "%" + nombre + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(mapearArticulo(datos));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " +
                    "VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, " +
                    "IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio " +
                    "WHERE Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private Articulo mapearArticulo(AccesoDatos datos)
        {
            Articulo articulo = new Articulo();

            articulo.Id = (int)datos.Lector["Id"];
            articulo.Codigo = (string)datos.Lector["Codigo"];
            articulo.Nombre = (string)datos.Lector["Nombre"];
            articulo.Descripcion = (string)datos.Lector["Descripcion"];
            articulo.Precio = (decimal)datos.Lector["Precio"];

            articulo.Marca = new Marca();
            articulo.Marca.Id = (int)datos.Lector["IdMarca"];
            articulo.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

            articulo.Categoria = new Categoria();
            articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
            articulo.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

            return articulo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio

{
    public

        class PokemonNegocio
    {

        public List<Pokemon> listarConSP()
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon Aux = new Pokemon();
                    Aux.Id = (int)datos.Lector["Id"];
                    Aux.Numero = datos.Lector.GetInt32(0);
                    Aux.Nombre = (string)datos.Lector["Nombre"];
                    Aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagen"))))
                        Aux.UrlImagen = (string)datos.Lector["UrlImagen"];


                    Aux.Tipo = new Elemento();
                    Aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    Aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    Aux.Debilidad = new Elemento();
                    Aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    Aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    lista.Add(Aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Pokemon> listar(string id = "")
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true;";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "SELECT Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id FROM POKEMONS P, ELEMENTOS E, ELEMENTOS D WHERE E.Id=P.IdTipo AND D.id=P.IdDebilidad AND P.Activo=1 ";

                if (id != "")
                    comando.CommandText += " and P.id= +" + id;

                comando.Connection = conexion;



                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon Aux = new Pokemon();
                    Aux.Id = (int)lector["Id"];
                    Aux.Numero = lector.GetInt32(0);
                    Aux.Nombre = (string)lector["Nombre"];
                    Aux.Descripcion = (string)lector["Descripcion"];

                    if (!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                        Aux.UrlImagen = (string)lector["UrlImagen"];


                    Aux.Tipo = new Elemento();
                    Aux.Tipo.Id = (int)lector["IdTipo"];
                    Aux.Tipo.Descripcion = (string)lector["Tipo"];
                    Aux.Debilidad = new Elemento();
                    Aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    Aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(Aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Insert into POKEMONS(Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad,UrlImagen)Values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad,@UrlImagen)");
                datos.setearParametro("@idTipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.setearParametro("@UrlImagen", nuevo.UrlImagen);
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

        public void AgregarConSP(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                /*DB StoreProcedure
                 * create procedure storedAltaPokemon
                   @numero int, @nombre varchar(50),@desc varchar(50), @img varchar(300), @idTipo int, @idDebilidad int,null, int
                   as
                   insert into POKEMONS values(@numero, @nombre, @desc, @img, @idTipo, @idDebilidad, 1);*/


                datos.setearProcedimiento("storedAltaPokemon");
                datos.setearParametro("@numero", nuevo.Numero);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@img", nuevo.UrlImagen);
                datos.setearParametro("@idTipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                //datos.setearParametro("@idEvolucion", null);
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

        public void Modificar(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set numero=@Numero,Nombre=@nombre,Descripcion=@descripcion,UrlImagen=@img, IdTipo=@idTipo, IdDebilidad=@idDebilidad where Id=@id");
                datos.setearParametro("@numero", poke.Numero);
                datos.setearParametro("@nombre", poke.Nombre);
                datos.setearParametro("@descripcion", poke.Descripcion);
                datos.setearParametro("@img", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.Id);
                datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@id", poke.Id);

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

        public void ModificarConSP(Pokemon poke)
        {

          /*    seteo del procedimiento almacenado
           *    create procedure storedModificarPokemon
                @numero int,
                @nombre varchar(50),
                @desc varchar(50),
                @img varchar(300),
                @idTipo int,
                @idDebilidad int,
                @id int
                as
                update POKEMONS set Numero = @numero,Nombre = @nombre, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo,IdDebilidad = @idDebilidad
                where id = @id;*/

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarPokemon");
                datos.setearParametro("@numero", poke.Numero);
                datos.setearParametro("@nombre", poke.Nombre);
                datos.setearParametro("@desc", poke.Descripcion);
                datos.setearParametro("@img", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.Id);
                datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@id", poke.Id);

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

        public void Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM POKEMONS where Id=@id");
                datos.setearParametro("@id",id);
                datos.ejecutarAccion(); 
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id FROM POKEMONS P, ELEMENTOS E, ELEMENTOS D WHERE E.Id=P.IdTipo AND D.id=P.IdDebilidad AND P.Activo=1 AND ";
                switch (campo)
                {
                    case "Número":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Numero >" + filtro;
                                break;
                            case "Menor a":
                                consulta += "Numero <" + filtro;
                                    break;
                            default: consulta += "Numero = " + filtro;
                                break;
                        }
                        break;

                    case "Nombre":
                            switch (criterio)
                            {
                                case "Empieza con":
                                    consulta += "Nombre like '" + filtro + "%'";
                                    break;
                                case "Termina con":
                                    consulta += "Nombre like '%" + filtro + "'";
                                    break;
                                default:
                                    consulta += "Nombre like '%" + filtro + "%'";
                                    break;
                            }
                        break;
                        
                    default:
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "P.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "P.Descripcion like '%" + filtro+"'";
                                break;
                            default:
                                consulta += "P.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon Aux = new Pokemon();
                    Aux.Id = (int)datos.Lector["Id"];
                    Aux.Numero = datos.Lector.GetInt32(0);
                    Aux.Nombre = (string)datos.Lector["Nombre"];
                    Aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagen"))))
                        Aux.UrlImagen = (string)datos.Lector["UrlImagen"];


                    Aux.Tipo = new Elemento();
                    Aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    Aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    Aux.Debilidad = new Elemento();
                    Aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    Aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    lista.Add(Aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarLogico(int id)
        {

            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update POKEMONS set Activo= 0 Where Id=@id");
                datos.setearParametro("@id",id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

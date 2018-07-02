using System;
using System.Collections.Generic;
using CentroBiologiaMolecularUCA;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class TOrdenAdn : Igeneric<OrdenAdn>
    {
        private SqlDataReader registros;
        //private Conexion c;
        //private SqlCommand comando;

        //PATRÓN SINGLETON

        #region "SINGLETON"
        public static TOrdenAdn dte = null;
        public TOrdenAdn()
        {

        }

        public static TOrdenAdn getInstance()
        {
            if (dte == null)
            {
                dte = new TOrdenAdn();
            }
            return dte;
        }

        #endregion
        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        //public DTEmpleado()
        //{
        //    c = Conexion.estaConectado();
        //}

        public bool crear(OrdenAdn e)
        {

            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                // string sql = "insert into T_Orden (Id_orden,Fecha,Entregado,Tipo_orden,Observaciones,Baucher,No_orden,Estado,Actividad) VALUES(2,@Mfecha,@Mentregado,@Mtipoorden,@Mobservaciones,@Mbaucher,@Mnoorden,@Mestado,1)";

                string sql = "insert into T_Orden (Tipo_caso,Id_examenes,Observaciones,Baucher,No_orden,Estado,Actividad,Fecha) VALUES(@Mtipocaso,@Mtipoorden,@Mobservaciones,@Mbaucher,@Mnoorden,@Mestado,1,@Mfecha)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@Mtipocaso", e.Tipo_caso);
                    comando.Parameters.AddWithValue("@Mtipoorden", e.Tipo_orden);
                    comando.Parameters.AddWithValue("@Mobservaciones", e.Observaciones);
                    comando.Parameters.AddWithValue("@Mbaucher", e.Baucher);
                    comando.Parameters.AddWithValue("@Mnoorden", e.No_orden);
                    comando.Parameters.AddWithValue("@Mestado", e.Estado);
                    comando.Parameters.AddWithValue("@Mfecha", e.Fecha);

                    //VALIDANDO SI LA CONEXIÓN ESTÁ ACTIVA O CERRADA
                    if (comando.Connection.State != System.Data.ConnectionState.Closed)
                    {
                        //EJECUTANDO SENTENCIA SQL CON EXECUTENONQUERY
                        int result = comando.ExecuteNonQuery();
                        /* 
                         * EL BLOQUE IF SIRVE PARA HACER UNA VALIDACIÓN DEL EXECUTENONQUERY
                         * DICHO MÉTODO DEVUELVE UN ENTERO, DONDE 0 ES QUE NO AFECTO NINGUNA FILA
                         * SI ES MAYOR A 0 (POSITIVO)
                         * QUIERE DECIR QUE SE GUARDARON DATOS EN LA BASE DE DATOS
                         */
                        if (result < 0)
                        {
                            guardado = false;
                            Console.WriteLine("ERROR AL INSERTAR DATOS");
                        }
                        else
                        {
                            guardado = true;
                        }
                    }
                    else
                    {
                        comando.Connection.Open();

                    }
                }
            }
            catch (Exception)
            {
                comando.Connection.Close();
                c.Close();
                c = null;
                throw;
            }
            finally
            {
                //LUEGO DE REALIZAR LA SENTENCIA SQL
                //CERRAMOS LA CONEXIÓN A LA BASE DE DATOS
                comando.Connection.Close();
                c.Close();
                c = null;
            }

            return guardado;
        }

        public bool modificar(OrdenAdn e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Orden set Tipo_caso=(@Mtipocaso),Id_examenes=(@Mtipoorden),Observaciones=(@Mobservaciones),Baucher=(@Mbaucher),No_orden=(@Mnoorden),Estado=(@Mestado),Fecha=(@Mfecha) where Id_orden=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@mid", e.Id_orden);
                    comando.Parameters.AddWithValue("@Mtipocaso", e.Tipo_caso);
                    comando.Parameters.AddWithValue("@Mtipoorden", e.Tipo_orden);
                    comando.Parameters.AddWithValue("@Mobservaciones", e.Observaciones);
                    comando.Parameters.AddWithValue("@Mbaucher", e.Baucher);
                    comando.Parameters.AddWithValue("@Mnoorden", e.No_orden);
                    comando.Parameters.AddWithValue("@Mestado", e.Estado);
                    comando.Parameters.AddWithValue("@Mfecha", e.Fecha);
                    //VALIDANDO SI LA CONEXIÓN ESTÁ ACTIVA O CERRADA
                    if (comando.Connection.State != System.Data.ConnectionState.Closed)
                    {
                        //EJECUTANDO SENTENCIA SQL CON EXECUTENONQUERY
                        int result = comando.ExecuteNonQuery();

                        /* 
                         * EL BLOQUE IF SIRVE PARA HACER UNA VALIDACIÓN DEL EXECUTENONQUERY
                         * DICHO MÉTODO DEVUELVE UN ENTERO, DONDE 0 ES QUE NO AFECTO NINGUNA FILA
                         * SI ES MAYOR A 0 (POSITIVO)
                         * QUIERE DECIR QUE SE GUARDARON DATOS EN LA BASE DE DATOS
                         */
                        if (result < 0)
                        {
                            guardado = false;
                            Console.WriteLine("ERROR AL INSERTAR DATOS");
                        }
                        else
                        {
                            guardado = true;
                        }
                    }
                    else
                    {
                        comando.Connection.Open();

                    }
                }
            }
            catch (Exception)
            {
                comando.Connection.Close();
                c.Close();
                c = null;
                throw;
            }
            finally
            {
                //LUEGO DE REALIZAR LA SENTENCIA SQL
                //CERRAMOS LA CONEXIÓN A LA BASE DE DATOS
                comando.Connection.Close();
                c.Close();
                c = null;
            }

            return guardado;
        }

        public bool eliminar(OrdenAdn orde)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Orden set Actividad=0 where Id_orden=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@mid", orde.Id_orden);
                    //VALIDANDO SI LA CONEXIÓN ESTÁ ACTIVA O CERRADA
                    if (comando.Connection.State != System.Data.ConnectionState.Closed)
                    {
                        //EJECUTANDO SENTENCIA SQL CON EXECUTENONQUERY
                        int result = comando.ExecuteNonQuery();

                        /* 
                         * EL BLOQUE IF SIRVE PARA HACER UNA VALIDACIÓN DEL EXECUTENONQUERY
                         * DICHO MÉTODO DEVUELVE UN ENTERO, DONDE 0 ES QUE NO AFECTO NINGUNA FILA
                         * SI ES MAYOR A 0 (POSITIVO)
                         * QUIERE DECIR QUE SE GUARDARON DATOS EN LA BASE DE DATOS
                         */
                        if (result < 0)
                        {
                            guardado = false;
                            Console.WriteLine("ERROR AL ELIMINAR DATOS");
                        }
                        else
                        {
                            guardado = true;
                        }
                    }
                    else
                    {
                        comando.Connection.Open();

                    }
                }
            }

            catch (Exception)
            {
                comando.Connection.Close();
                c.Close();
                c = null;
                throw;
            }
            finally
            {
                //LUEGO DE REALIZAR LA SENTENCIA SQL
                //CERRAMOS LA CONEXIÓN A LA BASE DE DATOS
                comando.Connection.Close();
                c.Close();
                c = null;
            }

            return guardado;
        }

        public SqlDataReader listarTodo()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select * from T_Orden where Actividad = 1;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }


        public SqlDataReader getOrdenporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select  Tipo_caso, Id_examenes , Observaciones, Baucher, No_orden, Estado, Fecha from T_Orden where Id_orden='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        //nuevo cambio
        public IEnumerable<OrdenAdn> GetData()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT  [Id_orden],[Baucher] FROM T_Orden where Actividad=1", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;
                    SqlDependency.Start(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new OrdenAdn()
                                
                            {
                                Id_orden = x.GetInt32(0),
                                Baucher = x.GetString(1),
                              
                            }).ToList();

                }
            }
        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            MyHub.Show();

        }

        List<OrdenAdn> Igeneric<OrdenAdn>.listarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
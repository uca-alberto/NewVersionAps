using System;
using System.Collections.Generic;
using CentroBiologiaMolecularUCA;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using System.Data.SqlClient;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTAdnPaternidad : Igeneric<OrdenAdn>
    {
        private SqlDataReader registros;
        //CONSTANTES DE CONEXIÓN Y COMANDO SQL


        #region "SINGLETON"
        public static DTAdnPaternidad dte = null;
        public DTAdnPaternidad()
        {

        }

        public static DTAdnPaternidad getInstance()
        {
            if (dte == null)
            {
                dte = new DTAdnPaternidad();
            }
            return dte;
        }

        #endregion
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public bool crear(OrdenAdn e)
        {

            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                // string sql = "insert into T_Orden (Id_orden,Fecha,Entregado,Tipo_orden,Observaciones,Baucher,No_orden,Estado,Actividad) VALUES(2,@Mfecha,@Mentregado,@Mtipoorden,@Mobservaciones,@Mbaucher,@Mnoorden,@Mestado,1)";

                string sql = "insert into T_Orden (id_Codigo,Tipo_caso,Id_examenes,Id_tipo_muestra,Id_cliente,Id_usuario,Id_empleado,Nombre_pareja,Nombre_menor,fec_nac,Observaciones,Baucher,Estado,Activo,Fecha) VALUES(@Mcodigo,@Mtipocaso,NULL,NULL,@Mcliente,@Midusuario,NULL,@Mnombrepareja,@Mnombrehijo,NULL,@Mobservaciones,@Mbaucher,@Mestado,1,@Mfecha)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                   // comando.Parameters.AddWithValue("@Midcliente", e.id_cliente);
                    comando.Parameters.AddWithValue("@Mcodigo", e.Id_codigo);
                    comando.Parameters.AddWithValue("@Mtipocaso", e.Tipo_Caso);
                    comando.Parameters.AddWithValue("@Mcliente", e.Id_cliente);
                    comando.Parameters.AddWithValue("@Midusuario", e.Id_usuario);
                    comando.Parameters.AddWithValue("@Mnombrepareja", e.Nombre_pareja);

                    comando.Parameters.AddWithValue("@Mnombrehijo", e.Nombre_menor);
                    comando.Parameters.AddWithValue("@Mobservaciones", e.Observaciones);
                    comando.Parameters.AddWithValue("@Mbaucher", e.Baucher);
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

        //
        public bool modificar(OrdenAdn e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Orden set Tipo_caso=(@Mtipocaso),Nombre_pareja=(@Mnombrepareja),Nombre_menor=(@Mnombrehijo),Observaciones=(@Mobservaciones),Baucher=(@Mbaucher),Estado=(@Mestado),Fecha=(@Mfecha) where Id_orden=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@mid", e.Id_orden);
                    comando.Parameters.AddWithValue("@Mtipocaso", e.Tipo_Caso);
                    
                    comando.Parameters.AddWithValue("@Mnombrepareja", e.Nombre_pareja);
                    comando.Parameters.AddWithValue("@Mnombrehijo", e.Nombre_menor);
                    comando.Parameters.AddWithValue("@Mobservaciones", e.Observaciones);
                    comando.Parameters.AddWithValue("@Mbaucher", e.Baucher);
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
                string sql = "update T_Orden set Activo=0 where Id_orden=(@mid)";

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
        //

        public SqlDataReader listarTodo()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select * from T_Orden where Activo = 1;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public SqlDataReader getOrdenporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select Id_codigo,Fecha,Tipo_caso,Nombre_pareja,Nombre_menor,Observaciones,Baucher,Estado from T_Orden where Id_orden='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public List<OrdenAdn> GetData()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT  [Id_orden],[Nombre_menor],[Baucher] FROM T_Orden where Activo=1 and Nombre_menor is not null", connection))
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
                                Nombre_menor = x.GetString(1),
                                Baucher = x.GetString(2),

                            }).ToList();

                }
            }
        }
        //nuevo
        public IEnumerable<OrdenAdn> GetDataDesactivados()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT  [Id_orden],[Baucher],[Nombre_menor] FROM T_Orden where Activo=1", connection))
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
                                Nombre_menor = x.GetString(1),
                                Baucher = x.GetString(2),

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

        public String generarCodigo()
        {
            c = Conexion.getInstance().ConexionDB();
            String codigo = "";
            int total = 0;
            String date;
            date = DateTime.Now.ToString("MM/dd/yyyy");
            String mes = date.Substring(0, 2);
            String anio = date.Substring(8, 2);

            try
            {
                SqlCommand cmd = new SqlCommand("Select count(*) as Id_orden from T_Orden", c);
                SqlDataReader sd = cmd.ExecuteReader();

                if (sd.Read())
                {
                    total = int.Parse(sd["Id_orden"].ToString()) + 1;
                }
                sd.Close();

                if (total < 10)
                {
                    codigo = "PAT" + mes + anio + "-0000" + total.ToString();
                }
                else if (total < 100)
                {
                    codigo = "PAT" + mes + anio + "-000" + total.ToString();
                }
                else if (total < 1000)
                {
                    codigo = "PAT" + mes + anio + "-00" + total.ToString();
                }
                else if (total < 10000)
                {
                    codigo = "PAT" + mes + anio + "-0" + total.ToString();
                }

            }
            catch (Exception)
            {

                c.Close();

            }
            return codigo;

        }



    }
}


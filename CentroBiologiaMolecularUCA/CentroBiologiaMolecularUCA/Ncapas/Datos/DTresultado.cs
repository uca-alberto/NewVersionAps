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
    public class DTresultado : Igeneric<Resultado>
    {
        private SqlDataReader registros;
        //private Conexion c;
        //private SqlCommand comando;
        //prueba2019
        //PATRÓN SINGLETON

        #region "SINGLETON"
        public static DTresultado dte = null;
        public DTresultado()
        {

        }
        public static DTresultado getInstance()
        {
            if (dte == null)
            {
                dte = new DTresultado();
            }
            return dte;
        }

        #endregion
        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public bool crear(Resultado e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();

                string sql = "insert into T_Resultados (Id_Orden,Fecha_procesamiento,Hora,Usuario_valida,Usuario_procesa,Estado,Observaciones,imagen,Activo) VALUES(@idorden,@Mfecha,@Mhora,@Musuariovalida,@Musuarioprocesa,@Mestado,@Mobservaciones,NULL,1)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@idorden", e.Id_orden);
                   // comando.Parameters.AddWithValue("@Mvalidacion", e.Validacion);
                    comando.Parameters.AddWithValue("@Mfecha", e.Fecha_procesamiento);
                    comando.Parameters.AddWithValue("@Mhora", e.Hora);
                    comando.Parameters.AddWithValue("@Musuariovalida", e.Usuario_valida);
                    comando.Parameters.AddWithValue("@Musuarioprocesa", e.Usuario_procesa);
                    comando.Parameters.AddWithValue("@Mestado", e.Estado);
                    comando.Parameters.AddWithValue("@Mobservaciones", e.Observaciones);

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

        public bool modificar(Resultado e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Resultados set Validacion=(@Mvalidacion),Fecha_procesamiento=(@Mfecha),Usuario_valida=(@Musuariovalida),Usuario_procesa=(@Musuarioprocesa),Estado=(@Mestado),Analisis=(@Manalisis),Resultado=(@Mresultado) where Id_resultado=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@mid", e.Id_resultado);
                    comando.Parameters.AddWithValue("@Mvalidacion", e.Validacion);
                    comando.Parameters.AddWithValue("@Mfecha", e.Fecha_procesamiento);
                    comando.Parameters.AddWithValue("@Musuariovalida", e.Usuario_valida);
                    comando.Parameters.AddWithValue("@Musuarioprocesa", e.Usuario_procesa);
                    comando.Parameters.AddWithValue("@Mestado", e.Estado);

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

        public bool eliminar(Resultado re)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Resultados set Actividad=0 where Id_resultado=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@mid", re.Id_resultado);
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
            String sql = "select * from T_Resultados where Actividad = 1;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public SqlDataReader getresultadoporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select  Validacion, Fecha_procesamiento, Usuario_valida, Usuario_procesa, Estado, Analisis, Resultado from T_Resultados where Id_resultado='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        //Para cargar los tipos de analisis a la tabla
        public SqlDataReader getAnalisisporId(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT detalle.Id_analisis, analisis.analisis From T_Tipo_Analisis analisis INNER JOIN T_Orden_detalle detalle on analisis.Id_analisis=detalle.Id_analisis where detalle.Id_orden='" + id + "';";
            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
        public SqlDataReader cargardatosporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT clientes.Nombre, clientes.Apellido,orden.Id_codigo,orden.Id_tipo_muestra,orden.Id_usuario,emp.Nombre_empleado, emp.Apellido,emp.Cargo FROM T_Orden orden INNER JOIN T_Clientes clientes ON orden.Id_cliente=clientes.Id_cliente INNER JOIN T_Usuario usuario ON usuario.Id_usuario=orden.Id_usuario INNER JOIN T_Empleados emp ON usuario.Id_empleado=emp.Id_empleado where Id_orden ='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public SqlDataReader cargardatosadnporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT clientes.Nombre, clientes.Apellido,orden.Id_codigo,orden.Nombre_pareja, orden.Nombre_menor FROM T_Orden orden INNER JOIN T_Clientes clientes ON orden.Id_cliente=clientes.Id_cliente where Id_orden ='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public SqlDataReader datousuario(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT T_Empleados.Nombre_empleado, T_Empleados.Apellido from T_Empleados INNER JOIN T_Usuario ON T_Usuario.Id_empleado = T_Empleados.Id_empleado Where T_Usuario.Id_usuario = '" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }



  
        public List<Resultado> GetData()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT  [Id_resultado],[Estado] FROM T_Resultados where Activo=1", connection))
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
                            .Select(x => new Resultado()

                            {
                                Id_resultado = x.GetInt32(0),
                                Estado = x.GetString(1)
                            }).ToList();

                }
            }
        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            MyHub.Show();

        }

        List<Resultado> Igeneric<Resultado>.listarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
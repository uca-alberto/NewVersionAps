using System;
using System.Collections.Generic;
using CentroBiologiaMolecularUCA;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;

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

                string sql = "insert into T_Resultados (Id_Orden,Validacion,Fecha_procesamiento,Hora,Usuario_valida,Usuario_procesa,Estado,Observaciones,imagen,Activo) VALUES(@idorden,NULL,@Mfecha,@Mhora,NULL,@Musuarioprocesa,@Mestado,@Mobservaciones,NULL,1)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@idorden", e.Id_orden);
                    comando.Parameters.AddWithValue("@Mfecha", e.Fecha_procesamiento);
                    comando.Parameters.AddWithValue("@Mhora", e.Hora);
                    //comando.Parameters.AddWithValue("@Musuariovalida", e.Usuario_valida);
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

        public bool crearAdn(Resultado e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();

                string sql = "insert into T_Resultados (Id_Orden,Validacion,Fecha_procesamiento,Hora,Usuario_valida,Usuario_procesa,Estado,Observaciones,imagen,Activo) VALUES(@idorden,@validacion,@Mfecha,@Mhora,NULL,@Musuarioprocesa,@Mestado,@Mobservaciones,@imagen,1)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@idorden", e.Id_orden);
                    comando.Parameters.AddWithValue("@validacion", e.Validacion);
                    comando.Parameters.AddWithValue("@Mfecha", e.Fecha_procesamiento);
                    comando.Parameters.AddWithValue("@Mhora", e.Hora);
                    //comando.Parameters.AddWithValue("@Musuariovalida", e.Usuario_valida);
                    comando.Parameters.AddWithValue("@Musuarioprocesa", e.Usuario_procesa);
                    comando.Parameters.AddWithValue("@Mestado", e.Estado);
                    comando.Parameters.AddWithValue("@Mobservaciones", e.Observaciones);
                    comando.Parameters.AddWithValue("@imagen", e.Imagen);

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
                string sql = "Delete from T_Resultados where Id_resultado=(@mid)";

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
		//update estado Orden
		public bool updateorden(Resultado re)
		{
			bool guardado = false;
			try
			{
				//CONSULTA SQL
				c = Conexion.getInstance().ConexionDB();
				string sql = "UPDATE ord SET ord.Estado=1 FROM T_Orden ord INNER JOIN T_Resultados res ON res.Id_Orden=ord.Id_orden where res.Id_resultado=(@mid)";

				//PASANDO PARÁMETROS A CONSULTA SQL
				using (comando = new SqlCommand(sql, c))
				{

					comando.Parameters.AddWithValue("@mid", re.Id_resultado);
					//VALIDANDO SI LA CONEXIÓN ESTÁ ACTIVA O CERRADA
					if (comando.Connection.State != System.Data.ConnectionState.Closed)
					{
						//EJECUTANDO SENTENCIA SQL CON EXECUTENONQUERY
						int result = comando.ExecuteNonQuery();
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
				comando.Connection.Close();
				c.Close();
				c = null;
			}

			return guardado;
		}



		//Listar todos los Resultados
		public SqlDataReader listarTodo()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select * from T_Resultados where Actividad = 1;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        //Cargar datos del resultado(OGM)
        public SqlDataReader getresultadoporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT Usuario_procesa,Fecha_procesamiento,Hora,Observaciones, imagen, Validacion FROM T_Resultados where Id_resultado='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        //Obtener data Ver Resultado segun Orden
        public SqlDataReader cargardatosporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT ord.Id_codigo,ord.Id_tipo_muestra,cli.Nombre,cli.Apellido FROM T_Orden ord INNER JOIN T_Clientes cli ON ord.Id_cliente=cli.Id_cliente where ord.Id_orden='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
        //Obtener data para generar el resultado 
        public SqlDataReader verdatosresultados(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT res.Id_Orden,res.Usuario_procesa,ord.Id_codigo,cli.Nombre,cli.Apellido,ord.Id_tipo_muestra FROM T_Resultados res INNER JOIN T_Orden ord ON ord.Id_orden=res.Id_Orden INNER JOIN T_Clientes cli ON cli.Id_cliente=ord.Id_cliente where Id_resultado='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
        //Obtener data para generar el resultado adn
        public SqlDataReader verdatosresultadosadn(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT res.Id_Orden,ord.Id_codigo,cli.Nombre,cli.Apellido,ord.Tipo_Caso, ord.Nombre_pareja, ord.Nombre_menor, ord.fec_nac FROM T_Resultados res INNER JOIN T_Orden ord ON ord.Id_orden=res.Id_Orden INNER JOIN T_Clientes cli ON cli.Id_cliente=ord.Id_cliente where Id_resultado='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
        //ADN
        public SqlDataReader cargardatosadnporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT clientes.Nombre, clientes.Apellido,orden.Id_codigo,orden.Nombre_pareja, orden.Nombre_menor, orden.Tipo_caso FROM T_Orden orden INNER JOIN T_Clientes clientes ON orden.Id_cliente=clientes.Id_cliente where Id_orden ='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }
        //data del Usuario que procesa el resultado
        public SqlDataReader datousuario(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT T_Empleados.Nombre_empleado, T_Empleados.Apellido from T_Empleados INNER JOIN T_Usuario ON T_Usuario.Id_empleado = T_Empleados.Id_empleado Where T_Usuario.Id_usuario = '" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        //Llenar tabla visualizar Resultado
        public SqlDataReader visualizartabla(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT ta.analisis,op.Resultado FROM T_Tipo_Analisis ta INNER JOIN T_Resultado_Detalle detalle ON ta.Id_analisis=detalle.Id_analisis INNER JOIN T_Opcion_resultado op ON op.Id_opcion=detalle.Resultado where detalle.Id_resultado='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        //Para cargar los tipos de analisis a la tabla
        public SqlDataReader getAnalisisporId(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT Id_analisis FROM T_Resultado_Detalle where Id_resultado='" + id + "';";
            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public SqlDataReader getAnalisisporIdorden(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "SELECT det.Id_analisis,tipo.analisis FROM T_Orden_detalle det INNER JOIN T_Tipo_Analisis tipo ON det.Id_analisis=tipo.Id_analisis where Id_orden='" + id + "';";
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
                using (SqlCommand command = new SqlCommand(@"SELECT  res.Id_resultado,res.Estado,exa.Nombre FROM T_Resultados res INNER JOIN T_Orden ord ON res.Id_Orden=ord.Id_orden INNER JOIN T_Examenes exa ON exa.Id_examenes=ord.Id_examenes where res.Activo=1 AND res.Estado = 'Aprobada'", connection))
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
                                Estado = x.GetString(1),
                                Tipo = x.GetString(2)
                            }).ToList();

                }
            }
        }

        public List<Resultado> GetDatos()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT  [Id_resultado],[Id_codigo], [Nombre], re.Estado FROM T_Resultados re INNER JOIN T_Orden ord ON re.Id_orden = ord.Id_orden INNER JOIN T_Examenes exa ON ord.Id_examenes=exa.Id_examenes where re.Activo=1 AND re.Estado = 'Procesada'", connection))
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
                                Id_codigo = x.GetString(1),
                                Examen = x.GetString(2),
                                Estado = x.GetString(3)
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

        public bool Aprobar(Resultado re)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Resultados set Estado='Aprobada', Usuario_valida = (@mus) where Id_resultado=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@mid", re.Id_resultado);
                    comando.Parameters.AddWithValue("@mus", re.Usuario_valida);
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

        public bool Anular(Resultado re)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Resultados set Estado='Anulada' where Id_resultado=(@mid)";

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

        public bool creardetalle(Resultado e)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();

                string sql = "insert into T_Resultado_Detalle (Id_resultado,Id_analisis,Resultado) VALUES(@Idresultado,@Idanalisis,@Resultado)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@Idresultado", e.Id_resultado);
                    comando.Parameters.AddWithValue("@Idanalisis", e.Id_analisis);
                    comando.Parameters.AddWithValue("@Resultado", e.Resultados);

                    //VALIDANDO SI LA CONEXIÓN ESTÁ ACTIVA O CERRADA
                    if (comando.Connection.State != System.Data.ConnectionState.Closed)
                    {
                        //EJECUTANDO SENTENCIA SQL CON EXECUTENONQUERY
                        int result = comando.ExecuteNonQuery();
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
                comando.Connection.Close();
                c.Close();
                c = null;
            }

            return guardado;

        }
        
        public bool ordenprocesada(Resultado res)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Orden set Estado=0 where Id_orden=(@mid)";

                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@mid", res.Id_orden);
                    //VALIDANDO SI LA CONEXIÓN ESTÁ ACTIVA O CERRADA
                    if (comando.Connection.State != System.Data.ConnectionState.Closed)
                    {
                        //EJECUTANDO SENTENCIA SQL CON EXECUTENONQUERY
                        int result = comando.ExecuteNonQuery();
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
                comando.Connection.Close();
                c.Close();
                c = null;
            }

            return guardado;
        }

        public int ultimoid()
        {
			int valor=0;
            string id;
			c = Conexion.getInstance().ConexionDB();
			try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(Id_resultado)as Id_Resultado FROM T_Resultados", c);
                SqlDataReader sd = cmd.ExecuteReader();

                if (sd.Read())
                {
                    id = sd["Id_Resultado"].ToString();
					valor = int.Parse(id);
				}
                sd.Close();
				

            }
            catch (Exception)
            {
				c.Close();
				c = null;
				throw;
			}
			finally
			{
				c.Close();
				c = null;
			}
			return valor;
        }
    }
}
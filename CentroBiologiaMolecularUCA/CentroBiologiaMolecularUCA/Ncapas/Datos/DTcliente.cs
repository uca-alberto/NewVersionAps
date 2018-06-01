using CentroBiologiaMolecularUCA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTcliente : Igeneric<Cliente>
    {
        private SqlDataReader registros;
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTcliente dte = null;
        public DTcliente()
        {

        }

        public static DTcliente getInstance()
        {
            if (dte == null)
            {
                dte = new DTcliente();
            }
            return dte;
        }
        #endregion

        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;

        public bool crear(Cliente cliente)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "insert into T_Clientes (Nombre,Activo,Apellido,Cedula,Direccion,Id_Departamento, Id_Municipio, Sexo, Num_telefono, Email) VALUES(@Mnombre,1,@Mapellido,@Mcedula,@Mdireccion,@Mdepartamento,@Mmunicipio,@Msexo,@Mtelefono,@Mcorreo)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@Mnombre", cliente.Nombres);
                    comando.Parameters.AddWithValue("@Mdireccion", cliente.Dirreccion);
                    comando.Parameters.AddWithValue("@Mapellido", cliente.Apellidos);
                    comando.Parameters.AddWithValue("@Mcedula", cliente.Cedula);
                    comando.Parameters.AddWithValue("@Mdepartamento", cliente.Departamento);
                    comando.Parameters.AddWithValue("@Mmunicipio", cliente.Municipio);
                    comando.Parameters.AddWithValue("@Msexo", cliente.Sexo);
                    comando.Parameters.AddWithValue("@Mtelefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@Mcorreo", cliente.Correo);

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

        public bool modificar(Cliente cliente)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Clientes set Nombre=(@Mnombre),Apellido=(@Mapellido),Cedula=(@Mcedula) ,Id_Departamento=(@Mdepartamento),Direccion=(@Mdireccion), Id_Municipio=(@Mmunicipio), Sexo=(@Msexo), Num_telefono=(@Mtelefono), Email=(@Mcorreo) where Id_Cliente=(@mid)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@mid", cliente.Id_Cliente);
                    comando.Parameters.AddWithValue("@Mnombre", cliente.Nombres);
                    comando.Parameters.AddWithValue("@Mdireccion", cliente.Dirreccion);
                    comando.Parameters.AddWithValue("@Mapellido", cliente.Apellidos);
                    comando.Parameters.AddWithValue("@Mcedula", cliente.Cedula);
                    comando.Parameters.AddWithValue("@Mdepartamento", cliente.Departamento);
                    comando.Parameters.AddWithValue("@Mmunicipio", cliente.Municipio);
                    comando.Parameters.AddWithValue("@Msexo", cliente.Sexo);
                    comando.Parameters.AddWithValue("@Mtelefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@Mcorreo", cliente.Correo);

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

        public bool eliminar(Cliente cli)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Clientes set Activo=0 where Id_Cliente=(@mid)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@mid", cli.Id_Cliente);
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

        /*public SqlDataReader listarCliente()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select * from T_Clientes where Activo= 1;";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand comando = new SqlCommand(sql, this.c))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    comando.Notification = null;
                    SqlDependency.Start(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
                    SqlDependency dependency = new SqlDependency(comando);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    this.registros = comando.ExecuteReader();
                    return this.registros;
                    c.Close();

                }
            }

        }*/

        public SqlDataReader getClienteporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select Nombre,Apellido,Cedula , Id_Departamento, Id_Municipio,Direccion, Sexo, Num_telefono, Email from T_Clientes where Id_Cliente='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public IEnumerable<Cliente> GetData()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT  [Id_cliente],[Nombre],[Apellido],[Email] FROM T_Clientes", connection))
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
                            .Select(x => new Cliente()
                            {
                                Id_Cliente = x.GetInt32(0),
                                Nombres = x.GetString(1),
                                Apellidos = x.GetString(2),
                                Correo = x.GetString(3)
                            }).ToList();

                }
            }
        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            MyHub.Show();

        }

        public List<Cliente> listarTodo()
        {
            throw new NotImplementedException();
        }
    }
}


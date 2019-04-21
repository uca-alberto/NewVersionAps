using CentroBiologiaMolecularUCA;
using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using Microsoft.AspNet.SignalR.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos
{
    public class DTUsuario : Igeneric<Usuario>
    {
        private SqlDataReader registros;
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static DTUsuario dtu = null;
        public DTUsuario()
        {

        }

        public static DTUsuario getInstance()
        {
            if (dtu == null)
            {
                dtu = new DTUsuario();
            }
            return dtu;
        }
        #endregion

        //CONSTANTES DE CONEXIÓN Y COMANDO SQL
        SqlConnection c = new SqlConnection();
        SqlCommand comando = null;


        public bool crear(Usuario usuario)
        {
            bool guardado = false;

            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();



                string sql = "CBM.dbo.AgregarUsuario";

                using (comando = new SqlCommand(sql, c))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_rol", usuario.Id_rol);
                    comando.Parameters.AddWithValue("@id_empleado", usuario.Id_empleado);
                    comando.Parameters.AddWithValue("@nombre_usuario", usuario.Nombre);
                    string hash = DTlogin.EncodePassword(string.Concat(usuario.Nombre, usuario.Contrasena));
                    comando.Parameters.AddWithValue("@contrasena", hash);
                    comando.Parameters.AddWithValue("activo", usuario.Activo);
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

        public bool modificar(Usuario usuario)
        {
            bool guardado = false;

            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Usuario set Id_rol = (@Mrol), Nombre_Usuario = (@MNombre), Contrasena = (@MContrasena) where Id_usuario=(@Mid)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {
                    comando.Parameters.AddWithValue("@Mid", usuario.Id_usuario);
                    comando.Parameters.AddWithValue("@id_empleado", usuario.Id_empleado);
                    comando.Parameters.AddWithValue("@MNombre", usuario.Nombre);
                    string hash = DTlogin.EncodePassword(string.Concat(usuario.Nombre, usuario.Contrasena));
                    comando.Parameters.AddWithValue("@Mcontrasena", hash);
                    comando.Parameters.AddWithValue("@Mrol", usuario.Id_rol);

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

        public bool eliminar(Usuario usuario)
        {
            bool guardado = false;

            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "update T_Usuario set Activo=0 where Id_usuario = (@Mid)";


                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@mid", usuario.Id_usuario);
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


        //Lista los usuarios que estan activos
        public SqlDataReader listarTodo()
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select * from T_Usuario where Activo = 1;";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }



        public SqlDataReader getUsuarioporid(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            String sql = "select Nombre_Usuario,Contrasena,Id_rol, Id_empleado from T_Usuario where Id_usuario='" + id + "';";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public bool log(Usuario us)
        {
            bool log = false;

            try
            {

                c = Conexion.getInstance().ConexionDB();
                //Recibir los datos del usuario para validarlos
                String sql = "SELECT Nombre_Usuario FROM T_Usuario where Nombre_Usuario = @usuario AND Contrasena = @contrasena";
                SqlCommand comando = new SqlCommand(sql, this.c);
                comando.Parameters.AddWithValue("usuario", us.Nombre);
                comando.Parameters.AddWithValue("contrasena", us.Contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(comando);
                //Revisar si existe

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    log = true;
                }
                else
                {
                    Console.WriteLine("ERROR AL INSERTAR DATOS");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return log;
        }
        // Listar los empleados sin usuario
        public SqlDataReader ListarEmpleados()
         {
            c = Conexion.getInstance().ConexionDB();
            String sql = "Select T_Empleados.Id_empleado, T_Empleados.Nombre_empleado, T_Empleados.Apellido, T_Empleados.Cedula  from T_Empleados  WHERE NOT EXISTS (Select T_empleados.Id_empleado from T_Usuario Where T_Empleados.Id_empleado = T_Usuario.Id_empleado)";

            SqlCommand comando = new SqlCommand(sql, this.c);
            this.registros = comando.ExecuteReader();
            return this.registros;
            c.Close();
        }

        public int Sicrear()
        {
            

                string sql = @"SELECT COUNT(*)
                         FROM T_Usuario
                         WHERE activo=1";
              

            int count;

            c = Conexion.getInstance().ConexionDB();
                try
                {

                    using (comando = new SqlCommand(sql, c))
                    {

                        count = Convert.ToInt32(comando.ExecuteScalar());

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

                                Console.WriteLine("ERROR AL INSERTAR DATOS");
                            }
                            else
                            {
                                comando.Connection.Open();
                            }
                        }

                    }



                }
                catch
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


            return count;
        }

        public int SicrearE()
        {
              string sql2 = @"SELECT COUNT(*)
                                FROM T_Empleados
                                WHERE activo=1";

        int count2;

        c = Conexion.getInstance().ConexionDB();
            try
            {

                using (comando = new SqlCommand(sql2, c))
                {

                    count2 = Convert.ToInt32(comando.ExecuteScalar());

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

                            Console.WriteLine("ERROR AL INSERTAR DATOS");
                        }
                        else
                        {
                            comando.Connection.Open();
                        }
                    }

                }



            }
            catch
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

            return count2;
        }

        public List<Usuario> GetData()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT  [Id_usuario],[Nombre_Usuario], [rol] FROM T_Usuario us INNER JOIN T_Rol rol ON us.Id_rol = rol.Id_rol where Activo=1", connection))
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
                            .Select(x => new Usuario()

                            {
                                Id_usuario = x.GetInt32(0),
                                Nombre = x.GetString(1),
                                nombre_rol = x.GetString(2),

                            }).ToList();
                }
            }
        }

        /// Permisos
        /// Listar los roles excepto el admin
        public List<Usuario> GetRoles()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"Select Id_rol, Rol from T_Rol WHERE rol != 'Administrador'", connection))
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
                            .Select(x => new Usuario()

                            {
                                Id_rol = x.GetInt32(0),
                                nombre_rol = x.GetString(1),

                            }).ToList();

                }
            }
        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            MyHub.Show();

        }



        //Listar permisos que no posee
        public SqlDataReader Permisos(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            string sql = "Select [Id_opciones], [rol_opciones] From T_Rol_Opciones Where Id_rol = 1 EXCEPT SELECT [Id_opciones], [rol_opciones] From T_Rol_Opciones Where Id_rol ='" + id + "')";
            SqlCommand comando = new SqlCommand(sql, c);
            SqlDataReader leer = comando.ExecuteReader();
            return leer;
            c.Close();
        }

        //Listar permisos que posee
        public SqlDataReader eliminable(int id)
        {
            c = Conexion.getInstance().ConexionDB();
            string sql = "Select Id_rol_opciones, rol_opciones FROM T_Rol_opciones WHERE Id_rol ='" + id + "';";
            SqlCommand comando = new SqlCommand(sql, c);
            SqlDataReader leer = comando.ExecuteReader();
            return leer;
            c.Close();
        }

        /// Permisos
        /// Extraer la seleccion
        public SqlDataReader opciones(int opc)
        {
            c = Conexion.getInstance().ConexionDB();
            string sql = "Select * from T_Rol_opciones Where Id_rol_opciones = '" + opc + "';";
            SqlCommand comando = new SqlCommand(sql, c);
            SqlDataReader opcion = comando.ExecuteReader();
            return opcion;
            c.Close();
        }


        /// Permisos
        /// Agregar permisos

        public bool guardar(Permiso per)
        {
            bool guardado = false;
            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "insert into T_Rol_opciones (Id_rol, Id_opciones, rol_opciones) VALUES(@id_rol, @id_opciones, @rol_opciones)";
                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@id_rol", per.Id_rol);
                    comando.Parameters.AddWithValue("@Id_opciones", per.Id_opciones);
                    comando.Parameters.AddWithValue("@rol_opciones", per.Rol_opciones);



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

        List<Usuario> Igeneric<Usuario>.listarTodo()
        {
            throw new NotImplementedException();
        }

        /// Permisos
        /// Eliminar permisos
        public bool delete(Permiso per)
        {
            bool eliminado = false;

            try
            {
                //CONSULTA SQL
                c = Conexion.getInstance().ConexionDB();
                string sql = "DELETE FROM T_Rol_opciones Where Id_rol_opciones = (@mid)";


                //PASANDO PARÁMETROS A CONSULTA SQL
                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@mid", per.Id_rol_opciones);
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
                            eliminado = false;
                            Console.WriteLine("ERROR AL ELIMINAR DATOS");
                        }
                        else
                        {
                            eliminado = true;
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


            return eliminado;
        }

        public bool acceso(int rol, string ubicacion)
        {
            bool autentico = false;
            //Declaramos la sentencia SQL 
            string sql = "SELECT COUNT(*) FROM T_Opciones INNER JOIN T_Rol_opciones ON T_Opciones.Id_opciones = T_Rol_opciones.Id_opciones INNER JOIN T_Rol ON T_Rol_opciones.Id_rol = T_Rol.Id_rol where T_Rol.Id_rol = @rol AND T_Opciones.Opciones = @ubicacion";
            c = Conexion.getInstance().ConexionDB();

            //Se utiliza Using para indicarle al compilador que este bloque se llame al metodo dispose

            try
            {

                using (comando = new SqlCommand(sql, c))
                {

                    comando.Parameters.AddWithValue("@rol", rol);
                    comando.Parameters.AddWithValue("@ubicacion", ubicacion);//QUITE EL HASH

                    int count = Convert.ToInt32(comando.ExecuteScalar());


                    if (count != 0)
                    {
                        autentico = true;
                    }


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

                            Console.WriteLine("ERROR AL INSERTAR DATOS");
                        }
                        else
                        {
                            comando.Connection.Open();
                        }
                    }

                }



            }
            catch
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


            return autentico;
        }
    }
}

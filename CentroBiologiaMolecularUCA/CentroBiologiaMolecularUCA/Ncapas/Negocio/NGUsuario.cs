using System.Collections.Generic;
using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio
{
    public class NGUsuario
    {
        //PATRÓN SINGLETON
        #region "SINGLETON"
        private static NGUsuario us = null;
        private NGUsuario()
        {

        }

        public static NGUsuario getInstance()
        {
            if (us == null)
            {
                us = new NGUsuario();
            }

            return us;
        }

        #endregion

        public bool guardarUsuario(Usuario usuario)
        {

            return DTUsuario.getInstance().crear(usuario);
        }
        public bool EliminarUsuario(Usuario usuario)
        {
            return DTUsuario.getInstance().eliminar(usuario);
        }
        public bool ModificarUsuario(Usuario usuario)
        {
            return DTUsuario.getInstance().modificar(usuario);
        }

        public bool logeo(Usuario usuario)
        {
            return DTUsuario.getInstance().log(usuario);
        }


        public SqlDataReader acceso(int rol)
        {
            return DTUsuario.getInstance().acceso(rol);
        }
        /*
        public SqlDataReader lista()
        {
            return DTUsuario.getInstance().lista();
        }
        */
        public SqlDataReader ListarEmpleados()
        {
            return DTUsuario.getInstance().ListarEmpleados();
        }

        public SqlDataReader getUsuarioporid(int id)
        {
            return DTUsuario.getInstance().getUsuarioporid(id);
        }

        public List<Usuario> GetData()
        {
            return DTUsuario.getInstance().GetData();
        }

        public SqlDataReader listarRol()
        {
            return DTrol.getInstance().listarRol();
        }

      /*  public SqlDataReader listarPermisos(int id)
        {
           /return DTUsuario.getInstance().listaPermisos(id);
        }

        public SqlDataReader permisos()
        {
            return DTUsuario.getInstance().Permisos();
        }

        public SqlDataReader opciones(string opc)
        {
            return DTUsuario.getInstance().opciones(opc);
        }

        public bool guardar(Permiso pers)
        {

            return DTUsuario.getInstance().guardar(pers);
        }

        public bool delete(Permiso pers)
        {
            return DTUsuario.getInstance().delete(pers);
        }*/
    }
}
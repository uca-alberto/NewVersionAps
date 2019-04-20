using CentroBiologiaMolecularUCA.Ncapas.Entidades;
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


        public bool acceso(int rol, string ubicacion)
        {
            return DTUsuario.getInstance().acceso(rol, ubicacion);
        }

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

        public SqlDataReader listarPermisos(int id)
        {
           return DTUsuario.getInstance().Permisos(id);
        }

        public SqlDataReader permisosUsuario(int id)
        {
            return DTUsuario.getInstance().eliminable(id);
        }


        public SqlDataReader opciones(int opc)
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
        }
    }
}
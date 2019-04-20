using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class Permiso
    {


        private int id_rol;
        private String rol;
        private String rol_opciones;
        private int id_rol_opciones;
        private int id_opciones;

        public int Id_rol
        {
            get
            {
                return id_rol;
            }
            set
            {
                id_rol = value;
            }

        }

        public string Rol
        {
            get
            {
                return rol;
            }
            set
            {
                rol = value;
            }
        }

        public string Rol_opciones
        {
            get
            {
                return rol_opciones;
            }
            set
            {
                rol_opciones = value;
            }
        }
        public int Id_rol_opciones
        {
            get
            {
                return id_rol_opciones;
            }
            set
            {
                id_rol_opciones = value;
            }
        }
        public int Id_opciones
        {
            get
            {
                return id_opciones;
            }
            set
            {
                id_opciones = value;
            }
        }
    }
}
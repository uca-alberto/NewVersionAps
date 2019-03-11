using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class Empleado
    {
        private int id_Empleado;
        private String nombre_Empleado;
        private String apellido;
        private String cargo;
        private String cedula;

        public int Id_Empleado
        {
            get
            {
                return id_Empleado;
            }

            set
            {
                id_Empleado = value;
            }
        }

        public string Nombre_Empleado
        {
            get
            {
                return nombre_Empleado;
            }

            set
            {
                nombre_Empleado = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }

        public string Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }
    }
}
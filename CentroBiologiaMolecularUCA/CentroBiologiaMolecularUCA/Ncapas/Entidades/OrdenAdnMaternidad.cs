using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class OrdenAdnMaternidad
    {
        private int id_maternidad;
        private String codigo;
        private String tipo_caso;
        private String tipo_orden;
        private String tipo_muestra;
        private String cliente;
        private String empleado;
        private String nombrepareja;
        private String nombremenor;
        private DateTime fecha_nac;
        private String observaciones;
        private String boucher;
        private String estado;
        private DateTime fecha;

        public int Id_maternidad
        {
            get
            {
                return id_maternidad;
            }

            set
            {
                id_maternidad = value;
            }
        }

        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Tipo_caso
        {
            get
            {
                return tipo_caso;
            }

            set
            {
                tipo_caso = value;
            }
        }

        public string Tipo_orden
        {
            get
            {
                return tipo_orden;
            }

            set
            {
                tipo_orden = value;
            }
        }

        public string Tipo_muestra
        {
            get
            {
                return tipo_muestra;
            }

            set
            {
                tipo_muestra = value;
            }
        }

        public string Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public string Empleado
        {
            get
            {
                return empleado;
            }

            set
            {
                empleado = value;
            }
        }

        public string Nombrepareja
        {
            get
            {
                return nombrepareja;
            }

            set
            {
                nombrepareja = value;
            }
        }

        public string Nombremenor
        {
            get
            {
                return nombremenor;
            }

            set
            {
                nombremenor = value;
            }
        }

        public DateTime Fecha_nac
        {
            get
            {
                return fecha_nac;
            }

            set
            {
                fecha_nac = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public string Boucher
        {
            get
            {
                return boucher;
            }

            set
            {
                boucher = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }
    }
}
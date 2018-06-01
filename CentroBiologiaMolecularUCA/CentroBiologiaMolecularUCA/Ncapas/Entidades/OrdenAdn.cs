using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class OrdenAdn
    {
        private int id_orden;
        private String tipo_caso;
        private String tipo_orden;
        private String observaciones;
        private String baucher;
        private int no_orden;
        private String estado;
        private String fecha;

        public int Id_orden
        {
            get
            {
                return id_orden;
            }

            set
            {
                id_orden = value;
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

        public string Baucher
        {
            get
            {
                return baucher;
            }

            set
            {
                baucher = value;
            }
        }

        public int No_orden
        {
            get
            {
                return no_orden;
            }

            set
            {
                no_orden = value;
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

        public string Fecha
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
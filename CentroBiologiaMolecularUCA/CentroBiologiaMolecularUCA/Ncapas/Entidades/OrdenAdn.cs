using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class OrdenAdn
    {
        private int id_orden;
        private String id_codigo;
        private String tipo_Caso;
        private String tipo_examen;
        private String tipo_muestra;
        private String id_cliente;
        private String id_usuario;
        private String id_empleado;
        private String nombre_pareja;
        private String nombre_menor;
        private DateTime fec_nac;
        private String observaciones;
        private String baucher;
        private String estado;
        private DateTime fecha;

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




        public string Tipo_examen
        {
            get
            {
                return tipo_examen;
            }

            set
            {
                tipo_examen = value;
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

        public string Id_codigo
        {
            get
            {
                return id_codigo;
            }

            set
            {
                id_codigo = value;
            }
        }

        public string Tipo_Caso
        {
            get
            {
                return tipo_Caso;
            }

            set
            {
                tipo_Caso = value;
            }
        }

        public string Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
            }
        }

        public string Id_empleado
        {
            get
            {
                return id_empleado;
            }

            set
            {
                id_empleado = value;
            }
        }

        public string Nombre_pareja
        {
            get
            {
                return nombre_pareja;
            }

            set
            {
                nombre_pareja = value;
            }
        }

        public string Nombre_menor
        {
            get
            {
                return nombre_menor;
            }

            set
            {
                nombre_menor = value;
            }
        }

        public DateTime Fec_nac
        {
            get
            {
                return fec_nac;
            }

            set
            {
                fec_nac = value;
            }
        }

        public string Id_usuario
        {
            get
            {
                return id_usuario;
            }

            set
            {
                id_usuario = value;
            }
        }
    }
}
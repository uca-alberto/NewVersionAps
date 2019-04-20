using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class Resultado
    {
        private int id_resultado;
        private int id_orden;
        private String validacion;
        private DateTime fecha_procesamiento;
        private DateTime hora;
        private String usuario_valida;
        private String usuario_procesa;
        private String estado;
        private String observaciones;
        private String imagen;
        private String tipo;
        //Detalle
        private int id_analisis;
        private int resultados;
        private string id_codigo;
        private string examen;

        public int Id_resultado
        {
            get
            {
                return id_resultado;
            }

            set
            {
                id_resultado = value;
            }
        }

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

        public string Validacion
        {
            get
            {
                return validacion;
            }

            set
            {
                validacion = value;
            }
        }

        public DateTime Fecha_procesamiento
        {
            get
            {
                return fecha_procesamiento;
            }

            set
            {
                fecha_procesamiento = value;
            }
        }

        public DateTime Hora
        {
            get
            {
                return hora;
            }

            set
            {
                hora = value;
            }
        }

        public string Usuario_valida
        {
            get
            {
                return usuario_valida;
            }

            set
            {
                usuario_valida = value;
            }
        }

        public string Usuario_procesa
        {
            get
            {
                return usuario_procesa;
            }

            set
            {
                usuario_procesa = value;
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

        public string Imagen
        {
            get
            {
                return imagen;
            }
            set
            {
                imagen = value;
            }
        }

        public int Id_analisis
        {
            get
            {
                return id_analisis;
            }

            set
            {
                id_analisis = value;
            }
        }

        public int Resultados
        {
            get
            {
                return resultados;
            }

            set
            {
                resultados = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
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

        public string Examen
        {
            get
            {
                return examen;
            }
            set
            {
                examen = value;
            }
        }
    }
}
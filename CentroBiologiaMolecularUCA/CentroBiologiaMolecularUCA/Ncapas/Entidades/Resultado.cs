using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class Resultado
    {
        private int id_resultado;
        private String validacion;
        private String fecha_procesamiento;
        private String usuario_valida;
        private String usuario_procesa;
        private String estado;
        private String analisis;
        private String parametros;

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

        public string Fecha_procesamiento
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

        public string Analisis
        {
            get
            {
                return analisis;
            }

            set
            {
                analisis = value;
            }
        }

        public string Parametros
        {
            get
            {
                return parametros;
            }

            set
            {
                parametros = value;
            }
        }
    }
}
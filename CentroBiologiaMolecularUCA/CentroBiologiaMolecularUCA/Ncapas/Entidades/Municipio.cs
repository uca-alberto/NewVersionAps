using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class Municipio
    {
        private int id_municipio;
        private int id_departamento;
        private string nombre_municipio;

        public int Id_municipio
        {
            get
            {
                return id_municipio;
            }

            set
            {
                id_municipio = value;
            }
        }

        public int Id_departamento
        {
            get
            {
                return id_departamento;
            }

            set
            {
                id_departamento = value;
            }
        }

        public string Nombre_municipio
        {
            get
            {
                return nombre_municipio;
            }

            set
            {
                nombre_municipio = value;
            }
        }
    }
}
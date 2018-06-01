using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class Departamento
    {
        private int id_departamneto;
        private string nombre_departamento;

        public int Id_departamneto
        {
            get
            {
                return id_departamneto;
            }

            set
            {
                id_departamneto = value;
            }
        }

        public string Nombre_departamento
        {
            get
            {
                return nombre_departamento;
            }

            set
            {
                nombre_departamento = value;
            }
        }
    }
}
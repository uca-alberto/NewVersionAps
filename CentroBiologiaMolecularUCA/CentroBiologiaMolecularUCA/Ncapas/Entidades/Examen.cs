using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class Examen
    {
        private int id_examenes;
        private string nombre;
        private int precio_examen;

        public int Id_examenes
        {
            get
            {
                return id_examenes;
            }

            set
            {
                id_examenes = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Precio_examen
        {
            get
            {
                return precio_examen;
            }

            set
            {
                precio_examen = value;
            }
        }
    }
}
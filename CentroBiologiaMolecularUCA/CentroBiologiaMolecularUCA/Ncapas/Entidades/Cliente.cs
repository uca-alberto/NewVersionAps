using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades
{
    public class Cliente
    {
        private int id_Cliente;
        private String nombres;
        private String apellidos;
        private String cedula;
        private int telefono;
        private String departamento;
        private String municipio;
        private String sexo;
        private String correo;
        private string dirreccion;

        public int Id_Cliente
        {
            get
            {
                return id_Cliente;
            }

            set
            {
                id_Cliente = value;
            }
        }

        public string Nombres
        {
            get
            {
                return nombres;
            }

            set
            {
                nombres = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                apellidos = value;
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

        public int Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Departamento
        {
            get
            {
                return departamento;
            }

            set
            {
                departamento = value;
            }
        }

        public string Municipio
        {
            get
            {
                return municipio;
            }

            set
            {
                municipio = value;
            }
        }

        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public string Dirreccion
        {
            get
            {
                return dirreccion;
            }

            set
            {
                dirreccion = value;
            }
        }
    }
}
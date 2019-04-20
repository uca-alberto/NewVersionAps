using CentroBiologiaMolecularUCA.Ncapas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Opc.Use
{
    public partial class Peruser : System.Web.UI.Page
    {

        public Permiso per;
        private SqlDataReader agregar;
        private int id_agregar;
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            String valor = Request.QueryString["id"];
            id = int.Parse(valor);
            if (!IsPostBack)
            {
                Magregar.DataSource = NGUsuario.getInstance().listarPermisos(id);
                Magregar.DataTextField = "rol_opciones";
                Magregar.DataValueField = "Id_rol_opciones";
                Magregar.DataBind();

                Meliminar.DataSource = NGUsuario.getInstance().permisosUsuario(id);
                Meliminar.DataTextField = "rol_opciones";
                Meliminar.DataValueField = "Id_rol_opciones";
                Meliminar.DataBind();
            }
        }


        //COMBO BOX
        protected void Mpermiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Magregar.SelectedIndex == 0)
            {

            }
            else
            {
            }
        }

        protected void Permisos(object sender, EventArgs e)
        {
            if (Magregar.Items.Count > 0)
            {
                for (int i = 0; i < Magregar.Items.Count; i++)
                {
                    if (Magregar.Items[i].Selected)
                    {
                        per = new Permiso();
                        id_agregar = Convert.ToInt32(Magregar.Items[i].Value);
                        this.agregar = NGUsuario.getInstance().opciones(id_agregar);
                        if (agregar.Read())
                        {
                            per.Id_opciones = Convert.ToInt32(agregar["Id_opciones"].ToString());
                            per.Rol_opciones = agregar["rol_opciones"].ToString();
                        }
                        per.Id_rol = id;

                        NGUsuario.getInstance().guardar(per);
                    }
                }
            }


            if (Meliminar.Items.Count > 0)
            {
                for (int i = 0; i < Meliminar.Items.Count; i++)
                {
                    if (Meliminar.Items[i].Selected)
                    {
                        per = new Permiso();
                        per.Id_rol_opciones = Convert.ToInt32(Meliminar.Items[i].Value);
                        NGUsuario.getInstance().delete(per);

                    }
                }
            }

            Response.Redirect("../../../Views/Opc/Use/Rolesuse.aspx");
        }
    }
}
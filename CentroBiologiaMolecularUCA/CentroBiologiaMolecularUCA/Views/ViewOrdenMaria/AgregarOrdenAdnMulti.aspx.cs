using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Datos;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;


namespace CentroBiologiaMolecularUCA.Views.ViewOrdenMaria
{
    public partial class AgregarOrdenAdnMulti : System.Web.UI.Page
    {
        private TOrdenAdn tOrden;
        private DTexamenes dtexamenes;
        private SqlDataReader registro;
        private Conexion conexion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }
        //maternidad
        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        //paternidad
        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        //nada
        protected void Button3_Click(object sender, EventArgs e)
        {
            
        }

        protected void Btnbackpaternidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }


        protected void InsertarOrden(object sender, EventArgs e)
        {
      
        }

        protected void Mtipoorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mtipoorden.SelectedIndex == 0)
            {

            }
            else
            {
            }
        }

        protected void Btnabuelidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Btnbackabuelidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Btnalzheimer_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void insertarordenmaternidad_Click(object sender, EventArgs e)
        {
            
        }

        protected void Btnpapiloma_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        protected void Btnbackmaternidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Btnbackalzheimer_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void btnpaternidad_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void insertarordenabuelidad_Click(object sender, EventArgs e)
        {

        }

        protected void insertarordenalzheimer_Click(object sender, EventArgs e)
        {

        }

        protected void insertarordenpapiloma_Click(object sender, EventArgs e)
        {

        }

        //  protected void Btnbackmaternidad_Click(object sender, EventArgs e)
        //  {
        //      MultiView1.ActiveViewIndex = 1;
        //  }

        //   protected void Btnbackabuelidad_Click(object sender, EventArgs e)
        //   {
        //       MultiView1.ActiveViewIndex = 2;
        //   }

        //  protected void Btnbackalzheimer_Click(object sender, EventArgs e)
        //  {
        //      MultiView1.ActiveViewIndex = 3;
        //  }
        //abuelidad
        //   protected void Button4_Click(object sender, EventArgs e)
        //   {
        //       MultiView1.ActiveViewIndex = 2;
        //   }
        //alzheimer
        // protected void Button5_Click(object sender, EventArgs e)
        // {
        //    MultiView1.ActiveViewIndex = 3;
        // }
    }
}
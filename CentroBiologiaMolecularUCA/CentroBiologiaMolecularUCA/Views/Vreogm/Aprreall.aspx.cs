using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Entidades;
using WebSistemaCentroBiologiaMolecularUCA.Ncapas.Negocio;

namespace CentroBiologiaMolecularUCA.Views.Vreogm
{
    public partial class Aprreall : System.Web.UI.Page
    {
        private static string id_us;
        protected void Page_Load(object sender, EventArgs e)
        {
            String userprocesa = (string)Session["Id_usuario"];
            id_us = userprocesa;

            String rolid = (string)Session["Id_rol"];
            string ubicacion = HttpContext.Current.Request.Url.AbsolutePath;

            int rol = Convert.ToInt32(rolid);

            bool permiso = false;

            if(rol == 1)
            {
                permiso = true;
            }
            else
            {
                permiso = NGUsuario.getInstance().acceso(rol, ubicacion);

            }

            //Se redirecciona si no tiene permiso
            if (permiso == false)
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: Acceso(); ", true);
            }
        }

        [WebMethod]
        public static List<Resultado> GetData()
        {
            return NGresultado.getInstance().getDatos();
        }

        [WebMethod]
        public static bool AprobarRe(String id)
        {
            bool resp = false;

            Resultado res = new Resultado
            {
                Id_resultado = Convert.ToInt32(id),
                Usuario_valida = id_us
            };

            resp = NGresultado.getInstance().Aprobar(res);
            return resp;
        }


        [WebMethod]
        public static bool AnularRe(String id)
        {
            bool resp = false;

            Resultado res = new Resultado
            {
                Id_resultado = Convert.ToInt32(id),

            };

            NGresultado.getInstance().Updateorden(res);
            resp = NGresultado.getInstance().Eliminar(res);
            return resp;
        }
    }
}
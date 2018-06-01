using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CentroBiologiaMolecularUCA.Startup))]

namespace CentroBiologiaMolecularUCA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            // Para obtener más información acerca de cómo configurar su aplicación, visite http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}

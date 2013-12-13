using Microsoft.Owin;
using Owin;

namespace DailyLog.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
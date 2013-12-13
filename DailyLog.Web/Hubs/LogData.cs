using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace DailyLog.Web.Hubs
{
    public class LogData : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}
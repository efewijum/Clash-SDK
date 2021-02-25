using Clash.SDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Events
{
    public delegate void TrafficEvt(object sender, TrafficEvtArgs e);
    public delegate void LoggingEvt(object sender, LoggingEvtArgs e);
    public delegate void ConnectionEvt(object sender, ConnectionEvtArgs e);

    public class TrafficEvtArgs
    {
        public ClashTrafficResponse Response;
    }

    public class LoggingEvtArgs
    {
        public ClashLogResponse Response;
    }

    public class ConnectionEvtArgs
    {
        public ClashConnectionResponse Response;
    }
}

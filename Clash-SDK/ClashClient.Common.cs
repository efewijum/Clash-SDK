using Clash.SDK.Models.Events;
using Clash.SDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Clash.SDK
{
    public sealed partial class ClashClient
    {
        public event TrafficEvt TrafficReceivedEvt;
        public event LoggingEvt LoggingReceivedEvt;
        public event ConnectionEvt ConnectionUpdatedEvt;

        private WebSocket TrafficWebSocketClient;
        private WebSocket LoggingWebSocketClient;
        private WebSocket ConnectionWebSocketClient;
        
        public void GetClashTraffic()
        {
            CloseClashTraffic();

            var socket = new WebSocket(API_TRAFFIC + $"?token={_secret}");
            socket.ConnectAsync();
            TrafficWebSocketClient = socket;
            TrafficWebSocketClient.OnMessage += TrafficDataReceived;
        }
        
        public void GetClashLog()
        {
            CloseClashLog();

            var socket = new WebSocket(API_LOGS + $"?token={_secret}");
            socket.ConnectAsync();
            LoggingWebSocketClient = socket;
            LoggingWebSocketClient.OnMessage += LoggingDataReceived;
        }

        public void GetClashConnection()
        {
            CloseClashConnection();

            var socket = new WebSocket(API_CONNECTIONS_WS + $"?token={_secret}");
            socket.ConnectAsync();
            ConnectionWebSocketClient = socket;
            ConnectionWebSocketClient.OnMessage += ConnectionDataUpdated;
        }

        public void CloseClashTraffic()
        {
            if (TrafficWebSocketClient != null)
            {
                try
                {
                    TrafficWebSocketClient.Close();
                    TrafficWebSocketClient = null;
                }
                catch
                {
                }
            }
        }

        public void CloseClashLog()
        {
            if (LoggingWebSocketClient != null)
            {
                try
                {
                    LoggingWebSocketClient.Close();
                    LoggingWebSocketClient = null;
                }
                catch
                {
                }
            }
        }

        public void CloseClashConnection()
        {
            if (ConnectionWebSocketClient != null)
            {
                try
                {
                    ConnectionWebSocketClient.Close();
                    ConnectionWebSocketClient = null;
                }
                catch
                {
                }
            }
        }

        private void TrafficDataReceived(object sender, MessageEventArgs args)
        {
            if (TrafficReceivedEvt != null)
            {
                string rawMsg = args.Data;
                var response = JsonConvert.DeserializeObject<ClashTrafficResponse>(rawMsg);
                TrafficReceivedEvt.Invoke(null, new TrafficEvtArgs { Response = response });
            }
        }

        private void LoggingDataReceived(object sender, MessageEventArgs args)
        {
            if (LoggingReceivedEvt != null)
            {
                string rawMsg = args.Data;
                var response = JsonConvert.DeserializeObject<ClashLogResponse>(rawMsg);
                LoggingReceivedEvt.Invoke(null, new LoggingEvtArgs { Response = response });
            }
        }

        private void ConnectionDataUpdated(object sender, MessageEventArgs args)
        {
            if (ConnectionUpdatedEvt != null)
            {
                string rawMsg = args.Data;
                var response = JsonConvert.DeserializeObject<ClashConnectionResponse>(rawMsg);
                ConnectionUpdatedEvt.Invoke(null, new ConnectionEvtArgs { Response = response });
            }
        }
    }
}

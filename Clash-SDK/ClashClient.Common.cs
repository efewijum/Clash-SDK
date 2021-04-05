using Clash.SDK.Models.Events;
using Clash.SDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Websocket.Client;

namespace Clash.SDK
{
    public sealed partial class ClashClient
    {
        public event TrafficEvt TrafficReceivedEvt;
        public event LoggingEvt LoggingReceivedEvt;
        public event ConnectionEvt ConnectionUpdatedEvt;

        private WebsocketClient TrafficWebSocketClient;
        private WebsocketClient LoggingWebSocketClient;
        private WebsocketClient ConnectionWebSocketClient;
        
        public void GetClashTraffic()
        {
            CloseClashTraffic();

            var socket = new WebsocketClient(new Uri(API_TRAFFIC + $"?token={_secret}"));
            socket.Start();
            TrafficWebSocketClient = socket;
            TrafficWebSocketClient.MessageReceived.Subscribe(msg =>
            {
                if (TrafficReceivedEvt != null)
                {
                    var response = JsonConvert.DeserializeObject<ClashTrafficResponse>(msg.Text);
                    TrafficReceivedEvt.Invoke(null, new TrafficEvtArgs { Response = response });
                }
            });
        }
        
        public void GetClashLog()
        {
            CloseClashLog();

            var socket = new WebsocketClient(new Uri(API_LOGS + $"?token={_secret}"));
            socket.Start();
            LoggingWebSocketClient = socket;
            LoggingWebSocketClient.MessageReceived.Subscribe(msg =>
            {
                if (LoggingReceivedEvt != null)
                {
                    var response = JsonConvert.DeserializeObject<ClashLogResponse>(msg.Text);
                    LoggingReceivedEvt.Invoke(null, new LoggingEvtArgs { Response = response });
                }
            });
        }

        public void GetClashConnection()
        {
            CloseClashConnection();

            var socket = new WebsocketClient(new Uri(API_CONNECTIONS_WS + $"?token={_secret}"));
            socket.Start();
            ConnectionWebSocketClient = socket;
            ConnectionWebSocketClient.MessageReceived.Subscribe(msg =>
            {
                if (ConnectionUpdatedEvt != null)
                {
                    var response = JsonConvert.DeserializeObject<ClashConnectionResponse>(msg.Text);
                    ConnectionUpdatedEvt.Invoke(null, new ConnectionEvtArgs { Response = response });
                }
            });
        }

        public void CloseClashTraffic()
        {
            if (TrafficWebSocketClient != null)
            {
                try
                {
                    TrafficWebSocketClient.Stop(WebSocketCloseStatus.Empty, string.Empty);
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
                    LoggingWebSocketClient.Stop(WebSocketCloseStatus.Empty, string.Empty);
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
                    ConnectionWebSocketClient.Stop(WebSocketCloseStatus.Empty, string.Empty);
                    ConnectionWebSocketClient = null;
                }
                catch
                {
                }
            }
        }
    }
}

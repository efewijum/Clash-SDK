using Clash.SDK.Models.Events;
using Clash.SDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Concurrency;
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
        
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns>Token Url参数</returns>
        private string GetToken()
        {
            return !string.IsNullOrWhiteSpace(_secret) ? $"?token={_secret}" : string.Empty;
        }

        /// <summary>
        /// 获取Clash流量WebSocket
        /// </summary>
        public void GetClashTraffic()
        {
            CloseClashTraffic();

            var socket = new WebsocketClient(new Uri(API_TRAFFIC + GetToken()));
            socket.Start();
            TrafficWebSocketClient = socket;
            TrafficWebSocketClient.MessageReceived.ObserveOn(TaskPoolScheduler.Default).Subscribe(msg =>
            {
                if (TrafficReceivedEvt != null)
                {
                    var response = JsonConvert.DeserializeObject<ClashTrafficResponse>(msg.Text);
                    TrafficReceivedEvt.Invoke(null, new TrafficEvtArgs { Response = response });
                }
            });
        }
        
        /// <summary>
        /// 获取Clash日志WebSocket
        /// </summary>
        public void GetClashLog()
        {
            CloseClashLog();

            var socket = new WebsocketClient(new Uri(API_LOGS + GetToken()));
            socket.Start();
            LoggingWebSocketClient = socket;
            LoggingWebSocketClient.MessageReceived.ObserveOn(TaskPoolScheduler.Default).Subscribe(msg =>
            {
                if (LoggingReceivedEvt != null)
                {
                    var response = JsonConvert.DeserializeObject<ClashLogResponse>(msg.Text);
                    LoggingReceivedEvt.Invoke(null, new LoggingEvtArgs { Response = response });
                }
            });
        }

        /// <summary>
        /// 获取Clash连接WebSocket
        /// </summary>
        public void GetClashConnection()
        {
            CloseClashConnection();

            var socket = new WebsocketClient(new Uri(API_CONNECTIONS_WS + GetToken()));
            socket.Start();
            ConnectionWebSocketClient = socket;
            ConnectionWebSocketClient.MessageReceived.ObserveOn(TaskPoolScheduler.Default).Subscribe(msg =>
            {
                if (ConnectionUpdatedEvt != null)
                {
                    var response = JsonConvert.DeserializeObject<ClashConnectionResponse>(msg.Text);
                    ConnectionUpdatedEvt.Invoke(null, new ConnectionEvtArgs { Response = response });
                }
            });
        }

        /// <summary>
        /// 关闭Clash流量WebSocket
        /// </summary>
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

        /// <summary>
        /// 关闭Clash日志WebSocket
        /// </summary>
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

        /// <summary>
        /// 关闭Clash连接WebSocket
        /// </summary>
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

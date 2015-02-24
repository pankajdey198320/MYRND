using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Component.Implementation;

namespace ComPoint.ComImplementation.Tcp
{
    public class TcpServerCompoint : CommunicationComponentBase
    {
      
        class TcpClientStateObject
        {
            public byte[] buffer;
            public TcpClient Client;
            public TcpClientStateObject(Byte[] buffer, TcpClient client)
            {
                this.buffer = buffer; this.Client = client;
            }
        }
        public override void SartComponent(Component.Interface.IMessageContext context)
        {
            this.MesageContext = context;
            this._server.Start();
            this._server.BeginAcceptTcpClient(new AsyncCallback(ReceivedClient), this._server);

        }
      
       

        #region logic for tcp

        TcpListener _server;
        TcpClient _client;

        public IPEndPoint EndPoint { get; set; }
        public TcpServerCompoint()
        {
            if (this.EndPoint == null)
            {
                IPAddress _address = IPAddress.Parse("127.0.0.1");
                this.EndPoint = new IPEndPoint(_address, 3838);
            }
            _server = new System.Net.Sockets.TcpListener(this.EndPoint);

        }

        

        void ReceivedClient(IAsyncResult state)
        {
            var obj = (TcpListener)state.AsyncState;
            var client = obj.EndAcceptTcpClient(state);
            NetworkStream networkStream = client.GetStream();

            byte[] buffer = new byte[client.ReceiveBufferSize];
            client.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.Partial, ReadCallBack, new TcpClientStateObject(buffer, client));

            obj.BeginAcceptTcpClient(ReceivedClient, obj);
        }
        void ReadCallBack(IAsyncResult result)
        {
            var state = (TcpClientStateObject)result.AsyncState;

            if (state.Client.Connected)
            {
                try
                {
                    var buffr = state.buffer.Where(p => p != 0).ToArray();
                    // NetworkStream networkStream = state.Client.GetStream();
                    string data = Encoding.UTF8.GetString(buffr, 0, buffr.Length);
                    Console.WriteLine(data);
                    this.MesageContext.Message += data;

                    byte[] buffer = new byte[state.Client.ReceiveBufferSize];
                    base.InvokeNextComponent();
                    state.Client.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.Partial, ReadCallBack, new TcpClientStateObject(buffer, state.Client));
                    //networkStream.BeginRead(buffer, 0, buffer.Length, ReadCallBack, new TcpClientStateObject(buffer, state.Client));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        
        #endregion
    }
}

using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Component.Implementation;
using Component.Interface;
using Component.MessageContext;

namespace ComPoint.ComImplementation.Tcp
{
    public class TcpServerCompoint : CommunicationComponentBase
    {

        class TcpClientStateObject
        {
            internal byte[] buffer;
            internal TcpClient Client;
            internal IMessageContext Context;
            public TcpClientStateObject(Byte[] buffer, TcpClient client)
            {
                this.buffer = buffer; this.Client = client;
            }
            public TcpClientStateObject(Byte[] buffer, TcpClient client, IMessageContext context)
                : this(buffer, client)
            {
                this.Context = context;
            }
        }

        public override void SartComponent(IMessageContext obj)
        {
            base.SartComponent(obj);

            this._server.Start();
            this._server.BeginAcceptTcpClient(new AsyncCallback(ReceivedClient), this._server);

        }



        #region logic for tcp

        TcpListener _server;
        TcpClient _client;

        public IPEndPoint EndPoint { get; set; }
        public TcpServerCompoint():base()
        {
            if (this.EndPoint == null)
            {
                IPAddress _address = IPAddress.Parse(Properties["IpAddress"]);
                this.EndPoint = new IPEndPoint(_address, Convert.ToInt32(Properties["Port"]));
            }
            _server = new System.Net.Sockets.TcpListener(this.EndPoint);

        }



        void ReceivedClient(IAsyncResult state)
        {
            System.Threading.Thread.CurrentThread.IsBackground = true;
            var obj = (TcpListener)state.AsyncState;
            var client = obj.EndAcceptTcpClient(state);
            NetworkStream networkStream = client.GetStream();

            byte[] buffer = new byte[client.ReceiveBufferSize];
            client.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.Partial, ReadCallBack, new TcpClientStateObject(buffer, client, new BaseMessageContext()));

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
                    //Console.WriteLine(data);
                    state.Context.Message += data;
                    if (data.Contains(this.EndChar))
                    {
                        base.InvokeNextComponent(state.Context);
                        state.Client.Close();
                        return;
                    }
                    byte[] buffer = new byte[state.Client.ReceiveBufferSize];
                    state.buffer = buffer;

                    state.Client.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.Partial, ReadCallBack, state);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Timers;

namespace ServerTcp
{


    public delegate void NEW_CLIENTS_DEL(ClientInformation info);
    public delegate void CLIENT_ONMESSAGE(NimTcpClient client);
    public delegate void CLIENT_ONMESSAGE_UI(string message , string user); 
    public delegate void ON_CLIENT_DISCONNECT(ClientInformation info);

    public class ServerSocket
    {

        public bool Active = false;
        private long ActiveTime = 0;

        private NimaTimer PendingChecker;
        private TcpListener server;
        // dummy clients
        private List<NimTcpClient> clients = new List<NimTcpClient>();
        // events
        public event NEW_CLIENTS_DEL OnNewClientsJoin;
        public event CLIENT_ONMESSAGE_UI OnClientOnMessage;
        public event ON_CLIENT_DISCONNECT OnClientDisconnectedUI;

        public static string FindLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }

        public bool ServerStart(string ip, string port)
        {
            IPAddress iPAddress = null;
            if (IPAddress.TryParse(ip, out iPAddress))
            {
                int _port = 0;

                if (int.TryParse(port, out _port))
                {
                    if (_port > IPEndPoint.MinPort && _port <= IPEndPoint.MaxPort)
                    {
                        server = new TcpListener(new IPEndPoint(iPAddress, _port));
                        try
                        {
                            server.Start();
                            PendingChecker = new NimaTimer();
                            PendingChecker.OnTick += PendingChecker_OnTick;
                            PendingChecker.Start();
                        }
                        catch (SocketException)
                        {
                            return false;
                        }
                        Active = true;
                        ActiveTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private void PendingChecker_OnTick(object sender, EventArgs e)
        {
            if (server.Pending())
            {
                server.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClient), null);
            }
        }

        private void AcceptTcpClient(IAsyncResult res)
        {
            TcpClient tcpClient = server.EndAcceptTcpClient(res);
            NimTcpClient NimTcpClient = new NimTcpClient(tcpClient);

            ClientInformation inf = new ClientInformation();
            inf.ID = clients.Count + 1;

            inf.RemoteAdress = tcpClient.Client.RemoteEndPoint.ToString();

            NimTcpClient.Info = inf;
            NimTcpClient.ID = clients.Count + 1;
            NimTcpClient.CONNECT = true;
            NimTcpClient.OnNewPacket += NimTcpClient_OnNewPacket;
            NimTcpClient.OnClientDisconnect += NimTcpClient_OnClientDisconnect;

            clients.Add(NimTcpClient);

            if (OnNewClientsJoin != null)
            {
                OnNewClientsJoin.Invoke(inf);
            }
        }

        private void NimTcpClient_OnClientDisconnect(ClientInformation info)
        {
            if (OnClientDisconnectedUI != null)
            {
                OnClientDisconnectedUI.Invoke(info);
            }
        }

        private void NimTcpClient_OnNewPacket(NimTcpClient client)
        {
            if (OnClientOnMessage != null)
            {
                CLIENT_MESSAGE cm = client.data_list.Last();
                string message = new UTF8Encoding(true).GetString(cm.DATA); 
                string user = client.Info.ID +" - "+ client.Info.RemoteAdress ;
                OnClientOnMessage.Invoke(message, user);
            }
        }

        public bool SendCustomMessage(string message, int id = -1 )
        {
            if (id < 0) // send to all
            {
                byte[] data = new UTF8Encoding(true).GetBytes(message);
                foreach (NimTcpClient c in clients)
                {
                    if (c.CONNECT)
                    {
                        c.send_message(data);
                    }
                }

                return true;
            }
            else
            {
                NimTcpClient dest_client = clients.Find(x => x.ID == id); 
                if (dest_client == null) return false;

                byte[] buffer = new UTF8Encoding(true).GetBytes(message); 

                return dest_client.send_message(buffer);
                
            }

        }
        
        public bool ServerDown()
        {
            if (Active)
            {
                server.Stop();
                Active = false;

                return true;
            }
            else
            {
                return true;
            }
        }

        public List<ClientInformation> GetAllClientsInformation()
        {
            List<ClientInformation> info = new List<ClientInformation>();
            for (int i = 0; i < clients.Count; i++)
            {
                info.Add(clients[i].Info);
            }

            return info;
        }

        public ClientInformation GetClientsInformation(int id)
        {
            NimTcpClient ct = clients.Where(c => c.ID == id).FirstOrDefault();
            return ct.Info;
        }

        public bool KickOutClientFromServer(int id)
        {
            NimTcpClient ct = clients.Where(c => c.ID == id).FirstOrDefault();

            if (ct == null) return false;

            ct.Close();
            ct.CONNECT = false;
            ct.Dispose();
            clients.Remove(ct);

            return true;
        }

    }

    public struct ClientInformation
    {
        public int ID;
        public string RemoteAdress;
        public long joinunix;
        public bool is_active;

    }

    public struct CLIENT_MESSAGE
    {
        public byte[] DATA;
        public long unix_coming;
        public SocketError state;
        public bool processed;
    }

    public class NimTcpClient : IDisposable
    {

        public bool CONNECT = false;
        public ClientInformation Info;
        public int ID = 0;
        public TcpClient client;
        public List<CLIENT_MESSAGE> data_list = new List<CLIENT_MESSAGE>();

        public event CLIENT_ONMESSAGE OnNewPacket;
        public event ON_CLIENT_DISCONNECT OnClientDisconnect; 

        private bool NEW_PACKET_LOCKER = false;

        public NimTcpClient(TcpClient client)
        {
            this.client = client;
            NimaTimer timer = new NimaTimer();
            timer.OnTick += Timer_OnTick;
            timer.Start();



        }

        public bool send_message(byte[] data) 
        {
            if (client.Connected && CONNECT)
            {
                int b_count = client.Client.Send(data , 0 , data.Length , 0 );  
                return true;
            }
            return false;
        }



        private void Timer_OnTick(object sender, EventArgs e)
        {
            
            if (!CONNECT) return;

            if (!IsConnected)
            {
                CONNECT = false ;
                if (OnClientDisconnect != null)
                {
                    OnClientDisconnect.Invoke(Info);
                }
            }

            if (client.Connected && client.Available > 0 && !NEW_PACKET_LOCKER)
            {
                NEW_PACKET_LOCKER = true;
                byte[] datas = new byte[client.Available];

                SocketError err;

                client.Client.Receive(
                    datas,
                    0,
                    datas.Length,
                    SocketFlags.None,
                    out err
                );


                CLIENT_MESSAGE CM = new CLIENT_MESSAGE();

                CM.unix_coming = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                CM.DATA = datas;
                CM.state = err;
                CM.processed = false;

                data_list.Add(CM);

                Task.Run(() =>
                {
                    if (OnNewPacket != null)
                    {
                        OnNewPacket.Invoke(this);
                    }
                });

                NEW_PACKET_LOCKER = false;
            }
        }

        public void Close()
        {
            client.Close();
        }

        public void Dispose()
        {
            client.Close();
        }

        public bool IsConnected
        {
            get
            {
                try
                {
                    if (client != null && client.Client != null && client.Client.Connected)
                    {
                        /* pear to the documentation on Poll:
                         * When passing SelectMode.SelectRead as a parameter to the Poll method it will return 
                         * -either- true if Socket.Listen(Int32) has been called and a connection is pending;
                         * -or- true if data is available for reading; 
                         * -or- true if the connection has been closed, reset, or terminated; 
                         * otherwise, returns false
                         */

                        // Detect if client disconnected
                        if (client.Client.Poll(0, SelectMode.SelectRead))
                        {
                            byte[] buff = new byte[1];
                            if (client .Client.Receive(buff, SocketFlags.Peek) == 0)
                            {
                                // Client disconnected
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

    }

    internal class NimaTimer
    {
        private Timer t;
        public event EventHandler<EventArgs> OnTick;
        public NimaTimer(int interval = 200)
        {
            t = new Timer(interval);
            t.Elapsed += T_Elapsed;
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnTick.Invoke(sender, e);
        }

        public void Start()
        {
            t.Start();
        }

        public void Stop()
        {
            t.Stop();
        }
    }


    public enum AlertType
    {
        DONE,
        FAILD,
        UNKNOWN,
        QUESTION,
    }

    public static class Alert
    {
        public static void play(AlertType type)
        {
            switch (type)
            {
                case AlertType.DONE:
                    Console.Beep(200, 100);
                    Console.Beep(400, 100);
                    break;
                case AlertType.FAILD:
                    Console.Beep(400, 100);
                    Console.Beep(600, 100);
                    break;
                case AlertType.UNKNOWN:
                    break;
                case AlertType.QUESTION:
                    break;
                default:
                    break;
            }
        }


    }

}


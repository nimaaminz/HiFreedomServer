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
    public delegate void CLIENT_ONMESSAGE

    public class ServerSocket
    {

        public  bool Active = false;
        private long ActiveTime = 0;

        private NimaTimer PendingChecker;
        private TcpListener server;
        // dummy clients
        private List<NimTcpClient> clients = new List<NimTcpClient>();
        // events
        public  event NEW_CLIENTS_DEL OnNewClientsJoin;

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
            clients.Add(NimTcpClient);

            if (OnNewClientsJoin != null)
            {
                OnNewClientsJoin.Invoke(inf);
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
        public byte[] DATA ; 
        public long unix_coming ; 
    }
    
    public class NimTcpClient : IDisposable 
    {

        public ClientInformation Info;
        public int ID = 0;
        public TcpClient client;
        public List<CLIENT_MESSAGE> data_list = new List<CLIENT_MESSAGE>();

        public NimTcpClient(TcpClient client)
        {
            this.client = client;
            NimaTimer timer = new NimaTimer();
            timer.OnTick += Timer_OnTick;
            timer.Start();

        }

        private void Timer_OnTick(object sender, EventArgs e)
        {
            if (client.Connected && client.Available > 0)
            {
                
                //client.Client.BeginReceive(
            }
        }


        private AsyncCallback begin_get_stream(IAsyncResult ar)
        {
        
        
        }


        public void Close()
        {
            client.Close();        
        }

        public void Dispose()
        {
            client.Close(); 
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

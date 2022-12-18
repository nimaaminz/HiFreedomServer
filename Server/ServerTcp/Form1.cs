using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerTcp
{
    public partial class Form1 : Form
    {

        private ServerSocket server_socket;

        private int SELECTED_ID = -1;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // FIND THE SERVER/LOCALMACHINE IP ADDRESS
            string LOCAL_IP = ServerSocket.FindLocalIP();
            if (LOCAL_IP != null)
            {
                txt_ip_address.Text = LOCAL_IP;
            }
            else
            {
                lbl_server_config_log.Text = "Couldn't Find Any Local IP Address";
            }
            server_socket = new ServerSocket();
            server_socket.OnNewClientsJoin += Server_socket_OnNewClientsJoin;
            server_socket.OnClientOnMessage += Server_socket_OnClientOnMessage;
            server_socket.OnClientDisconnectedUI += Server_socket_OnClientDisconnectedUI;


            btn_server_config.PerformClick();
        }

        private void Server_socket_OnClientDisconnectedUI(ClientInformation info)
        {
            alert(AlertType.FAILD);
            UPDATE_CLIENTS_LIST_FLAG = true ; 
        }

        private void Server_socket_OnClientOnMessage(string message, string user)
        {
            UpdateText(txt_server_messages , user + " : "+ message);
        }

        private bool UPDATE_CLIENTS_LIST_FLAG = false;

        private void timer_update_data_Tick(object sender, EventArgs e)
        {
            if (UPDATE_CLIENTS_LIST_FLAG)
            {
                UPDATE_CLIENTS_LIST_FLAG = false;
                DataTableClientsListUpdate();
            }
        }

        private bool CLIENTS_LIST_UPDATE_LOCKER = false;
        private void DataTableClientsListUpdate()
        {

            if (server_socket == null || !server_socket.Active || CLIENTS_LIST_UPDATE_LOCKER) return;
            CLIENTS_LIST_UPDATE_LOCKER = true;

            dt_clients_list.Rows.Clear();

            List<ClientInformation> ClientsList = server_socket.GetAllClientsInformation();

            int i = 0;

            if (ClientsList.Count > 0)
                foreach (ClientInformation ci in server_socket.GetAllClientsInformation())
                {

                    dt_clients_list.Rows.Add();
                    dt_clients_list.Rows[i].Cells[0].Value = ci.ID;
                    dt_clients_list.Rows[i].Cells[1].Value = ci.RemoteAdress;
                    i++;
                }


            CLIENTS_LIST_UPDATE_LOCKER = false;
        }


        private void Server_socket_OnNewClientsJoin(ClientInformation info)
        {
            UPDATE_CLIENTS_LIST_FLAG = true;
            UpdateText(lbl_server_config_log, "New Clients : " + info.RemoteAdress);
        }


        private void UpdateText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((Action)(() => UpdateText(label, text)));
                return;
            }
            label.Text = text;
        }

        private void UpdateText(TextBox label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((Action)(() => UpdateText(label, text)));
                return;
            }
            label.AppendText(Environment.NewLine);
            label.Text += text; 
        }

        private void btn_server_config_Click(object sender, EventArgs e)
        {
            btn_server_config.Enabled = false;

            if (!server_socket.Active)
            {
                if (server_socket.ServerStart(txt_ip_address.Text, txt_port_number.Text))
                {

                    btn_server_config.Text = "Disconnect";
                    lbl_server_config_log.Text = String.Empty;
                }
                else
                {
                    lbl_server_config_log.Text =
                    "Something Wrong On Configing Server : " +
                    txt_ip_address.Text + ":" + txt_port_number.Text;
                }
            }
            else
            {
                if (server_socket.ServerDown())
                {
                    btn_server_config.Text = "Start";
                    lbl_server_config_log.Text = String.Empty;
                }
            }
            btn_server_config.Enabled = true;
        }


        // ******* 
        // *******
        // clients group box elements
        // *******
        // *******
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            if (SELECTED_ID >= 0)
            {
                if (server_socket.KickOutClientFromServer(SELECTED_ID))
                {
                    UPDATE_CLIENTS_LIST_FLAG = true ;
                    SELECTED_ID = -1;

                    alert(AlertType.DONE);
                }
                else
                {
                    alert(AlertType.FAILD);
                }
            }
        }

        private void btn_ping_Click(object sender, EventArgs e)
        {

        }

        private void btn_message_to_client_Click(object sender, EventArgs e)
        {
            if (SELECTED_ID >= 0)
            {
                server_socket.SendCustomMessage(txt_send_custom_message.Text , SELECTED_ID) ;
            }
        }

        private void dt_clients_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dt_clients_list.Rows.Count > 0)
            {
                SELECTED_ID = int.Parse(dt_clients_list.Rows[e.RowIndex].Cells[0].Value.ToString());
                btn_message_to_client.Text = $"Send Message {SELECTED_ID}" ; 
            }
        }

        private void alert(AlertType type)
        {
            Task.Run(() =>
            {
                Alert.play(type);
            });
        }

        private void btn_send_to_all_Click(object sender, EventArgs e)
        {
            if(server_socket.Active)
                server_socket.SendCustomMessage(txt_send_custom_message.Text);
        }
    }
}

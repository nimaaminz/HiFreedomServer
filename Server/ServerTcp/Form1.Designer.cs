namespace ServerTcp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupbox2 = new System.Windows.Forms.GroupBox();
            this.txt_send_custom_message = new System.Windows.Forms.TextBox();
            this.btn_message_to_client = new System.Windows.Forms.Button();
            this.btn_send_to_all = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.dt_clients_list = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_server_config_log = new System.Windows.Forms.Label();
            this.btn_server_config = new System.Windows.Forms.Button();
            this.txt_port_number = new System.Windows.Forms.TextBox();
            this.txt_ip_address = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_server_commands = new System.Windows.Forms.TextBox();
            this.txt_server_messages = new System.Windows.Forms.TextBox();
            this.timer_update_data = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupbox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_clients_list)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(425, 559);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(415, 549);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupbox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(407, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupbox2
            // 
            this.groupbox2.Controls.Add(this.txt_send_custom_message);
            this.groupbox2.Controls.Add(this.btn_message_to_client);
            this.groupbox2.Controls.Add(this.btn_send_to_all);
            this.groupbox2.Controls.Add(this.btn_disconnect);
            this.groupbox2.Controls.Add(this.dt_clients_list);
            this.groupbox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupbox2.Location = new System.Drawing.Point(10, 99);
            this.groupbox2.Name = "groupbox2";
            this.groupbox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupbox2.Size = new System.Drawing.Size(387, 412);
            this.groupbox2.TabIndex = 1;
            this.groupbox2.TabStop = false;
            this.groupbox2.Text = "Clinets";
            // 
            // txt_send_custom_message
            // 
            this.txt_send_custom_message.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txt_send_custom_message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_send_custom_message.Location = new System.Drawing.Point(125, 299);
            this.txt_send_custom_message.Multiline = true;
            this.txt_send_custom_message.Name = "txt_send_custom_message";
            this.txt_send_custom_message.Size = new System.Drawing.Size(260, 114);
            this.txt_send_custom_message.TabIndex = 6;
            this.txt_send_custom_message.Text = "Send Something";
            // 
            // btn_message_to_client
            // 
            this.btn_message_to_client.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_message_to_client.Font = new System.Drawing.Font("Courier New", 8F);
            this.btn_message_to_client.Location = new System.Drawing.Point(10, 339);
            this.btn_message_to_client.Name = "btn_message_to_client";
            this.btn_message_to_client.Size = new System.Drawing.Size(109, 34);
            this.btn_message_to_client.TabIndex = 5;
            this.btn_message_to_client.Text = "Select!";
            this.btn_message_to_client.UseVisualStyleBackColor = true;
            this.btn_message_to_client.Click += new System.EventHandler(this.btn_message_to_client_Click);
            // 
            // btn_send_to_all
            // 
            this.btn_send_to_all.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_send_to_all.Font = new System.Drawing.Font("Courier New", 9F);
            this.btn_send_to_all.Location = new System.Drawing.Point(10, 379);
            this.btn_send_to_all.Name = "btn_send_to_all";
            this.btn_send_to_all.Size = new System.Drawing.Size(109, 34);
            this.btn_send_to_all.TabIndex = 4;
            this.btn_send_to_all.Text = "Send To All";
            this.btn_send_to_all.UseVisualStyleBackColor = true;
            this.btn_send_to_all.Click += new System.EventHandler(this.btn_send_to_all_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_disconnect.ForeColor = System.Drawing.Color.Red;
            this.btn_disconnect.Location = new System.Drawing.Point(9, 299);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(110, 34);
            this.btn_disconnect.TabIndex = 3;
            this.btn_disconnect.Text = "Kick";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // dt_clients_list
            // 
            this.dt_clients_list.AllowUserToAddRows = false;
            this.dt_clients_list.AllowUserToDeleteRows = false;
            this.dt_clients_list.AllowUserToOrderColumns = true;
            this.dt_clients_list.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_clients_list.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_clients_list.BackgroundColor = System.Drawing.Color.White;
            this.dt_clients_list.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dt_clients_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_clients_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dt_clients_list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dt_clients_list.Location = new System.Drawing.Point(9, 23);
            this.dt_clients_list.Name = "dt_clients_list";
            this.dt_clients_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_clients_list.Size = new System.Drawing.Size(376, 267);
            this.dt_clients_list.TabIndex = 0;
            this.dt_clients_list.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_clients_list_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "RAddress";
            this.Column2.Name = "Column2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_server_config_log);
            this.groupBox1.Controls.Add(this.btn_server_config);
            this.groupBox1.Controls.Add(this.txt_port_number);
            this.groupBox1.Controls.Add(this.txt_ip_address);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Config";
            // 
            // lbl_server_config_log
            // 
            this.lbl_server_config_log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_server_config_log.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_server_config_log.ForeColor = System.Drawing.Color.Red;
            this.lbl_server_config_log.Location = new System.Drawing.Point(3, 64);
            this.lbl_server_config_log.Name = "lbl_server_config_log";
            this.lbl_server_config_log.Size = new System.Drawing.Size(381, 22);
            this.lbl_server_config_log.TabIndex = 2;
            this.lbl_server_config_log.Text = " ";
            this.lbl_server_config_log.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_server_config
            // 
            this.btn_server_config.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_server_config.Font = new System.Drawing.Font("Courier New", 9F);
            this.btn_server_config.Location = new System.Drawing.Point(305, 25);
            this.btn_server_config.Name = "btn_server_config";
            this.btn_server_config.Size = new System.Drawing.Size(80, 24);
            this.btn_server_config.TabIndex = 2;
            this.btn_server_config.Text = "Start";
            this.btn_server_config.UseVisualStyleBackColor = true;
            this.btn_server_config.Click += new System.EventHandler(this.btn_server_config_Click);
            // 
            // txt_port_number
            // 
            this.txt_port_number.Font = new System.Drawing.Font("Courier New", 11F);
            this.txt_port_number.Location = new System.Drawing.Point(217, 25);
            this.txt_port_number.Name = "txt_port_number";
            this.txt_port_number.Size = new System.Drawing.Size(82, 24);
            this.txt_port_number.TabIndex = 1;
            this.txt_port_number.Text = "1010";
            // 
            // txt_ip_address
            // 
            this.txt_ip_address.Font = new System.Drawing.Font("Courier New", 11F);
            this.txt_ip_address.Location = new System.Drawing.Point(9, 25);
            this.txt_ip_address.Name = "txt_ip_address";
            this.txt_ip_address.Size = new System.Drawing.Size(202, 24);
            this.txt_ip_address.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(414, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Control";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.txt_server_commands);
            this.panel2.Controls.Add(this.txt_server_messages);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(431, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 559);
            this.panel2.TabIndex = 1;
            // 
            // txt_server_commands
            // 
            this.txt_server_commands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_server_commands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_server_commands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_server_commands.Font = new System.Drawing.Font("Courier New", 11F);
            this.txt_server_commands.ForeColor = System.Drawing.Color.Yellow;
            this.txt_server_commands.Location = new System.Drawing.Point(0, 542);
            this.txt_server_commands.Name = "txt_server_commands";
            this.txt_server_commands.Size = new System.Drawing.Size(611, 17);
            this.txt_server_commands.TabIndex = 1;
            this.txt_server_commands.Text = "cmd";
            // 
            // txt_server_messages
            // 
            this.txt_server_messages.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_server_messages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_server_messages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_server_messages.ForeColor = System.Drawing.Color.Lime;
            this.txt_server_messages.Location = new System.Drawing.Point(0, 0);
            this.txt_server_messages.Multiline = true;
            this.txt_server_messages.Name = "txt_server_messages";
            this.txt_server_messages.Size = new System.Drawing.Size(611, 559);
            this.txt_server_messages.TabIndex = 0;
            // 
            // timer_update_data
            // 
            this.timer_update_data.Enabled = true;
            this.timer_update_data.Tick += new System.EventHandler(this.timer_update_data_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 571);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupbox2.ResumeLayout(false);
            this.groupbox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_clients_list)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupbox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_server_config;
        private System.Windows.Forms.TextBox txt_port_number;
        private System.Windows.Forms.TextBox txt_ip_address;
        private System.Windows.Forms.Label lbl_server_config_log;
        private System.Windows.Forms.DataGridView dt_clients_list;
        private System.Windows.Forms.Button btn_message_to_client;
        private System.Windows.Forms.Button btn_send_to_all;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Timer timer_update_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox txt_server_messages;
        private System.Windows.Forms.TextBox txt_server_commands;
        private System.Windows.Forms.TextBox txt_send_custom_message;
    }
}


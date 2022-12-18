package com.example.hifreedomv0;

import android.net.InetAddresses;

import java.io.IOException;
import java.net.Inet4Address;
import java.net.Inet6Address;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.SocketAddress;
import java.net.SocketTimeoutException;
import java.net.UnknownHostException;
import java.nio.channels.IllegalBlockingModeException;

/**
 *
 *  THE MAIN INTERFACE CLASS FOR TCP/IP
 *  PROTOCOL CONNECTION TO THE SERVER
 *  IP AND PORT OF SERVER : 192.168.0.6:1010
 *  Date : 2022-12-18
 *  Midnight . . .
 *
 * */
public class NimSocketConnection {

    private Socket client_socket ;
    private boolean CONNECTED = false ;


    public NimSocketConnection() {
        client_socket = new Socket();
    }

    public boolean connect(String host , int port)
    {
        if (client_socket != null) {
            try {
                InetAddress addr = InetAddress.getByName(host);
                SocketAddress sockaddr = new InetSocketAddress(addr, port);
                client_socket.connect(sockaddr);
                if(client_socket.isConnected())
                {
                    CONNECTED = true;
                    return true  ;
                }
                else
                {
                    return false ;
                }

            } catch (IOException ex)
            {

                return false ;
            }
            catch (IllegalBlockingModeException ex)
            {

                return false ;
            }
            catch (IllegalArgumentException ex)
            {

                return false ;
            }
            catch (Exception ex)
            {
                return false ;
            }

        }
        return false ;
    }



}
































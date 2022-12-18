package com.example.hifreedomv0;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class MainActivity extends AppCompatActivity {


    private NimSocketConnection socket_connection = null ;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // INITIAL COMPONENTS AND EVERY THING
        socket_connection = new NimSocketConnection() ;
        /**
         * ONCLICK FOR CONNECT BUTTON !
         * SHOULD CHECK THE IP AND ALSO PORTS
         * */
        Button btn_connect =  findViewById(R.id.btn_connect) ;
        btn_connect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String ip = ((TextView) findViewById(R.id.txt_ip)).getText().toString();
                String _port = ((TextView) findViewById(R.id.txt_port_number)).getText().toString();
                int port = Integer.parseInt(_port) ;

                TextView state_lbl = (TextView) findViewById(R.id.txtlbl_state) ;


                if (socket_connection.connect(ip , port))
                {
                    state_lbl.setText("Connect Successfully !");
                }
                else
                {
                    state_lbl.setText("Couldn't Connect To Server !");
                }

            }
        });




    }
}
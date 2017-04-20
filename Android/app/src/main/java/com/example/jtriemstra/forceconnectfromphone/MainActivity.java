package com.example.jtriemstra.forceconnectfromphone;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.bluetooth.*;
import android.util.Log;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

public class MainActivity extends Activity {
    final int ACTIVITY_REQUEST_CODE_ENABLE_BT = 1;
    BluetoothAdapter m_objAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void createServer(View view) {

        if (m_objAdapter == null) m_objAdapter = BluetoothAdapter.getDefaultAdapter();

        if (m_objAdapter == null) {
            // Device does not support Bluetooth
            Log.d("MainActivity", "Bluetooth adapter is null");
        }

        if (!m_objAdapter.isEnabled()) {
            Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(enableBtIntent, ACTIVITY_REQUEST_CODE_ENABLE_BT);
        }
        else {
            doConnection();
        }
    }

    public void createClient(View view) {
        if (m_objAdapter == null) m_objAdapter = BluetoothAdapter.getDefaultAdapter();

        if (m_objAdapter == null) {
            // Device does not support Bluetooth
            Log.d("MainActivity", "Bluetooth adapter is null");
        }

        if (!m_objAdapter.isEnabled()) {
            Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(enableBtIntent, ACTIVITY_REQUEST_CODE_ENABLE_BT);
        }
        else {
            //doConnection();
            doClient();
        }
    }

        @Override
    protected void onActivityResult(int requestCode,
                                    int resultCode,
                                    Intent data)
    {
        if (requestCode == ACTIVITY_REQUEST_CODE_ENABLE_BT)
        {
            doConnection();
        }
    }

    private void doConnection()
    {
        try
        {
            BluetoothServerSocket objServerSocket = m_objAdapter.listenUsingInsecureRfcommWithServiceRecord("LGP", java.util.UUID.fromString("00112233-4455-6677-8899-aabbccddeeff"));
            BluetoothSocket objTransferSocket = objServerSocket.accept();

            if (objTransferSocket != null)
            {
                InputStreamReader objStreamReader = new InputStreamReader(objTransferSocket.getInputStream());
                int intCharacterRead = 0;
                while ((intCharacterRead = objStreamReader.read()) != -1)
                {
                    Log.d("MainActivity", "Character: " + intCharacterRead);
                }
            }
        }
        catch (Exception ex)
        {
            Log.d("MainActivity", "Error: " + ex.toString());
        }
    }

    private void doClient()
    {
        try {
            BluetoothDevice objServerDevice = m_objAdapter.getRemoteDevice("AC:7B:A1:AC:72:D0");
            BluetoothSocket objTransferSocket = objServerDevice.createInsecureRfcommSocketToServiceRecord(java.util.UUID.fromString("00112233-4455-6677-8899-aabbccddeeee"));

            if (objTransferSocket != null){
                objTransferSocket.connect();
                OutputStreamWriter objWriter = new OutputStreamWriter((objTransferSocket.getOutputStream()));
                objWriter.write("This is a test");
                objWriter.flush();
                objWriter.close();
            }
        }
        catch (Exception ex){
            Log.d("MainActivity", "Error: " + ex.toString());
            Log.e("MainActivity", "trace", ex);
        }
    }
}

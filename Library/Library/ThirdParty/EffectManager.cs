
using UnityEngine;
using System.IO.Ports;
using System;
using System.Collections;
using System.Threading;

public class EffectManager : SingleTon<EffectManager>
{
    SerialPort serialPort;
    PortTable table;

    private string vibePortNumber;
    bool enabledVulbEffect;
    int millsEffectTime;

    bool isSuccessfulInitialize = false;

    private EffectManager()
    {
        //table = TableManager.LoadTable<PortTable>("PortTable");

        try
        {
            LocalData.Load();
            serialPort = new SerialPort();
            serialPort.PortName = LocalData.Instance.m_userData.Port;
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Open();
            isSuccessfulInitialize = true;
        }
        catch(Exception e)
        {
            Debug.Log("Error : " + e.Message);
            isSuccessfulInitialize = false;  
        }
    }
    public void SendVibeLeft(bool on = true)
    {
        if( isSuccessfulInitialize )
        {
            byte[] buf = { (byte)'1', (byte)'2' };
            if (on)
                serialPort.Write(buf, 0, 1);
            if (!on)
                serialPort.Write(buf, 1, 1);
        }
    }
    public void SendVibeRight(bool on = true)
    {
        if (isSuccessfulInitialize)
        {
            byte[] buf = { (byte)'3', (byte)'4' };
            if (on)
                serialPort.Write(buf, 0, 1);
            if (!on)
                serialPort.Write(buf, 1, 1);
        }
    }

    public bool EnabledVulbEffect
    {
        get
        {
            return enabledVulbEffect;
        }
        set
        {
            enabledVulbEffect = value;
        }
    }
}

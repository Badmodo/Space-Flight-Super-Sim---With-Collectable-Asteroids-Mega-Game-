using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteConsoleToFile : MonoBehaviour
{
    private void OnEnable()
    {
        Application.logMessageReceived += Log;

        Debug.Log("WRITERRRRRR");
        Debug.LogError("ERROR!");
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    public void Log(string _logString, string _stackTrace, LogType _type)
    {
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/GameLogs";
        Directory.CreateDirectory(filePath);

        string fileName = filePath + "/log.txt";
        string fileName2 = filePath + "/log2.txt";

        StreamWriter file = new StreamWriter(fileName2, true);

        //if (_type == LogType.Log)
        //    return;

        try
        {
            file.Write("[" + DateTime.Now.ToString() + "] ");
            file.Write(_logString + "\n");
        }
        catch (IOException IOex)
        {
            Debug.LogError(IOex);
            Application.logMessageReceived -= Log;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
            Application.logMessageReceived -= Log;
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }
}
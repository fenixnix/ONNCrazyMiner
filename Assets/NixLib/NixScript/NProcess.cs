using System.IO;
using UnityEngine;

public class NProcess
{
    static public void Start(string pPath = "/WTC/WTCLocalServer.exe")
    {
        string filePath = System.Environment.CurrentDirectory + pPath;
        Debug.Log("Open WTC Server:" + filePath);
        if (!File.Exists(filePath))
        {
            Debug.Log("Not find WTC Server .exe file:" + filePath);
            return;
        }
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.FileName = filePath;
        process.Start();
    }

    static public void Close(string pName = "WTCLocalServer")
    {
        Debug.Log("Close " + pName);
        if (CheckProcess(pName))
        {
            KillProcess(pName);
        }
    }

    static void KillProcess(string processName)
    {
        System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
        foreach (System.Diagnostics.Process process in processes)
        {
            try
            {
                if (!process.HasExited)
                {
                    if (process.ProcessName == processName)
                    {
                        process.Kill();
                        UnityEngine.Debug.Log(processName + " Closed");
                    }
                }
            }
            catch (System.InvalidOperationException)
            {
                //UnityEngine.Debug.Log("Holy batman we've got an exception!");
            }
        }
    }

    static bool CheckProcess(string processName)
    {
        bool isRunning = false;
        System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
        int i = 0;
        foreach (System.Diagnostics.Process process in processes)
        {
            try
            {
                i++;
                if (!process.HasExited)
                {
                    if (process.ProcessName.Contains(processName))
                    {
                        UnityEngine.Debug.Log(processName + "is Running");
                        isRunning = true;
                        continue;
                    }
                    else if (!process.ProcessName.Contains(processName) && i > processes.Length)
                    {
                        UnityEngine.Debug.Log(processName + "没有运行");
                        isRunning = false;
                    }
                }
            }
            catch (System.Exception ep)
            {
            }
        }
        return isRunning;
    }
}


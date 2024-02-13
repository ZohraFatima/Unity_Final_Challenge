using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
public class writingCSV : MonoBehaviour
{
    // Start is called before the first frame update
    public static string filepath=Application.dataPath + "/CubePositionLog.csv";
    private StreamWriter writer;
     public bool checker=false;
     
    void Start()
    {
        //filepath = Application.dataPath + "/CubePositionLog.csv";
        writer = new StreamWriter(filepath, false);
        if(writer.BaseStream.Length==0)
            WriteToCSV("Timestamp,X,Y,Z,Collision_object");
   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer.timerIsRunning==true)
        {
            LogPosition();
        }
        else
        {
            if (writer != null)
            {
                writer.Close();
                writer = null;
                checker = true;
                Debug.Log("file closed");
                SceneManager.LoadScene("Graph_Plot");
               
            }
        }
    }
    void LogPosition()
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        WriteToCSV($"{timestamp},{cube.rb.position.x},{cube.rb.position.y},{cube.rb.position.z},{cube.result}");
    }
    void WriteToCSV(string line)
    {
        if (writer != null)
        {
            writer.WriteLine(line);
        }
    }
}
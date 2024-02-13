using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class readingCSV : MonoBehaviour
{

    public static List<float> xValues;
    public static List<float> zValues;
    public static bool check=false;

    void Start()
    {
        ReadCSV();
        
    }

    void ReadCSV()
    {
       // Debug.Log(writingCSV.filepath);
        //Debug.Log("doing");
        xValues = new List<float>();
        zValues = new List<float>();

        try
        {

            using (StreamReader reader = new StreamReader(writingCSV.filepath))
            {
                // Read the header line
                string headerLine = reader.ReadLine();
                Debug.Log("file opened for reading");

                // Get the column indices for "x" and "z"
                string[] headers = headerLine.Split(',');
                int xIndex = Array.IndexOf(headers, "X");
                int zIndex = Array.IndexOf(headers, "Z");

                // Read each line and extract x, z values
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    // Extract x and z values
                    float x = float.Parse(values[xIndex]);
                    float z = float.Parse(values[zIndex]);

                    // Store x and z values in lists
                    xValues.Add(x);
                    zValues.Add(z);
                }

                reader.Close();
                Debug.Log("File closed after reading");
            }

        }
        catch (Exception e)
        {
            Debug.LogError($"Error reading CSV file: {e.Message}");
            return;
        }

        // Now you have lists of x and z values
        // You can access xValues[i] and zValues[i] for each data point
        for (int i = 0; i < xValues.Count; i++)
        {
            Debug.Log($"Point {i + 1}: x = {xValues[i]}, z = {zValues[i]}");
        }
      check=true;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class plot : MonoBehaviour
{
    
    public Canvas canvas;
    
    public GameObject circlePrefab;
     
    public RectTransform panel;
   

    void Update()
    {
        if(readingCSV.check==true){
        PlotGraph();
        readingCSV.check=false;
        }

    }

    void PlotGraph()
    {
        int pointCount = readingCSV.zValues.Count;

        for (int i = 0; i < pointCount; i++)
        {
            float x = readingCSV.xValues[i]; 
            float z = readingCSV.zValues[i];
            Debug.Log("plotting");
            Vector3 position = new Vector3(x, z, 0);

            GameObject circle = Instantiate(circlePrefab, position, Quaternion.identity);
            circle.transform.SetParent(panel, false);
      
        }
    }
}
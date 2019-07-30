using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InSceneLogger : MonoBehaviour
{
    public int max_rows;

    List<string> logs = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetLogger()
    {
        this.GetComponent<TextMesh>().text = "Log: \n";
    }

    public void Log(string s)
    {
        this.logs.Add(s);
        this.UpdateLog();
    }

    public void UpdateLog()
    {
        TextMesh self = this.GetComponent<TextMesh>();
        ResetLogger();
        string output = "";
        for (int i = Math.Max(logs.Count - max_rows, 0); i < logs.Count; ++i)
        {
            string item = logs[i];
            output += " >> " + item + "\n";
        }
        this.GetComponent<TextMesh>().text += output;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

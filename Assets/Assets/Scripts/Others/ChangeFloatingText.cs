using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloatingText : MonoBehaviour {


    internal float auxSec = 3;
    internal float startTime;
    internal float stopTime;
    internal int ok = 0;

    void Start(){
        startTime = Time.time;
    }

    void Update()
    {
        stopTime = Time.time;
        if (ok == 1 && stopTime - startTime > auxSec)
        {
            GameObject.Find("FloatingText").GetComponent<TextMesh>().text = "";
            ok = 0;
        }
    }

    /// <summary>
    /// This function is used to change th FloatingText to the string s and stay there for sec seconds
    /// </summary>
    /// <param name="s"></param>
    /// <param name="sec"></param>
    internal void ChangeText(string s, float sec)
    {
        ok = 1;
        auxSec = sec;
        startTime = Time.time;
        GameObject.Find("FloatingText").GetComponent<TextMesh>().text = s;
    }
}

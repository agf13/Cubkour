using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepVariables : MonoBehaviour {

    internal int skillVar = 0;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(GameObject.Find("BagOVariables"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

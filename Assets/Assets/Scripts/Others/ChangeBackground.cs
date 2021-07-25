using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour {


    public Material[] material;
    internal Renderer rend;

    private GameObject quad1;
    private GameObject quad2;
    private GameObject quad3;
    private GameObject quad4;
    private GameObject quad5;
    private GameObject quad6;


    internal bool adventureStarted = false;


    // Use this for initialization
    void Start ()
    {
        for (var i = 1; i <= 6; i++)
        {
            rend = GameObject.Find("Quad_"+i).GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material[0];
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(adventureStarted == true)
        {
            for (var i = 1; i <= 6; i++)
            {
                rend = GameObject.Find("Quad_" + i).GetComponent<Renderer>();
                rend.enabled = true;
                rend.sharedMaterial = material[1];
            }
        }
	}
}

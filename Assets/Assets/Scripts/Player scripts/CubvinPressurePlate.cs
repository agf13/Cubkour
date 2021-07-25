using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubvinPressurePlate : MonoBehaviour {

    internal bool isOnGround = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(isOnGround);
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log(col.gameObject.name);
    //    if (col.gameObject.name != null)
    //    {
    //        isOnGround = true;
    //    }
    //}

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.name);
        isOnGround = true;
    }
}

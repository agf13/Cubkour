using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMoving : MonoBehaviour {


    public float rotationSpeed = 3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.X)) ///To move the decoration of the cube
        {
            if (Input.GetKey(KeyCode.Q))
                transform.Rotate(Vector3.down, rotationSpeed, Space.Self);
            if (Input.GetKey(KeyCode.E))
                transform.Rotate(Vector3.up, rotationSpeed, Space.Self);
        }


        //if(GameObject.Find("Cubvin").GetComponent<Skills>().skill == 3 && Input.GetKey(KeyCode.F)) ///To make some decoration move herself
        //{
        //     GameObject.Find("Eye").transform.Rotate(Vector3.down, 3, Space.Self);
        //}
    }
}

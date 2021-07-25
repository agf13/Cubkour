using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfTheEye : MonoBehaviour {

    private Rigidbody rb;
    private float rotationSpeed = 3f;


    // Use this for initialization
    void Start ()
    {
        //rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.X))
        {
            if (Input.GetKey(KeyCode.W))
                transform.Rotate(Vector3.right, rotationSpeed, Space.Self);
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(Vector3.forward, rotationSpeed, Space.Self);
            if (Input.GetKey(KeyCode.S))
                transform.Rotate(Vector3.left, rotationSpeed, Space.Self);
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(Vector3.back, rotationSpeed, Space.Self);
            //if (Input.GetKey(KeyCode.Q))
            //    transform.Rotate(Vector3.down, rotationSpeed, Space.Self);
            //if (Input.GetKey(KeyCode.E))
            //    transform.Rotate(Vector3.up, rotationSpeed, Space.Self);
            if(Input.GetKey(KeyCode.R))
            {
                //var rotationPos = transform.rotation.eulerAngles;
                //rotationPos.x = 0;
                //rotationPos.y = 270;
                //rotationPos.z = 0;
                transform.rotation = GameObject.Find("Cubvin").transform.rotation;
            }
        }
    }
}

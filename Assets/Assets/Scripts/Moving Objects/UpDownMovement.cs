using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour {

    private Rigidbody rb;

    public float top = 0;
    public float bottom = 0;
    public float speed = (float)0.05;
    public float direction = -1;
    private Vector3 initialCoord;
    private Vector3 initialRot;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        initialCoord = transform.position;
        initialRot = transform.rotation.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
        //if(this.name == "Hint_1")
        //{
        //    Debug.Log(this.transform.position.y);
        //}
        //rb.transform.Translate(0f, 1f, 0f);
        float posY = rb.transform.position.y;

        if (direction == -1 && posY <= bottom)
            direction = 1;
        if (direction == 1 && posY >= top)
            direction = -1;
        
        if (direction == -1 && posY >= bottom)
        {
            rb.transform.Translate(0f, direction * speed, 0f);
            //transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }
        if (direction == 1 && posY <= top)
        {
            rb.transform.Translate(0f, direction * speed, 0f);
            //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
    }

    internal void Restart()
    {
        //Reset to initial position and rotation. we need to hit these later and we don't want them to fly god know where if we already hit them once.
        transform.position = initialCoord;
        transform.rotation = Quaternion.Euler(initialRot);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }
}

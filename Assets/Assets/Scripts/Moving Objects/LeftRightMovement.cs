using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovement : MonoBehaviour {

    private float maxRight;
    private float maxLeft;
    private float direction = 1;
    private float speed = 0.05f;
    private Vector3 obj;


    // Use this for initialization
    void Start () {
        obj = transform.localPosition;
        maxLeft = obj.x - 3;
        maxRight = obj.x + 3;
        //Debug.Log(maxLeft + " " + maxRight + " " + obj);
    }
	
	// Update is called once per frame
	void Update () {
        obj = transform.localPosition;
        //Debug.Log(transform.position.x);
        if (direction == 1 && obj.x <= maxRight) //move object
        {
            this.transform.Translate(direction * speed, 0f, 0f);
        }

        if (direction == -1 && obj.x >= maxLeft) //move object
        {
            this.transform.Translate(direction * speed, 0f, 0f);
        }

        if (direction == 1 && obj.x >= maxRight) //change dfirection
        {
            direction = -1;
        }

        if (direction == -1 && obj.x <= maxLeft) //change direction
        {
            direction = 1;
        }
    }
}

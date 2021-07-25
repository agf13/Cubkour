using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_rotation : MonoBehaviour
{

    private Rigidbody rb;
    public float rotationSpeed = (float)5; /// this is for rotating the cube to recalibrate yourself
    public float rotationSpeedV2 = (float)3; /// this is for rotating the cube on Y axis (turn left or right)
    public float rotationSpeedForMouse = 5.5f;
    public float rotationSpeedForMouse_2 = 2.5f;
    private Ray ray;
    private GameObject cubvinPaparazzi;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cubvinPaparazzi = GameObject.Find("CubvinPaparazzi");
    }

    void Update()
    {
        ///First try for rotation if found down here.
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //    rb.AddForce(movement * speed);


        ///We won't be using this for now. Gonna change controls from arrowKeys to WASD
        //if (Input.GetKey(KeyCode.W))
        //{
        //    rb.transform.Rotate(Vector3.right, rotationSpeed, Space.Self);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.transform.Rotate(Vector3.forward, rotationSpeed, Space.Self);
        //}
        //if (Input.GetKey(KeyCode.S))
        //    rb.transform.Rotate(Vector3.left, rotationSpeed, Space.Self);
        //if (Input.GetKey(KeyCode.D))
        //    rb.transform.Rotate(Vector3.back, rotationSpeed, Space.Self);

        


        if (!Input.GetKey(KeyCode.X)) ///If X is pressed, the Eye is the only one who should be moving.
        {
            if (Input.GetKey(KeyCode.Q))
            {
                rb.transform.Rotate(Vector3.down, rotationSpeedV2, Space.Self);
            }
            if (Input.GetKey(KeyCode.E))
            {
                rb.transform.Rotate(Vector3.up, rotationSpeedV2, Space.Self);
            }
        }

        //MousePosToAngles();
        //MoveToMousePos();
        //MoveToMousePos_V2();
        MouseMovePlayer();
    }


    //==================================================================================================================================================================
    void MousePosToAngles() ///From the net
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var brutRot = ray.direction;
        var dif = brutRot.y - (-0.8);
        var angle = (dif * 360) / 1.6;
        Debug.Log(brutRot.y + " - " + ray);

    }
    //==================================================================================================================================================================

    void MoveToMousePos() ///From the net
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.z, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.down); // Turns Right
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up); //Turns Left
    }
    //==================================================================================================================================================================

    void MoveToMousePos_V2() ///From the net
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }
    //==================================================================================================================================================================

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) ///This came with "from the net" the 3rd
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    //==================================================================================================================================================================

    void MouseMovePlayer() ///Net + self knowledge + laziness (just the ifs)
    {
        var mousex = Input.GetAxis("Mouse X");
        var mousey = Input.GetAxis("Mouse Y");
        var cameraRot = cubvinPaparazzi.transform.rotation;
        //Debug.Log(mousex + " - " + mousey);
        var mousexThreshold = 0.1;
        var mouseyThreshold = 0.1;
        if (mousex > mousexThreshold) //if cursor moves to right
        {
            //rb.transform.Rotate(Vector3.up, rotationSpeedV2, Space.Self);
            rb.transform.Rotate(Vector3.up, mousex * 6, Space.Self);
        }
        else if (mousex < -mousexThreshold) //if cursor moves to left
        {
            //rb.transform.Rotate(Vector3.down, rotationSpeedV2, Space.Self);
            rb.transform.Rotate(Vector3.up, mousex * 6, Space.Self);
        }
        else
        {
            // Code for mouse standing still ... which means nothing to see here
        }
        
        if (mousey > mouseyThreshold && cubvinPaparazzi.transform.rotation.x >= -90) //if cursor moves up
        {
            //cubvinPaparazzi.transform.Rotate(Vector3.left, rotationSpeedForMouse_2, Space.Self);
            cubvinPaparazzi.transform.Rotate(Vector3.left, mousey * 6, Space.Self);
            //Debug.Log(cubvinPaparazzi.transform.rotation);
        }
        else if (mousey < -mouseyThreshold && cubvinPaparazzi.transform.rotation.x <= 90) //if cursor moves down
        {
            //cubvinPaparazzi.transform.Rotate(Vector3.right, rotationSpeedForMouse_2, Space.Self);
            cubvinPaparazzi.transform.Rotate(Vector3.left, mousey * 6, Space.Self);
            //Debug.Log(cubvinPaparazzi.transform.rotation);
        }
        else
        {
            // Code for mouse standing still ... which means nothing to see here
        }

    }
}


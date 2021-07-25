using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToDefaulfPosition : MonoBehaviour {

    internal float X0 = (float) 0.13;
    internal float Y0 = (float) 32.86;
    internal float Z0 = (float) -32;
	

	private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Cubvin")
        {
            //Debug.Log("coliziune!");
            ResetPos(X0, Y0, Z0, "Cubvin");
            //GameObject.Find("Cubvin").GetComponent<Renderer>().sharedMaterial = GetComponent<ChangeColor>().material[0];
        }
    }

    internal void ResetPos(float x, float y, float z, string name)
    {
        ///Teleport to the location of coord x,y,z, relative to the object (in out case, Cubvin)
        var obj = GameObject.Find(name);
        var obj_rb = obj.GetComponent<Rigidbody>();
        var cube = obj.transform.position;
        cube.x = x;
        cube.y = y;
        cube.z = z;
        obj.transform.position = cube;

        ///Nulify inertial forces of moving
        obj_rb.velocity = Vector3.zero;

        ///Nulify movement of rotation
        obj_rb.angularVelocity = Vector3.zero;

        var rotationPos = obj_rb.transform.rotation.eulerAngles;
        rotationPos.x = 0;
        rotationPos.z = 0;
        obj_rb.transform.rotation = Quaternion.Euler(rotationPos);
    }
}

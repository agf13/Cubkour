using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Skills : MonoBehaviour {

    private Rigidbody rb;
    private float distance = 3; ///distace for ninja skill
    internal int skill = 0; /// 0 - no skill, 1 - ninja, 2 - magician, 3 - Bill Cipher Power
    internal float auxSec = 1;
    internal float startTime;
    internal float stopTime;
    internal int ok; ///Used for not going through the same if meaningless
    //internal GameObject CubvinSoul;
    private GameObject eye;
    private GameObject hat;
    private GameObject katana;
    private GameObject bill;
    private Objects objToUse;

    private float sin;
    private float cos;
    private float angle;

    // Use this for initialization
    void Start (){
        objToUse = GameObject.Find("ColectObj").GetComponent<Objects>();
        rb = GetComponent<Rigidbody>();
        eye = objToUse.eye;
        hat = objToUse.hat;
        katana = objToUse.katana;
        bill = objToUse.bill;
        skill = GameObject.Find("BagOVariables").GetComponent<KeepVariables>().skillVar;
    }



    // Update is called once per frame
    void Update ()
    {
        stopTime = Time.time;
        //angle = rb.transform.rotation.eulerAngles.y;
        //angle = (angle*10%10 > 5)? Mathf.Ceil(angle) : Mathf.Floor(angle);
        //cos = Mathf.Cos(rb.transform.rotation.eulerAngles.y);
        //sin = Mathf.Sin(rb.transform.rotation.eulerAngles.y);
        //Debug.Log("sin: " + sin + "   -   cos: " + cos + "   -   angle: " + rb.transform.rotation.eulerAngles.y + "   -   aproxAngle: " + angle);
        if (skill != 0 && Input.GetKeyDown(KeyCode.F)){
            switch(skill)
            {
                case 1: /// NinjaSkill : teleport some distance in front of you
                    Vector3 TpPos = GameObject.Find("CubvinAstralProjection").transform.position;  ///TpPos = teleport position (you can use this only if you are a ninja)
                    rb.transform.position = TpPos;

                    break;
                case 2: /// MagicianSKill : return the cube on his feet
                    GameObject.Find("ParticleSystem").GetComponent<ParticleSystem>().Play(true);
                    var rotationPos = rb.transform.rotation.eulerAngles;
                    rotationPos.x = 0;
                    rotationPos.z = 0;
                    rb.transform.rotation = Quaternion.Euler(rotationPos);
                    rb.angularVelocity = Vector3.zero; //reset rotation velocity
                    startTime = Time.time;
                    ok = 1;
                    break;
                case 3: /// BillCipherSkill : when F is pressed you can pass through anything, excent Bill_resistent obj (see the function which do this above)
                    //rb.detectCollisions = false;  --FINALLY! Stayed half a day to realize I can disable BoxColider rather than this
                    rb.GetComponent<BoxCollider>().enabled = false; ///Make the Cupe able to pass thorough objects
                    rb.GetComponent<MeshRenderer>().enabled = false; ///Make Cubvin invisible
                    bill.SetActive(true);
                    //CubvinSoul.GetComponent<MeshRenderer>().enabled = false; ///Make CubvinSoul Invisible (though, I can just leave this invisible the whole time) ... Did IT ;)                          ... That means this line is completly useless now. ;)
                    eye.SetActive(false);
                    break;
                default:
                    break;
            }
        }

        if (skill == 3 && Input.GetKeyUp(KeyCode.F))  /// Stop the eye from moving
        {
            rb.GetComponent<BoxCollider>().enabled = true; ///Cubvin can pass through things again
            //GameObject.Find("Eye").transform.Rotate(Vector3.down, 0, Space.Self);
            rb.GetComponent<MeshRenderer>().enabled = true; ///Cubvin is visible again
            //CubvinSoul.GetComponent<MeshRenderer>().enabled = true; ///His Soul is rendered again (again, I could really just leave this unrendered) ... Did IT ;)                          ... That means this line is completly useless now. :D
            eye.SetActive(true);
            bill.SetActive(false);
        }
        if(ok == 1 && stopTime - startTime > auxSec) ///Stops the animation after 1 sec.
        {
            GameObject.Find("ParticleSystem").GetComponent<ParticleSystem>().Stop(true);
            ok = 0;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextTutorial : MonoBehaviour
{

    private string currentScene;
    internal int tips = 0;
    private int maxTips = 1;
    private int dieCount = 0;

    private float maxY = 10.5f;
    private float maxZ = 0.45f;
    private Vector3 scaleSign;
    private float incrY = 0.05f; //increment
    private float incrZ = 0.0009f; //increment
    private bool startScale = false;
    internal bool preStartScale = false;
    private bool lastMsj = false;
    private float actualY;
    private float actualZ;
    private float initialY;
    private float initialZ;

    private Objects script_Objects;
    private GameObject cubvin;
    private GameObject floatingText;
    private ChangeFloatingText boolTime;
    private ChangeFloatingText message;
    private CubvinSoul6sense script_CubvinSoul6sense;
    private PlayerController script_PlayerController;
    private GameObject sacredDoor;
    private GameObject lvlSign;
    private GameObject aditional;

    internal bool weirdMagedon = false;
    internal bool tutorialNotSkipped = true;

    // Use this for initialization
    void Start()
    {
        script_Objects = GameObject.Find("ColectObj").GetComponent<Objects>();
        cubvin = script_Objects.cubvin;
        currentScene = SceneManager.GetActiveScene().name;
        floatingText = script_Objects.floatingText;
        boolTime = floatingText.GetComponent<ChangeFloatingText>();
        message = floatingText.GetComponent<ChangeFloatingText>();
        script_CubvinSoul6sense = GameObject.Find("CubvinSoul").GetComponent<CubvinSoul6sense>();
        script_PlayerController = cubvin.GetComponent<PlayerController>();
        script_Objects = GameObject.Find("ColectObj").GetComponent<Objects>();

        if (SceneManager.GetActiveScene().name == "Training")
        {
            script_CubvinSoul6sense.messages.text = "If you want to skip the tutorial, press T+L+1 .";
            script_CubvinSoul6sense.thingsToDo.text = "Things to do: \r\nclearing the tutorial";
            script_PlayerController.ableToMove = false; ///TO DO: need to remember to remove this commented line after I finish with the testing
            //Debug.Log(script_PlayerController.ableToMove);
            GameObject.Find("Msj_greeting_Lvl1").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Msj_greeting_Training").GetComponent<Renderer>().enabled = true;
            sacredDoor = GameObject.Find("SacredDoor");
            script_Objects.tunel.SetActive(false);

            lvlSign = GameObject.Find("Msj_greeting_Lvl1");
            scaleSign = lvlSign.transform.localScale;
            initialY = scaleSign.y;
            initialZ = scaleSign.z;
            lvlSign.GetComponent<UpDownMovement>().enabled = false;
            lvlSign.SetActive(false);

            aditional = GameObject.Find("Aditional");
            aditional.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        //Debug.Log(cubvin.transform.position.x + " " +cubvin.transform.position.z);
        //Debug.Log(tips + "   " + maxTips);
        dieCount = script_CubvinSoul6sense.dieCount;
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Training")
        {
            if (tutorialNotSkipped == true)
            {
                if (tips < maxTips)  ///Facem asta ca sa stim ca nu intram in switch doar ca sa ne spnua debug-ul ca nu stie cum a iesit de acolo (adica sa nu atingem "default"-ul). Ultimul "case" de dinainte de "default" trebuie sa nu aiba maxTips++.
                {
                    switch (tips)
                    {
                        case 0:
                            //floatingText.GetComponent<ChangeFloatingText>().ChangeText("",2);
                            if (boolTime.ok == 0)
                            {
                                sacredDoor.SetActive(true);
                                message.ChangeText("*Yawwwn*", 2);
                                //script_Objects.thought1.SetActive(true);
                                //script_Objects.numaratulOilor++;
                                script_Objects.thoughts[1].SetActive(true);
                                tips++;
                                maxTips++;
                            }
                            break;
                        case 1:
                            if (boolTime.ok == 0)
                            {
                                if (dieCount == 0)
                                {
                                    message.ChangeText("Hmmm... WHAT? Where am I? Why can't I move?", 4);
                                    //script_Objects.thought2.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    script_Objects.thoughts[2].SetActive(true);
                                }
                                else
                                {
                                    message.ChangeText("Hmmm... WHAT? Again here?", 3);
                                    //script_Objects.thought2_afterDie.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    script_Objects.thoughts[12].SetActive(true);
                                }
                                tips++;
                                maxTips++;
                            }
                            break;
                        case 2:
                            if (boolTime.ok == 0)
                            {
                                if (dieCount == 0)
                                {
                                    message.ChangeText("A trainig room? I wonder if they meant tutorial room.", 4);
                                    //script_Objects.thought3.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    script_Objects.thoughts[3].SetActive(true);
                                }
                                else
                                {
                                    message.ChangeText("The strange door which is about to dissapear \r\nis here again.", 4);
                                    //script_Objects.thought3_afterDie.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    script_Objects.thoughts[13].SetActive(true);
                                }
                                tips++;
                                maxTips++;
                            }
                            break;
                        case 3:
                            //Debug.Log("case 3");
                            if (boolTime.ok == 0)
                            {
                                //Debug.Log("Acum intra in case 3");
                                script_PlayerController.ableToMove = true;
                                //Debug.Log("2 linii mai jos in case 3 | " + boolTime + " | " + dieCount);
                                GameObject.Find("SacredDoor").SetActive(false);
                                if (dieCount == 0)
                                {
                                    //Debug.Log("Cand intri aici? Acum?");
                                    //message.ChangeText("Ooohh! The door...opened? Maybe I can move now?\r\n Should I try the ARROW KEYS...", 5);
                                    message.ChangeText("Ooohh! The door...opened? Maybe I can move now?\r\n Should I try WASD keys...", 5);
                                    //script_Objects.thought4.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    script_Objects.thoughts[4].SetActive(true);
                                    //script_PlayerController.speed = 0f; ///TO DO: need to remember to remove this commented line after I finish with the testing
                                }
                                else
                                {
                                    //message.ChangeText("Ooohh! Such a surprise, it dissapeared again!\r\n ... I already know I can move with ARROW KEYS.", 5);
                                    message.ChangeText("Ooohh! Such a surprise, it dissapeared again!\r\n ... I already know I can move with WASD keys.", 5);
                                    //script_Objects.thought4_afterDie.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    script_Objects.thoughts[14].SetActive(true);
                                    if (GameObject.Find("Tunel"))
                                    {
                                        tips = 10000; ///We don't need to pass thorugh the entire tutorial again
                                    }
                                }
                                tips++;
                                maxTips++;
                            }
                            break;
                        case 4:
                            if (script_CubvinSoul6sense.doorTouched)
                            {
                                boolTime.ok = 0;
                                if (boolTime.ok == 0)
                                {
                                    //message.ChangeText("How do I look around? ... I feel like Q and E would do the job.", 5);
                                    message.ChangeText("Hmm...It seems I can look around by \r\nfollowing a strange invisible cursor.", 5);
                                    //script_Objects.thought5.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    script_Objects.thoughts[5].SetActive(true);
                                    tips++;
                                    maxTips++;
                                }
                            }
                            break;
                        case 5:
                            if (boolTime.ok == 0)
                            {
                                message.ChangeText("Now let's get back through the door I came in... \r\n I hope black doesn't mean I can't.", 5);
                                //script_Objects.thought6.SetActive(true);
                                //script_Objects.numaratulOilor++;
                                script_Objects.thoughts[6].SetActive(true);
                                tips++;
                                maxTips++;
                                //Debug.Log("Aici aven tips = 6 deja. Mai e mesajul cu intoarcere deasupra cubului?");
                            }
                            break;
                        case 6:
                            if (script_CubvinSoul6sense.doorTouchedAgain)
                            {
                                boolTime.ok = 0;
                                message.ok = 0;
                                if (boolTime.ok == 0)
                                {
                                    message.ChangeText("!?", 2);
                                    tips++;
                                    maxTips++;
                                }
                            }
                            break;
                        case 7:
                            if (boolTime.ok == 0)
                            {
                                message.ChangeText("So I can't get back ... Or that's what they think, \r\n but unfortunately for them Qgod left us CUBKOUR.", 7);
                                //script_Objects.thought7.SetActive(true);
                                //script_Objects.numaratulOilor++;
                                script_Objects.thoughts[7].SetActive(true);
                                tips++;
                                maxTips++;
                            }
                            break;
                        case 8: //When you enter case 8, maxTips=9 and when you exit case 8, maxTIps = 10;
                            if (boolTime.ok == 0)
                            {
                                message.ChangeText("Holding the SPACE while running into a wall. \r\n I can clear the wall in no moment.", 5);
                                //script_Objects.thought8.SetActive(true);
                                //script_Objects.numaratulOilor++;
                                script_Objects.thoughts[8].SetActive(true);
                                tips++;
                                maxTips++;
                            }
                            break;
                        case 9:
                            if (script_CubvinSoul6sense.startZoneTouched == 1)
                            {
                                boolTime.ok = 0;
                                message.ok = 0;
                                if (boolTime.ok == 0)
                                {
                                    message.ChangeText("See? Easy!", 2);
                                    aditional.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    //script_Objects.thought9.SetActive(true);
                                    script_Objects.thoughts[9].SetActive(true);
                                    //GameObject.Find("Msj_greeting_Training").GetComponent<Renderer>().enabled = false; ///Disable tutorial (I mean trainig) plate.
                                    //GameObject.Find("Msj_greeting_Training").GetComponent<UpDownMovement>().enabled = false;
                                    //lvlSign.SetActive(true);
                                    //lvlSign.GetComponent<Renderer>().enabled = true; ///Change plate message. This is when lvl1 starts
                                    //lvlSign.GetComponent<UpDownMovement>().enabled = true;
                                    //preStartScale = true;
                                    tips++;
                                    maxTips++;
                                }
                            }
                            break;
                        case 10:
                            if (lastMsj == true)
                            {
                                boolTime.ok = 0;
                                if (boolTime.ok == 0)
                                {
                                    message.ChangeText("And... A giant tunel just appeared out of nowhere.\r\nThis can mean a single thing ...", 4);
                                    //script_Objects.thought10.SetActive(true);
                                    //script_Objects.numaratulOilor++;
                                    script_Objects.thoughts[10].SetActive(true);
                                    tips++;
                                    maxTips++;
                                }
                            }
                            break;
                        case 11:
                            if (boolTime.ok == 0)
                            {
                                message.ChangeText("Yap! Adventure time!", 3);
                                //script_Objects.thought11.SetActive(true);
                                //script_Objects.numaratulOilor++;
                                script_Objects.thoughts[11].SetActive(true);
                                GameObject.Find("Background").GetComponent<ChangeBackground>().adventureStarted = true;
                                tips++;
                                maxTips++;
                            }
                            break;
                        default:
                            Debug.Log("crapatura in switch. Cumva am iesit de aici");
                            maxTips--;
                            break;
                    }
                    //if (maxTips == 10)  ///The number represent the number of the last message + 1. Beeing maxTips=Tips, we won't get into switch's "default".
                    //    maxTips--;
                }
            }

            //if (script_CubvinSoul6sense.startAnimation == true)
            //{
            //    GameObject.Find("Msj_greeting_Training").GetComponent<Renderer>().enabled = false; ///Disable tutorial (I mean trainig) plate.
            //    GameObject.Find("Msj_greeting_Training").GetComponent<UpDownMovement>().enabled = false;
            //    lvlSign.SetActive(true);
            //    lvlSign.GetComponent<Renderer>().enabled = true; ///Change plate message. This is when lvl1 starts
            //    lvlSign.GetComponent<UpDownMovement>().enabled = true;
            //    preStartScale = true;
            //}

            if (preStartScale == true) //Scaling the Sign which announce that you got to lvl 1. It is just for animation, so that it would be more dramatic when the tunel appears.
            {
                GameObject.Find("Msj_greeting_Training").GetComponent<Renderer>().enabled = false; ///Disable tutorial (i mean trainig) plate.
                GameObject.Find("Msj_greeting_Training").GetComponent<UpDownMovement>().enabled = false;
                lvlSign.SetActive(true);
                lvlSign.GetComponent<Renderer>().enabled = true; ///Change plate message. This is when lvl1 starts
                lvlSign.GetComponent<UpDownMovement>().enabled = true;
                if (lvlSign.transform.position.y >= 2.40 && lvlSign.transform.position.y <= 2.52)
                {
                    lvlSign.GetComponent<UpDownMovement>().enabled = false;
                    startScale = true;
                    GameObject.Find("MagicMsjTrigger_1").GetComponent<MeshCollider>().convex = true;
                    message.ChangeText("What is happening?!",2);
                }

                if (startScale == true)
                {
                    actualY = scaleSign.y;
                    actualZ = scaleSign.z;
                    if (scaleSign.y <= maxY)
                    {
                        scaleSign.y += incrY;
                    }
                    if (scaleSign.z <= maxZ)
                    {
                        scaleSign.z += incrZ;
                    }
                    lvlSign.transform.localScale = scaleSign;

                    if (actualY >= maxY && actualZ >= maxZ)
                    {
                        startScale = false;
                        preStartScale = false;
                        script_Objects.tunel.SetActive(true);
                        scaleSign.y = initialY;
                        scaleSign.z = initialZ;
                        lvlSign.transform.localScale = scaleSign;
                        lvlSign.GetComponent<UpDownMovement>().enabled = true;
                        lastMsj = true;
                        GameObject.Find("MagicMsjTrigger_1").GetComponent<MeshCollider>().convex = false;
                    }
                    ///Retunr sign to its initial position, rotation and velocity
                    var rotationPosSign = lvlSign.transform.rotation.eulerAngles;
                    rotationPosSign.x = 0;
                    rotationPosSign.y = 0;
                    rotationPosSign.z = 0;
                    lvlSign.transform.rotation = Quaternion.Euler(rotationPosSign);

                    script_Objects.msjTrigger.SetActive(true);


                    //Debug.Log("y: " + scaleSign.y + " z: " + scaleSign.z + " --- " + preStartScale + ", " + startScale);
                }

            }
        }
        if(weirdMagedon == true)
        {
            script_Objects.BillCipherStone_training.SetActive(true);
        }
    }
}

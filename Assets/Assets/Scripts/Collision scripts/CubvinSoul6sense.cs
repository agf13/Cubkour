using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CubvinSoul6sense : MonoBehaviour {

    private GameObject cubvin;
    private Objects objToUse;
    private GameObject eye;
    private GameObject hat;
    private GameObject katana;
    private GameObject bill;

    public Text thingsToDo;
    public Text messages;
    
    private float wallRun = 0;
    private string s;

    private string next_scene;
    private float x_playground = 12;
    private float y_playground = 12;
    private float z_playground = 0;
    private float x_training = 51;
    private float y_training = 0;
    private float z_training = -3;
    internal float x_training_lvl1 = -164;
    internal float y_training_lvl1 = -23;
    internal float z_training_lvl1 = -3;
    private int score;
    private bool objFirstMOved = false;

    internal float minPos;
    internal float X;
    internal float Y;
    internal float Z;
    internal int startZoneTouched = 0;
    internal int dieCount = 0;
    internal bool restartSigns = false;
    internal bool touchedSign = false;
    internal bool startAnimation = false;

    internal bool doorTouched = false;
    internal bool doorTouchedAgain = false;
    internal int[] floatingSignsHit = new int[20];

    private GameObject signToBill;
    private GameObject portal;

    private Vector3 signToBillPowerPos;
    private TextTutorial script_TextTutorial;
    private ChangeFloatingText script_ChangeFloatingText;
    private PickUpObj script_PickUpObjects;
    internal PlayerController script_PlayerController;


    void Start()
    {
        objToUse = GameObject.Find("ColectObj").GetComponent<Objects>();
        cubvin = objToUse.cubvin;
        Vector3 pos = cubvin.transform.position;
        string currentScene = SceneManager.GetActiveScene().name;
        script_TextTutorial = this.GetComponent<TextTutorial>();
        script_ChangeFloatingText = GameObject.Find("FloatingText").GetComponent<ChangeFloatingText>();
        thingsToDo.text = "Things to do:";
        messages.text = "Messages:";
        script_PlayerController = GameObject.Find("Cubvin").GetComponent<PlayerController>();
        //Debug.Log(script_PlayerController);
        switch (currentScene)
        {
            case "Playground":
                pos.x = X = x_playground;
                pos.y = Y = y_playground;
                pos.z = Z = z_playground;
                cubvin.transform.position = pos;
                minPos = -50;
                break;
            case "Training":
                for(var i = 1; i <= 16; i++)
                {
                    floatingSignsHit[i] = 0;
                }
                pos.x = X = x_training;
                pos.y = Y = y_training;
                pos.z = Z = z_training;
                cubvin.transform.position = pos;
                var rotationPos = cubvin.transform.rotation.eulerAngles;
                rotationPos.x = 0;
                rotationPos.y = -90;
                rotationPos.z = 0;
                cubvin.transform.rotation = Quaternion.Euler(rotationPos);
                minPos = -40;
                portal = GameObject.Find("Portal");
                portal.SetActive(false);
                signToBill = GameObject.Find("Sign");
                signToBillPowerPos = signToBill.transform.position; ///Need this to find the superpower
                script_PickUpObjects = GameObject.Find("ColectableObj").GetComponent<PickUpObj>();
                score = 0;
                break;
            default:
                Debug.Log("Amm... cred ca ai uitat sa adaugi coord initiale pt aceasta scena. Sa speram ca ai fost plasat totusi bine undeva pe mapa 0:) ");
                break;
        }
    }

    // Update() =========================================================================================================================================================

    void Update()
    {
        //Debug.Log(cubvin.transform.position);
        if (cubvin.transform.position.y < minPos) ///If Cubvin falls under the map reset him to some coord x,y,z
        {
            Respawn();
        }
            //if (cubvin.transform.position.y < minPos) ///If Cubvin falls under the map reset him to some coord x,y,z
            //{
            //    ///Teleport to the location of coord x,y,z, relative to the object (in our case, the object is Cubvin)
            //    var cube = cubvin.transform.position;
            //    cube.x = X;
            //    cube.y = Y;
            //    cube.z = Z;
            //    cubvin.transform.position = cube;

            //    ///Nulify inertial forces of moving
            //    cubvin.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //    ///Nulify movement of rotation
            //    cubvin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //    ///Reset the rotation of the cube
            //    var rotationPos = cubvin.transform.rotation.eulerAngles;
            //    rotationPos.x = 0;
            //    rotationPos.z = 0;
            //    cubvin.transform.rotation = Quaternion.Euler(rotationPos);

            //    if(SceneManager.GetActiveScene().name == "Training")
            //    {
            //        ///Retunr sign to its initial position, rotation and velocity
            //        signToBill.transform.position = signToBillPowerPos; 
            //        signToBill.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //        signToBill.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //        var rotationPosSign = signToBill.transform.rotation.eulerAngles;
            //        rotationPosSign.x = 0;
            //        rotationPosSign.y = -172;
            //        rotationPosSign.z = 0;
            //        signToBill.transform.rotation = Quaternion.Euler(rotationPosSign);

            //        //Reset Cubvin inner conversation
            //        GameObject.Find("CubvinSoul").GetComponent<TextTutorial>().tips = 0;

            //        //Reset important variables in TextTutorial
            //        doorTouched = false;
            //        doorTouchedAgain = false;
            //        startZoneTouched = 0; 
            //    }

            //    dieCount++;
            //    for (var i = 1; i <= 16; i++)
            //    {
            //        floatingSignsHit[i] = 0;
            //        var obj = GameObject.Find("Sign_" + i);
            //        if(obj)
            //            obj.GetComponent<UpDownMovement>().Restart();
            //    }
            //}

            if (SceneManager.GetActiveScene().name == "Training")
        {

            bool onTheSpotOk = true;
            for(var i = 1; i<=16; i++)
            {
                if (floatingSignsHit[i] == 0) onTheSpotOk = false;
            }
            if (onTheSpotOk == true) script_TextTutorial.weirdMagedon = true; 
        }
    }

    // TriggerEnter() =========================================================================================================================================================

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.name);
        int skillNr = GameObject.Find("Cubvin").GetComponent<Skills>().skill;

        if (skillNr == 3 && col.gameObject.tag == "Bill_resistent" && Input.GetKey(KeyCode.F))
        {
            cubvin.GetComponent<BoxCollider>().enabled = true; ///Make Cubvin able to colide again
            //GameObject.Find("Eye").transform.Rotate(Vector3.down, 0, Space.Self); ///Stop Eye from moving
            cubvin.GetComponent<MeshRenderer>().enabled = true; ///Make Cubvon visible again
            //GameObject.Find("CubvinSoul").GetComponent<MeshRenderer>().enabled = true; ///Make CubvinSoul reaper. Though, this is just visual, so I don't think I really need it :-?
            GameObject.Find("FloatingText").GetComponent<ChangeFloatingText>().ChangeText("I can't get through",2); ///Show a msj saying you can't get through
        }

        if(col.gameObject.name == "BillCipherStone")
        {
            //Debug.Log("Billlll");
            script_PlayerController.sound.Stop();
            script_PlayerController.sound.PlayOneShot(script_PlayerController.billSummon, 1f);
        }

        if(col.gameObject.tag == "NextLevel")
        {

            objToUse = GameObject.Find("ColectObj").GetComponent<Objects>();
            hat = objToUse.hat;
            eye = objToUse.eye;
            katana = objToUse.katana;
            bill = objToUse.bill;

            eye.SetActive(true);
            hat.SetActive(true);
            katana.SetActive(true);
            bill.SetActive(true);
            SceneManager.LoadScene("Training");
            //if (SceneManager.GetActiveScene().name == "Playground")
            //{
            //    MoveObjectToNewScene.LoadScene("Training", GameObject.Find("BagOVariables"));
            //    SceneManager.UnloadSceneAsync("Playground");
            //}
        }

        if (col.gameObject.tag == "Wall" && wallRun == 0)
        {
            cubvin.GetComponent<Rigidbody>().velocity = Vector3.zero;
            wallRun = 1;
        }

        if(col.gameObject.name == "MagicMsjTrigger_1" && SceneManager.GetActiveScene().name == "Training")
        {
            if (script_TextTutorial.tips == 6 &&  cubvin.transform.position.x < 42)//When we are touching the door the second time (in Training room)
                doorTouchedAgain = true;
            doorTouched = true;
        }

        if(col.gameObject.name == "StartZone" && SceneManager.GetActiveScene().name == "Training")
        {
            if(script_TextTutorial.tips == 9)
            {
                startZoneTouched = 1;
            }
        }

        if(SceneManager.GetActiveScene().name == "Training")
        {
            if(col.gameObject.name == "PortalTestVersion")
            {
                SceneManager.LoadScene(3);
            }

            if(col.gameObject.name == "Portal")
            {

                Cursor.visible = true;
                SceneManager.LoadScene(0);
            }

            if(col.gameObject.name == "lvl1_floor_0" && objFirstMOved == false)
            {
                //GameObject.Find("CubvinFirstEye").transform.rotation = cubvin.transform.rotation;
                //Debug.Log("Macar am ajuns aici");
                X = x_training_lvl1;
                Y = y_training_lvl1;
                Z = z_training_lvl1;
                script_PlayerController.sound.clip = script_PlayerController.background_lvl1;
                script_PlayerController.sound.Play();
                script_ChangeFloatingText.ChangeText("I feel like I need to look for some objects.",3);
                script_PickUpObjects.ChangePos();
                objFirstMOved = true;
            }
            if(col.gameObject.name == "Trigger_lvl1")
            { 
                script_TextTutorial.preStartScale = true;
            }

            if(col.gameObject.tag == "ColectableObj")
            {
                script_PickUpObjects.ChangePos();
                score++;
                thingsToDo.text = "Colected " + score + " / 9";
                if(score == 9)
                {
                    messages.text = "Goodjob, Cubvin! I didn't expect you to get this far. Unfortunatly for you, though, now I have to dissapoint you by informing you that you have no escape.\r\nBut, if you want, you can continue to pick up keys, so you won't get bored.";
                    portal.SetActive(true);
                }
            }

            if(col.gameObject.name == "MsjTrigger_1")
            {
                messages.text = "Impressive Cubvin! I didn't expect you to get here. /r/nThe exit is at the end of the tunnel. Good luck!";
                //var rotCamera = GameObject.Find("CubvinFirstEye").transform.rotation;
                //rotCamera.x = 0;
                //rotCamera.y = 0.4f;
                //rotCamera.z = 0;
                //GameObject.Find("CubvinFirstEye").transform.rotation = rotCamera;
            }

            if (col.gameObject.transform.parent.tag == "Sign" && touchedSign == false)
            {
                Debug.Log("mhm");
                touchedSign = true;
                script_ChangeFloatingText.ok = 0;
                script_ChangeFloatingText.ChangeText("So I can hit the signs. \r\nI wonder what would happed if I hit every sign?",4);
                GameObject.Find("ColectObj").GetComponent<Objects>().thoughts[15].SetActive(true);
            }
            //Debug.Log(col.gameObject.transform.parent.name);
            switch (col.gameObject.transform.parent.name)
            {
                case "Sign_1":
                    floatingSignsHit[1] = 1;
                    break;
                case "Sign_2":
                    floatingSignsHit[2] = 1;
                    break;
                case "Sign_3":
                    floatingSignsHit[3] = 1;
                    break;
                case "Sign_4":
                    floatingSignsHit[4] = 1;
                    break;
                case "Sign_5":
                    floatingSignsHit[5] = 1;
                    break;
                case "Sign_6":
                    floatingSignsHit[6] = 1;
                    break;
                case "Sign_7":
                    floatingSignsHit[7] = 1;
                    break;
                case "Sign_8":
                    floatingSignsHit[8] = 1;
                    break;
                case "Sign_9":
                    floatingSignsHit[9] = 1;
                    break;
                case "Sign_10":
                    floatingSignsHit[10] = 1;
                    break;
                case "Sign_11":
                    floatingSignsHit[11] = 1;
                    break;
                case "Sign_12":
                    floatingSignsHit[12] = 1;
                    break;
                case "Sign_13":
                    floatingSignsHit[13] = 1;
                    break;
                case "Sign_14":
                    floatingSignsHit[14] = 1;
                    break;
                case "Sign_15":
                    floatingSignsHit[15] = 1;
                    break;
                case "Sign":
                    floatingSignsHit[16] = 1;
                    break;
                default:
                    break;
            }
            s = "";
            for(int i = 1; i<=15; i++)
            {
                s += floatingSignsHit[i] + " ";
            }
        }


    }

    // TriggerExit() =========================================================================================================================================================

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Wall")
        {
            cubvin.GetComponent<Rigidbody>().velocity = Vector3.zero;
            wallRun = 0;
        }
    }

    // ...nothing...=========================================================================================================================================================


    // some king of strange function which I'm not using anymore =========================================================================================================================================================



    static public class MoveObjectToNewScene
    {
        static GameObject targetObject;
        static string targetSceneName;
        static Scene currentScene;
        static Scene newScene;

        /// <summary>
        /// Move a GameObject from the current scene to another scene.
        /// </summary>
        /// <param name="sceneName">Name of the scene you want to load.</param>
        /// <param name="targetGameObject">GameObject you want to move to the new scene.</param>
        static public void LoadScene(string sceneName, GameObject targetGameObject)
        {
            // set some globals
            targetObject = targetGameObject;
            targetSceneName = sceneName;

            // get the current active scene
            currentScene = SceneManager.GetActiveScene();

            // load the new scene in the background
            SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Additive);

            // Attach the SceneLoaded method to the sceneLoaded delegate.
            // SceneLoaded will be called when the new scene is loaded.
            SceneManager.sceneLoaded += SceneLoaded;
        }

        /// <summary>
        /// After new scene loads, move GameObject from current scene to new scene.
        /// When finished, unload current scene. The new scene becomes current scene.
        /// </summary>
        /// <param name="newScene">New scene that was loaded.</param>
        /// <param name="loadMode">Mode that was used to load the scene.</param>
        static public void SceneLoaded(Scene newScene, LoadSceneMode loadMode)
        {
            // remove this method from the sceneLoaded delegate
            SceneManager.sceneLoaded -= SceneLoaded;

            // get the scene we just loaded into the background
            newScene = SceneManager.GetSceneByName(targetSceneName);

            // move the gameobject from scene A to scene B
            SceneManager.MoveGameObjectToScene(targetObject.gameObject, newScene);

            // unload scene A
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }

    internal void Respawn()
    {

        ///Teleport to the location of coord x,y,z, relative to the object (in our case, the object is Cubvin)
        var cube = cubvin.transform.position;
        cube.x = X;
        cube.y = Y;
        cube.z = Z;
        cubvin.transform.position = cube;

        ///Nulify inertial forces of moving
        cubvin.GetComponent<Rigidbody>().velocity = Vector3.zero;

        ///Nulify movement of rotation
        cubvin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        ///Reset the rotation of the cube
        var rotationPos = cubvin.transform.rotation.eulerAngles;
        rotationPos.x = 0;
        rotationPos.z = 0;
        cubvin.transform.rotation = Quaternion.Euler(rotationPos);

        if (SceneManager.GetActiveScene().name == "Training")
        {
            ///Retunr sign to its initial position, rotation and velocity
            signToBill.transform.position = signToBillPowerPos;
            signToBill.GetComponent<Rigidbody>().velocity = Vector3.zero;
            signToBill.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            var rotationPosSign = signToBill.transform.rotation.eulerAngles;
            rotationPosSign.x = 0;
            rotationPosSign.y = -172;
            rotationPosSign.z = 0;
            signToBill.transform.rotation = Quaternion.Euler(rotationPosSign);

            //Reset Cubvin inner conversation
            GameObject.Find("CubvinSoul").GetComponent<TextTutorial>().tips = 0;

            //Reset important variables in TextTutorial
            doorTouched = false;
            doorTouchedAgain = false;
            startZoneTouched = 0;
        }

        dieCount++;
        for (var i = 1; i <= 16; i++)
        {
            floatingSignsHit[i] = 0;
            var obj = GameObject.Find("Sign_" + i);
            if (obj)
                obj.GetComponent<UpDownMovement>().Restart();
        }
    }

}

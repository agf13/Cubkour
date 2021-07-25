using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    private float time;
    private float startTime;
    private float stopTime;
    internal bool ableToMove;
    public float speed = (float) 0.21;
    public float jumpPower = (float) 0.2;

    public AudioClip jumpSound;
    public AudioClip background_training;
    public AudioClip background_lvl1;
    public AudioClip billSummon;
    internal AudioSource sound;

    private CubvinPressurePlate script_CubvinPressurePlate;
    private Objects script_Objects;
    private CubvinSoul6sense script_CubvinSoul6sense;
    private PlayerController script_PlayerController;
    private TextTutorial script_TextTutorial;

    private Rigidbody rb;

    void Start()
    {
        ableToMove = true;
        rb = GetComponent<Rigidbody>();
        time = Time.time;
        sound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        sound.clip = background_training;
        sound.Play();
        script_CubvinPressurePlate = GameObject.Find("CheckForPlaySound").GetComponent<CubvinPressurePlate>();
        startTime = Time.time;
        script_Objects = GameObject.Find("ColectObj").GetComponent<Objects>();
        script_CubvinSoul6sense = GameObject.Find("CubvinSoul").GetComponent<CubvinSoul6sense>();
        script_PlayerController = GameObject.Find("Cubvin").GetComponent<PlayerController>();
        script_TextTutorial = GameObject.Find("CubvinSoul").GetComponent<TextTutorial>();
        if (script_Objects.scenenName == "Training")
        {
            //Debug.Log("Yap. De asta");
            ableToMove = false;
        }
    }


    void Update()
    {
        if (script_PlayerController.sound.isPlaying == false)
        {
            //Debug.Log("Nu sa auzit nimic");
            sound.Play();
        }
        //float moveHorizontal = Input.GetAxis("Horizontal");  //--Nu mai avem intocmai nevoie de asta de cand ne-am dat seama ca putem scrie ca mai jus
        //float moveVertical = Input.GetAxis("Vertical");  //--Acelasi lucru care scrie in comment-ul cu un rand mai sus

        ///First here are the functions whick need to be checked as a cube
        ///... ok, maybe there are no functions which needs to be here.

        ///Here ends the functions
        //if (Input.GetKey(KeyCode.UpArrow)) ///move front
        //    rb.transform.Translate(0f, 0f, speed);
        //if (Input.GetKey(KeyCode.DownArrow)) ///move backward
        //    rb.transform.Translate(0f, 0f, -speed);
        //if (Input.GetKey(KeyCode.RightArrow)) ///move right
        //    rb.transform.Translate(speed, 0f, 0f);
        //if (Input.GetKey(KeyCode.LeftArrow)) ///move left
        //    rb.transform.Translate(-speed, 0f, 0f);
        if (Input.GetKey(KeyCode.T))
        {
            if(Input.GetKey(KeyCode.L))
            {
                if(Input.GetKey(KeyCode.Alpha1))
                {
                    script_CubvinSoul6sense.X = script_CubvinSoul6sense.x_training_lvl1;
                    script_CubvinSoul6sense.Y = script_CubvinSoul6sense.y_training_lvl1;
                    script_CubvinSoul6sense.Z = script_CubvinSoul6sense.z_training_lvl1;
                    script_CubvinSoul6sense.Respawn();
                    script_PlayerController.ableToMove = true;
                    script_TextTutorial.tutorialNotSkipped = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            stopTime = Time.time;
            if (stopTime - startTime < 0.2)
                speed = 0.4f;
            else
                speed = 0.2f;
            startTime = stopTime;
        }

        if (Input.GetKey(KeyCode.W) && ableToMove == true) ///move front
        {
            rb.transform.Translate(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.S) && ableToMove == true) ///move backward
            rb.transform.Translate(0f, 0f, -speed);
        if (Input.GetKey(KeyCode.D) && ableToMove == true) ///move right
            rb.transform.Translate(speed, 0f, 0f);
        if (Input.GetKey(KeyCode.A) && ableToMove == true) ///move left
            rb.transform.Translate(-speed, 0f, 0f);

        if (Input.GetKey(KeyCode.Space)) ///jump
        {
            if (script_CubvinPressurePlate.isOnGround == true)
            {
                sound.PlayOneShot(jumpSound, 1f);
                //sound.Play();
                script_CubvinPressurePlate.isOnGround = false;
            }
                rb.transform.Translate(0f, jumpPower, 0f);
        }


        if (Input.GetKey(KeyCode.G)) ///jump
            rb.velocity = Vector3.zero;


    } 
}
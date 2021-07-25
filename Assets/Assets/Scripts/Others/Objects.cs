using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objects : MonoBehaviour {

    internal GameObject eye;
    internal GameObject hat;
    internal GameObject bill;
    internal GameObject katana;
    internal GameObject cubvin;
    internal GameObject cubvinSoul;
    internal GameObject floatingText;
    internal GameObject particles;
    internal GameObject hat_v2;
    internal GameObject p;
    internal GameObject tunel;
    internal GameObject innerLight;
    internal GameObject BillCipherStone_training;

    internal GameObject thought1;
    internal GameObject thought2;
    internal GameObject thought3;
    internal GameObject thought4;
    internal GameObject thought5;
    internal GameObject thought6;
    internal GameObject thought7;
    internal GameObject thought8;
    internal GameObject thought9;
    internal GameObject thought10;
    internal GameObject thought11;
    internal GameObject thought2_afterDie;
    internal GameObject thought3_afterDie;
    internal GameObject thought4_afterDie;
    internal GameObject[] thoughts = new GameObject[20];
    internal GameObject msjTrigger;

    internal int numaratulOilor = 0; //Cu aceasta variabila numaram cate ganduri au aparut in scena de training  ... dar, nu o sa o mai folosim

    private int skillSet;
    internal string scenenName;
    


    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;

        eye = GameObject.Find("Eye");
        hat = GameObject.Find("Hat");
        katana = GameObject.Find("Katana");
        bill = GameObject.Find("BillCipher");
        cubvin = GameObject.Find("Cubvin");
        cubvinSoul = GameObject.Find("CubvinSoul");
        floatingText = GameObject.Find("FloatingText");
        particles = GameObject.Find("ParticleSystem");
        hat_v2 = GameObject.Find("Hat_V2");
        innerLight = GameObject.Find("InnerLight");
        skillSet = GameObject.Find("BagOVariables").GetComponent<KeepVariables>().skillVar;
        scenenName = SceneManager.GetActiveScene().name;
        if (scenenName == "Training")
        {
            numaratulOilor = 0;
            tunel = GameObject.Find("Tunel") ;
            tunel.SetActive(false);
            //thought1 = GameObject.Find("Sign_1");
            //thought2 = GameObject.Find("Sign_2");
            //thought3 = GameObject.Find("Sign_3");
            //thought4 = GameObject.Find("Sign_4");
            //thought5 = GameObject.Find("Sign_5");
            //thought6 = GameObject.Find("Sign_6");
            //thought7 = GameObject.Find("Sign_7");
            //thought8 = GameObject.Find("Sign_8");
            //thought9 = GameObject.Find("Sign_9");
            //thought10 = GameObject.Find("Sign_10");
            //thought11 = GameObject.Find("Sign_11");
            //thought2_afterDie = GameObject.Find("Sign_2_afterDie");
            //thought3_afterDie = GameObject.Find("Sign_3_afterDie");
            //thought4_afterDie = GameObject.Find("Sign_4_afterDie");
            BillCipherStone_training = GameObject.Find("BillCipherStone");
            for(var i = 1; i<=15; i++)
            {
                thoughts[i] = GameObject.Find("Sign_" + i);
                thoughts[i].SetActive(false);
            }

            //thought1.SetActive(false);
            //thought2.SetActive(false);
            //thought3.SetActive(false);
            //thought4.SetActive(false);
            //thought5.SetActive(false);
            //thought6.SetActive(false);
            //thought7.SetActive(false);
            //thought8.SetActive(false);
            //thought9.SetActive(false);
            //thought10.SetActive(false);
            //thought11.SetActive(false);
            //thought2_afterDie.SetActive(false);
            //thought3_afterDie.SetActive(false);
            //thought4_afterDie.SetActive(false);
            BillCipherStone_training.SetActive(false);
            //msjTrigger = GameObject.Find("MsjTrigger_1");
            //msjTrigger.SetActive(false);
        }


        
        hat_v2.SetActive(true);
        eye.SetActive(false);
        hat.SetActive(false);
        katana.SetActive(false);
        bill.SetActive(false);
        particles.GetComponent<ParticleSystem>().Stop(true);
        innerLight.SetActive(false);


    }
    



}

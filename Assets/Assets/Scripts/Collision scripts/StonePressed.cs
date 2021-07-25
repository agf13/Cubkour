using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePressed: MonoBehaviour {

    private GameObject eye;
    private GameObject hat;
    private GameObject katana;
    private GameObject bill;
    private GameObject hat_v2;

    private KeepVariables script_KeepVariables;
    private Objects script_Objects;


    internal float startTime;
    internal float stopTime;
    private float secForBillAnimation = 9.05f;


    void Start()
    {
        script_Objects = GameObject.Find("ColectObj").GetComponent<Objects>();
        hat = script_Objects.hat;
        eye = script_Objects.eye;
        katana = script_Objects.katana;
        bill = script_Objects.bill;
        script_KeepVariables = GameObject.Find("BagOVariables").GetComponent<KeepVariables>();
        hat_v2 = script_Objects.hat_v2;
    }

    void Update()
    {
        stopTime = Time.time;
        if(stopTime - startTime >= secForBillAnimation)
        {
            script_Objects.innerLight.SetActive(false);
            TransformInBill();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cubvin")
        {
            var cubvin = GameObject.Find("Cubvin");
            var skillNumber = cubvin.GetComponent<Skills>();
            switch(this.gameObject.name)
            {
                case "NinjaStone":
                    skillNumber.skill = 1;
                    TransformInNinja();
                    break;
                case "MagicianStone":
                    skillNumber.skill = 2;
                    TransformInMagician();
                    break;
                case "BillCipherStone":
                    AnimationForBillSummon();
                    skillNumber.skill = 3;
                    break;
            }
        }
    }

    void AnimationForBillSummon()
    {
        startTime = Time.time;
        script_Objects.innerLight.SetActive(true);
    }

    void TransformInBill()
    {
        script_KeepVariables.skillVar = 3;
        GameObject.Find("FloatingText").GetComponent<ChangeFloatingText>().ChangeText("Bill Cipher: \n  Now you can pass through walls.\r\nJust hold F.", 2);
        hat_v2.SetActive(false);
        katana.SetActive(false);
        hat.SetActive(false);
        eye.SetActive(true);
        bill.SetActive(false);
    }

    void TransformInMagician()
    {
        script_KeepVariables.skillVar = 2;
        GameObject.Find("FloatingText").GetComponent<ChangeFloatingText>().ChangeText("Magician: \n Hocus-Pocus back on legs.\r\nJust press F.", 2);
        hat_v2.SetActive(false);
        katana.SetActive(false);
        hat.SetActive(true);
        eye.SetActive(false);
        bill.SetActive(false);
    }

    void TransformInNinja()
    {
        script_KeepVariables.skillVar = 1;
        GameObject.Find("FloatingText").GetComponent<ChangeFloatingText>().ChangeText("Ninja: \n You can dash some cubes in front of you. \r\nJust press F.", 2);
        hat_v2.SetActive(false);
        katana.SetActive(true);
        hat.SetActive(false);
        eye.SetActive(false);
        bill.SetActive(false);
    }
}

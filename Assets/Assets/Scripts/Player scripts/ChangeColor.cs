using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public Material[] material;
    internal Renderer rend;

    private Objects script_Objects;
    private int skillSet;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        skillSet = GameObject.Find("BagOVariables").GetComponent<KeepVariables>().skillVar;
        script_Objects = GameObject.Find("ColectObj").GetComponent<Objects>();
        if(skillSet!=0)
        {
            rend.sharedMaterial = material[skillSet];
            switch(skillSet)
            {
                case 1:
                    script_Objects.hat_v2.SetActive(false);
                    script_Objects.eye.SetActive(false);
                    script_Objects.hat.SetActive(false);
                    script_Objects.katana.SetActive(true);      ///Katana for a true ninja
                    script_Objects.bill.SetActive(false);
                    break;
                case 2:
                    script_Objects.hat_v2.SetActive(false);
                    script_Objects.eye.SetActive(false);
                    script_Objects.hat.SetActive(true);         //A true magician requiers a true hat
                    script_Objects.katana.SetActive(false); 
                    script_Objects.bill.SetActive(false);
                    break;
                case 3:
                    script_Objects.hat_v2.SetActive(false);
                    script_Objects.eye.SetActive(true);         // All seeing eye
                    script_Objects.hat.SetActive(false);
                    script_Objects.katana.SetActive(false); 
                    script_Objects.bill.SetActive(false);
                    break;
                default:
                    break;
            }

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "NinjaStone")
        {
            rend.sharedMaterial = material[1];
        }
        if (col.gameObject.name == "MagicianStone")
        {
            rend.sharedMaterial = material[2];
        }
        if (col.gameObject.name == "BillCipherStone")
        {
            rend.sharedMaterial = material[3];
        }
    }



}

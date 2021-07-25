using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour {


    private GetMenuColumns script_GetMenuColumns;



    // Use this for initialization
    void Start ()
    {

        script_GetMenuColumns = GameObject.Find("Canvas").GetComponent<GetMenuColumns>();
    }
	
	public void BackToMenuFunction()
    {
        script_GetMenuColumns.menuPanel.SetActive(true);
        script_GetMenuColumns.instructionsPanel.SetActive(false);
        script_GetMenuColumns.exitPanel.SetActive(false);
    }
}

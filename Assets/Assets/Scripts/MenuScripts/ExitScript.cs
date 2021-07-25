using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

    private GetMenuColumns script_GetMenuColumns;

	// Use this for initialization
	void Start () {
        script_GetMenuColumns = GameObject.Find("Canvas").GetComponent<GetMenuColumns>();
	}
	
	public void ExitFunction()
    {
        script_GetMenuColumns.menuPanel.SetActive(false);
        script_GetMenuColumns.exitPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInstructions : MonoBehaviour {

    private GetMenuColumns script_GetMenuColumns;

    void Start()
    {
        script_GetMenuColumns = GameObject.Find("Canvas").GetComponent<GetMenuColumns>();
    }

	public void LoadInstructionsFormMenu()
    {
        script_GetMenuColumns.instructionsPanel.SetActive(true);
        script_GetMenuColumns.menuPanel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMenuColumns : MonoBehaviour {

    internal GameObject menuPanel;
    internal GameObject instructionsPanel;
    internal GameObject exitPanel;

    internal GameObject historyButton;
    internal GameObject exitButton;
    internal GameObject startButton;
    internal GameObject instructionsButton;


    // Use this for initialization
    void Start ()
    { 
        //buttons
        startButton = GameObject.Find("StartButton");
        instructionsButton = GameObject.Find("InstructionsButton");
        historyButton = GameObject.Find("HistoryButton");
        exitButton = GameObject.Find("ExitButton");

        //panels
        menuPanel = GameObject.Find("MainMenuPanel");
        instructionsPanel = GameObject.Find("InstructionsPanel");
        exitPanel = GameObject.Find("ExitPanel");

        //functions
        instructionsPanel.SetActive(false);
        exitPanel.SetActive(false);
        historyButton.GetComponent<Button>().interactable = false;

    }

    //// Update is called once per frame
    //void Update () {

    //}
}

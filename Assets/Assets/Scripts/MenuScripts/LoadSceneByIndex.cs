﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour {

	public void LoadByIndex(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}

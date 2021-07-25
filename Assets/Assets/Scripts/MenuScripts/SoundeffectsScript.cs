using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundeffectsScript : MonoBehaviour {

    internal AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip buttonPressedSound;

    // Use this for initialization
    void Start () {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        Debug.Log(audioSource);
	}

    public void PlayHoverSOund()
    {
        audioSource.PlayOneShot(hoverSound, 1f);
    }

    public void ButtonPressedSound()
    {
        audioSource.PlayOneShot(buttonPressedSound, 1f);
    }
}

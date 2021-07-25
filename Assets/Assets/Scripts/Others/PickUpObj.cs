using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObj : MonoBehaviour {

    
    internal GameObject[] pos = new GameObject[20];
    private Random rnd = new Random();
    internal int nextPos;
    internal bool ok = true;

    private CubvinSoul6sense script_CubvinSoul6sense;
    private GameObject strangeSnake;


    // Use this for initialization
    void Start ()
    {
        script_CubvinSoul6sense = GameObject.Find("CubvinSoul").GetComponent<CubvinSoul6sense>();
		for(int i=1; i<=8; i++)
        {
            pos[i] = GameObject.Find("KeyPos_"+i);
        }
        strangeSnake = GameObject.Find("ColectableObj");
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    internal void ChangePos()
    {
        nextPos = Random.Range(1, 9);
        strangeSnake.transform.position = pos[nextPos].transform.position;
        switch(nextPos)
        {
            case 1:
                script_CubvinSoul6sense.messages.text = "Hint: The object is located at the top of the shuriken.";
                break;
            case 2:
                script_CubvinSoul6sense.messages.text = "Hint: On a pillar from something which looks like stonehenge. ";
                break;
            case 3:
                script_CubvinSoul6sense.messages.text = "Hint: Look above the stars.";
                break;
            case 4:
                script_CubvinSoul6sense.messages.text = "Hint: Between the stars.";
                break;
            case 5:
                script_CubvinSoul6sense.messages.text = "Hint: You need to wallrun.";
                break;
            case 6:
                script_CubvinSoul6sense.messages.text = "Hint: Is standing on the edge. Can you get up there?";
                break;
            case 7:
                script_CubvinSoul6sense.messages.text = "Hint: Pure purple nothingness.";
                break;
            case 8:
                script_CubvinSoul6sense.messages.text = "Hint: On the floating steppers.";
                break;
            default:
                Debug.Log("S-a ajuns la default, adica la fct ChangePos(). nextPos iese din range cel mai probabil.");
                ChangePos();
                break;
        }
    }
}

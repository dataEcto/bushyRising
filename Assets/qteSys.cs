﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qteSys : MonoBehaviour {
    
    //The Key that the player needs to press
    public GameObject displayBox;
    //The Box that shows if the key was pressed properly
    public GameObject passBox;

    //Int that determines what key to press
    public int qteGen;
    //Int that counts down to next key
    public int waitingForKey;
    //Checks to see if correct key is being pressed
    public int correctKey;
    //Int that checks if something is being done,
    //preventing further button presses
    public int countingDown;
	
	// Update is called once per frame
	void Update () {
		
        if (waitingForKey == 0)
        {
            qteGen = Random.Range(1, 4);
            countingDown = 1;

            if (qteGen == 1)
            {
                waitingForKey = 1;
                displayBox.GetComponent<Text>().text = "[E]";
            }

            if(qteGen == 2)
            {
                waitingForKey = 1;
                displayBox.GetComponent<Text>().text = "[R]";
            }

            if (qteGen == 3)
            {
                waitingForKey = 1;
                displayBox.GetComponent<Text>().text = "[T]";
            }
        }

        //Now check if we're pressing the right key
        if (qteGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("Ekey"))
                {
                    correctKey = 1;
                    //Key pressing is an error bc we havent made it yet
                    StartCoroutine(KeyPressing ());
                }

                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing ());
                }
            }
            

        }
	}
}
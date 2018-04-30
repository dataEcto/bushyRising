using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class qteSys : MonoBehaviour {
    
    //The text box that displays the Key that the player needs to press
    public GameObject displayBox;
    //The text box that shows if the key was pressed properly
    public GameObject passBox;

    //Int that determines what key to press
    public int qteGen;
    //Int that waits for a key press
    public int waitingForKey;
    //Checks to see if correct key is being pressed
    public int correctKey;
    //Int that checks if something is being done,
    //preventing further button presses
    public int countingDown;


    void Update () {
		
        //If this is a zero,
        //Then run code to display a key to press
        if (waitingForKey == 0)
        {
            //We create a random number to choose the letters from
            //An extra number is added just to be safe
            qteGen = Random.Range(1, 4);
            //Later on, this int will confirm that
            //something is happening and stop any further button presses
            //To be elaborated upon later
            countingDown = 1;
            //This is the countdown timer 
            StartCoroutine(countDown());

            //Each number in qteGen will be assigned a letter
            //And will then be shown on our display box, which was established earlier
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

        //Now check if we're pressing the key
        //For each of the 3 keys we are pressing
        if (qteGen == 1)
        {
            //Check if a key is actually being pressed...BUT
            if (Input.anyKeyDown)
            {
                //Is it the right key?
                if (Input.GetButtonDown("Ekey"))
                {
                    //This variable will be used in a seperate routine
                    correctKey = 1;
                    //Which is this one!
                    StartCoroutine(KeyPressing ());
                }

                //If not....
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing ());
                }
            }
            

        }

        //Same as above, so not really gonna comment on this
        if (qteGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("Rkey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }

                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }


        }

        if (qteGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("Tkey"))
                {
                    correctKey = 1;
                    //Key pressing is an error bc we havent made it yet
                    StartCoroutine(KeyPressing());
                }

                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }


        }
    }

    //This is where we actually test if the key is being pressed.
    IEnumerator KeyPressing() {
        //We stop further key presses by reseting the qteGen
        //It is 4 because that is higher than the amount of key presses to choose from
        qteGen = 4;

        //If the key was correctly pressed
        if (correctKey == 1)
        {
            countingDown = 2;
            passBox.GetComponent<Text>().text = "Pass!";

            //We want to wait a bit before changing the correctKey back to its default state
            //which is 0
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";

            //This is where we get a new key
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }

        if (correctKey == 2)
        {
            countingDown = 2;
            passBox.GetComponent<Text>().text = "failed!";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }

    }

    //The Countdown Timer
    IEnumerator countDown()
    {
        //Where the counting down happens
        yield return new WaitForSeconds(3f);

        if (countingDown == 1)
        {
            qteGen = 4;
            countingDown = 2;
            passBox.GetComponent<Text>().text = "failed!";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
        }
    }
}

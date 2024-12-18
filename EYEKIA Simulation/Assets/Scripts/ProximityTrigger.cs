using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximityTrigger : MonoBehaviour
{
    //For Modes
    Modes mode;
    private void Start()
    {
        mode = GameObject.FindObjectOfType<Modes>();
    }

    //Subtitle variables
    public TextMeshProUGUI subtitles;
    string subText;

    bool isTalking; //To check if someone near is talking
    private void OnTriggerEnter(Collider other)
    {
        if(mode.isOn && !mode.isOff)
        {
            //If the object in the trigger collider of the player is named...do this
            string name = other.name;
            switch (name)
            {
                case "StartMan":
                    isTalking = true;
                    subText = "Oh no, whatever happened there! Was it some accident?";
                    StartCoroutine(WordForWord());

                    break;

                case "CrimeWoman":
                    isTalking = true;
                    subText = "I was driving and suddenly some guy appeared right in front of me. I had to swerve!";
                    StartCoroutine(WordForWord());

                    break;

                case "Man":
                    isTalking = true;
                    subText = "What happened just now? I saw the indicator on my Eyekia glasses.";
                    StartCoroutine(WordForWord());

                    break;

                default:
                    subText = "";
                    subtitles.text = subText;
                    isTalking = false;
                    break;
            }
        }

    }
    //To have no text when out of radius
    private void OnTriggerExit(Collider other)
    {
        subText = "";
        subtitles.text = subText;
        isTalking = false;
    }

    IEnumerator WordForWord()
    {
        if (isTalking && mode.isOn && !mode.isOff)
        {
            while(subtitles.text.Length <= subText.Length)
            {
                //To individually show words like live captions
                foreach (string word in subText.Split(' '))
                {
                    yield return new WaitForSeconds(0.2f); //As some words were not being picked up at the start
                    subtitles.text += word + " ";
                    float randomTime = Random.Range(0.1f, 0.2f);
                    yield return new WaitForSeconds(randomTime); //pauses between words to mimic live captioning
                }
            }
            
        }
    }

    

}


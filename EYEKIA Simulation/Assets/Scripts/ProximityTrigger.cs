using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximityTrigger : MonoBehaviour
{
    //Indicator variables
    CalculateDistance distCalc;
    float distance;

    private void Start()
    {
        distance = GetComponent<CalculateDistance>().distance; //To get the distance var from CalcDist Class
    }

    //Subtitle variables
    public TextMeshProUGUI subtitles;
    string subText;

    bool isTalking; //To check if someone near is talking

    private void OnTriggerEnter(Collider other)
    {
        //To calculate the distance once inside radius
        other.gameObject.AddComponent<CalculateDistance>();

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
                subText = "What happned just now? I saw the indicator on my Eyekia glasses.";
                StartCoroutine(WordForWord());
                break;

            case "LorryCargo":
            case "Police":
            case "Minivan":
                Debug.Log("Engine Noises");
                break;
            case "Ambulance":
                Debug.Log("Sirens");
                break;

            default:
                subText = "";
                subtitles.text = subText;
                isTalking = false;
                break;
        }  
    }

    //To have no text when out of radius
    private void OnTriggerExit(Collider other)
    {
        //to stop calculating distance when out of range
        Destroy(other.gameObject.GetComponent<CalculateDistance>());

        subText = "";
        subtitles.text = subText;
        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        //To check if still talking or not
        if (subtitles.text.Length <= subText.Length)
        {
            isTalking = true;
        }
        else
        {
            isTalking = false;
        }
    }

    IEnumerator WordForWord()
    {
        if (isTalking)
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


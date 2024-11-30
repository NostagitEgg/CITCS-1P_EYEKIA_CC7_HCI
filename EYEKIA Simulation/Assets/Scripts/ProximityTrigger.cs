using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximityTrigger : MonoBehaviour
{
    //Indicator variables
    CalculateDistance distCalc;
    float distance;

    public GameObject[] leftIndicators, rightIndicators;
    public TextMeshProUGUI[] L_IndicatorText, R_IndicatorText;
    string indText;

    bool isHeard; //if it makes a sound

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
        isHeard = true;

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

                indText = "Person Talking";
                break;

            case "CrimeWoman":
                isTalking = true;
                subText = "I was driving and suddenly some guy appeared right in front of me. I had to swerve!";
                StartCoroutine(WordForWord());

                indText = "Person Talking";
                break;

            case "Man":
                isTalking = true;
                subText = "What happned just now? I saw the indicator on my Eyekia glasses.";
                StartCoroutine(WordForWord());

                indText = "Person Talking";
                break;

            case "LorryCargo":
            case "Police":
            case "Minivan":
            case "Ambulance":
                indText = "Engine Noises";
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
        isHeard = false;

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

    public void AddToIndicator()
    {
        if (isHeard && distCalc.isLeft)
        {
            for (int i = 0; i < leftIndicators.Length; i++)
            {
                if (L_IndicatorText[i] == null)
                {
                    leftIndicators[i].SetActive(true);
                    L_IndicatorText[i].text = indText;
                }
                else
                {
                    i++;
                }
            }
        }
        else if (isHeard && distCalc.isRight)
        {
            for (int i = 0; i < rightIndicators.Length; i++)
            {
                if (R_IndicatorText[i] == null)
                {
                    rightIndicators[i].SetActive(true);
                    R_IndicatorText[i].text = indText;
                }
                else
                {
                    i++;
                }
            }
        }
        
    }

}


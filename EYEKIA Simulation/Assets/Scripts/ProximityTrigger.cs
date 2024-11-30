using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximityTrigger : MonoBehaviour
{
    //Indicator variables
   /* CalculateDistance distCalc;

    public GameObject[] leftIndicators;
    public GameObject[] rightIndicators;
    public TextMeshProUGUI[] L_IndicatorText;
    public TextMeshProUGUI[] R_IndicatorText;*/
    public string indText;

    public bool isHeard; //if it makes a sound

    //Subtitle variables
    public TextMeshProUGUI subtitles;
    string subText;

    bool isTalking; //To check if someone near is talking

    /*private void Start()
    {
        distCalc = GetComponent<CalculateDistance>();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        isHeard = true;

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

        
        /*if (distCalc.isLeft)
        {
            for (int i = 0; i < leftIndicators.Length; i++)
            {
                //leftIndicators[i].SetActive(true);
                //if text in the indicator is empty, make the holder active and make it the text
                if (L_IndicatorText[i].text == "")
                {
                    L_IndicatorText[i].text = indText;
                }
                else
                {
                    i++;
                }
            }
        }
        else if (distCalc.isRight)
        {
             for (int i = 0; i < rightIndicators.Length; i++)
             {
                 //rightIndicators[i].SetActive(true);
                 if (R_IndicatorText[i].text == "")
                 {
                     R_IndicatorText[i].text = indText;
                 }
                 else
                 {
                     i++;
                 }
             }
        }*/

    }

    //To have no text when out of radius
    private void OnTriggerExit(Collider other)
    {
        isHeard = false;

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

    /*public void AddToLeftIndicator()
    {
        for (int i = 0; i < leftIndicators.Length; i++)
        {
            //leftIndicators[i].SetActive(true);
            //if text in the indicator is empty, make the holder active and make it the text
            if (L_IndicatorText[i] == null)
            {
                L_IndicatorText[i].text = indText;
            }
            else
            {
                i++;
            }
        }
        
    }

    public void AddToRightIndicator()
    {
        for (int i = 0; i < rightIndicators.Length; i++)
        {
            //rightIndicators[i].SetActive(true);
            if (R_IndicatorText[i] == null)
            {
                R_IndicatorText[i].text = indText;
            }
            else
            {
                i++;
            }
        }

    }*/

}


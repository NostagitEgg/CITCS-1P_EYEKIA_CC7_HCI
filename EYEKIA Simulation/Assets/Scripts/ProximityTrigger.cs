using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximityTrigger : MonoBehaviour
{
    /*//Indicator variables
    public GameObject[] leftIndicators;
    public GameObject[] rightIndicators;
    public TextMeshProUGUI[] L_IndicatorText;
    public TextMeshProUGUI[] R_IndicatorText;
    public string indText;*/
    
    //Subtitle variables
    public TextMeshProUGUI subtitles;
    string subText;

    bool isTalking; //To check if someone near is talking

    /*//Variables for Calculating Distance
    public GameObject player;
    public float distance;

    //Variables for Calculating Position of object (left or right of player)
    public GameObject camObject;
    public Camera playerCam;

    public bool isLeft, isRight;
    [SerializeField]
    Vector3 directionRelativeToCam;

    [SerializeField]
    int colliderCounter = 0;*/

    public bool isTriggered;
    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        //If the object in the trigger collider of the player is named...do this
        string name = other.name;
        switch (name)
        {
            case "StartMan":
                isTalking = true;
                subText = "Oh no, whatever happened there! Was it some accident?";
                StartCoroutine(WordForWord());

                //indText = "Person Talking";
                break;

            case "CrimeWoman":
                isTalking = true;
                subText = "I was driving and suddenly some guy appeared right in front of me. I had to swerve!";
                StartCoroutine(WordForWord());

                //indText = "Person Talking";
                break;

            case "Man":
                isTalking = true;
                subText = "What happened just now? I saw the indicator on my Eyekia glasses.";
                StartCoroutine(WordForWord());

                //indText = "Person Talking";
                break;

            case "LorryCargo":
                //indText = "Engine Noises";
                break;

            case "Police":
                //indText = "Engine Noises";
                break;

            case "Minivan":
                //indText = "Engine Noises";
                break;

            case "Ambulance":
                //indText = "Engine Noises";
                break;

            default:
                subText = "";
                subtitles.text = subText;
                isTalking = false;
                break;
        }

        /*if(other.name != "Capsule")
        {
            colliderCounter += 1;

            if(colliderCounter >= 6)
            {
                colliderCounter = 0; //Reset counter to avoid out of bounds
            }
        }*/
    }

    /*private void OnTriggerStay(Collider other)
    {
        if(other.name != "Capsule")
        {
            distance = Vector3.Distance(other.transform.position, player.transform.position);

            //From reddit
            //Direction of this object from player
            directionRelativeToCam = other.transform.position - player.transform.position;
            //however the direction is not that useful because if your player faces north, his right side is to the east, but if he 
            //faces south, his right side is west.
            //so we need to rotate the direction Dir, to make sure it is unaffected by the players rotation
            directionRelativeToCam = Quaternion.Inverse(player.transform.rotation) * directionRelativeToCam;
        }
        
        if (directionRelativeToCam.x < 0)
        {
            isRight = false;
            isLeft = true;
        }
        else if (directionRelativeToCam.x > 0)
        {
            isRight = true;
            isLeft = false;
        }
    }*/

    //To have no text when out of radius
    private void OnTriggerExit(Collider other)
    {
        //colliderCounter -= 1;
        subText = "";
        subtitles.text = subText;
        isTalking = false;

        isTriggered = false;
        //indText = "";
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

        /*//To have the text on left or right depending on direction, and to use free indicator space
        if (isRight && !isLeft)
        {
            for (int i = 0; i < colliderCounter; i++)
            {
                if (R_IndicatorText[i].text == "")
                {
                    R_IndicatorText[i].text = indText;
                }
                else if (R_IndicatorText[i].text != "")
                {
                    R_IndicatorText[i + 1].text = indText;
                }
            }
        }
        else if (isLeft && !isRight)
        {

            for (int i = 0; i < colliderCounter; i++)
            {
                if (L_IndicatorText[i].text == "")
                {
                    L_IndicatorText[i].text = indText;
                }
                else if (L_IndicatorText[i].text != "")
                {
                    L_IndicatorText[i + 1].text = indText;
                }
            }
        }*/
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


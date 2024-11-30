using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    //Variables for Calculating Distance
    public GameObject player;
    public float distance;

    //Variables for Calculating Position of object (left or right of player)
    public GameObject camObject;
    public Camera playerCam;

    public bool isLeft, isRight;
    [SerializeField]
    Vector3 directionRelativeToCam;

    public GameObject[] leftIndicators;
    public GameObject[] rightIndicators;
    public TextMeshProUGUI[] L_IndicatorText;
    public TextMeshProUGUI[] R_IndicatorText;
    string indText;
    bool isHeard;

    /*private void Start()
    {
        isHeard = player.GetComponent<ProximityTrigger>().isHeard;
    }*/

    // Update is called once per frame
    void Update()
    {
        string name = this.name;
        switch (name)
        {
            case "StartMan":
                indText = "Person Talking";
                break;

            /*case "CrimeWoman":
                indText = "Person Talking";
                break;

            case "Man":
                indText = "Person Talking";
                break;

            case "LorryCargo":
            case "Police":
            case "Minivan":
            case "Ambulance":
                indText = "Engine Noises";
                break;*/

            default:
                indText = "";
                break;
        }

         distance = Vector3.Distance(transform.position, player.transform.position);

         //From reddit
         //Direction of this object from player
         directionRelativeToCam = transform.position - player.transform.position;
         //however the direction is not that useful because if your player faces north, his right side is to the east, but if he 
         //faces south, his right side is west.
         //so we need to rotate the direction Dir, to make sure it is unaffected by the players rotation
         directionRelativeToCam = Quaternion.Inverse(player.transform.rotation) * directionRelativeToCam;

        /*if (directionRelativeToCam.x < 0 && isHeard)
        {
             isRight = false;
             isLeft = true;

             for (int i = 0; i < leftIndicators.Length; i++)
             {
                 //leftIndicators[i].SetActive(true);
                 //if text in the indicator is empty, make the holder active and make it the text
                 if (L_IndicatorText[i].text == "")
                 {
                     L_IndicatorText[i].text = indText;
                    break;
                 }
                 else
                 {
                     i++;
                 }
             }
        }
        else if (directionRelativeToCam.x > 0 && isHeard)
        {
             isRight = true;
             isLeft = false;

             for (int i = 0; i < rightIndicators.Length; i++)
             {
                 //rightIndicators[i].SetActive(true);
                 if (R_IndicatorText[i].text == "")
                 {
                     R_IndicatorText[i].text = indText;
                    break;
                 }
                 else
                 {
                     i++;
                 }
             }
        }*/
        
    
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    //Indicator variables
    public GameObject[] leftIndicators;
    public GameObject[] rightIndicators;
    public TextMeshProUGUI[] L_IndicatorText;
    public TextMeshProUGUI[] R_IndicatorText;
    public string indText;

    //Variables for Calculating Distance
    public GameObject player;
    public float distance;

    //Variables for Calculating Position of object (left or right of player)
    public GameObject camObject;
    public Camera playerCam;

    public bool isLeft, isRight;
    [SerializeField]
    Vector3 directionRelativeToCam;

    bool canAddToIndicator;

    ProximityTrigger proxy;

    private void Start()
    {
        proxy = FindObjectOfType<ProximityTrigger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Capsule" && proxy.isTriggered)
        {
            canAddToIndicator = true;
        }
        else if (proxy.isTriggered == false) 
        {
            canAddToIndicator = false;
        }

        //indicator texts based on collider
        string name = this.gameObject.name;
        switch (name)
        {
            case "StartMan":
                indText = "Person Talking";
                break;

            case "CrimeWoman":
                indText = "Person Talking";
                break;

            case "Man":
                indText = "Person Talking";
                break;

            case "LorryCargo":
                indText = "Engine Noises";
                break;

            case "Police":
                indText = "Engine Noises";
                break;

            case "Minivan":
                indText = "Engine Noises";
                break;

            case "Ambulance":
                indText = "Engine Noises";
                break;

            default:
                indText = "";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        distance = Vector3.Distance(transform.position, player.transform.position);

        //From reddit
        //Direction of this object from player
        directionRelativeToCam = transform.position - player.transform.position;
        //however the direction is not that useful because if your player faces north, his right side is to the east, but if he 
        //faces south, his right side is west.
        //so we need to rotate the direction Dir, to make sure it is unaffected by the players rotation
        directionRelativeToCam = Quaternion.Inverse(player.transform.rotation) * directionRelativeToCam;

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

        //To have the text on left or right depending on direction, and to use free indicator space
        if (isRight && !isLeft)
        {
            for (int i = 0; i <= 5 && canAddToIndicator; i++)
            {
                if (R_IndicatorText[i].text == "")
                {
                    R_IndicatorText[i].text = indText;
                }
                else if (R_IndicatorText[i].text != "")
                {
                    R_IndicatorText[i + 1].text = indText;
                }
                if (R_IndicatorText[5].text != "")
                {
                    canAddToIndicator = false;
                    R_IndicatorText[i].text = "";
                }
            }
        }
        else if (isLeft && !isRight)
        {

            for (int i = 0; i < 5 && canAddToIndicator; i++)
            {
                if (L_IndicatorText[i].text == "")
                {
                    L_IndicatorText[i].text = indText;
                    R_IndicatorText[i].text = "";
                }
                else if (L_IndicatorText[i].text != "")
                {
                    L_IndicatorText[i + 1].text = indText;
                }
                if (R_IndicatorText[5].text != "")
                {
                    canAddToIndicator = false;
                    R_IndicatorText[i].text = "";
                }
            }
        }
    }
}

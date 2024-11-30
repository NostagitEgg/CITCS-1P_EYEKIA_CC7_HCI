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
    }

    // Update is called once per frame
    void Update()
    { 
        if(proxy.isTriggered)
        {
            canAddToIndicator = true;
        }
        else
        {
            canAddToIndicator = false;
        }

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

    }

    private void OnTriggerStay(Collider other)
    {
        //To have the text on left or right depending on direction
        if (isRight && !isLeft && canAddToIndicator)
        {
            //indicator texts based on collider
            string name = this.gameObject.name;
            switch (name)
            {
                case "LorryMoving":
                case "MinivanMoving":
                case "MuscleMoving":
                    indText = "Incoming Vehicle";
                    R_IndicatorText[1].text = indText;

                    if(R_IndicatorText[1] != null)
                    {
                        R_IndicatorText[2].text = indText;

                        if (R_IndicatorText[2] != null)
                        {
                            R_IndicatorText[3].text = indText;
                        }
                    }
                    break;

                case "PoliceMoving":
                case "AmbulanceMoving":
                    indText = "SIRENS";
                    R_IndicatorText[0].text = indText;
                    break;

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
                case "Police":
                case "Minivan":
                case "Ambulance":
                    indText = "Engine Noises";
                    break;

                default:
                    indText = "";

                    if (!canAddToIndicator)
                    {
                        R_IndicatorText[0].text = "";
                    }
                    break;
            }

            
        }
        else if (isLeft && !isRight && canAddToIndicator)
        {


        }
    }
}

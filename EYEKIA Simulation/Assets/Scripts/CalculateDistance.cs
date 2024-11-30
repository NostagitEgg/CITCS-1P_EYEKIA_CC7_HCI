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

    public bool isAdded;
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

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Capsule")
        {
            //To have the text on left or right depending on direction
            if (isRight && !isLeft)
            {
                //indicator texts based on collider
                string name = this.gameObject.name;
                switch (name)
                {
                    case "LorryMoving":
                        indText = "Incoming Vehicle";
                        if (R_IndicatorText[2].text == "")
                        {
                            R_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[2].text != "" && !isAdded)
                        {
                            R_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "MinivanMoving":
                        indText = "Incoming Vehicle";
                        if (R_IndicatorText[2].text == "")
                        {
                            R_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[2].text != "" && !isAdded)
                        {
                            R_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "MuscleMoving":
                        indText = "Incoming Vehicle";
                        if (R_IndicatorText[2].text == "")
                        {
                            R_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[2].text != "" && !isAdded)
                        {
                            R_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "PoliceMoving":
                        indText = "SIRENS";
                        if (R_IndicatorText[0].text == "")
                        {
                            R_IndicatorText[0].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[0].text != "" && !isAdded)
                        {
                            R_IndicatorText[1].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "AmbulanceMoving":
                        indText = "SIRENS";
                        if (R_IndicatorText[0].text == "")
                        {
                            R_IndicatorText[0].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[0].text != "" && !isAdded)
                        {
                            R_IndicatorText[1].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "StartMan":
                        indText = "Person Talking";
                        if (R_IndicatorText[4].text == "")
                        {
                            R_IndicatorText[4].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[4].text != "" && !isAdded)
                        {
                            R_IndicatorText[5].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "CrimeWoman":
                        indText = "Person Talking";
                        if (R_IndicatorText[4].text == "")
                        {
                            R_IndicatorText[4].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[4].text != "" && !isAdded)
                        {
                            R_IndicatorText[5].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "Man":
                        indText = "Person Talking";
                        if (R_IndicatorText[4].text == "")
                        {
                            R_IndicatorText[4].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[4].text != "" && !isAdded)
                        {
                            R_IndicatorText[5].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "LorryCargo":
                        indText = "Engine Noises";
                        if (R_IndicatorText[2].text == "")
                        {
                            R_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[2].text != "" && !isAdded)
                        {
                            R_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "Police":
                        indText = "Engine Noises";
                        if (R_IndicatorText[2].text == "")
                        {
                            R_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[2].text != "" && !isAdded)
                        {
                            R_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "Minivan":
                        indText = "Engine Noises";
                        if (R_IndicatorText[2].text == "")
                        {
                            R_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[2].text != "" && !isAdded)
                        {
                            R_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "Ambulance":
                        indText = "Engine Noises";
                        if (R_IndicatorText[2].text == "")
                        {
                            R_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (R_IndicatorText[2].text != "" && !isAdded)
                        {
                            R_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;
                }


            }
            else if (isLeft && !isRight)
            {
                //indicator texts based on collider
                string name = this.gameObject.name;
                switch (name)
                {
                    case "LorryMoving":
                        indText = "Incoming Vehicle";
                        if (L_IndicatorText[2].text == "")
                        {
                            L_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[2].text != "" && !isAdded)
                        {
                            L_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "MinivanMoving":
                        indText = "Incoming Vehicle";
                        if (L_IndicatorText[2].text == "")
                        {
                            L_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[2].text != "" && !isAdded)
                        {
                            L_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "MuscleMoving":
                        indText = "Incoming Vehicle";
                        if (L_IndicatorText[2].text == "")
                        {
                            L_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[2].text != "" && !isAdded)
                        {
                            L_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "PoliceMoving":
                        indText = "SIRENS";
                        if (L_IndicatorText[0].text == "")
                        {
                            L_IndicatorText[0].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[0].text != "" && !isAdded)
                        {
                            L_IndicatorText[1].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "AmbulanceMoving":
                        indText = "SIRENS";
                        if (L_IndicatorText[0].text == "")
                        {
                            L_IndicatorText[0].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[0].text != "" && !isAdded)
                        {
                            L_IndicatorText[1].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "StartMan":
                        indText = "Person Talking";
                        if (L_IndicatorText[4].text == "")
                        {
                            L_IndicatorText[4].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[4].text != "" && !isAdded)
                        {
                            L_IndicatorText[5].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "CrimeWoman":
                        indText = "Person Talking";
                        if (L_IndicatorText[4].text == "")
                        {
                            L_IndicatorText[4].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[4].text != "" && !isAdded)
                        {
                            L_IndicatorText[5].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "Man":
                        indText = "Person Talking";
                        if (L_IndicatorText[4].text == "")
                        {
                            L_IndicatorText[4].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[4].text != "" && !isAdded)
                        {
                            L_IndicatorText[5].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "LorryCargo":
                        indText = "Engine Noises";
                        if (L_IndicatorText[2].text == "")
                        {
                            L_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[2].text != "" && !isAdded)
                        {
                            L_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "Police":
                        indText = "Engine Noises";
                        if (L_IndicatorText[2].text == "")
                        {
                            L_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[2].text != "" && !isAdded)
                        {
                            L_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "Minivan":
                        indText = "Engine Noises";
                        if (L_IndicatorText[2].text == "")
                        {
                            L_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[2].text != "" && !isAdded)
                        {
                            L_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;

                    case "Ambulance":
                        indText = "Engine Noises";
                        if (L_IndicatorText[2].text == "")
                        {
                            L_IndicatorText[2].text = indText;
                            isAdded = true;
                        }
                        else if (L_IndicatorText[2].text != "" && !isAdded)
                        {
                            L_IndicatorText[3].text = indText;
                            isAdded = true;
                        }
                        break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Capsule")
        {

            //indicator texts based on collider
            //Right side
            string name = this.gameObject.name;
            switch (name)
            {
                case "LorryMoving":
                    indText = "Incoming Vehicle";
                    if (R_IndicatorText[2].text != "")
                    {
                        R_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        R_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "MinivanMoving":
                    indText = "Incoming Vehicle";
                    if (R_IndicatorText[2].text != "")
                    {
                        R_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        R_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "MuscleMoving":
                    indText = "Incoming Vehicle";
                    if (R_IndicatorText[2].text != "")
                    {
                        R_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        R_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "PoliceMoving":
                    indText = "SIRENS";
                    if (R_IndicatorText[0].text != "")
                    {
                        R_IndicatorText[0].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[1].text != "")
                    {
                        R_IndicatorText[1].text = "";
                        isAdded = false;
                    }
                    break;

                case "AmbulanceMoving":
                    indText = "SIRENS";
                    if (R_IndicatorText[0].text != "")
                    {
                        R_IndicatorText[0].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[1].text != "")
                    {
                        R_IndicatorText[1].text = "";
                        isAdded = false;
                    }
                    break;

                case "StartMan":
                    indText = "Person Talking";
                    if (R_IndicatorText[4].text != "")
                    {
                        R_IndicatorText[4].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[5].text != "")
                    {
                        R_IndicatorText[5].text = "";
                        isAdded = false;
                    }
                    break;

                case "CrimeWoman":
                    indText = "Person Talking";
                    if (R_IndicatorText[4].text != "")
                    {
                        R_IndicatorText[4].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[5].text != "")
                    {
                        R_IndicatorText[5].text = "";
                        isAdded = false;
                    }
                    break;

                case "Man":
                    indText = "Person Talking";
                    if (R_IndicatorText[4].text != "")
                    {
                        R_IndicatorText[4].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[5].text != "")
                    {
                        R_IndicatorText[5].text = "";
                        isAdded = false;
                    }
                    break;

                case "LorryCargo":
                    indText = "Engine Noises";
                    if (R_IndicatorText[2].text != "")
                    {
                        R_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        R_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "Police":
                    indText = "Engine Noises";
                    if (R_IndicatorText[2].text != "")
                    {
                        R_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        R_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "Minivan":
                    indText = "Engine Noises";
                    if (R_IndicatorText[2].text != "")
                    {
                        R_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        R_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "Ambulance":
                    indText = "Engine Noises";
                    if (R_IndicatorText[2].text != "")
                    {
                        R_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        R_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;
            }

            //Left side
            switch (name)
            {
                case "LorryMoving":
                    indText = "Incoming Vehicle";
                    if (L_IndicatorText[2].text != "")
                    {
                        L_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[3].text != "")
                    {
                        L_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "MinivanMoving":
                    indText = "Incoming Vehicle";
                    if (L_IndicatorText[2].text != "")
                    {
                        L_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[3].text != "")
                    {
                        L_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "MuscleMoving":
                    indText = "Incoming Vehicle";
                    if (L_IndicatorText[2].text != "")
                    {
                        L_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[3].text != "")
                    {
                        L_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "PoliceMoving":
                    indText = "SIRENS";
                    if (L_IndicatorText[0].text != "")
                    {
                        L_IndicatorText[0].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[1].text != "")
                    {
                        L_IndicatorText[1].text = "";
                        isAdded = false;
                    }
                    break;

                case "AmbulanceMoving":
                    indText = "SIRENS";
                    if (L_IndicatorText[0].text != "")
                    {
                        L_IndicatorText[0].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[1].text != "")
                    {
                        L_IndicatorText[1].text = "";
                        isAdded = false;
                    }
                    break;

                case "StartMan":
                    indText = "Person Talking";
                    if (L_IndicatorText[4].text != "")
                    {
                        L_IndicatorText[4].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[5].text != "")
                    {
                        L_IndicatorText[5].text = "";
                        isAdded = false;
                    }
                    break;

                case "CrimeWoman":
                    indText = "Person Talking";
                    if (L_IndicatorText[4].text != "")
                    {
                        L_IndicatorText[4].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[5].text != "")
                    {
                        L_IndicatorText[5].text = "";
                        isAdded = false;
                    }
                    break;

                case "Man":
                    indText = "Person Talking";
                    if (L_IndicatorText[4].text != "")
                    {
                        L_IndicatorText[4].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[5].text != "")
                    {
                        L_IndicatorText[5].text = "";
                        isAdded = false;
                    }
                    break;

                case "LorryCargo":
                    indText = "Engine Noises";
                    if (L_IndicatorText[2].text != "")
                    {
                        L_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[3].text != "")
                    {
                        L_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "Police":
                    indText = "Engine Noises";
                    if (L_IndicatorText[2].text != "")
                    {
                        L_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[3].text != "")
                    {
                        L_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "Minivan":
                    indText = "Engine Noises";
                    if (L_IndicatorText[2].text != "")
                    {
                        L_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[3].text != "")
                    {
                        L_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;

                case "Ambulance":
                    indText = "Engine Noises";
                    if (L_IndicatorText[2].text != "")
                    {
                        R_IndicatorText[2].text = "";
                        isAdded = false;
                    }
                    else if (L_IndicatorText[3].text != "")
                    {
                        L_IndicatorText[3].text = "";
                        isAdded = false;
                    }
                    break;
            }

        }
    }
}

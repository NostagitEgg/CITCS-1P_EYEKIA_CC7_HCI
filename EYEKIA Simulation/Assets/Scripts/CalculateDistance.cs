using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculateDistance : MonoBehaviour
{
    //For Modes
    Modes mode;

    private void Start()
    {
        mode = GameObject.FindObjectOfType<Modes>();
    }
    //Indicator variables
    public GameObject[] leftIndicators;
    public GameObject[] rightIndicators;
    public TextMeshProUGUI[] L_IndicatorText;
    public TextMeshProUGUI[] R_IndicatorText;
    public string indText;

    public GameObject[] gfx;

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

    Color tmp;
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
        if (other.name == "Capsule" && mode.isOn && !mode.isOff)
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
                        if (!mode.isFocused)
                        {
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
                        }
                        
                        break;

                    case "Police":
                        if (!mode.isFocused)
                        {
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
                        }
                        
                        break;

                    case "Minivan":
                        if (!mode.isFocused)
                        {
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
                        }
                       
                        break;

                    case "Ambulance":
                        if (!mode.isFocused)
                        {
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
                        if (!mode.isFocused)
                        {
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
                        }
                        
                        break;

                    case "Police":
                        if (!mode.isFocused)
                        {
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
                        }
                       
                        break;

                    case "Minivan":
                        if (!mode.isFocused)
                        {
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
                        }
                        
                        break;

                    case "Ambulance":
                        if (!mode.isFocused)
                        {
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
                        }
                        
                        break;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        foreach (GameObject image in gfx)
        {
            tmp = image.GetComponent<Image>().color;
            if (this.distance >= player.GetComponent<SphereCollider>().radius)
            {
                tmp.a = 0;
            }
            else if (this.distance < player.GetComponent<SphereCollider>().radius)
            {
                tmp.a = (player.GetComponent<SphereCollider>().radius / this.distance)/5;
            }
            else if ((this.distance / player.GetComponent<SphereCollider>().radius) <= 0.75f)
            {
                tmp.a = 1f;
            }
        }

        if (other.name == "Capsule" && mode.isOn && !mode.isOff)
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
                        gfx[16].GetComponent<Image>().color = tmp;
                        gfx[17].GetComponent<Image>().color = tmp;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        gfx[18].GetComponent<Image>().color = tmp;
                        gfx[19].GetComponent<Image>().color = tmp;
                    }
                    break;

                case "MinivanMoving":
                    indText = "Incoming Vehicle";
                    if (R_IndicatorText[2].text != "")
                    {
                        gfx[16].GetComponent<Image>().color = tmp;
                        gfx[17].GetComponent<Image>().color = tmp;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        gfx[18].GetComponent<Image>().color = tmp;
                        gfx[19].GetComponent<Image>().color = tmp;
                    }
                    break;

                case "MuscleMoving":
                    indText = "Incoming Vehicle";
                    if (R_IndicatorText[2].text != "")
                    {
                        gfx[16].GetComponent<Image>().color = tmp;
                        gfx[17].GetComponent<Image>().color = tmp;
                    }
                    else if (R_IndicatorText[3].text != "")
                    {
                        gfx[18].GetComponent<Image>().color = tmp;
                        gfx[19].GetComponent<Image>().color = tmp;
                    }
                    break;

                case "PoliceMoving":
                    indText = "SIRENS";
                    if (R_IndicatorText[0].text != "")
                    {
                        gfx[12].GetComponent<Image>().color = tmp;
                        gfx[13].GetComponent<Image>().color = tmp;
                    }
                    else if (R_IndicatorText[1].text != "")
                    {
                        gfx[14].GetComponent<Image>().color = tmp;
                        gfx[15].GetComponent<Image>().color = tmp;
                    }
                    break;

                case "AmbulanceMoving":
                    indText = "SIRENS";
                    if (R_IndicatorText[0].text != "")
                    {
                        gfx[12].GetComponent<Image>().color = tmp;
                        gfx[13].GetComponent<Image>().color = tmp;
                    }
                    else if (R_IndicatorText[1].text != "")
                    {
                        gfx[14].GetComponent<Image>().color = tmp;
                        gfx[15].GetComponent<Image>().color = tmp;
                    }
                    break;

                case "StartMan":
                    indText = "Person Talking";
                    if (R_IndicatorText[4].text != "")
                    {
                        gfx[20].GetComponent<Image>().color = tmp;
                        gfx[21].GetComponent<Image>().color = tmp;
                    }
                    else if (R_IndicatorText[5].text != "")
                    {
                        gfx[22].GetComponent<Image>().color = tmp;
                        gfx[23].GetComponent<Image>().color = tmp;
                    }
                    break;

                case "CrimeWoman":
                    indText = "Person Talking";
                    if (R_IndicatorText[4].text != "")
                    {
                        gfx[20].GetComponent<Image>().color = tmp;
                        gfx[21].GetComponent<Image>().color = tmp;
                    }
                    else if (R_IndicatorText[5].text != "")
                    {
                        gfx[22].GetComponent<Image>().color = tmp;
                        gfx[23].GetComponent<Image>().color = tmp;
                    }
                    break;

                case "Man":
                    indText = "Person Talking";
                    if (R_IndicatorText[4].text != "")
                    {
                        gfx[20].GetComponent<Image>().color = tmp;
                        gfx[21].GetComponent<Image>().color = tmp;
                    }
                    else if (R_IndicatorText[5].text != "")
                    {
                        gfx[22].GetComponent<Image>().color = tmp;
                        gfx[23].GetComponent<Image>().color = tmp;
                    }
                    break;

                case "LorryCargo":
                    if (!mode.isFocused)
                    {
                        indText = "Engine Noises";
                        if (R_IndicatorText[2].text != "")
                        {
                            gfx[16].GetComponent<Image>().color = tmp;
                            gfx[17].GetComponent<Image>().color = tmp;
                        }
                        else if (R_IndicatorText[3].text != "")
                        {
                            gfx[18].GetComponent<Image>().color = tmp;
                            gfx[19].GetComponent<Image>().color = tmp;
                        }
                    }
                    break;

                case "Police":
                    if (!mode.isFocused)
                    {
                        indText = "Engine Noises";
                        if (R_IndicatorText[2].text != "")
                        {
                            gfx[16].GetComponent<Image>().color = tmp;
                            gfx[17].GetComponent<Image>().color = tmp;
                        }
                        else if (R_IndicatorText[3].text != "")
                        {
                            gfx[18].GetComponent<Image>().color = tmp;
                            gfx[19].GetComponent<Image>().color = tmp;
                        }
                    }
                    break;

                case "Minivan":
                    if (!mode.isFocused)
                    {
                        indText = "Engine Noises";
                        if (R_IndicatorText[2].text != "")
                        {
                            gfx[16].GetComponent<Image>().color = tmp;
                            gfx[17].GetComponent<Image>().color = tmp;
                        }
                        else if (R_IndicatorText[3].text != "")
                        {
                            gfx[18].GetComponent<Image>().color = tmp;
                            gfx[19].GetComponent<Image>().color = tmp;
                        }
                    }
                    break;

                case "Ambulance":
                    if (!mode.isFocused)
                    {
                        indText = "Engine Noises";
                        if (R_IndicatorText[2].text != "")
                        {
                            gfx[16].GetComponent<Image>().color = tmp;
                            gfx[17].GetComponent<Image>().color = tmp;
                        }
                        else if (R_IndicatorText[3].text != "")
                        {
                            gfx[18].GetComponent<Image>().color = tmp;
                            gfx[19].GetComponent<Image>().color = tmp;
                        }
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
                        gfx[4].GetComponent<Image>().color = tmp;
                        gfx[5].GetComponent<Image>().color = tmp;
                    }
                     else if (L_IndicatorText[3].text != "")
                     {
                        gfx[6].GetComponent<Image>().color = tmp;
                        gfx[7].GetComponent<Image>().color = tmp;
                    }
                     break;

                 case "MinivanMoving":
                     indText = "Incoming Vehicle";
                     if (L_IndicatorText[2].text != "")
                     {
                        gfx[4].GetComponent<Image>().color = tmp;
                        gfx[5].GetComponent<Image>().color = tmp;
                    }
                     else if (L_IndicatorText[3].text != "")
                     {
                        gfx[6].GetComponent<Image>().color = tmp;
                        gfx[7].GetComponent<Image>().color = tmp;
                    }
                     break;

                 case "MuscleMoving":
                     indText = "Incoming Vehicle";
                     if (L_IndicatorText[2].text != "")
                     {
                        gfx[4].GetComponent<Image>().color = tmp;
                        gfx[5].GetComponent<Image>().color = tmp;
                    }
                     else if (L_IndicatorText[3].text != "")
                     {
                        gfx[6].GetComponent<Image>().color = tmp;
                        gfx[7].GetComponent<Image>().color = tmp;
                    }
                     break;

                 case "PoliceMoving":
                     indText = "SIRENS";
                     if (L_IndicatorText[0].text != "")
                     {
                        gfx[0].GetComponent<Image>().color = tmp;
                        gfx[1].GetComponent<Image>().color = tmp;
                    }
                     else if (L_IndicatorText[1].text != "")
                     {
                        gfx[2].GetComponent<Image>().color = tmp;
                        gfx[3].GetComponent<Image>().color = tmp;
                    }
                     break;

                 case "AmbulanceMoving":
                     indText = "SIRENS";
                     if (L_IndicatorText[0].text != "")
                     {
                        gfx[0].GetComponent<Image>().color = tmp;
                        gfx[1].GetComponent<Image>().color = tmp;
                    }
                     else if (L_IndicatorText[1].text != "")
                     {
                        gfx[2].GetComponent<Image>().color = tmp;
                        gfx[3].GetComponent<Image>().color = tmp;
                    }
                     break;

                 case "StartMan":
                     indText = "Person Talking";
                     if (L_IndicatorText[4].text != "")
                     {
                        gfx[8].GetComponent<Image>().color = tmp;
                        gfx[9].GetComponent<Image>().color = tmp;
                    }
                     else if (L_IndicatorText[5].text != "")
                     {
                        gfx[10].GetComponent<Image>().color = tmp;
                        gfx[11].GetComponent<Image>().color = tmp;
                    }
                     break;

                 case "CrimeWoman":
                     indText = "Person Talking";
                     if (L_IndicatorText[4].text != "")
                     {
                        gfx[8].GetComponent<Image>().color = tmp;
                        gfx[9].GetComponent<Image>().color = tmp;
                    }
                     else if (L_IndicatorText[5].text != "")
                     {
                        gfx[10].GetComponent<Image>().color = tmp;
                        gfx[11].GetComponent<Image>().color = tmp;
                    }
                     break;

                 case "Man":
                     indText = "Person Talking";
                     if (L_IndicatorText[4].text != "")
                     {
                        gfx[8].GetComponent<Image>().color = tmp;
                        gfx[9].GetComponent<Image>().color = tmp;
                    }
                     else if (L_IndicatorText[5].text != "")
                     {
                        gfx[10].GetComponent<Image>().color = tmp;
                        gfx[11].GetComponent<Image>().color = tmp;
                    }
                     break;

                 case "LorryCargo":
                     indText = "Engine Noises";
                    if (!mode.isFocused)
                    {
                        if (L_IndicatorText[2].text != "")
                        {
                            gfx[4].GetComponent<Image>().color = tmp;
                            gfx[5].GetComponent<Image>().color = tmp;
                        }
                        else if (L_IndicatorText[3].text != "")
                        {
                            gfx[6].GetComponent<Image>().color = tmp;
                            gfx[7].GetComponent<Image>().color = tmp;
                        }
                    }
                    
                     break;

                 case "Police":
                     indText = "Engine Noises";
                    if (!mode.isFocused)
                    {
                        if (L_IndicatorText[2].text != "")
                        {
                            gfx[4].GetComponent<Image>().color = tmp;
                            gfx[5].GetComponent<Image>().color = tmp;
                        }
                        else if (L_IndicatorText[3].text != "")
                        {
                            gfx[6].GetComponent<Image>().color = tmp;
                            gfx[7].GetComponent<Image>().color = tmp;
                        }
                    }
                    
                     break;

                 case "Minivan":
                     indText = "Engine Noises";
                    if (!mode.isFocused)
                    {
                        if (L_IndicatorText[2].text != "")
                        {
                            gfx[4].GetComponent<Image>().color = tmp;
                            gfx[5].GetComponent<Image>().color = tmp;
                        }
                        else if (L_IndicatorText[3].text != "")
                        {
                            gfx[6].GetComponent<Image>().color = tmp;
                            gfx[7].GetComponent<Image>().color = tmp;
                        }
                    }
                    
                     break;

                 case "Ambulance":
                     indText = "Engine Noises";
                    if (!mode.isFocused)
                    {
                        if (L_IndicatorText[2].text != "")
                        {
                            gfx[4].GetComponent<Image>().color = tmp;
                            gfx[5].GetComponent<Image>().color = tmp;
                        }
                        else if (L_IndicatorText[3].text != "")
                        {
                            gfx[6].GetComponent<Image>().color = tmp;
                            gfx[7].GetComponent<Image>().color = tmp;
                        }
                    }
                    
                     break;
             }

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.name == "Capsule" && mode.isOn && !mode.isOff)
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

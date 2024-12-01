using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modes : MonoBehaviour
{
    public Slider slider;
    public GameObject player;

    public bool isOn, isOff, isFocused;

    // Start is called before the first frame update
    void Start()
    {
        isOff = true;
        isOn = false;
        isFocused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slider.value = 0;
            Off();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slider.value = 1;
            On();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        { 
            slider.value = 2;
            Focused();
        }
    }

    public void Off()
    {
        isOff = true;
        isOn = false;
        isFocused = false;

        

    }
    public void On()
    {
        isOn = true;
        isOff = false;
        isFocused = false;
        player.GetComponent<SphereCollider>().radius = 20;

    }

    public void Focused()
    {
        isOn = true;
        isOff = false;
        isFocused = true;
        player.GetComponent<SphereCollider>().radius = 10;
    }
}

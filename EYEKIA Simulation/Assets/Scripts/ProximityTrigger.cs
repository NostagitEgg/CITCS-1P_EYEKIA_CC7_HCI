using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Text Test
        string name = other.name;
        switch (name)
        {
            case "StartMan":
                Debug.Log("What a beautiful day");
                break;
            case "LorryCargo":
                Debug.Log("Engine Noises");
                break;
            case "Police":
                Debug.Log("Engine Noises");
                break;
        }  
    }
}

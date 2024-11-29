using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerCam = camObject.GetComponent<Camera>();
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

        if (directionRelativeToCam.x > 0)
        {
            isRight = true;
            isLeft = false;
        }
        else
        {
            isRight = false;
            isLeft = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 lastPosition = new Vector3(0,0,0);

    void Start()
    {
        lastPosition = player.transform.position;    
    }
    // Update is called once per frame
    void Update()
    {
        //if (player.transform.position != lastPosition)
        //{
            
        //}
    }
}

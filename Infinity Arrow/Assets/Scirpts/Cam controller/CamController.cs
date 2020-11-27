using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject Player;

    Vector3 offSet;
    void Start()
    {
        offSet = this.transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0,  Player.transform.position.y + offSet.y,transform.position.z); 
    }
}

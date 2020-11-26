using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y - 17)
        {
            Destroy(this.gameObject);
        }
    }
}

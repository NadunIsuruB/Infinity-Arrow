using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class PlatformManager : MonoBehaviour
{
    public List<GameObject> Platforms;


    public static PlatformManager instanse;
    private void Awake()
    {
        if (instanse)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanse = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

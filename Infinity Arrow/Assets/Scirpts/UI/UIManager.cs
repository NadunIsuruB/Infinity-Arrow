using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(0);
    }
}

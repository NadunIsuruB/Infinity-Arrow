using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text score;
    public float Score;

    public static ScoreManager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Update()
    {
        Score += Time.deltaTime;

        score.text = Score.ToString("0");
    }
}

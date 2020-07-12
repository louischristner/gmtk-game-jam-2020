using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int value = 0;
    public Text scoreText;

    int maxScore;

    void Start()
    {
        maxScore = GameObject.FindGameObjectsWithTag("diamond").Length;
    }

    void Update()
    {
        scoreText.text = value.ToString() + " / " + maxScore.ToString();
    }
}

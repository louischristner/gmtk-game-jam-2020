using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int value = 0;
    public Text scoreText;

    void Update()
    {
        scoreText.text = value.ToString();
    }
}

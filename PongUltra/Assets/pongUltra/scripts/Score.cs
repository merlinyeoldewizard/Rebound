using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int scoreNumber;
    
    public void setScoreNumber(int value)
    {
        scoreNumber = value;
        scoreText.text = scoreNumber.ToString();
    }

    public void changeScore(int value)
    {
        scoreNumber += value;
        scoreText.text = scoreNumber.ToString();
    }
}
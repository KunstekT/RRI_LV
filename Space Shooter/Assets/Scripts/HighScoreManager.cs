using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    static int score = 0;

    void Start(){
        UpdateScoreText();
    }
    public void ResetScore(){
        score = 0;
    }

    public void UpdateScoreText(){
        scoreText.text = ""+score;
    }

    public void AddScore(int value){
        score+=value;
        UpdateScoreText();
    }
}

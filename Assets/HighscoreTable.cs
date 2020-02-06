using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HighscoreTable : MonoBehaviour
{
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI elapsedTime;

    private int score = 0, t;

    private static HighscoreTable _instance;

    public static HighscoreTable Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        highScore.text ="HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
        
    }

    private void Update()
    {
        totalScore.text = "SCORE: " + score.ToString();
        t = (int)Time.timeSinceLevelLoad;
        elapsedTime.text ="TIME: " + t.ToString();

        CalculateScore();
    }

    public void CalculateScore()
    {
        int finalScore = score * t;


        if (finalScore > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", finalScore);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}



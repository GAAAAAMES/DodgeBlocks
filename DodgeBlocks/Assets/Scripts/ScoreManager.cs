using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score = 0;
    public float highScore;
    public Text scoreLabel;
    public Text coinsLabel;
    public Text highScoreLabel;
    private float toIncreaseWith;


    // Start is called before the first frame update
    void Start()
    {
        toIncreaseWith = 0f;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreLabel.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        toIncreaseWith = Time.timeSinceLevelLoad / 1000;
        AddToScore();
    }

    void AddToScore()
    {
        if (Time.timeScale >= 1)
        {
            scoreLabel.text = "Score: " + (int)(Time.timeSinceLevelLoad + score);
            score += toIncreaseWith;
            if((int)(Time.timeSinceLevelLoad+score)>=highScore)
            {
                PlayerPrefs.SetInt("HighScore", (int)(score + Time.timeSinceLevelLoad));
                highScoreLabel.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
            }
        }
    }
}

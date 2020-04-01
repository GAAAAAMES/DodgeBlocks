using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private float score = 0;
    private Text scoreLabel;
    private float toIncreaseWith;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<Text>();
        toIncreaseWith = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        toIncreaseWith = Time.timeSinceLevelLoad / 1000;
        AddToScore();
    }

    void AddToScore()
    {
        scoreLabel.text = "Score: " + (int)(Time.timeSinceLevelLoad + score);
        score += toIncreaseWith;
    }
}

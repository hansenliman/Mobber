using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    int score = 0;

    //public void AddScore()
    //{
    //    score++;
    //}

    public void AddScore(int val)
    {
        score += val;
    }

    public void ShowScore()
    {
        scoreText.enabled = !scoreText.enabled;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Final Score: " + score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int rightScore;
    public int leftScore;

    public int maxScore;
    public BallController ball;


    public void AddRightScore (int increment)
    {
        rightScore += increment;
        ball.ResetBall();
        if (rightScore >= maxScore)
        {
            GameOver();
            Debug.Log("Created By : Galih Tyas A");
        }

    }

    public void AddLeftScore(int increment)
    {
        leftScore += increment;
        if (leftScore >= maxScore)
        {
            GameOver();
            Debug.Log("Created By : Galih Tyas A");
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
    }

}

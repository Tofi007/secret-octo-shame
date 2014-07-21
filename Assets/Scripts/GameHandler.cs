using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{

    public int tapDecreaser = 1;
    public float timeScoreMultiplier = 1.2f;
    private int score;
    private int highestScore;
    private float fractionalScore = 0.0f;
    public bool isGameOver;
    public GameObject restartButton;
    public ScoreLabelController scoreLabelController;
    
    void Start()
    {
        score = 0;
        highestScore = 0;
        fractionalScore = 0.0f;
        isGameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(1);
        }
        if (!isGameOver)
        {
            fractionalScore += timeScoreMultiplier * Time.deltaTime;
            if(fractionalScore > 1.0f)
            {
                fractionalScore -= 1.0f;
                IncreaseScore(1);
            }
        }
    }

    /*
    void OnGUI()
    {
        GUI.Box(new Rect(200, 10, 500, 30), "Score:" + (int) score);
        //print((int)score);
        if (isGameOver)
        {
            GUI.Box(new Rect(200, 150, 100, 60), "Lose!!!!4");
            if (GUI.Button(new Rect(200, 180, 100, 60), "Restart"))
            {
                Application.LoadLevel(0);
            } 
        }
    }
    */

    public void DecreaseTaps()
    {
        if (!isGameOver)
        {
            score -= tapDecreaser;
        }
    }

    public void IncreaseScore(int num)
    {
        score += num;
        if(score > highestScore)
        {
            highestScore = score;
            if (score % 50 == 0)
            {
                scoreLabelController.Pulse(1.5f, 0.6f);
            } else if (score % 10 == 0)
            {
                scoreLabelController.Pulse(1.3f, 0.6f);
            }
        }
    }

    public void GameEnd()
    {
        isGameOver = true;
        restartButton.SetActive(true);
    }

    public int getScore()
    {
        return score;
    }

}

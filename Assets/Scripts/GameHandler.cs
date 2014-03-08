using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{

    public float tapDecreaser = 1f;
    public float timeScore = 1.2f;

    private float score;
    public bool isGameOver;
    
    void Start()
    {
        score = 0;
        isGameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!isGameOver)
        {
            score += timeScore * Time.deltaTime;
        }
    }
    
    void OnGUI()
    {
        GUI.Box(new Rect(200, 10, 500, 30), "Score:" + (int) score);
        print((int)score);
        if (isGameOver)
        {
            GUI.Box(new Rect(200, 150, 100, 60), "Lose!!!!4");
            if (GUI.Button(new Rect(200, 180, 100, 60), "Restart"))
            {
                Application.LoadLevel(0);
            } 
        }
    }

    public void DecreaseTaps()
    {
        if (!isGameOver)
        {
            score -= tapDecreaser;
        }
    }

    public void GameEnd()
    {
        isGameOver = true;
    }
}

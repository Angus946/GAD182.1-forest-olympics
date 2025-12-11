using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public int score;
    public bool GameOver;
    public Transform title;
    public Text scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GameOver = false;
        scoreboard.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == true)
        {
            title.localPosition = new Vector3(0f, 0f, 0f);
            GameOver = false;
        }
    }

    public void ScoreAdd()
    {
        score++;
        scoreboard.text = score.ToString();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }
}
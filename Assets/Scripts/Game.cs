using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    private int HighScore = 0;
    public int Score { get; set; } = 0;

    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI TimerUI;
    public GameObject startScreen;

    public AudioSource music;

    static Game instance = null;

    float timer = 90.0f;

    public enum eState
    {
        Title,
        StartGame,
        Game,
        GameOver
    }

    public eState State { get; set; } = eState.Title;

    private void Update()
    {
        switch (State)
        {
            case eState.Title:
                startScreen.SetActive(true);
                break;
            case eState.StartGame:
                startScreen.SetActive(false);
                Score = 0;
                timer = 90;
                State = eState.Game;
                music.Play();
                break;
            case eState.Game:
                timer -= Time.deltaTime;
                TimerUI.text = ((int)timer).ToString();
                if(timer <= 0)
                {
                    State = eState.GameOver;
                }
                break;
            case eState.GameOver:
                music.Stop();
                if(Score > HighScore)
                {
                    HighScore = Score;
                }
                break;
            default:
                break;
        }
    }
    
    private void Awake()
    {
        instance = this;
    }

    public static Game Instance
    {
        get
        {
            return instance;
        }
    }

    public void AddPoints(int points)
    {
        Score += points;
        ScoreUI.text = Score.ToString();
    }

    public void StartGame()
    {
        State = eState.StartGame;
    }
}

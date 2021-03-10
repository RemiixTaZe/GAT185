using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    private int HighScore = 0;
    public int Score { get; set; } = 0;
    float score;

    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI HighScoreUI;
    public TextMeshProUGUI TimerUI;
    public Character character;
    public Slider slider;

    static Game instance = null;

    public bool usesTimer = true;
    public float timer = 90.0f;
    float etimer = 90.0f;

    public enum eState
    {
        Title,
        StartGame,
        Game,
        GameOver
    }

    public eState State { get; set; } = eState.StartGame;

    private void Update()
    {
        switch (State)
        {
            case eState.Title:
                break;
            case eState.StartGame:
                GameController.Instance.transition.StartTransition(Color.clear, 1);
                Score = 0;
                if(usesTimer)
                {
                    etimer = timer;
                }
                else
                {
                    character.health.health = character.health.healthMax;
                }
                character.animator.SetBool("Death", false);
                StartGame();
                break;
            case eState.Game:
                if(usesTimer)
                {
                    etimer -= Time.deltaTime;
                    TimerUI.text = ((int)etimer).ToString();
                    if(etimer <= 0)
                    {
                        GameOver();
                    }
                }
                else
                {
                    score += Time.deltaTime;
                    Score = (int)score;
                    ScoreUI.text = Score.ToString();

                    if(character.health.health <=0)
                    {
                        GameOver();
                    }
                }

                break;
            case eState.GameOver:
                if(Score > GameController.Instance.highscore)
                {
                    GameController.Instance.SetHighScore(Score);
                }
                character.transform.position.Set(character.spawn.x, character.spawn.y, character.spawn.z);
                GameController.Instance.OnLoadMenuScene("MainMenu");
                etimer = timer;
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
        HighScoreUI.text = HighScore.ToString();
    }

    public void GameOver()
    {
        State = eState.GameOver;
    }
}

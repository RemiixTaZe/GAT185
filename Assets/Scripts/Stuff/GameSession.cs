using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameSession : MonoBehaviour
{
    public int Score { get; set; } = 0;

    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI TimerUI;
    public GameObject startScreen;
    public Character character;
    public UnityEvent startSessionEvents;

    static GameSession instance = null;
    public static GameSession Instance
    {
        get
        {
            return instance;
        }
    }

    public float timer = 90.0f;

    public enum eState
    {
        StartSession,
        Session,
        EndSession,
        GameOver
    }

    public eState State { get; set; } = eState.StartSession;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
        switch (State)
        {
            case eState.StartSession:
                Score = 0;
                Debug.Log("Start Session");
                EventManager.Instance.TriggerEvent("StartSession");
                startSessionEvents?.Invoke();
                GameController.Instance.transition.StartTransition(Color.clear, 1);
                State = eState.Session;
                break;
            case eState.Session:
                break;
            case eState.GameOver:
                break;
            default:
                break;
        }
    }

    public void AddPoints(int points)
    {
        Score += points;
        ScoreUI.text = string.Format("{0:D4}", Score);
    }
}

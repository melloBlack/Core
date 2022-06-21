using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameStateHandler();
public delegate void LevelStateHandler();

public class EventManager : MonoBehaviour
{
    static EventManager _instance;
    public static EventManager Instance => _instance;

    public event GameStateHandler GamePlayHandler;
    public event GameStateHandler GameOverHandler;
    public event GameStateHandler GameFinishHandler;

    private void Awake()
    {
        Singleton();
    }

    void Singleton()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void TriggerPlayStage()
    {
        GamePlayHandler?.Invoke();
    }
    public void TriggerGameOverStage()
    {
        GameOverHandler?.Invoke();
    }
    public void TriggerFinishStage()
    {
        GameFinishHandler?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameStateHandler();
public delegate void LevelStateHandler();

public class EventManager : MonoSingleton<EventManager>
{
    public event GameStateHandler GamePlayHandler;
    public event GameStateHandler GameOverHandler;
    public event GameStateHandler GameFinishHandler;

    private void Awake()
    {
        Singleton(true);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IGameState
{
    static GameController _instance;

    public static GameController Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        Initiation();
    }
    private void OnDisable()
    {
        RemoveListeners();
    }

    #region Members

    PlayerController _playerController;
    public PlayerController PlayerController
    {
        get { return _playerController; }
        set { _playerController = value; }
    }

    CameraController _cameraController;
    public CameraController CameraController
    {
        get { return _cameraController; }
        set { _cameraController = value; }
    }

    UIController _uiController;
    public UIController UIController
    {
        set { _uiController = value; }
        get { return _uiController; }
    }

    #endregion

    #region EM Listeners Game States

    #region For Game States

    public void Play()
    {

    }

    public void GameOver()
    {

    }

    public void Finish()
    {

    }

    #endregion

    #endregion

    #region Unique Methods

    void Initiation()
    {
        AddListeners();
    }

    public void RemoveListeners()
    {
        EventManager.Instance.GamePlayHandler -= Play;
        EventManager.Instance.GameOverHandler -= GameOver;
        EventManager.Instance.GameFinishHandler -= Finish;
    }

    public void AddListeners()
    {
        EventManager.Instance.GamePlayHandler += Play;
        EventManager.Instance.GameOverHandler += GameOver;
        EventManager.Instance.GameFinishHandler += Finish;
    }

    #endregion
}

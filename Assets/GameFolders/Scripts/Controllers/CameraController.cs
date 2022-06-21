using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, IGameState
{
    #region Fields and Properties

    Transform _target = null;

    #endregion

    #region MonoBehaviour Methods

    private void Awake()
    {
        Initiation();
    }
    private void OnDisable()
    {
        RemoveListeners();
    }

    #endregion

    #region EM Listeners

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
        GameController.Instance.CameraController = this;
    }

    public void AddListeners()
    {
        EventManager.Instance.GamePlayHandler += Play;
        EventManager.Instance.GameOverHandler += GameOver;
        EventManager.Instance.GameFinishHandler += Finish;
    }

    public void RemoveListeners()
    {
        EventManager.Instance.GamePlayHandler -= Play;
        EventManager.Instance.GameOverHandler -= GameOver;
        EventManager.Instance.GameFinishHandler -= Finish;
    }

    public void Assign(Transform target)
    {
        _target = target;
    }

    #endregion
}

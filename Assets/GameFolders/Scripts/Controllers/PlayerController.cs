using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IGameState
{
    #region Fields an Properties

    [SerializeField] MovementData movementData;

    #endregion

    #region MonoBehaviour Methods

    private void Awake()
    {

    }
    private void Start()
    {
        Initiation();
    }
    private void OnDisable()
    {
        RemoveListeners();
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
        GameController.Instance.PlayerController = this;
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

    #endregion
}

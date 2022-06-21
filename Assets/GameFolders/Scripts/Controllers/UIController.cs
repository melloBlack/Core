using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;

public class UIController : MonoBehaviour, IGameState
{
    #region Fields and Properties

    [GUIColor(0f, 1f, 1f), Title("Panels")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject gameOverPanel;

    [GUIColor(0f, 1f, 1f), Title("Buttons")]
    [SerializeField] Button startButton;
    [SerializeField] Button tryAgainButton;
    [SerializeField] Button nextLevelButton;

    [GUIColor(0f, 1f, 1f), Title("Joystick Input")]
    [SerializeField] DynamicJoystick joystick;

    #endregion

    #region MonoBehaviour Methods

    private void Start()
    {
        Initiation();
    }
    private void OnDisable()
    {
        RemoveListeners();
    }

    #endregion

    #region Event Listeners

    #region For Game States

    public void Play()
    {
        startPanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void Finish()
    {
        startPanel.SetActive(false);
        victoryPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        startPanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    #endregion

    #region For Level States

    public void StackState()
    {

    }

    public void CinematicState()
    {

    }

    #endregion

    #region For Buttons
    void StartGame()
    {
        GameManager.Instance.GameState = Enums.GameState.Play;
    }

    void TryAgain()
    {
        GameManager.Instance.RestartLevel();
    }

    void NextLevel()
    {
        GameManager.Instance.NextLevel();
    }

    #endregion

    #endregion

    #region Unique Methods

    void Initiation()
    {
        AddListeners();

        startButton.onClick.AddListener(StartGame);
        tryAgainButton.onClick.AddListener(TryAgain);
        nextLevelButton.onClick.AddListener(NextLevel);

        startPanel.SetActive(true);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        GameController.Instance.UIController = this;
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

    public float Horizontal()
    {
        return joystick.Horizontal;
    }

    public float Vertical()
    {
        return joystick.Vertical;
    }

    public Vector2 Direction()
    {
        return joystick.Direction;
    }

    #endregion
}

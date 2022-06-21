using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    #region Game State

    Enums.GameState _gameState = Enums.GameState.Pause;

    public Enums.GameState GameState
    {
        get { return _gameState; }
        set 
        { 
            _gameState = value;
            switch (_gameState)
            {
                case Enums.GameState.Pause:
                    break;
                case Enums.GameState.Play:
                    EventManager.Instance.TriggerPlayStage();
                    break;
                case Enums.GameState.Over:
                    EventManager.Instance.TriggerGameOverStage();
                    break;
                case Enums.GameState.Finish:
                    Level++;
                    EventManager.Instance.TriggerFinishStage();
                    break;
                default:
                    break;
            }
        }
    }

    public bool Playability() 
    { 
        return _gameState == Enums.GameState.Play; 
    }

    #endregion

    [GUIColor(0f, 1f, 1f), Title("Level System")]
    [SerializeField] int levelCount;
    [GUIColor(0f, 1f, 1f)]
    [SerializeField] int randomLevelLowerLimit;

    public int Level
    {
        get
        {
            if (PlayerPrefs.GetInt(Constants.Prefs.LEVEL) == 0)
            {
                PlayerPrefs.SetInt(Constants.Prefs.LEVEL, 1);
                return PlayerPrefs.GetInt(Constants.Prefs.LEVEL);
            }
            else if (PlayerPrefs.GetInt(Constants.Prefs.LEVEL) > levelCount)
            {
                return Random.Range(randomLevelLowerLimit, levelCount);
            }
            else
            {
                return PlayerPrefs.GetInt(Constants.Prefs.LEVEL);
            }
        }
        set { PlayerPrefs.SetInt(Constants.Prefs.LEVEL, value); }
    }

    public int Gold
    {
        get
        {
            return PlayerPrefs.GetInt(Constants.Prefs.GOLD);
        }
        set
        {
            PlayerPrefs.SetInt(Constants.Prefs.GOLD, value);
        }
    }

    private void Awake()
    {
        Singleton();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            NextLevel();
        }
    }

    void Singleton()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void RestartLevel()
    {
        _gameState = Enums.GameState.Pause;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        _gameState = Enums.GameState.Pause;
        SceneManager.LoadScene(Level);
    }
}

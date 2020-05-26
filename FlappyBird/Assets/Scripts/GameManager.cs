using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    Spawner spawner;

    public int Score { get; set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        PlayerController.Instance.DisablePlayerControl();
    }

    public void StartGame()
    {
        PlayerController.Instance.EnablePlayerControl();
        spawner.gameObject.SetActive(true);
        GameEvents.OnGameStartButtonPressedFunction();
    }

    public void GameOver()
    {
        spawner.StopSpawnCoroutines();
        spawner.gameObject.SetActive(false);
        SaveBestScore();
        GameEvents.OnGameOveredFunction();
    }

    public void SaveBestScore()
    {
        if (Score > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", Score);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

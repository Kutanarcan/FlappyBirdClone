using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    [SerializeField]
    Canvas startGameCanvas;
    [SerializeField]
    Canvas gameOverCanvas;
    [SerializeField]
    Canvas inGameCanvas;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text bestScoreText;

    void Awake()
    {
        GameEvents.OnGameOvered += Gameover;
        UIEvents.OnScoreChanged += UpdateScoreText;
        bestScoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
        startGameCanvas.enabled = false;
        inGameCanvas.enabled = true;
    }

    public void Gameover()

    {
        gameOverCanvas.enabled = true;
        inGameCanvas.enabled = false;
    }

    public void GameoverButton()
    {
        GameManager.Instance.Restart();
    }

    void OnDestroy()
    {
        GameEvents.OnGameOvered -= Gameover;
        UIEvents.OnScoreChanged -= UpdateScoreText;
    }

    public void UpdateScoreText()
    {
        scoreText.text = GameManager.Instance.Score.ToString();
    }
}

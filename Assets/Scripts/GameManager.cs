using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;    
    public TextMeshProUGUI hiscoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1;
        player.enabled = true;
        UpdateHiScore();

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        player. enabled = false;
        playButton.SetActive(true);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(false);
        UpdateHiScore();

        Pause();
    }

    public void IncreaseScore() 
    { 
        score++; 
        scoreText.text = score.ToString();
    }
    private void UpdateHiScore()
    {
        int hiScore = PlayerPrefs.GetInt("hiScore", 0);
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt("hiScore", hiScore);
        }
        hiscoreText.text = hiScore.ToString();
    }


}

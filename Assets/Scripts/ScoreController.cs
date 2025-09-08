using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    private int score;
    private int HighScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        UpdateHighScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void EnemyDeath()
    {
        score += 100;
        UpdateScore();
        CheckHighScore();
    }

    private void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScore();
        }
    }

    void UpdateHighScore()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}

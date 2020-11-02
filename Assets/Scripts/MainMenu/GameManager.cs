using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Text scoreText, scoreGameover, scorePausePanel, countBallText;
    private int score;
    private int countBall;

    [SerializeField] private GameObject m_gameOverPanel;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }



    void Start()
    {
        score = 0;
        countBall = 10;
        UpdateScore();
        
    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        scoreGameover.text = "" + score;
        scorePausePanel.text = "" +  score;
    }

    public void BallNumber()
    {

        countBall -= 1;
        UpdateCountBall();

        if (countBall == 0)
            countBall = 0;

    }


    void UpdateCountBall()
    {
        countBallText.text = "Ball: " + countBall;
    }

    public void ShowGameoverPanel()
    {

        if(countBall <= 0)
        {
            m_gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        m_gameOverPanel.SetActive(true);
        Time.timeScale = 0;

    }

} // class














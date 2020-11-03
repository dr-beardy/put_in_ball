using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Text scoreText, scoreGameover, scorePausePanel, countBallText;
    private int m_score;
    private int m_countBall;

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
        m_score = 0;
        m_countBall = 10;
        UpdateScore();
        
    }


    public void AddScore(int newScoreValue)
    {
        m_score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + m_score;
        scoreGameover.text = "" + m_score;
        scorePausePanel.text = "" +  m_score;
    }

    public void BallNumber()
    {

        m_countBall -= 1;
        UpdateCountBall();

        if (m_countBall == 0)
            m_countBall = 0;

    }


    void UpdateCountBall()
    {
        countBallText.text = "Ball: " + m_countBall;
    }

    public void ShowGameoverPanel()
    {

        if(m_countBall <= 0)
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














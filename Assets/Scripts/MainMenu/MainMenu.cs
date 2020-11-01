using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //public BallsCountDown countBall;
   // [SerializeField] private Text m_textScorePanel, m_score, m_gameOverScore;
    [SerializeField] private GameObject m_pausePanel;


    private void Start()
    {
        TextUpdate();
       
    }

    void Update()
    {
        /*if (countBall.ballNumber == 0)
        {
            Time.timeScale = 0;
            m_gameOverPanel.SetActive(true);
        }*/
    }

    public void PauseBtn()
    {
        Time.timeScale = 0;
        m_pausePanel.SetActive(true);
    }

    public void PlayBtn()
    {
        Time.timeScale = 1;
        m_pausePanel.SetActive(false);
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("GamePlay");

        Time.timeScale = 1;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    void TextUpdate()
    {
        
        //m_ballsText.text = "Ball: " + countBall.ballNumber.ToString();
       
    }


} // class
























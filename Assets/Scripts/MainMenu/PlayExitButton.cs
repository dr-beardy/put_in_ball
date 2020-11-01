using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayExitButton : MonoBehaviour
{
    
    public void PlayBtn()
    {
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1;
    }

    public void ExitBtn()
    {
        Application.Quit();
    }



} // class










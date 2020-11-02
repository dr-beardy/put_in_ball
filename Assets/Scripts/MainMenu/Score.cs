using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    private Text m_scoretext;
    private int m_scorePoint;

    private void Start()
    {
        m_scoretext = GameObject.Find("UIScore").GetComponent<Text>();
    }





    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Helper.BASKET_TAG)
        {
            m_scorePoint++;
            m_scoretext.text = "Score: " + m_scorePoint;
        }
    }



} // class






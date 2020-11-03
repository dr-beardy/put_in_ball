using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private SpriteRenderer sr;
    private int m_score;
    private Transform m_checkGoals;
    [SerializeField] LayerMask m_mask;

    private void Start()
    {
        m_checkGoals = GameObject.FindGameObjectWithTag("BallScore").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        m_score = 0;
        StartCoroutine(AddScore());
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        SoundsManager.PlaySounds("hitBall");

        if (target.gameObject.tag == Helper.GROUND_TAG)
        {
            
            StartCoroutine(DeactivateBall(0.5f));
        }

        if(target.gameObject.tag == Helper.PLAYER_TAG)
        {
            sr.material.color = Color.red;
            StartCoroutine(Wait());

        }

    }


    IEnumerator DeactivateBall(float d)
    {
        yield return new WaitForSeconds(d);
        gameObject.SetActive(false);

    }



    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Helper.PLAYER_TAG)
        {
            GameManager.Instance.GameOver();
        }

        if (target.tag == Helper.BASKET_TAG && Physics2D.Raycast(m_checkGoals.position, Vector2.up, 0.1f, m_mask))
        {
            m_score = 1;
        }
        else
        {
            m_score = 0;
        }

    }

    IEnumerator AddScore()
    {
        if(m_score == 1)
        {
            GameManager.Instance.AddScore(m_score);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(AddScore());
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.7f);
        GetComponent<BoxCollider2D>().enabled = true;
    }


} // class




















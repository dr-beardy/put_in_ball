using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private Animator m_anim;
    [SerializeField] private Transform m_ballCheck, m_ballExit;
    [SerializeField] private LayerMask m_mask;
    private int m_score;

    void Awake()
    {
        m_anim = GetComponent<Animator>();
    }

    private void Start()
    {
        m_anim.SetBool("Ball_in", false);
        m_score = 0;

    }

    private void Update()
    {
        if (Physics2D.Raycast(m_ballCheck.position, Vector2.up, 0.1f, m_mask))
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (Physics2D.Raycast(m_ballExit.position, Vector2.down, 0.1f, m_mask))
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Helper.BALL_TAG)
        {

            m_anim.SetBool("Ball_in", true);
            m_score++;
            GameManager.Instance.AddScore(m_score);
            SoundsManager.PlaySounds("basket");

        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == Helper.BALL_TAG)
        {
            m_anim.SetBool("Ball_in", false);
        }
    }


} // class


















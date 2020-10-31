using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private Animator m_anim;
    [SerializeField] private Transform m_ballCheck;
    [SerializeField] private LayerMask m_mask;

    void Awake()
    {
        m_anim = GetComponent<Animator>();
    }

    private void Start()
    {
        m_anim.SetBool("Ball_in", false);
    }

    private void Update()
    {
        if (Physics2D.Raycast(m_ballCheck.position, Vector2.up, 0.1f, m_mask))
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Helper.BALL_TAG)
        {
            m_anim.SetBool("Ball_in", true);
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


















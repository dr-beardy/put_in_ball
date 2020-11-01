using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private float m_speed = 6f;
    private float m_jumpForce = 10f;

    [SerializeField] Transform m_groundCheck, m_ballcheck;
    [SerializeField] LayerMask m_mask;

    private Animator m_anim;
    private Rigidbody2D m_body;

    private bool isGrounded, isJumped, isStart;

    Ball ball;

    private void Awake()
    {
        m_body = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }

    void Start()
    {
        isStart = true;
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(m_groundCheck.position, Vector2.down, 0.1f, m_mask);

        if (isGrounded)
        {
            isJumped = true;
            if (isJumped)
            {
                Jump();
            }

        }

        Move();

    }

    void Move()
    {
        if (isStart)
        {
            float h = Input.GetAxisRaw("Horizontal");

            if(h > 0)
            {
                m_body.velocity = new Vector2(m_speed, m_body.velocity.y);
                m_anim.SetFloat("Run", 1);
            }
            else if(h < 0)
            {
                m_body.velocity = new Vector2(-m_speed, m_body.velocity.y);
                m_anim.SetFloat("Run", 1);
            }
            else
            {
                m_body.velocity = new Vector2(0, m_body.velocity.y);
                m_anim.SetFloat("Run", -1);
            }
            
        }

    }

    void Jump()
    {
        if (isJumped)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_body.velocity = new Vector2(m_body.velocity.x, m_jumpForce);
                m_anim.SetBool("Jump", true);
                isJumped = false;
            }
            else
            {
                m_anim.SetBool("Jump", false);
            }
        }

    }



} // class
























using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public SpriteRenderer sr;
    public static bool deadBall = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
            //deadBall = true;
            StartCoroutine(Wait());

        }

    }

    IEnumerator DeactivateBall(float d)
    {
        yield return new WaitForSeconds(d);
        gameObject.SetActive(false);

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.7f);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Helper.PLAYER_TAG)
        {
            GameManager.Instance.GameOver();
        }
    }


} // class




















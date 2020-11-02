using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstObj : MonoBehaviour
{

    private int m_numberOfBalls = 10;
    private int m_count = 0;

    [SerializeField] GameObject m_object;

    private float m_position;
    
    void Start()
    {

        StartCoroutine(InstantiatObjects());

    }


    IEnumerator InstantiatObjects()
    {
       

        m_position = Random.Range(0f, 4.5f);
        Vector3 tempPosition = new Vector3(m_position, 10f, 0);

        Instantiate(m_object, tempPosition, Quaternion.identity);

        yield return new WaitForSeconds(4f);
        GameManager.Instance.BallNumber();

        m_count++;
          

        if (m_count == m_numberOfBalls)
        {
            StopCoroutine(InstantiatObjects());
            yield return new WaitForSeconds(2f);
            GameManager.Instance.ShowGameoverPanel();
        }
        else
        {
            StartCoroutine(InstantiatObjects());
        }


    }




} // class



























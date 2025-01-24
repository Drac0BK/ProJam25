using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    MyPlayer m_myPlayer;
    public bool canTurnOff = false;
    float m_Y = 100;
    public float loopTimer = 1;
    float timer = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MyPlayer>() != null)
        {
            m_myPlayer = other.gameObject.GetComponent<MyPlayer>();
            m_myPlayer.StartCoroutine("capturedPlayer");
        }
    }

    private void Start()
    {
        timer = loopTimer;
    }

    private void FixedUpdate()
    {
        if (canTurnOff)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer < 0)
            {
                timer = loopTimer;
                transform.position += new Vector3(0, m_Y, 0);
                m_Y = m_Y * -1;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    float timer = 10;

    public GameObject canvas;
    bool setActive = false;
    public void setCanvas(bool m_b)   
    {
        canvas.SetActive(m_b);
        setActive = m_b;
        timer = 10;
    }

    private void Update()
    {
        if (setActive)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
        if (timer < 0)
        {
            timer = 10;
            setCanvas(false);
        }
    }
}

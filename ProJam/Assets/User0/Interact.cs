using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    float timer = 1;

    public GameObject canvas;
    bool setActive = false;
    bool hasInteracted = false;
    public void setCanvas(bool m_b)   
    {
        if (!hasInteracted)
        {
            if (setActive == false)
            {
                canvas.SetActive(true);
                setActive = true;
                hasInteracted = true;
            }
            else if (setActive == true)
            {
                canvas.SetActive(false);
                setActive = false;
                hasInteracted = true;
            }
            timer = 1;
        }
    }

    private void Update()
    {
        if (hasInteracted)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
        if (timer < 0)
        {
            timer = 1;
            hasInteracted = false;
            //setCanvas(false);
        }
    }
}

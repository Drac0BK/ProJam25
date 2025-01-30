using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerUp : MonoBehaviour
{
    public bool trojan = true;
    public bool phish = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MyPlayer>() != null)
        {
            if(trojan)
            other.gameObject.GetComponent<MyPlayer>().powerUpGot(0);
            else if (phish)
                other.gameObject.GetComponent<MyPlayer>().powerUpGot(1);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, 0.5f, 0);
    }
}

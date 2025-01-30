using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject nextStop;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MyPlayer>() != null)
        {
            other.transform.position = nextStop.transform.position;   
        }
    }
}

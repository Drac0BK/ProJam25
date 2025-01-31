using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<MyPlayer>().StartCoroutine("capturedPlayer");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MyPlayer>().StartCoroutine("capturedPlayer");
        }
    }
}

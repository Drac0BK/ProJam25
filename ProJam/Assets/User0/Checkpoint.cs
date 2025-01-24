using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    MyPlayer m_myPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MyPlayer>() != null)
        {
            m_myPlayer = other.gameObject.GetComponent<MyPlayer>();
            m_myPlayer.SetCheckpoint(gameObject);
        }
    }
}

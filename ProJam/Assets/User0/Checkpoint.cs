using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isCheckpoint;
    public bool isEndpoint;


    MyPlayer m_myPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if(isCheckpoint)
            if (other.gameObject.GetComponent<MyPlayer>() != null)
            {
                m_myPlayer = other.gameObject.GetComponent<MyPlayer>();
                m_myPlayer.SetCheckpoint(gameObject);
            }

        if(isEndpoint)
            if (other.gameObject.GetComponent<MyPlayer>() != null)
            {
                    Debug.Log("End Scene");
            }
    }
}

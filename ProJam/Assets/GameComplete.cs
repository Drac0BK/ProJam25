using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete : MonoBehaviour
{
    public GameObject player;
    public GameObject endPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MyPlayer>() != null)
        {
            player.gameObject.SetActive(false);
            endPlayer.gameObject.SetActive(true);
        }
    }
}

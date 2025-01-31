using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public GameObject player;
    public GameObject endPlayer;
    public GameObject canvasEnd;
    public TextMeshProUGUI text;
    float timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MyPlayer>() != null)
        {
            timer = other.gameObject.GetComponent<MyPlayer>().SetIsPlaying(false);
            player.gameObject.SetActive(false);
            endPlayer.gameObject.SetActive(true);
            canvasEnd.gameObject.SetActive(true);
            int time = (int)timer;
            text.text = time.ToString() + " Seconds";
        }
    }

    public void restartScene()
    {
        SceneManager.LoadScene(0);
    }
}

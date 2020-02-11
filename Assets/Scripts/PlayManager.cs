using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public Timer timer;
    private List<CoinPickup> Coins = new List<CoinPickup>();
    // Start is called before the first frame update
    void Start()
    {
        Coins.AddRange(FindObjectsOfType<CoinPickup>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Cancel") == 1)
        {
            SceneManager.LoadScene("Menu");
        }

        Coins.RemoveAll(x => x == null);
        if (Coins.Count == 0)
        {//We have collected all the coins
            timer.Stop();
        }
    }
}

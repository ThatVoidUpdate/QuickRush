using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Coins.RemoveAll(x => x == null);
        if (Coins.Count == 0)
        {//We have collected all the coins
            timer.Stop();
        }
    }
}

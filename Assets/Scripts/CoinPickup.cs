using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour, IPickup
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetType() == typeof(CompositeCollider2D))
        {
            col.GetComponent<Player>().coinCounter.Coins++;
            col.GetComponent<Player>().coinCounter.UpdateText();
            Destroy(gameObject);
        }
    }
}

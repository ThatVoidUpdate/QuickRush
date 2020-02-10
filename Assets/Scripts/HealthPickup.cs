using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour, IPickup
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetType() == typeof(CompositeCollider2D))
        {
            col.GetComponent<Player>().Health += col.GetComponent<Player>().Health < col.GetComponent<Player>().MaxHealth ? 1 : 0;
            col.GetComponent<Player>().healthBar.UpdateBar();
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

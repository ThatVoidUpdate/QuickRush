using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetType() == typeof(CompositeCollider2D))
        {
            StartCoroutine(col.GetComponent<Player>().Die());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    public float Health;
    public bool CanMove;
    public Vector2 Movement;
    public float AttackDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            transform.position += (Vector3)Movement * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetType() == typeof(CompositeCollider2D))
        {
            col.GetComponent<Player>().DoDamage(AttackDamage);
        }

    }
}

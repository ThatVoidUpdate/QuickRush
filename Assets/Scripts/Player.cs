using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    [Space]
    public Collider2D TerrainCollider;

    private Rigidbody2D rb;
    private BoxCollider2D collider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal") * Speed, 0));
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = rb.velocity.y + Time.deltaTime * -9.81f;
        if (Input.GetAxis("Jump") == 1 && collider.IsTouching(TerrainCollider))
        {
            VerticalMovement = JumpForce;
        }
        rb.velocity = new Vector2(HorizontalMovement * Speed * Time.deltaTime, VerticalMovement);

    }
}

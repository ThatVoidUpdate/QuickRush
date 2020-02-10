using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    [Space]
    public Collider2D TerrainCollider;
    [Header("Graphics")]
    public Sprite StandardSprite;
    public Sprite Movingsprite;

    [Space]
    public float MaxHealth;
    private float Health;
    public HealthBar healthBar;

    private Rigidbody2D rb;
    private new BoxCollider2D collider;
    private new SpriteRenderer renderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        Health = MaxHealth;
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
        rb.velocity = new Vector2(HorizontalMovement * Speed, VerticalMovement);
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            renderer.sprite = Movingsprite;

            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            renderer.sprite = StandardSprite;
        }
    }

    public float GetHealth()
    {
        return Health;
    }

    public void DoDamage(float Damage)
    {
        Health -= Damage;
        healthBar.UpdateBar();
        if (Health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Blegh");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

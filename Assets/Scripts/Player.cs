using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    [Space]
    public TilemapCollider2D collision;

    [Header("Graphics")]
    public Sprite StandardSprite;
    public Sprite Movingsprite;
    public Sprite HurtSprite;

    [Space]
    public float MaxHealth;
    public float Health;
    public HealthBar healthBar;

    [Space]
    public CoinCounter coinCounter;

    [Space]
    public Animator ScreenBlackout;

    private Rigidbody2D rb;
    private new CompositeCollider2D collider;
    private new SpriteRenderer renderer;

    private bool CanChangeSprite = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CompositeCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        Health = MaxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal") * Speed, 0));
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = rb.velocity.y + Time.deltaTime * -9.81f;
        if (Input.GetAxis("Jump") == 1 && collider.IsTouching(collision))
        {
            VerticalMovement = JumpForce;
        }
        rb.velocity = new Vector2(HorizontalMovement * Speed, VerticalMovement);
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (CanChangeSprite)
            {
                renderer.sprite = Movingsprite;
            }            

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
            if (CanChangeSprite)
            {
                renderer.sprite = StandardSprite;
            }            
        }
    }

    public void DoDamage(float Damage)
    {
        StartCoroutine(DoHurtGraphics());
        Health -= Damage;
        healthBar.UpdateBar();
        if (Health <= 0)
        {
            StartCoroutine(Die());
        }
    }
    public IEnumerator Die()
    {
        ScreenBlackout.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        ScreenBlackout.SetTrigger("Die");
    }

    IEnumerator DoHurtGraphics()
    {
        InvokeRepeating("FlipVisible", 0.0f, 0.1f);
        renderer.sprite = HurtSprite;
        renderer.color = Color.red;
        CanChangeSprite = false;
        yield return new WaitForSeconds(0.5f);
        renderer.sprite = StandardSprite;
        renderer.color = Color.white;
        CanChangeSprite = true;
        renderer.enabled = true;
        CancelInvoke();
    }

    private void FlipVisible()
    {
        renderer.enabled = !renderer.enabled;
    }
}
//#7582 ♥

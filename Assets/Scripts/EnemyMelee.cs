using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    public int damage;

    private Transform player;
    private Animator anim;
    private Rigidbody2D rb;
    private float deathTimer;
    private bool isDead = false;
    [SerializeField] private GameObject xpDrop;
    [SerializeField] private GameObject splat;
    private SpriteRenderer sprite;
    private float splatTimer = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        if (transform.position.x > 38 || transform.position.x < -38 || transform.position.y > 28 || transform.position.y < -28) Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2((transform.position.x - player.position.x) * moveSpeed, (transform.position.y - player.position.y) * moveSpeed).normalized;
        if (!isDead) rb.velocity = -velocity;
        else if (isDead && deathTimer >= 1) Destroy(gameObject);
        if (isDead) deathTimer += Time.deltaTime;

        splatTimer += Time.deltaTime;
        if (splat != null && splatTimer >= 0.3f && !isDead)
        {
            Instantiate(splat, new Vector2(transform.position.x, transform.position.y - 0.15f), Quaternion.Euler(0, 0, Random.Range(-360f, 360f)));
            splatTimer = 0;
        }

        //Color update
        sprite.color = new Color(1, sprite.color.g + Time.deltaTime, sprite.color.g + Time.deltaTime);

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player") && !isDead) other.gameObject.GetComponent<PlayerMovement>().GetDamage(damage);
        else if (other.transform.CompareTag("Obstacle")) Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
    }

    public void GetDamage(float dmg)
    {
        health -= dmg;
        sprite.color = new Color(1, 0, 0);
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            if (!isDead) Instantiate(xpDrop, transform.position, Quaternion.identity);
            Destroy(GetComponent<Collider2D>());
            isDead = true;
        }
    }
}

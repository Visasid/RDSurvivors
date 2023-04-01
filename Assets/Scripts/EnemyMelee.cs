using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public int damage;

    private Transform player;
    private Animator anim;
    private Rigidbody2D rb;
    private float deathTimer;
    private bool isDead = false;
    [SerializeField] private GameObject xpDrop;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2((transform.position.x - player.position.x) * moveSpeed, (transform.position.y - player.position.y) * moveSpeed).normalized;
        if (!isDead) rb.velocity = -velocity;
        else if (isDead && deathTimer >= 1) Destroy(gameObject);
        if (isDead) deathTimer += Time.deltaTime;

        //Color update
        sprite.color = new Color(1, sprite.color.g + Time.deltaTime, sprite.color.g + Time.deltaTime);

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player") && !isDead) other.gameObject.GetComponent<PlayerMovement>().GetDamage(damage);
    }

    public void GetDamage(int dmg)
    {
        health -= dmg;
        sprite.color = new Color(1, 0, 0);
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            if (!isDead) Instantiate(xpDrop, transform.position, Quaternion.identity);
            isDead = true;
        }
    }
}

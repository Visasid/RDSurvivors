using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public int damage;

    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2((transform.position.x - player.position.x) * moveSpeed, (transform.position.y - player.position.y) * moveSpeed).normalized;

        rb.velocity = -velocity;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player")) other.gameObject.GetComponent<PlayerMovement>().GetDamage(damage);
    }

    public void GetDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0) Destroy(gameObject);
    }
}

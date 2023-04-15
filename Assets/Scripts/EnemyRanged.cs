using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public float hp;
    public int damage;
    public float moveSpeed;

    [SerializeField] private GameObject bullet;
    private Transform player;
    private Rigidbody2D rb;
    private bool isLookingRight = false;
    private SpriteRenderer sprite;
    private float angle;
    [SerializeField] private GameObject xpDrop;

    //ShootTimers
    private float shootCD = 1.5f;
    private float shootTimer = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 velocity = new Vector2((transform.position.x - player.position.x) * moveSpeed, (transform.position.y - player.position.y) * moveSpeed).normalized;
        rb.velocity = -velocity;
        if (rb.velocity.x > 0 && !isLookingRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isLookingRight = true;
        }
        else if (rb.velocity.x < 0 && isLookingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isLookingRight = false;
        }

        //Shooting
        Vector3 direction = player.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootCD)
        {
            shootTimer = 0;
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle)).GetComponent<BulletEnemy>().damage = damage;
        }

        //Color update
        sprite.color = new Color(1, sprite.color.g + Time.deltaTime, sprite.color.g + Time.deltaTime);
    }

    public void GetDamage(float dmg)
    {
        hp -= dmg;
        sprite.color = new Color(1, 0, 0);
        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(xpDrop, transform.position, Quaternion.identity);
        }
        }
}

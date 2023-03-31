using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public int health;
    public int maxHealth;

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private float invulnerabilityT = 0;

    //UI
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text healthTxt;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(x * speed, y * speed);
        if (x != 0 || y != 0) anim.SetBool("isWalking", true);
        else anim.SetBool("isWalking", false);

        //Invulnerability after damage
        invulnerabilityT -= Time.deltaTime;

        //UI updates
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        healthTxt.text = health.ToString() + "/" + maxHealth.ToString();
    }

    public void GetDamage(int dmg)
    {
        if (invulnerabilityT <= 0)
        {
            health -= dmg;
            if (health <= 0) Destroy(gameObject);
            anim.SetTrigger("Damaged");

            invulnerabilityT = 1;
        }
    }
}

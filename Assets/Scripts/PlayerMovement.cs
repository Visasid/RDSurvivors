using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public float xp;
    public float pickupRange;
    [SerializeField] private float maxXp;
    [SerializeField] private int level = 0;

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private float invulnerabilityT = 0;

    //UI
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text healthTxt;
    [SerializeField] private Slider xpBar;
    [SerializeField] private TMP_Text levelTxt;

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
        xpBar.value = xp;
        xpBar.maxValue = maxXp;
        levelTxt.text = level.ToString();

        //Level update
        if (xp >= maxXp)
        {
            xp = 0;
            maxXp *= 1.5f;
            level++;
            GetUpgrade();
        }
    }

    public void GetUpgrade()
    {

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

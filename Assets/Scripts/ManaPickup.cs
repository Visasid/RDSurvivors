using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    private Transform player;
    private float speed = 2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        speed += Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().xp += 1;
            Destroy(gameObject);
        }    
    }
}

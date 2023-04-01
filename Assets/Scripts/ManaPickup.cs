using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    private Transform player;
    private float speed = 2;
    private bool isPicking = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (isPicking) speed += Time.deltaTime;
        if (player.GetComponent<PlayerMovement>().pickupRange >= Vector3.Distance(transform.position, player.position) || isPicking)
        {
            isPicking = true;
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
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

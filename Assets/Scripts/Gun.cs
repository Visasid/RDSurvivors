using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int damage;
    [SerializeField] private float shotCD;
    [SerializeField] private Transform shotPoint;

    public float ammo;
    private float shotTimer = 100;

    private void Start()
    {
        ammo = maxAmmo;
    }

    private void Update()
    {
        //Timers
        shotTimer += Time.deltaTime;

        //Script
        if (Input.GetMouseButton(0) && shotTimer >= shotCD && ammo > 0)
        {
            shotTimer = 0;
            Bullet bul = Instantiate(bullet, shotPoint.position, shotPoint.rotation).GetComponent<Bullet>();
            bul.damage = damage;
            ammo -= 1;
        }
    }
}

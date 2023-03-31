using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public int maxAmmo;
    public int damage;
    public float shotCD;
    public float reloadTime;
    [SerializeField] private Transform shotPoint;

    public float ammo;
    private float shotTimer = 100;
    private float reloadTimer = 0;
    private bool isReloading = false;

    [SerializeField] private TMP_Text ammoText;

    private void Start()
    {
        ammo = maxAmmo;
    }

    private void Update()
    {
        //Timers
        shotTimer += Time.deltaTime;
        if (isReloading) reloadTimer += Time.deltaTime;
        if (reloadTimer >= reloadTime)
        {
            reloadTimer = 0;
            isReloading = false;
            ammo = maxAmmo;
        }

        //Script
        if (Input.GetMouseButton(0) && shotTimer >= shotCD && ammo > 0 && !isReloading)
        {
            shotTimer = 0;
            Bullet bul = Instantiate(bullet, shotPoint.position, shotPoint.rotation).GetComponent<Bullet>();
            bul.damage = damage;
            ammo -= 1;
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading && ammo != maxAmmo) isReloading = true;

        //UI
        ammoText.text = ammo.ToString() + "/" + maxAmmo.ToString();
    }
}

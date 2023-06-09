using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public int maxAmmo;
    public float damage;
    public float shotCD;
    public float reloadTime;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private AudioClip sound;
    [SerializeField] private GameObject soundSource;

    public float ammo;
    private float shotTimer = 100;
    private float reloadTimer = 0;
    private bool isReloading = false;

    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private Slider reloadBar;

    private void Start()
    {
        ammo = maxAmmo;
    }

    private void Update()
    {
        //Timers
        shotTimer += Time.deltaTime;
        if (isReloading)
        {
            reloadTimer += Time.deltaTime;
            reloadBar.maxValue = reloadTime;
            reloadBar.value = reloadTimer;
        }
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
            AudioSource source = Instantiate(soundSource, transform.position, Quaternion.identity).GetComponent<AudioSource>();
            source.clip = sound;
            source.Play();
            bul.damage = damage;
            ammo -= 1;
        }
        else if (!isReloading && ammo == 0) isReloading = true;

        if (Input.GetKeyDown(KeyCode.R) && !isReloading && ammo != maxAmmo) isReloading = true;

        //UI
        ammoText.text = ammo.ToString() + "/" + maxAmmo.ToString();

        if (isReloading) reloadBar.gameObject.SetActive(true);
        else reloadBar.gameObject.SetActive(false);
    }
}

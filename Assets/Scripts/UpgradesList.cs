using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesList : MonoBehaviour
{
    private PlayerMovement player;
    private Gun gun;
    private int[] upgrade = new int[3];

    //UI
    [SerializeField] private GameObject upgradeList;
    [SerializeField] private Image[] upImgs;
    [SerializeField] private TMP_Text[] upNames;
    [SerializeField] private TMP_Text[] upDescs;
    [SerializeField] private Sprite[] images;

    private int upgradesCount = 5;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        Transform x = transform.Find("HandUp").transform.Find("HandDown");
        for (int i = 0; i < x.childCount; i++)
        {
            if (x.GetChild(i).gameObject.activeInHierarchy)
            {
                gun = x.GetChild(i).GetComponent<Gun>();
                break;
            }
        }
    }

    public void SetUpgrades()
    {
        upgrade[0] = Random.Range(1, upgradesCount);
        while (true)
        {
            int x = Random.Range(1, upgradesCount);
            if (upgrade[0] != x)
            {
                upgrade[1] = x;
                break;
            }
        }
        while (true)
        {
            int x = Random.Range(1, upgradesCount);
            if (upgrade[0] != x && upgrade[1] != x)
            {
                upgrade[2] = x;
                break;
            }
        }
        ListUpdate();
        Time.timeScale = 0;
    }

    //1 - Enchanced Automatics: +15% shot speed
    //2 - Iron Skin: +10% health
    //3 - Extended Mag: +2 max ammo
    //4 - Expansive Bullets: +10% damage
    //5 - Fast Hands: +10% reload speed
    private void ListUpdate()
    {
        for (int i = 0; i < 3; i++)
        {
            if (upgrade[i] == 1)
            {
                upNames[i].text = "Enchanced Automatics";
                upDescs[i].text = "+15% shot speed";
                upImgs[i].sprite = images[i];
            }
            else if (upgrade[i] == 2)
            {
                upNames[i].text = "Iron Skin";
                upDescs[i].text = "+10% health";
                upImgs[i].sprite = images[i];
            }
            else if (upgrade[i] == 3)
            {
                upNames[i].text = "Extended Mag";
                upDescs[i].text = "+2 max ammo";
                upImgs[i].sprite = images[i];
            }
            else if (upgrade[i] == 4)
            {
                upNames[i].text = "Expansive Bullets";
                upDescs[i].text = "+25% damage";
                upImgs[i].sprite = images[i];
            }
            else if (upgrade[i] == 5)
            {
                upNames[i].text = "Fast Hands";
                upDescs[i].text = "+10% reload speed";
                upImgs[i].sprite = images[i];
            }
        }
        upgradeList.SetActive(true);
    }

    public void SelectUpgrade(int grade)
    {
        if (upgrade[grade - 1] == 1) gun.shotCD -= gun.shotCD * 0.15f;
        else if (upgrade[grade - 1] == 2)
        {
            player.maxHealth += (int)(player.maxHealth * 0.1f);
            player.health += (int)(player.maxHealth * 0.1f);
        }
        else if (upgrade[grade - 1] == 3) gun.maxAmmo += 2;
        else if (upgrade[grade - 1] == 4) gun.damage += gun.damage * 0.25f;
        else if (upgrade[grade - 1] == 5) gun.reloadTime -= gun.reloadTime * 0.1f;
        upgradeList.SetActive(false);
        Time.timeScale = 1;
    }
}

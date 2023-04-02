using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
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
        for (int i = 1; i < upgradesCount; i++)
        {
            if (upgrade[0] != i)
            {
                upgrade[1] = i;
                break;
            }
        }
        for (int i = 1; i < upgradesCount; i++)
        {
            if (upgrade[0] != i && upgrade[1] != i)
            {
                upgrade[2] = i;
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
                upDescs[i].text = "+10% damage";
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

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingBar : MonoBehaviour
{
    public Image barImage;

    public float time;
    public float currentCoins;

    public float power;
    public float level;
    public float cost;

    public TextMeshProUGUI coinsTxt;
    public TextMeshProUGUI variableTxt;


    public void Start()
    {
        currentCoins = 0;

        power = 1;
        level = 1;
        cost = 10;
    }


    public void Update()
    {
        if (time < 1)
        {
            time += Time.deltaTime;
            barImage.fillAmount = time;
        }
        else
        {
            time = 0;
            currentCoins += power;
            Debug.Log(power);
        }

        coinsTxt.text = "Coins: " + currentCoins.ToString("G3");
        variableTxt.text = "Power: " + power.ToString("G3") + "\nLevel: " + level + "\nCost: " + cost.ToString("G3");
    }


    public void UpgradeBtn()
    {
        Debug.Log(cost);
        if (currentCoins >= cost)
        {
            currentCoins -= cost;

            level++;
            power *= 1.07f;
            cost *= 1.07f;
        }
    }
}

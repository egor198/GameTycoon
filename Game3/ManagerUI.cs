using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUI: MonoBehaviour
{
    public GameObject menuBild;
    public GameObject menuLevel;
    public GameObject[] bilds;
    public static Vector3 posSpawn;
    public static GameObject objDes;
    public static BildMoney currenBild;
    public int[] priceBild;
    public int[] priceLevel;
    public TextMeshProUGUI textMoney;
    private CurrencyManager currencyManager;
    private Currency goldCurrency;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        goldCurrency = currencyManager.GetCurrency("Gold");
        goldCurrency.amount = 50;
    }

    private void Update()
    {
        textMoney.text = $"Монет:{goldCurrency.amount}";
    }

    public void buttonBild(int a)
    {
        if(goldCurrency.amount >= priceBild[a])
        {
            Destroy(objDes);
            GameObject bild = Instantiate(bilds[a], posSpawn, Quaternion.identity);
            goldCurrency.SubtractAmount(priceBild[a]);
            menuLevel.SetActive(true);
            menuLevel.transform.position = menuBild.transform.position;
            menuBild.SetActive(false);
        }
    }
    public void buttoClos()
    {
        menuBild.SetActive(false);
    }
    public void buttoClosLevel()
    {
        menuLevel.SetActive(false);
    }

    public void bildLevelUp(int a)
    {
        if(a == 0 && goldCurrency.amount >= priceLevel[0] && currenBild.intervalMoney >= 0.5)
        {
            currenBild.intervalMoney -= 0.3f;
            goldCurrency.SubtractAmount(priceLevel[0]);
        }
        if(a == 1 && goldCurrency.amount >= priceLevel[1])
        {
            currenBild.countMoneyTime += 5;
            goldCurrency.SubtractAmount(priceLevel[1]);
        }
    }
}

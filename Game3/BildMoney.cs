using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildMoney: MonoBehaviour
{
    public float countMoneyTime;
    public float intervalMoney;
    private float timer;
    public GameObject menuBildMoney;
    public GameObject textEffect;
    private CurrencyManager currencyManager;
    private Currency goldCurrency;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        goldCurrency = currencyManager.GetCurrency("Gold");

        timer = intervalMoney;
        menuBildMoney = GameObject.Find("Menu");
        if (menuBildMoney != null)
        {
            menuBildMoney.SetActive(false);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            goldCurrency.AddAmount(countMoneyTime);
            timer = intervalMoney;
            textEffect.GetComponent<TextMesh>().text = countMoneyTime.ToString();
            GameObject eff = Instantiate(textEffect, transform);
            Destroy(eff, 1);
        }
    }

    private void OnMouseDown()
    {
        menuBildMoney.SetActive(true);
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        menuBildMoney.transform.position = new Vector3(position.x, position.y + 75, position.z);
        ManagerUI.currenBild = gameObject.GetComponent<BildMoney>();
    }
}

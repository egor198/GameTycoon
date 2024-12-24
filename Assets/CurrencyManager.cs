using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public Currency[] currencies;
    public Image currencyIconPrefab;

    private void Start()
    {
        ShowCurrencyIcons();
    }

    private void Update()
    {
        foreach (Currency currency in currencies)
        {
            currency.amoutText = Mathf.Round(currency.amount);
        }
    }

    public void ShowCurrencyIcons()
    {
        foreach (Currency currency in currencies)
        {
            currency.amoutText = Mathf.Round(currency.amount);
            currencyIconPrefab.sprite = currency.currencyIcon;
        }
    }
    public Currency GetCurrency(int id)
    {
        foreach (var currency in currencies)
        {
            if (currency.id == id)
            {
                return currency;
            }
        }
        return null; // Если валюта не найдена
    }

    public bool amoutEnough(float value, int idCurrecny)
    {
        return currencies[idCurrecny].amount >= value; 
    }
}
using System.Collections;
using System.Collections.Generic;
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

    public void ShowCurrencyIcons()
    {
        float offsetY = 0;

        foreach (Currency currency in currencies)
        {
            /*Image newIcon = Instantiate(currencyIconPrefab, transform);
            newIcon.sprite = currency.currencyIcon;
            newIcon.rectTransform.anchoredPosition = new Vector2(0, offsetY);*/

            currencyIconPrefab.sprite = currency.currencyIcon;
            offsetY -= 50; // Сдвиг для следующей иконки
        }
    }
    public Currency GetCurrency(string name)
    {
        foreach (var currency in currencies)
        {
            if (currency.currencyName == name)
            {
                return currency;
            }
        }
        return null; // Если валюта не найдена
    }
}
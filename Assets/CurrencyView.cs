using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    public TextMeshProUGUI textCurrency;
    private CurrencyManager currencyManager;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    public void UpdateView()
    {
        textCurrency.text = $"Монет:{currencyManager.GetCurrency(0).amoutText}";
    }
}

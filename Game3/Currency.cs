using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Currency", menuName = "Currency")]
public class Currency : ScriptableObject
{
    public string currencyName;
    public float amount; // Сумма валюты
    public Sprite currencyIcon;

    public void AddAmount(float value)
    {
        amount += value;
    }

    public void SubtractAmount(float value)
    {
        amount -= value;

    }
}
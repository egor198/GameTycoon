using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Currency", menuName = "Currency")]
public class Currency : ScriptableObject
{
    public string currencyName;
    public float amount; // ����� ������
    public Sprite currencyIcon;
    public int id;
    public float amoutText;

    public void AddAmount(float value)
    {
        amount += value;
    }

    public void SubtractAmount(float value)
    {
        amount -= value;
    }
}
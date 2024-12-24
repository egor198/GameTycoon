using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildMoney: MonoBehaviour
{
    public float countMoneyTime; // ���������� �����, ������� �����������
    public float intervalMoney; // �������� ���������� �����
    private float timer; // ������ ��� ������������ ���������

    public GameObject menuBildMoney; // ���� ��� ����������� 
    public GameObject textEffect; // ������ ������ ��� ����������� �����

    private CurrencyManager currencyManager; // ������ �� CurrencyManager
    private Currency goldCurrency; // ������ �� ������ ������ 
    // ваыпрваороы
    // dfjghdhgf

    public int level;

    private void Start()
    {
        InitializeComponents();
        SetupMenu();
    }

    private void Update()
    {
        HandleMoneyAccumulation();
    }

    private void OnMouseDown()
    {
        ShowMoneyMenu();
    }

    // ������������� �����������
    private void InitializeComponents()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        goldCurrency = currencyManager.GetCurrency(0);
        timer = intervalMoney; // ������������� �������
    }

    // ��������� ����
    private void SetupMenu()
    {
        menuBildMoney = GameObject.Find("Menu");
        if (menuBildMoney != null)
        {
            menuBildMoney.SetActive(false); // �������� ���� ��� ������
        }
    }

    // ��������� ���������� �����
    private void HandleMoneyAccumulation()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            goldCurrency.AddAmount(countMoneyTime); // ��������� ����� � ������
            timer = intervalMoney; // ���������� ������

            // ���������� ������ ������
            DisplayTextEffect();
        }
    }

    // ����������� ������� ������
    private void DisplayTextEffect()
    {
        textEffect.GetComponent<TextMesh>().text = countMoneyTime.ToString();
        GameObject effectInstance = Instantiate(textEffect, transform);
        Destroy(effectInstance, 1); // ���������� ������ ����� 1 �������
    }

    // ����� ���� ��� ������
    private void ShowMoneyMenu()
    {
        menuBildMoney.SetActive(true);
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        menuBildMoney.transform.position = new Vector3(position.x, position.y + 75, position.z);
        ManagerUI.currenBild = gameObject.GetComponent<BildMoney>();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUI: MonoBehaviour
{
    // ������� ����
    public GameObject menuBild;
    public GameObject menuLevel;

    // ������� ��� ��������
    public GameObject[] bilds;
    public static Vector3 posSpawn; // ������� ������ ��������
    public static GameObject objDes; // ������ ��� �����������
    public static BildMoney currenBild; // ������� ������ BildMoney

    // ���� �� �������
    public int[] priceBild;
    public int[] priceLevel;

    // UI ��������
    public TextMeshProUGUI textMoney;

    private CurrencyManager currencyManager; // �������� �����
    private Currency goldCurrency; // ������ ������
    private CurrencyView view;

    private void Start()
    {
        InitializeCurrency();
    }

    private void Update()
    {
        UpdateMoneyText();
    }

    // ������������� ������
    private void InitializeCurrency()
    {
        view = FindAnyObjectByType<CurrencyView>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        goldCurrency = currencyManager.GetCurrency(0);
        goldCurrency.amount = 50; // ��������� ���������� ������
    }

    // ���������� ������ � ����������� ������
    private void UpdateMoneyText()
    {
        view.UpdateView();
        
    }

    // ��������� ������� ������ ��� ������� Bild
    public void ButtonBild(int index)
    {
        if (CanAffordBild(index))
        {
            PurchaseBild(index);
        }
    }

    // ��������, ���������� �� ������ ��� ������������ Bild
    private bool CanAffordBild(int index)
    {
        return goldCurrency.amount >= priceBild[index];
    }

    // ������� ������� Bild
    private void PurchaseBild(int index)
    {
        Destroy(objDes);
        GameObject bild = Instantiate(bilds[index], posSpawn, Quaternion.identity);
        goldCurrency.SubtractAmount(priceBild[index]);
        ShowLevelMenu();
    }

    // ���������� ���� ������
    private void ShowLevelMenu()
    {
        menuLevel.SetActive(true);
        menuLevel.transform.position = menuBild.transform.position;
        menuBild.SetActive(false);
    }

    // ��������� ���� Bild
    public void ButtonClose()
    {
        menuBild.SetActive(false);
    }

    // ��������� ���� ������
    public void ButtonCloseLevel()
    {
        menuLevel.SetActive(false);
    }

    // ���������� ������ Bild
    public void BildLevelUp(int index)
    {
        if (index == 0 && currencyManager.amoutEnough(priceLevel[0], 0) && currenBild.intervalMoney >= 0.5)
        {
            UpgradeInterval();
        }
        else if (index == 1 && currencyManager.amoutEnough(priceLevel[1], 0))
        {
            UpgradeAmount();
        }
    }

    // ����������� �������� Bild
    private void UpgradeInterval()
    {
        currenBild.intervalMoney -= 0.3f;
        goldCurrency.SubtractAmount(priceLevel[0]);
    }

    // ����������� ���������� �����
    private void UpgradeAmount()
    {
        currenBild.countMoneyTime += 5;
        goldCurrency.SubtractAmount(priceLevel[1]);
    }
}

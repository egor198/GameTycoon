using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUI: MonoBehaviour
{
    // Объекты меню
    public GameObject menuBild;
    public GameObject menuLevel;

    // Объекты для создания
    public GameObject[] bilds;
    public static Vector3 posSpawn; // Позиция спавна объектов
    public static GameObject objDes; // Объект для уничтожения
    public static BildMoney currenBild; // Текущий объект BildMoney

    // Цены на объекты
    public int[] priceBild;
    public int[] priceLevel;

    // UI элементы
    public TextMeshProUGUI textMoney;

    private CurrencyManager currencyManager; // Менеджер валют
    private Currency goldCurrency; // Валюта золота
    private CurrencyView view;

    private void Start()
    {
        InitializeCurrency();
    }

    private void Update()
    {
        UpdateMoneyText();
    }

    // Инициализация валюты
    private void InitializeCurrency()
    {
        view = FindAnyObjectByType<CurrencyView>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        goldCurrency = currencyManager.GetCurrency(0);
        goldCurrency.amount = 50; // Начальное количество золота
    }

    // Обновление текста с количеством золота
    private void UpdateMoneyText()
    {
        view.UpdateView();
        
    }

    // Обработка нажатия кнопки для покупки Bild
    public void ButtonBild(int index)
    {
        if (CanAffordBild(index))
        {
            PurchaseBild(index);
        }
    }

    // Проверка, достаточно ли золота для приобретения Bild
    private bool CanAffordBild(int index)
    {
        return goldCurrency.amount >= priceBild[index];
    }

    // Процесс покупки Bild
    private void PurchaseBild(int index)
    {
        Destroy(objDes);
        GameObject bild = Instantiate(bilds[index], posSpawn, Quaternion.identity);
        goldCurrency.SubtractAmount(priceBild[index]);
        ShowLevelMenu();
    }

    // Показывает меню уровня
    private void ShowLevelMenu()
    {
        menuLevel.SetActive(true);
        menuLevel.transform.position = menuBild.transform.position;
        menuBild.SetActive(false);
    }

    // Закрывает меню Bild
    public void ButtonClose()
    {
        menuBild.SetActive(false);
    }

    // Закрывает меню уровня
    public void ButtonCloseLevel()
    {
        menuLevel.SetActive(false);
    }

    // Обновление уровня Bild
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

    // Увеличивает интервал Bild
    private void UpgradeInterval()
    {
        currenBild.intervalMoney -= 0.3f;
        goldCurrency.SubtractAmount(priceLevel[0]);
    }

    // Увеличивает количество денег
    private void UpgradeAmount()
    {
        currenBild.countMoneyTime += 5;
        goldCurrency.SubtractAmount(priceLevel[1]);
    }
}

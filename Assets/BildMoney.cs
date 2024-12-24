using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildMoney: MonoBehaviour
{
    public float countMoneyTime; // Количество денег, которое начисляется
    public float intervalMoney; // Интервал начисления денег
    private float timer; // Таймер для отслеживания интервала

    public GameObject menuBildMoney; // Меню для отображения 
    public GameObject textEffect; // Эффект текста для отображения суммы

    private CurrencyManager currencyManager; // Ссылка на CurrencyManager
    private Currency goldCurrency; // Ссылка на валюту золота

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

    // Инициализация компонентов
    private void InitializeComponents()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        goldCurrency = currencyManager.GetCurrency(0);
        timer = intervalMoney; // Инициализация таймера
    }

    // Настройка меню
    private void SetupMenu()
    {
        menuBildMoney = GameObject.Find("Menu");
        if (menuBildMoney != null)
        {
            menuBildMoney.SetActive(false); // Скрываем меню при старте
        }
    }

    // Обработка начисления денег
    private void HandleMoneyAccumulation()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            goldCurrency.AddAmount(countMoneyTime); // Добавляем сумму к валюте
            timer = intervalMoney; // Сбрасываем таймер

            // Отображаем эффект текста
            DisplayTextEffect();
        }
    }

    // Отображение эффекта текста
    private void DisplayTextEffect()
    {
        textEffect.GetComponent<TextMesh>().text = countMoneyTime.ToString();
        GameObject effectInstance = Instantiate(textEffect, transform);
        Destroy(effectInstance, 1); // Уничтожаем эффект через 1 секунду
    }

    // Показ меню для валюты
    private void ShowMoneyMenu()
    {
        menuBildMoney.SetActive(true);
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        menuBildMoney.transform.position = new Vector3(position.x, position.y + 75, position.z);
        ManagerUI.currenBild = gameObject.GetComponent<BildMoney>();
    }
}

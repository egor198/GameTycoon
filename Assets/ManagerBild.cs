using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBild: MonoBehaviour
{
    public GameObject menuBild; // Меню для отображения 
    public GameObject[] bilds; // Здания для стройки

    private void OnMouseDown()
    {
        ActiveMenu();
    }

    public void ActiveMenu()
    {
        menuBild.SetActive(true);
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        menuBild.transform.position = new Vector3(position.x, position.y + 75, position.z);
        ManagerUI.posSpawn = transform.position;
        ManagerUI.objDes = gameObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBild: MonoBehaviour
{
    public GameObject menuBild;
    public GameObject[] bilds;

    private void OnMouseDown()
    {
        menuBild.SetActive(true);
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        menuBild.transform.position = new Vector3(position.x, position.y + 75, position.z);
        ManagerUI.posSpawn = transform.position;
        ManagerUI.objDes = gameObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToShop : MonoBehaviour
{
    public GameObject BoxObject;
    private void Start()
    {
        ToInvent();
    }
    public void ToInvent()
    {
        BoxObject.SetActive(false);
    }
    public void ToBoxObj()
    {
        BoxObject.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToShop : MonoBehaviour
{
    public GameObject BoxObject;
    [SerializeField] private TextMeshProUGUI outputname, outputinfo;
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
        outputname.GetComponent<TextMeshProUGUI>().text = "";
        outputinfo.GetComponent<TextMeshProUGUI>().text = "";
        BoxObject.SetActive(true);
    }
}
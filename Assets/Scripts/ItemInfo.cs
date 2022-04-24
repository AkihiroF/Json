using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    public InventoryItems inventory;
    public int collvo;
    public Items iteminfo;

    private void Update()
    {
        this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventory.collitem[collvo].ToString();
        Debug.Log("Index = " + collvo);
    }
}

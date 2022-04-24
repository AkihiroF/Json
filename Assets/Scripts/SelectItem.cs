using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI outputname, outputinfo;
    [SerializeField] private Button openItem;
    [SerializeField] private CreateBox createbox;
    [SerializeField] private InventoryItems inventoryItems;
    [SerializeField] private SavingData save;
    public List<ItemInfo> itemInfos;
    [SerializeField] private BlackCock black;
    
    private void Start()
    {
        outputname.GetComponent<TextMeshProUGUI>().text = "";
        outputinfo.GetComponent<TextMeshProUGUI>().text = "";
    }
    public void SelectBoxItem(GameObject boxobj, Items iteminfo)
    {
        outputname.GetComponent<TextMeshProUGUI>().text = iteminfo.namebox;
        outputinfo.GetComponent<TextMeshProUGUI>().text = "Тип предмета "+iteminfo.typeitem;
        Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
        e.AddListener(() => this.Sell(iteminfo.price, boxobj));
        openItem.GetComponent<Button>().onClick = e;
    }
    public void Sell(int prise, GameObject obj)
    {
        if (Check(obj.GetComponent<ItemInfo>().iteminfo, obj))
        {
            createbox.Delete(obj);
            inventoryItems.itemininv.Remove(obj.GetComponent<ItemInfo>().iteminfo);
            inventoryItems.collitem.RemoveAt(obj.GetComponent<ItemInfo>().collvo);
            UpItem(itemInfos, obj.GetComponent<ItemInfo>().collvo);
            black.itemObj.Remove(obj);
        }
        Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
        openItem.GetComponent<Button>().onClick = e;
        Start();
        save.Remove(obj.GetComponent<ItemInfo>().iteminfo);
    }
    private bool Check(Items item, GameObject obj) 
    {
        for(int i = 0; i < inventoryItems.itemininv.Count; i++)
        {
            if(inventoryItems.itemininv[i] == item)
            {
                if(inventoryItems.collitem[i] > 1)
                {
                    inventoryItems.collitem[i] --;
                    obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventoryItems.collitem[i].ToString();
                    return false;
                }
            }
        }
        return true;

    }
    private void UpItem(List<ItemInfo> items, int index)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(i >= index)
            {
                items[i].collvo--;
            }
        }
    }
}

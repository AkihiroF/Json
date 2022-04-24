using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenBox : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform positionInBox;
    [SerializeField] private CreateBox createbox;
    [SerializeField] private SelectItem selectItem;
    public SelectBox sel;
    [SerializeField] private GameObject uvedomlenie;
    [SerializeField] public InventoryItems inventoryItems;
    [SerializeField] private BlackCock black;
    [SerializeField] private SavingData save;
    [SerializeField] private Back blackpanel;
    private float time = -1;
    public bool start;

    public void Open(BoxItem box, GameObject objbox)
    {
        var it = Random.Range(0, box.itemsInBox.Count);
        CreateItemInInventory(box.itemsInBox[it]);
        sel.Opened();
        createbox.Delete(objbox);
    }
    public void CreateItemInInventory(Items item)
    {
        if(item.typeitem == Items.TypeBox.Delete && start == false)
        {
            black.Dell(save);
            blackpanel.Close();
        }
        else if(ChekInventory(item) == false)
        {
            AddInInvent(item);
            if (start == false)
            {
                save.SaveData(item);
            }
        }
    }

    private bool ChekInventory(Items inputitem)
    {
        for(int i = 0; i < inventoryItems.itemininv.Count; i++)
        {
            if(inventoryItems.itemininv[i] == inputitem)
            {
                inventoryItems.collitem[i]++;
                uvedomlenie.GetComponent<TextMeshProUGUI>().text = $"Вы получили {inputitem.namebox}";
                time = 0.5f;
                sel.Start();
                if (start == false)
                {
                    save.SaveData(inputitem);
                }
                return true;
            }
        }
        return false;
    }

    public void AddInInvent(Items item)
    {
        Transform btn = Instantiate(itemPrefab, positionInBox).transform;
        btn.gameObject.SetActive(true);
        btn.GetComponent<Image>().sprite = item.icon;
        btn.transform.SetParent(positionInBox);
        btn.GetComponent<Button>().onClick.AddListener(() => selectItem.SelectBoxItem(btn.gameObject, item));
        selectItem.itemInfos.Add(btn.GetComponent<ItemInfo>());
        btn.GetComponent<ItemInfo>().iteminfo = item;
        btn.GetComponent<ItemInfo>().inventory = inventoryItems;
        btn.GetChild(0).GetComponent<TextMeshProUGUI>().text = btn.GetComponent<ItemInfo>().collvo.ToString();
        uvedomlenie.GetComponent<TextMeshProUGUI>().text = $"Вы получили {item.namebox}";
        time = 0.5f;
        sel.Start();
        inventoryItems.itemininv.Add(item);
        inventoryItems.collitem.Add(1);
        btn.GetComponent<ItemInfo>().collvo = inventoryItems.collitem.Count-1;
        black.itemObj.Add(btn.gameObject);
        Debug.Log(inventoryItems.collitem.Count - 1);
    }
    private void Update()
    {
        if(time >= 0)
        {
            uvedomlenie.SetActive(true);
            time -= Time.deltaTime;
        }
        else
        {
            uvedomlenie.SetActive(false);
        }
    }
}

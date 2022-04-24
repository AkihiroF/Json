using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCock : MonoBehaviour
{
    public InventoryItems inventory;
    public SelectItem selectitem;
    public List<GameObject> itemObj;

    public void Dell(SavingData save)
    {
        inventory.itemininv.Clear();
        inventory.collitem.Clear();
        for (int i = 0; i < itemObj.Count; i++)
        {
            Destroy(itemObj[i]);
        }
        itemObj.Clear();

        save.Dell();
    }
}

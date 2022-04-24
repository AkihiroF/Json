using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavingData : MonoBehaviour
{
    public string namebox;
    List<InputEmpty> empty = new List<InputEmpty>();
    [SerializeField] string filename;
    [SerializeField] private OpenBox create;

    private void Start()
    {
        if (File.Exists("/" + filename))
        {
            empty = JsonSave.ReadListFromJSON<InputEmpty>(filename);
            create.start = true;
            for (int i = 0; i < empty.Count; i++)
            {
                create.CreateItemInInventory(empty[i].item);
            }
            create.start = false;
        }
        else create.start = false;
    }
    public void SaveData(Items item)
    {
        empty.Add(new InputEmpty(item));
        JsonSave.SaveToJSON<InputEmpty>(empty, filename);
    }

    public void Remove(Items remit)
    {
        List<InputEmpty> newempty = new List<InputEmpty>();
        for (int i =0; i<empty.Count-1; i++)
        {
            if(empty[i].item == remit)
            {
                empty.Remove(empty[i]);
            }
            newempty.Add(empty[i]);
        }
        Dell();
        for(int i = 0; i < newempty.Count; i++)
        {
            SaveData(newempty[i].item);
        }

    }
    public void Dell()
    {
        empty = new List<InputEmpty>();
        JsonSave.SaveToJSON<InputEmpty>(empty, filename);
    }

}





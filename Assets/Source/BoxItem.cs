using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptObj/Boxs", fileName = "Box")]
public class BoxItem : ScriptableObject
{
    public Sprite icon;
    public int price;
    public string namebox;
    public string sizeitems;
    public enum TypeBox { Legendary , Medium , Shit}
    public List<Items> itemsInBox;
    public TypeBox typebox;
    [SerializeField]  List<Sprite> sprites;

    public void InputSprite()
    {
        List<int> items = new List<int>();
        int leg = 0;
        int med = 0;
        int loh = 0;
        for (int i = 0; i < itemsInBox.Count; i++)
        {
            switch (itemsInBox[i].typeitem)
            {
                case Items.TypeBox.Legendary:
                    leg++;
                    break;
                case Items.TypeBox.Medium:
                    med++;
                    break;
                case Items.TypeBox.Shit:
                    loh++;
                    break;
            }
        }
        items.Add(leg);
        items.Add(med);
        items.Add(loh);
        switch (typebox)
        {
            case TypeBox.Legendary:
                sizeitems = ExitItem(items);
                icon = sprites[0];
                break;
            case TypeBox.Medium:
                sizeitems = ExitItem(items);
                icon = sprites[1];
                break;
            case TypeBox.Shit:
                sizeitems = ExitItem(items);
                icon = sprites[2];
                break;
        }
    }
    private string ExitItem(List<int> list)
    {
        string infoitems = "";
        /*for (int i = 0; i < list.Count; i++)
        {
            infoitems += $"{list[i]}\n";
        }*/

        infoitems = $"Тип сундука: {typebox}\nШанс выподения предмета\nЛегендарный {list[0] * 10}%\nРедкий {list[1] * 10}%\nОбычный {list[2] * 10}%";
        return infoitems;
    }
}

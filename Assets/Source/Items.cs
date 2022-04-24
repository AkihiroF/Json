using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptObj/Items", fileName = "Item")]
public class Items : ScriptableObject
{
    public Sprite icon;
    public int price;
    public string namebox;
    public enum TypeBox { Legendary, Medium, Shit , Delete}
    public TypeBox typeitem;
}

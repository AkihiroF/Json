using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBox : MonoBehaviour
{
    public List<BoxItem> items;
    public SelectBox selectBox;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform positionInBox;
    [SerializeField] private SavingData save;
    public int sizebox, realsizebox;

    private void Awake()
    {
        CreateItems(sizebox);
    }
    private void Update()
    {
        if(realsizebox < sizebox)
        {
            CreateItems(sizebox - realsizebox);
        }
    }
    public void CreateItems(int size)
    {
        for (int i = 0; i < size; i++)
        {
            realsizebox++;
            var it = Random.Range(0, items.Count);
            items[it].InputSprite();
            Transform btn = Instantiate(itemPrefab, positionInBox).transform;
            btn.gameObject.SetActive(true);
            btn.GetComponent<Image>().sprite = items[it].icon;
            btn.transform.SetParent(positionInBox);
            btn.GetComponent<Button>().onClick.AddListener(() => selectBox.SelectBoxItem(items[it].namebox,items[it].sizeitems, items[it], btn.gameObject));
        }
    }
    public void Delete(GameObject obj)
    {
        Destroy(obj);
        realsizebox--;
    }
}

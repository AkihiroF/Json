using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI outputname, outputinfo;
    [SerializeField] private Button openButton;
    [SerializeField] public OpenBox openBox;

    public void Start()
    {
        outputname.GetComponent<TextMeshProUGUI>().text = "";
        outputinfo.GetComponent<TextMeshProUGUI>().text = "";
    }
    public void SelectBoxItem(string namebox, string infobox, BoxItem box, GameObject boxobj)
    {
        outputname.GetComponent<TextMeshProUGUI>().text = namebox;
        outputinfo.GetComponent<TextMeshProUGUI>().text = infobox;
        Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
        e.AddListener(() => openBox.Open(box, boxobj));
        openBox.GetComponent<Button>().onClick = e;
    }
    public void Opened()
    {
        Button.ButtonClickedEvent e = new Button.ButtonClickedEvent();
        openBox.GetComponent<Button>().onClick = e;
    }
}

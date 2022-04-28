using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool active;
    private void Start()
    {
        active = false;
        panel.SetActive(active);
    }

    public void Close()
    {
        active =! active;
        panel.SetActive(active);
    }
}

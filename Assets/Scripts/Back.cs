using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }

    public void Close()
    {
#pragma warning disable CS0618 // Тип или член устарел
        panel.SetActive(!panel.active);
#pragma warning restore CS0618 // Тип или член устарел
    }
}

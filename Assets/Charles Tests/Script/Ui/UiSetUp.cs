using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSetUp : MonoBehaviour
{
    [SerializeField] GameObject UI;
    bool activeUI = false;

    private void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        bool activeUI = false;
        UI.SetActive(activeUI);
    }

    public void UiActive()
    {
        activeUI = !activeUI;
        UI.SetActive(activeUI);
    }
}

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
        UI.SetActive(false);
    }

    public void UiActive()
    {
        if (!activeUI)
        {
            UI.SetActive(false);
            activeUI = true;
        }
        else
        {
            UI.SetActive(true);
            activeUI = false;
        }
    }
}

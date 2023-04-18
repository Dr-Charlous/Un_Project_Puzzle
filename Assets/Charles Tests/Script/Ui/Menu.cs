using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("LV1");
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}

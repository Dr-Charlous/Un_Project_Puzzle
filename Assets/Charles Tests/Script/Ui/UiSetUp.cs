using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSetUp : MonoBehaviour
{
    [SerializeField] GameObject Recipe;
    [SerializeField] GameObject Quest;
    [SerializeField] GameObject Pause;
    bool recipeUI = false;
    bool questUI = false;
    bool pauseUI = false;

    private void Awake()
    {
        Recipe = GameObject.FindGameObjectWithTag("Recipe");
        Quest = GameObject.FindGameObjectWithTag("Quest");
        Pause = GameObject.FindGameObjectWithTag("Pause");
        recipeUI = false;
        questUI = false;
        pauseUI = false;
        Recipe.SetActive(recipeUI);
        Quest.SetActive(questUI);
        Pause.SetActive(pauseUI);
    }

    public void RecipeAff()
    {
        recipeUI = !recipeUI;
        Recipe.SetActive(recipeUI);
        Debug.Log("Recipe");
    }

    public void QuestAff()
    {
        questUI = !questUI;
        Quest.SetActive(questUI);
        Debug.Log("Quest");
    }

    public void PauseAff()
    {
        pauseUI = !pauseUI;
        Pause.SetActive(pauseUI);
        Debug.Log("Pause");

        if (pauseUI == false)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0.2f;
    }
}

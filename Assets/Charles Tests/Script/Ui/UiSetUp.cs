using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSetUp : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Recipe;
    [SerializeField] GameObject Quest;
    [SerializeField] GameObject Pause;
    bool activeUI = false;
    bool recipeUI = false;
    bool questUI = false;
    bool pauseUI = false;

    private void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        Recipe = GameObject.FindGameObjectWithTag("Recipe");
        Quest = GameObject.FindGameObjectWithTag("Quest");
        Pause = GameObject.FindGameObjectWithTag("Pause");
        activeUI = false;
        recipeUI = false;
        questUI = false;
        pauseUI = false;
        UI.SetActive(activeUI);
        Recipe.SetActive(recipeUI);
        Quest.SetActive(questUI);
        Pause.SetActive(pauseUI);
    }

    public void UiAff()
    {
        activeUI = !activeUI;
        UI.SetActive(activeUI);
    }

    public void RecipeAff()
    {
        recipeUI = !recipeUI;
        Recipe.SetActive(recipeUI);
    }

    public void QuestAff()
    {
        questUI = !questUI;
        Quest.SetActive(questUI);
    }

    public void PauseAff()
    {
        pauseUI = !pauseUI;
        Pause.SetActive(pauseUI);

        if (pauseUI == false)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0.2f;
    }
}

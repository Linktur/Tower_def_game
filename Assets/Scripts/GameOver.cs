using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public SceneFader sceneFader;
    public Button retry;
    public Button mainMenu;
    public string mainMenuSceneName = "StartMenu";

    private void Start()
    {
        if (retry != null)
        {
            retry.onClick.AddListener(Retry);
        }
        mainMenu.onClick.AddListener(Menu);
    }

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("я хуй!");

        sceneFader.FadeTo(mainMenuSceneName);
    }
}

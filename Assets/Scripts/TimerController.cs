using System.Security.Authentication;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Для загрузки сцен

public class GameController : MonoBehaviour
{
    public Text timerText; // Ссылка на текстовый объект для отображения таймера
    private float timeRemaining = 120f; // 5 минут = 300 секунд
    private bool timerIsRunning = false;
    public GameObject StopGame;
    private GameObject health;

    void Start()
    {
        timerIsRunning = true;
        health = GameObject.FindGameObjectWithTag("health");
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Чтобы отображать полные секунды

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("To survive " + "{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        // Логика завершения игры
        // // Например, загрузка экрана победы
        // SceneManager.LoadScene("StartMenu");
        StopGame.SetActive(true);
        health.SetActive(false);
        
        
    }
}
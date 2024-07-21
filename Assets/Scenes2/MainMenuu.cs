using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleLevelManager : MonoBehaviour
{
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button exitButton;

    public Button playButton;
    public Button backButton;
    public GameObject gameMenu;
    public GameObject mainMenu;
    
    void Start()
    {
        // Инициализация кнопок
        level1Button.onClick.AddListener(() => LoadLevel("Level 1"));
        level2Button.onClick.AddListener(() => LoadLevel("Level 2"));
        level3Button.onClick.AddListener(() => LoadLevel("Level 3"));
        level4Button.onClick.AddListener(() => LoadLevel("Level 4"));
        if (playButton != null)
        {
            playButton.onClick.AddListener(PLayButtonFunc);
        } 
        if (exitButton != null)
        {
           exitButton.onClick.AddListener(ExitGame);
        } 
        if (backButton != null)
        { 
            backButton.onClick.AddListener(BackButtonFunc);
        }
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    void PLayButtonFunc()
    {
        mainMenu.SetActive(false);
        gameMenu.SetActive(true);
    } 
    void BackButtonFunc()
    {
        gameMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
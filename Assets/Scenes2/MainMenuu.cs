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

    void Start()
    {
        // Инициализация кнопок
        level1Button.onClick.AddListener(() => LoadLevel("Level 1"));
        level2Button.onClick.AddListener(() => LoadLevel("Level 2"));
        level3Button.onClick.AddListener(() => LoadLevel("Level 3"));
        level4Button.onClick.AddListener(() => LoadLevel("Level 4"));
        exitButton.onClick.AddListener(ExitGame);
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverUIController : MonoBehaviour
{
    public static GameoverUIController instance;

    [SerializeField] private Canvas gameOverCanvas;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        gameOverCanvas.enabled = false;
    }

    public void GameoverPanel()
    {
        gameOverCanvas.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_LEVEL_NAME);
    }
}

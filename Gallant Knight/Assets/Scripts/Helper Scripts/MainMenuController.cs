using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

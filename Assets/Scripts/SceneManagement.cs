using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagement : MonoBehaviour
{ 
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("KyleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

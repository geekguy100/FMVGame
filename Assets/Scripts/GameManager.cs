/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/29/2021
//
// Brief Description : Handle's managing the game's state.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

/// <summary>
/// Handles managing the game's state.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// True if the game is paused.
    /// </summary>
    private bool paused;

    /// <summary>
    /// Event called when the game's pause state is toggled.
    /// </summary>
    public UnityAction<bool> GamePausedEvent;

    [Tooltip("The pause menu UI.")]
    [SerializeField] private GameObject pauseMenu;

    /// <summary>
    /// Member variable initialization.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        paused = false;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        // Enable the pause menu if the escape key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;
        pauseMenu.SetActive(paused);
        GamePausedEvent?.Invoke(paused);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
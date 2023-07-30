using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public static bool isPaused;

    private void Start() {
        pauseMenu.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (isPaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void GoToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        isPaused = false;
    }

    public void QuitGame() {
        Application.Quit();
    }
}

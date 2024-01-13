using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject pauseButton;

    private void Start() {
        pauseMenuObject.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void PauseGame() {
        pauseButton.SetActive(false);
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        pauseButton.SetActive(true);
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}

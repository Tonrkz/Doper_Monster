using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverSceneManager : MonoBehaviour {

    [SerializeField] TMP_Text scoreText;

    void Start() {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
    }

    public void Exit() {
        Application.Quit();
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}

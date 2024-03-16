using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverSceneManager : MonoBehaviour {

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    void Start() {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        Debug.Log(PlayerPrefs.GetString("LastLevel"));
        if (PlayerPrefs.GetString("LastLevel") == "EasyStage") {
            if (PlayerPrefs.GetInt("EasyHighScore") < PlayerPrefs.GetInt("Score")) {
                highScoreText.text = "New High Score!";
                PlayerPrefs.SetInt("EasyHighScore", PlayerPrefs.GetInt("Score"));
            }
            else {
                highScoreText.text = "";
            }
        }
        else if (PlayerPrefs.GetString("LastLevel") == "MediumStage") {
            if (PlayerPrefs.GetInt("MediumHighScore") < PlayerPrefs.GetInt("Score")) {
                highScoreText.text = "New High Score!";
                PlayerPrefs.SetInt("MediumHighScore", PlayerPrefs.GetInt("Score"));
            }
            else {
                highScoreText.text = "";
            }
        }
        else if (PlayerPrefs.GetString("LastLevel") == "HardStage") {
            if (PlayerPrefs.GetInt("HardHighScore") < PlayerPrefs.GetInt("Score")) {
                highScoreText.text = "New High Score!";
                PlayerPrefs.SetInt("HardHighScore", PlayerPrefs.GetInt("Score"));
            }
            else {
                highScoreText.text = "";
            }
        }
    }

    public void Exit() {
        Application.Quit();
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void ButtonOnClickSFX() {
        GameObject.FindGameObjectWithTag("ButtonSound").GetComponent<ButtonSoundManager>().ButtonClickSFX();
    }
}

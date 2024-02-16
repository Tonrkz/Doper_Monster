using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSelectionSceneManager : MonoBehaviour {

    [SerializeField] TMP_Text easyHighScoreText;
    [SerializeField] TMP_Text mediumHighScoreText;
    [SerializeField] TMP_Text hardHighScoreText;

    void Start() {
        if (!PlayerPrefs.HasKey("EasyHighScore")) {
            PlayerPrefs.SetInt("EasyHighScore", 0);
        }
        if (!PlayerPrefs.HasKey("MediumHighScore")) {
            PlayerPrefs.SetInt("MediumHighScore", 0);
        }
        if (!PlayerPrefs.HasKey("HardHighScore")) {
            PlayerPrefs.SetInt("HardHighScore", 0);
        }
        easyHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("EasyHighScore");
        mediumHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("MediumHighScore");
        hardHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HardHighScore");
    }

    public void GotoTestStage() {
        SceneManager.LoadScene("TestGameplay");
    }

    public void GoToEasyStage() {
        SceneManager.LoadScene("EasyStage");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}

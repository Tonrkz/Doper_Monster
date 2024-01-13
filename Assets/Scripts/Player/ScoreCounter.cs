using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour {

    [SerializeField] TMP_Text scoreText;

    void Update() {
        UpdateScoreText("Score: " + PlayerManager.instance.Score);
    }

    void UpdateScoreText(string msg) {
        scoreText.text = msg;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class IntroSceneManager : MonoBehaviour {

    [SerializeField] Image logo;
    [SerializeField] TMP_Text presentsText;

    private void Start() {
        StartCoroutine(WaitForLogo());
    }

    void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator WaitForLogo() {
        yield return new WaitForSeconds(5f);
        GoToMainMenu();
    }
}

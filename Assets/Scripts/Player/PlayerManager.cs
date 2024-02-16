using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    [SerializeField] int sanity = 100;
    public int Sanity { get { return sanity; } set { sanity = value; } }
    [SerializeField] int score = 0;
    public int Score { get { return score; } set { score = value; } }
    [SerializeField] List<GameObject> obstacleList = new List<GameObject>();

    void Start() {
        instance = this;
    }

    void Update() {
        if (sanity > 100) {
            sanity = 100;
        }
        if (sanity < 0 || sanity == 0) {
            Debug.Log("Dead");
            sanity = 0;
            StartCoroutine(Dead());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<DessertManager>() != null) {
            DessertManager dessert = collision.gameObject.GetComponent<DessertManager>();
            score += dessert.Point;
            switch (dessert.Type) {
                case DessertType.heal:
                    sanity += 5;
                    break;
                case DessertType.damage:
                    sanity -= 7;
                    break;
                case DessertType.speed:
                    StartCoroutine(GetComponent<PlayerMovement>().TempSpeedUp());
                    break;
                case DessertType.invis:
                    StartCoroutine(GetComponent<PlayerMovement>().TempInvis(obstacleList));
                    break;
            }
            StartCoroutine(DessertSpawner.instance.WaitToSpawnDessert());
            Destroy(dessert.gameObject);
        }
    }

    IEnumerator Dead() {
        Debug.Log("Coroutine(Dead());");
        yield return new WaitForSeconds(3f);
        Debug.Log("Finished!");
        PlayerPrefs.SetInt("Score", Score);
        GoToGameOver();
    }

    void GoToGameOver() {
        SceneManager.LoadScene("GameOver");
    }
}

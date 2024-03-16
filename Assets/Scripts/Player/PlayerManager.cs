using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    [SerializeField] int maxSanity;
    public int MaxSanity { get { return maxSanity; } set { maxSanity = value; } }
    int sanity;
    public int Sanity { get { return sanity; } set { sanity = value; } }

    [SerializeField] int score = 0;
    public int Score { get { return score; } set { score = value; } }

    int level = 1;
    public int Level { get { return level; } set { level = value; } }

    int currentTier = 1;
    public int CurrentTier { get { return currentTier; } set { currentTier = value; } }

    [SerializeField] internal List<GameObject> obstacleList = new List<GameObject>();

    internal Animator playerAnimator;

    void Start() {
        instance = this;
        sanity = maxSanity;
        Debug.Log(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetString("LastLevel", SceneManager.GetActiveScene().name);
        playerAnimator = GetComponent<Animator>();
    }

    void Update() {
        if (sanity > maxSanity) {
            sanity = maxSanity;
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
            PlayerSoundManager.instance.EatingSFX();
            switch (dessert.Type) {
                case DessertType.heal:
                    sanity += 5;
                    break;
                case DessertType.damage:
                    playerAnimator.SetTrigger("hurt");
                    sanity -= 7;
                    break;
                case DessertType.speed:
                    StartCoroutine(GetComponent<PlayerMovement>().TempSpeedUp());
                    break;
                case DessertType.invis:
                    StartCoroutine(GetComponent<PlayerMovement>().TempInvis(obstacleList));
                    StopCoroutine(GetComponent<PlayerMovement>().TempInvis(obstacleList));
                    break;
            }
            StartCoroutine(DessertSpawner.instance.WaitToSpawnDessert());
            Destroy(dessert.gameObject);
        }
    }

    IEnumerator Dead() {
        playerAnimator.SetBool("isDead", true);
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

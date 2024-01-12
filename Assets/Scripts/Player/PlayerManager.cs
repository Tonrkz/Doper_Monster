using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<DessertManager>() != null) {
            DessertManager dessert = collision.gameObject.GetComponent<DessertManager>();
            score += dessert.Point;
            switch (dessert.Type) {
                case DessertType.Heal:
                    sanity += 5;
                    break;
                case DessertType.Damage:
                    sanity -= 7;
                    break;
                case DessertType.Speed:
                    StartCoroutine(GetComponent<PlayerMovement>().TempSpeedUp());
                    break;
                case DessertType.Invis:
                    StartCoroutine(GetComponent<PlayerMovement>().TempInvis(obstacleList));
                    break;
            }
            Destroy(dessert.gameObject);
        }
    }
}

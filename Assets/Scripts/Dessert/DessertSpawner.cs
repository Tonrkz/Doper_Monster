using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertSpawner : MonoBehaviour {

    [SerializeField] GameObject dessertPrefab;

    public static DessertSpawner instance;
    float expireTime = 0f;

    private void Start() {
        instance = this;
        for (int i = 0 ; i < 5 ; i++) {
            SpawnDessert();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnDessert();
        }
    }

    internal void SpawnDessert() {
        GameObject dessert = Instantiate(dessertPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.6f, 3.6f)), Quaternion.identity);
        expireTime = Random.Range(3f, 5f);

        int type = Random.Range(1, 100);
        if (type >= 1 && type <= 50) {
            type = Random.Range(1, 100);
            if (type >= 1 && type <= 50) {
                dessert.GetComponent<DessertManager>().Type = DessertType.lowPoint;
            }
            else if (type > 50 && type <= 85) {
                dessert.GetComponent<DessertManager>().Type = DessertType.midPoint;
            }
            else {
                dessert.GetComponent<DessertManager>().Type = DessertType.highPoint;
            }
        }
        else {
            type = Random.Range(1, 100);
            if (type >= 1 && type <= 50) {
                dessert.GetComponent<DessertManager>().Type = DessertType.damage;
            }
            else if (type > 50 && type <= 80) {
                dessert.GetComponent<DessertManager>().Type = DessertType.heal;
            }
            else if (type > 80 && type <= 90) {
                dessert.GetComponent<DessertManager>().Type = DessertType.speed;
            }
            else {
                dessert.GetComponent<DessertManager>().Type = DessertType.invis;
            }
        }

        StartCoroutine(ExpiringTime(dessert));
        dessert.GetComponent<DessertManager>().SetupDessert(dessert.GetComponent<DessertManager>().Type);
    }

    internal IEnumerator WaitToSpawnDessert() {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        SpawnDessert();
    }

    internal IEnumerator ExpiringTime(GameObject dessert) {
        yield return new WaitForSeconds(expireTime);
        if (dessert.GetComponent<DessertManager>() != null) {
            if (dessert.GetComponent<DessertManager>().Type == DessertType.lowPoint || dessert.GetComponent<DessertManager>().Type == DessertType.midPoint || dessert.GetComponent<DessertManager>().Type == DessertType.highPoint) {
                PlayerManager.instance.Sanity -= 6;
            }
            StartCoroutine(WaitToSpawnDessert());
            Destroy(dessert.gameObject);
        }
    }
}

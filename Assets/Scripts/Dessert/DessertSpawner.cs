using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertSpawner : MonoBehaviour {

    [SerializeField] GameObject dessertPrefab;

    public static DessertSpawner instance;

    int dessertBasePoint = 0;
    public int DessertBasePoint { get { return dessertBasePoint; } set { dessertBasePoint = value; } }

    float minExpireTime = 3f;
    public float MinExpireTime { get { return minExpireTime; } set { minExpireTime = value; } }

    float maxExpireTime = 5f;
    public float MaxExpireTime { get { return maxExpireTime; } set { maxExpireTime = value; } }

    float expireTime = 0f;

    private void Start() {
        instance = this;
        for (int i = 0 ; i < 5 ; i++) {
            SpawnDessert();
        }
        StartCoroutine(WaitToSpawnMoreDessert());
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnDessert();
        }
    }

    internal void SpawnDessert() {
        GameObject dessert = Instantiate(dessertPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.6f, 3.6f)), Quaternion.identity);
        expireTime = Random.Range(minExpireTime, maxExpireTime);

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
            if (type >= 1 && type <= 40) {
                dessert.GetComponent<DessertManager>().Type = DessertType.damage;
            }
            else if (type > 40 && type <= 60) {
                dessert.GetComponent<DessertManager>().Type = DessertType.heal;
            }
            else if (type > 60 && type <= 90) {
                dessert.GetComponent<DessertManager>().Type = DessertType.speed;
            }
            else {
                dessert.GetComponent<DessertManager>().Type = DessertType.invis;
            }
        }

        StartCoroutine(ExpiringTime(dessert));
        dessert.GetComponent<DessertManager>().SetupDessert(dessert.GetComponent<DessertManager>().Type, dessertBasePoint);
    }

    internal IEnumerator WaitToSpawnDessert() {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        SpawnDessert();
    }

    //The longer player lasts, The more dessert be spawned.
    internal IEnumerator WaitToSpawnMoreDessert() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(20, 27));
            SpawnDessert();
        }
    }

    internal IEnumerator ExpiringTime(GameObject dessert) {
        yield return new WaitForSeconds(expireTime);
        if (dessert.GetComponent<DessertManager>() != null) {
            if (dessert.GetComponent<DessertManager>().Type == DessertType.lowPoint || dessert.GetComponent<DessertManager>().Type == DessertType.midPoint || dessert.GetComponent<DessertManager>().Type == DessertType.highPoint) {
                PlayerManager.instance.playerAnimator.SetTrigger("hurt");
                PlayerManager.instance.Sanity -= 6;
            }
            StartCoroutine(WaitToSpawnDessert());
            Destroy(dessert.gameObject);
        }
    }
}

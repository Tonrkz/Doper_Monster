using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertSpawner : MonoBehaviour {

    [SerializeField] GameObject dessertPrefab;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnDessert();
        }
    }

    void SpawnDessert() {
        GameObject dessert = Instantiate(dessertPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.6f, 3.6f)), Quaternion.identity);

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

        dessert.GetComponent<DessertManager>().SetupDessert(dessert.GetComponent<DessertManager>().Type);
    }
}

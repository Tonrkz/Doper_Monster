using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DessertType {
    lowPoint,
    midPoint,
    HighPoint,
    Heal,
    Damage,
    Speed,
    Invis
}

public class DessertManager : MonoBehaviour {

    [SerializeField] int point = 0;
    public int Point { get { return point; } set { point = value; } }
    [SerializeField] DessertType type;
    [SerializeField] float timeExists;

    void Start() {

    }

    void Update() {
        SetupDessert(type);
    }

    void SetupDessert(DessertType type) {
        SpriteRenderer rdr = GetComponent<SpriteRenderer>();
        switch (type) {
            case DessertType.lowPoint:
                rdr.color = new Color32(184, 255, 186, 255);
                point = 3;
                break;
            case DessertType.midPoint:
                rdr.color = new Color32(117, 255, 121, 255);
                point = 7;
                break;
            case DessertType.HighPoint:
                rdr.color = new Color32(43, 255, 49, 255);
                point = 13;
                break;
            case DessertType.Heal:
                rdr.color = new Color32(255, 118, 99, 255);
                point = 5;
                break;
            case DessertType.Damage:
                rdr.color = new Color32(85, 27, 171, 255);
                point = 0;
                break;
            case DessertType.Speed:
                rdr.color = new Color32(255, 255, 61, 255);
                point = 2;
                break;
            case DessertType.Invis:
                rdr.color = new Color32(0, 229, 255, 255);
                point = 5;
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DessertType {
    lowPoint,
    midPoint,
    highPoint,
    heal,
    damage,
    speed,
    invis
}

public class DessertManager : MonoBehaviour {

    int point = 0;
    public int Point { get { return point; } set { point = value; } }
    [SerializeField] DessertType type;
    public DessertType Type { get { return type; } set { type = value; } }

    public void SetupDessert(DessertType type, int basePoint) {
        SpriteRenderer rdr = GetComponent<SpriteRenderer>();
        switch (type) {
            case DessertType.lowPoint:
                rdr.color = new Color32(184, 255, 186, 255);
                point = 3 + basePoint;
                break;
            case DessertType.midPoint:
                rdr.color = new Color32(117, 255, 121, 255);
                point = 7 + basePoint;
                break;
            case DessertType.highPoint:
                rdr.color = new Color32(43, 255, 49, 255);
                point = 13 + basePoint;
                break;
            case DessertType.heal:
                rdr.color = new Color32(255, 118, 99, 255);
                point = 5;
                break;
            case DessertType.damage:
                rdr.color = new Color32(85, 27, 171, 255);
                point = 0;
                break;
            case DessertType.speed:
                rdr.color = new Color32(255, 255, 61, 255);
                point = 2;
                break;
            case DessertType.invis:
                rdr.color = new Color32(0, 229, 255, 255);
                point = 4;
                break;
        }
    }
}
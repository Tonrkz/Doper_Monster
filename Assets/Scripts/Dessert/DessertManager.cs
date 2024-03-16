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

    [SerializeField] List<Sprite> dessertSpriteList = new List<Sprite>();

    public void SetupDessert(DessertType type, int basePoint) {
        SpriteRenderer rdr = GetComponent<SpriteRenderer>();
        switch (type) {
            case DessertType.lowPoint:
                rdr.sprite = dessertSpriteList[0];
                point = 3 + basePoint;
                break;
            case DessertType.midPoint:
                rdr.sprite = dessertSpriteList[1];
                point = 7 + basePoint;
                break;
            case DessertType.highPoint:
                rdr.sprite = dessertSpriteList[2];
                point = 13 + basePoint;
                break;
            case DessertType.heal:
                rdr.sprite = dessertSpriteList[3];
                point = 5;
                break;
            case DessertType.damage:
                rdr.sprite = dessertSpriteList[4];
                point = 0;
                break;
            case DessertType.speed:
                rdr.sprite = dessertSpriteList[5];
                point = 2;
                break;
            case DessertType.invis:
                rdr.sprite = dessertSpriteList[6];
                point = 4;
                break;
        }
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
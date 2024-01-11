using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    [SerializeField] int hp = 10;
    public int HP { get { return hp; } set { hp = value; } }
    [SerializeField] int score = 0;
    public int Score { get { return score; } set { score = value; } }

    void Start() {
        instance = this;
    }

    void Update() {

    }
}

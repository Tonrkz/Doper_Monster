using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    [SerializeField] int hp = 10;
    public int HP { get { return hp; } set { hp = value; } }

    void Start() {
        instance = this;
    }

    void Update() {

    }
}

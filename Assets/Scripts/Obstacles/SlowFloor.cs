using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFloor : MonoBehaviour {
    float maxSpeedEnter;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovement>() != null) {
            maxSpeedEnter = collision.GetComponent<PlayerMovement>().MaxMoveSpeed;
            collision.GetComponent<PlayerMovement>().MaxMoveSpeed *= 0.6f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        collision.GetComponent<PlayerMovement>().MaxMoveSpeed = maxSpeedEnter;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFloor : MonoBehaviour {
    float maxSpeedEnter = 0;
    float slowedMaxSpeed = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovement>() != null) {
            maxSpeedEnter = collision.GetComponent<PlayerMovement>().MaxMoveSpeed;
            Debug.Log(maxSpeedEnter);
            slowedMaxSpeed = maxSpeedEnter / 2;
            Debug.Log(slowedMaxSpeed);
            collision.GetComponent<PlayerMovement>().MaxMoveSpeed /= 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovement>() != null) {
            if (slowedMaxSpeed * 2 != collision.GetComponent<PlayerMovement>().MaxMoveSpeed) {
                maxSpeedEnter += collision.GetComponent<PlayerMovement>().MaxMoveSpeed - slowedMaxSpeed;
                Debug.Log("Not Equal" + maxSpeedEnter);
                collision.GetComponent<PlayerMovement>().MaxMoveSpeed = maxSpeedEnter;
            }
            else {
                collision.GetComponent<PlayerMovement>().MaxMoveSpeed = maxSpeedEnter;
            }
        }
    }
}

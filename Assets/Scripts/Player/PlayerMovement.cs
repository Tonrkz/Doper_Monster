using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler {

    public static PlayerMovement instance;

    bool isDrag = false;
    [SerializeField] float maxMoveSpeed = 25;
    public float MaxMoveSpeed { get { return maxMoveSpeed; } set { maxMoveSpeed = value; } }
    [SerializeField] float smoothTime = 0.3f;
    Vector2 currentVelocity;

    Rigidbody2D rb;

    void Start() {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (isDrag && GetComponent<PlayerManager>().Sanity > 0) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed));
            //rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + mousePosition * maxMoveSpeed * Time.deltaTime);
            //transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
        }
        if (maxMoveSpeed <= 0) {
            maxMoveSpeed = 10f;
        }
    }

    internal IEnumerator TempSpeedUp() {
        Debug.Log("Speed Up");
        maxMoveSpeed += 25;
        yield return new WaitForSeconds(5);
        Debug.Log("Speed Down");
        maxMoveSpeed -= 25;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Clicked");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("UnClicked");
    }

    public void OnDrag(PointerEventData eventData) {
        isDrag = true;
        Debug.Log("Dragged");
    }

    public void OnEndDrag(PointerEventData eventData) {
        isDrag = false;
        Debug.Log("Undragged");
    }
}

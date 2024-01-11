using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler {

    bool isDrag = false;
    [SerializeField] float maxMoveSpeed = 10;
    [SerializeField] float smoothTime = 0.3f;
    Vector2 currentVelocity;

    void Start() {

    }

    void Update() {
        if (isDrag && GetComponent<PlayerManager>().HP > 0) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
        }
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

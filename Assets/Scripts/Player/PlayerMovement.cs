using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler {

    bool isDrag = false;
    [SerializeField] float maxMoveSpeed = 10;
    public float MaxMoveSpeed { get { return maxMoveSpeed; } set { maxMoveSpeed = value; } }
    [SerializeField] float smoothTime = 0.3f;
    Vector2 currentVelocity;

    void Start() {

    }

    void Update() {
        if (isDrag && GetComponent<PlayerManager>().Sanity > 0) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
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

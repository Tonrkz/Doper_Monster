using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler {

    public static PlayerMovement instance;

    bool isDrag = false;
    [SerializeField] float maxMoveSpeed = 7f;
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
            maxMoveSpeed = 7f;
        }
        if (PlayerManager.instance.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Walk")) {
            PlayerManager.instance.playerAnimator.speed = currentVelocity.magnitude / maxMoveSpeed;
        }
        else {
            PlayerManager.instance.playerAnimator.speed = 1;
        }
    }

    internal IEnumerator TempSpeedUp() {
        Debug.Log("Speed Up");
        maxMoveSpeed += 5;
        yield return new WaitForSeconds(5);
        Debug.Log("Speed Down");
        maxMoveSpeed -= 5;
    }

    internal IEnumerator TempInvis(List<GameObject> obstacleList) {
        Debug.Log("Invis");
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 128);
        foreach (var item in obstacleList) {
            item.GetComponent<Rigidbody2D>().simulated = false;
        }
        yield return new WaitForSeconds(5);
        foreach (var item in obstacleList) {
            item.GetComponent<Rigidbody2D>().simulated = true;
        }
        Debug.Log("Uninvis");
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    public void OnPointerDown(PointerEventData eventData) {
        PlayerManager.instance.playerAnimator.SetTrigger("grab");
        Debug.Log("Clicked");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("UnClicked");
    }

    public void OnDrag(PointerEventData eventData) {
        isDrag = true;
        PlayerManager.instance.playerAnimator.SetBool("isWalking", true);
        Debug.Log("Dragged");
    }

    public void OnEndDrag(PointerEventData eventData) {
        isDrag = false;
        PlayerManager.instance.playerAnimator.SetBool("isWalking", false);
        Debug.Log("Undragged");
    }
}

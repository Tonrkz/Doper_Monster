using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    Vector3 ogSize = Vector3.one;
    Vector3 newSize = Vector3.one * 1.1f;
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Hover");
        transform.localScale = newSize;
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Unhover");
        transform.localScale = ogSize;
    }
}

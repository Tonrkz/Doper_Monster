using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    [SerializeField] Slider sanityBarSlider;
    [SerializeField] Slider easeSanityBarSlider;
    float lerpSpeed = 0.05f;

    private void Start() {
        sanityBarSlider.maxValue = GetComponent<PlayerManager>().Sanity;
        sanityBarSlider.value = sanityBarSlider.maxValue;
        easeSanityBarSlider.value = sanityBarSlider.maxValue;
    }

    private void Update() {
        if (sanityBarSlider.value != GetComponent<PlayerManager>().Sanity) {
            sanityBarSlider.value = GetComponent<PlayerManager>().Sanity;
        }
        if (easeSanityBarSlider.value != sanityBarSlider.value) {
            easeSanityBarSlider.value = Mathf.Lerp(easeSanityBarSlider.value, GetComponent<PlayerManager>().Sanity, lerpSpeed);
        }
    }
}

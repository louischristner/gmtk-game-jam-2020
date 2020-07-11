using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyChangeCounter : MonoBehaviour
{
    public float maxValue = 10f;
    public GameObject player;

    Slider counterSlider;

    void Start()
    {
        counterSlider = GetComponent<Slider>();
        counterSlider.value = 0;
        counterSlider.maxValue = maxValue;
    }

    void Update()
    {
        counterSlider.value += Time.deltaTime;

        if (counterSlider.value >= counterSlider.maxValue) {
            player.GetComponent<PlayerMovement>().UpdateKeyMapping();
            counterSlider.value = 0;
        }
    }
}

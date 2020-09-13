using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyChangeCounter : MonoBehaviour
{
    public float maxValue = 10f;
    public GameObject player;

    private AudioSource sound;

    Slider counterSlider;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        counterSlider = GetComponent<Slider>();
        counterSlider.value = 0;
        counterSlider.maxValue = maxValue;
    }

    void Update()
    {
        counterSlider.value += Time.deltaTime;

        if (counterSlider.value >= counterSlider.maxValue) {
            sound.Play();
            player.GetComponent<PlayerMovement>().UpdateKeyMapping();
            counterSlider.value = 0;
        }
    }

    public void Reset()
    {
        counterSlider.value = 0;
    }
}

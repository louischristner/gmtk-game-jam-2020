using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] sounds;

    private AudioSource coin;
    private AudioSource hit;

    void Start()
    {
        sounds = GetComponents<AudioSource>();

        coin = sounds[0];
        hit = sounds[1];
    }

    public void PlayCoin()
    {
        coin.Play();
    }

    public void PlayHit()
    {
        hit.Play();
    }
}

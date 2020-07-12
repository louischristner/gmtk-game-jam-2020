using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLosing : MonoBehaviour
{
    public GameObject player;
    public KeyChangeCounter kcCounter;

    private SoundHandler soundHandler;

    Vector3 savedPosition;

    void Start()
    {
        savedPosition = player.transform.position;

        soundHandler = GetComponent<SoundHandler>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "spike" || collider.gameObject.tag == "deathzone") {
            ResetToCheckpoint();
        } else if (collider.gameObject.tag == "checkpoint") {
            savedPosition = player.transform.position;
            Debug.Log("saved");
        }
    }

    void ResetToCheckpoint()
    {
        soundHandler.PlayHit();
        kcCounter.Reset();
        player.transform.position = savedPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLosing : MonoBehaviour
{
    public GameObject player;
    public KeyChangeCounter kcCounter;

    Vector3 savedPosition;

    void Start()
    {
        savedPosition = player.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "spike" || collider.gameObject.tag == "deathzone") {
            StartCoroutine(ResetToCheckpoint());
        } else if (collider.gameObject.tag == "checkpoint") {
            savedPosition = player.transform.position;
            Debug.Log("saved");
        }
    }

    IEnumerator ResetToCheckpoint()
    {
        yield return new WaitForSeconds(0.2f);

        kcCounter.Reset();
        player.transform.position = savedPosition;
    }
}

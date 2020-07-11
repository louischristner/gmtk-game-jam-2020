using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoring : MonoBehaviour
{
    public GameObject scoreManager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "diamond") {
            scoreManager.GetComponent<ScoreManager>().value += 1;
            Destroy(collider.gameObject);
        }
    }
}

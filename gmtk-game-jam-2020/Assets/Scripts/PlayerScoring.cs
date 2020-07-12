using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScoring : MonoBehaviour
{
    public GameObject scoreManager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "diamond") {
            scoreManager.GetComponent<ScoreManager>().value += collider.gameObject.GetComponent<DiamondValues>().Collect();
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "exit") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("EXIT");
        }
    }
}

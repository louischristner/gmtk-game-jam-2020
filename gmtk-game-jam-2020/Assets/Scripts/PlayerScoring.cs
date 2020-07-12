using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScoring : MonoBehaviour
{
    public GameObject scoreManager;

    private SoundHandler soundHandler;

    void Start()
    {
        soundHandler = GetComponent<SoundHandler>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "diamond") {
            scoreManager.GetComponent<ScoreManager>().value += collider.gameObject.GetComponent<DiamondValues>().Collect();
            soundHandler.PlayCoin();
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "exit") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("EXIT");
        }
    }
}

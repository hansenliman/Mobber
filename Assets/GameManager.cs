using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool playedVictory = false;
    bool gameHasEnded = false;
    bool gameStarted = false;
    public AudioClip sound;

    public float restartDelay = 8f;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<Score>().ShowScore();
            Invoke("Restart", restartDelay);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            gameStarted = true;
        }
        if (gameStarted == false)
        {
            return;
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            PlayVictory();
            Invoke("EndGame", 3f);
        }
    }

    void PlayVictory()
    {
        if(playedVictory == false)
        {
            playedVictory = true;
            AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
            AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip explosionSound;
    public GameObject deathEffect;
    GameObject text;
    int health = 7;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            health--;
            //text = GameObject.Find("Text");
            //text.GetComponent<Score>().AddScore(-25);
            FindObjectOfType<Score>().AddScore(-5);
            AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
            AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
            AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
            if (health <= 0)
            {
                GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1.2f);
                AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
                AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
                AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
                AudioSource.PlayClipAtPoint(explosionSound, transform.position, 1f);
                AudioSource.PlayClipAtPoint(explosionSound, transform.position, 1f);
                AudioSource.PlayClipAtPoint(explosionSound, transform.position, 1f);
                AudioSource.PlayClipAtPoint(explosionSound, transform.position, 1f);
                FindObjectOfType<GameManager>().EndGame();
                Destroy(gameObject);
            }
        }
    }
}

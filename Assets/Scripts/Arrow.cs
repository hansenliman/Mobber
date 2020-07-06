using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public AudioClip sound;
    GameObject text;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = sound;
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            //GetComponent<AudioSource>().Play();
            text = GameObject.Find("Text");
            text.GetComponent<Score>().AddScore(2);
            //FindObjectOfType<Score>().addScore();
            //Debug.Log("Score added!");
            //FindObjectOfType<Score>().AddScore(1);
            AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
            AudioSource.PlayClipAtPoint(sound, transform.position, 1.0f);
            Destroy(gameObject);
        }
    }
}

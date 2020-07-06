using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raydric : MonoBehaviour
{
    public AudioClip sound;
    public GameObject deathEffect;
    int health = 1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Arrow")
        {
            health--;
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(sound, transform.position, 0.4f);
                GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.667f);
                Destroy(transform.parent.gameObject);
            }
        }

    }

}

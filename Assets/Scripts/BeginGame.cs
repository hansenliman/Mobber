using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginGame : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] enemies;
    public Text intro;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Horde");

        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Arrow")
        {
            {
                foreach (GameObject enemy in enemies)
                {
                    enemy.SetActive(true);
                }
                intro.enabled = false;
            }
        }

    }
}

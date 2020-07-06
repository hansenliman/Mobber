using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform player;
    public GameObject bulletPrefab;
    public Animator animator;
    public float arrowForce = 20f;

    public Camera cam;

    public Rigidbody2D rb;

    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Fire");
            
            Shoot();
        }
    }

    void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        animator.SetFloat("MouseHorizontal", mousePos[0] - player.position[0]);
        animator.SetFloat("MouseVertical", mousePos[1] - player.position[1]);
        Vector2 playerPosition = new Vector2();
        playerPosition[0] = player.position[0];
        playerPosition[1] = player.position[1];
        Vector2 lookDir = mousePos - playerPosition;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(bulletPrefab, player.position, player.rotation);
        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
        arrowRb.AddForce(player.up * arrowForce, ForceMode2D.Impulse);
    }
}

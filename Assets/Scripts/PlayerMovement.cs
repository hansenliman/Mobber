using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }
    */

    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    Vector2 facing;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.sqrMagnitude > 0.01){ // then the player is moving
            facing.x = movement.x;
            facing.y = movement.y;

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        if (movement.sqrMagnitude < 0.01) // if player is not moving, play idle animation
        {
            animator.SetFloat("Horizontal", facing.x);
            animator.SetFloat("Vertical", facing.y);

            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.ClampMagnitude(movement, 1f) * moveSpeed * Time.fixedDeltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoleGFX : MonoBehaviour
{

    public AIPath aipath;
    Vector2 movement;
    Vector2 facing;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        movement.x = aipath.desiredVelocity.x;
        movement.y = aipath.desiredVelocity.y;

        if (movement.sqrMagnitude > 0.01)
        { // then the player is moving


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
}
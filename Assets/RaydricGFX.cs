using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RaydricGFX : MonoBehaviour
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
        
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (aipath.reachedDestination)
        {
            animator.SetFloat("Horizontal", facing.x);
            animator.SetFloat("Vertical", facing.y);
            animator.SetTrigger("Attack");
            return;
        }

        /**
        if (aipath.reachedDestination)
        {
            if (animator.GetBool("IsAttacking") == true)
            {
                animator.SetFloat("Horizontal", facing.x);
                animator.SetFloat("Vertical", facing.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
                return;
            }
            animator.SetFloat("Horizontal", facing.x);
            animator.SetFloat("Vertical", facing.y);
            animator.SetBool("IsAttacking", true);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            return;
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
        
        **/

        if (movement.sqrMagnitude > 0.01)
        { // then the player is moving


            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            animator.SetFloat("Speed", movement.sqrMagnitude);

            facing.x = movement.x;
            facing.y = movement.y;
        }
        if (movement.sqrMagnitude < 0.01) // if player is not moving, play idle animation
        {
            animator.SetFloat("Horizontal", facing.x);
            animator.SetFloat("Vertical", facing.y);

            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        
        /**
         * Update:
         * Move towards player.
         * 
         * 
         */


    }
}
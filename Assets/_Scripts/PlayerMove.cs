using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private float moveSpeed;

    //[SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    Vector2 movement;

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // The player don't move if the dialogue is playing
        if (DialogueManager.Instance.dialogueIsPlaying)
        {
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // it makes the character moves on the same speed in diagonals
        movement = new Vector2(movement.x, movement.y).normalized;

        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }
}
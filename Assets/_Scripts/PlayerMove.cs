using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private float moveSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    Vector2 movement;

    public Animator flip;

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // The player don't move if the dialogue is playing
        /*if (DialogueManager.Instance.dialogueIsPlaying)
        {
            return;
        }*/

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // it makes the character moves on the same speed in diagonals
        movement = new Vector2(movement.x, movement.y).normalized;

        animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(transform.localScale.x==1 && movement.x>0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            flip.SetTrigger("Flip");
        }

        else if(transform.localScale.x==-1 && movement.x<0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            flip.SetTrigger("Flip");
        }
    }
}

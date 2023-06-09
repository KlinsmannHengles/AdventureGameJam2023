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

    [SerializeField] private ParticleSystem dust;

    private void FixedUpdate()
    {
        // The player don't move if the dialogue is playing
        if (DialogueManager.Instance.dialogueIsPlaying)
        {
            animator.SetFloat("Speed", 0f);
            return;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // The player don't move if the dialogue is playing
        if (DialogueManager.Instance.dialogueIsPlaying)
        {
            animator.SetFloat("Speed", 0f);
            return;
        }

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
        } else if(transform.localScale.x==-1 && movement.x<0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            flip.SetTrigger("Flip");
        }

        var emission = dust.emission;
        if (movement.x != 0 || movement.y != 0) {
            dust.Play();
            emission.enabled = true;}
        else {
            emission.enabled = false;
        }
    }

}

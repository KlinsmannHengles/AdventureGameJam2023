using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    public Animator animator;
    private bool mainCamera = true;

    // Start is called before the first frame update
    void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.Play("Sunset");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.Play("MainCamera");
        }
    }

    private void SwitchState()
    {
        if (mainCamera)
        {
            animator.Play("Sunset");
        } else
        {
            animator.Play("MainCamera");
        }
        mainCamera = !mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

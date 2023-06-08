using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class DialogueTrigger : MonoBehaviour
{

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private Spline cueSpline;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown("e") && !DialogueManager.Instance.dialogueIsPlaying)
        {
            DialogueManager.Instance.EnterDialogueMode(inkJSON);
        } else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision: " + collision);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Inside condition");
            playerInRange = true;
            cueSpline.transform.position = this.gameObject.transform.position + new Vector3(0f, 1.9f, 0f);
            visualCue.SetActive(true);
            AnimateVisualCue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }
    }

    private void AnimateVisualCue()
    {
        // Go up and go down animation
        Tween.Spline(cueSpline, visualCue.transform, 0, 1f, false, 1, 0, Tween.EaseInOut, Tween.LoopType.PingPong);
    }

}

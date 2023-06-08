using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length_x;
    private float length_y;
    private float startPos_x;
    private float startPos_y;

    private Transform cam;

    [SerializeField] private float parallaxEffect_x;
    [SerializeField] private float parallaxEffect_y;

    // Start is called before the first frame update
    void Start()
    {
        startPos_x = transform.position.x;
        startPos_y = transform.position.y;
        length_x = GetComponent<SpriteRenderer>().bounds.size.x;
        length_y = GetComponent<SpriteRenderer>().bounds.size.y;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance_x = cam.transform.position.x * parallaxEffect_x;
        float distance_y = cam.transform.position.y * parallaxEffect_y;
        transform.position = new Vector3(startPos_x + distance_x, startPos_y + distance_y, transform.position.z);
    }
}

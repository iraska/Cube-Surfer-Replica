using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouchMovement : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                position = new Vector3(-pos.x, 0.0f, 0.0f);

                // Position the cube.
                transform.position = position;
            }
        }
    }
}
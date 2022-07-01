using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // SerializeField makes a field display in the Inspector and causes it to be saved.
    [SerializeField]    
    private float forwardSpeed;
    [SerializeField]
    private float leftRightSpeed;

    private float position;
    private float width;

    void Start()
    {
        width = (float)Screen.width / 2.0f;

        // Position used for the cube.
        position = 0;
    }

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            // We need to get input from the user.
            Touch touch = Input.GetTouch(0); // first touch

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                position = (pos.x - width) / width;
            }
            else
            {
                position = 0;
            }
        }

        // deltaTime: Amount of time that has passed since the last state change.
        this.transform.Translate(position * leftRightSpeed * Time.deltaTime, 0, forwardSpeed * Time.deltaTime);
        // We use the X (horizontal) axis to go left and right and it will go forward all the time.
    }
}
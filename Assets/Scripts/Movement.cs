using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float leftRightSpeed;
    public float forwardSpeed;
    
    private float position;
    private float width;

    public Rigidbody rigidbody;

    void Start()
    {
        width = (float)Screen.width / 2.0f;

        rigidbody = this.GetComponent<Rigidbody>();

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
    }

    // When working with physics
    void FixedUpdate()
    {
        // We use the X (horizontal) axis to go left and right and it will go forward all the time.
        Vector3 vector3 = new Vector3(-forwardSpeed, 0, position * leftRightSpeed);

        // deltaTime: Amount of time that has passed since the last state change.
        rigidbody.MovePosition(transform.position + (vector3 * Time.deltaTime));
    }
}
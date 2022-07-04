using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardSpeed;
    public float leftRightSpeed;

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
        Vector3 vector3 = new Vector3(-forwardSpeed, 0, position * leftRightSpeed);

        // deltaTime: Amount of time that has passed since the last state change.
        //rigidbody.MovePosition(transform.position + (vector3 * Time.deltaTime));

        // fixedDeltaTime: The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's FixedUpdate) are performed.
        rigidbody.MovePosition(transform.position + (vector3 * Time.fixedDeltaTime));
    }
}
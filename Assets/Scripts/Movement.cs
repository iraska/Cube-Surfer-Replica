using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]    // SerializeField makes a field display in the Inspector and causes it to be saved.
    private float forwardSpeed;
    [SerializeField]
    private float leftRightSpeed;

    void Start()
    {

    }
    void Update()
    {
        // We need to get input from the user.

        float horizontalAxis = Input.GetAxis("Horizontal") * leftRightSpeed * Time.deltaTime;

        // deltaTime: Amount of time that has passed since the last state change.

        this.transform.Translate(horizontalAxis, 0, forwardSpeed * Time.deltaTime);

        // We use the X (horizontal) axis to go left and right and it will go forward all the time.
    }
    }

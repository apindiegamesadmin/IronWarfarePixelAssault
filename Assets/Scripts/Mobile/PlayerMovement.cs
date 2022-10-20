using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public TankMovementData movementData;
    public Joystick movementJoystick;

    private Vector2 movementVector;
    private float currentSpeed = 0;
    private float currentForwardDirection = 1;
    public static bool PointerDown = false;
    Vector2 move;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.zero;
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
        if (movementVector.y > 0)
        {
            if (currentForwardDirection == -1)
                currentSpeed = 0;
            currentForwardDirection = 1;
        }
        else if (movementVector.y < 0)
        {
            if (currentForwardDirection == 1)
                currentSpeed = 0;
            currentForwardDirection = -1;
        }

    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= movementData.deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.maxSpeed);
    }

    private void Update()
    {
        // if (movementJoystick.CheckDistance() > 40f)

        move.x = movementJoystick.Horizontal;
        move.y = movementJoystick.Vertical;

        float hAxis = move.x;
        float vAxis = move.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -zAxis);

    }

    private void FixedUpdate()
    {
        // if (movementJoystick.CheckDistance() > 50f)
        // {
        //     rb2d.velocity = new Vector2(movementJoystick.Horizontal * movementData.maxSpeed * Time.fixedDeltaTime, movementJoystick.Vertical * movementData.maxSpeed * Time.fixedDeltaTime);
        // }
        // else
        // {
        //     rb2d.velocity = Vector2.zero;
        // }

        if (PointerDown)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            if (movementJoystick.CheckDistance() < 50)
            {
                rb2d.velocity = Vector2.zero;
            }
            else if (movementJoystick.CheckDistance() > 50f)
            {
                rb2d.velocity = new Vector2(movementJoystick.Horizontal * movementData.maxSpeed * Time.fixedDeltaTime, movementJoystick.Vertical * movementData.maxSpeed * Time.fixedDeltaTime);
            }
        }

    }
}

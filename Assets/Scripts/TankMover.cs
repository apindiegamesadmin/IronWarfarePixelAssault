using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public TankMovementData movementData;

    private Vector2 movementVector;
    public Joystick movementJoystick;
    private float currentSpeed = 0;
    private float currentForwardDirection = 1;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
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

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * currentSpeed * currentForwardDirection * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));

        // // Vector2 movementDirection = movementJoystick.Direction;
        // float horizontalInput = movementJoystick.Horizontal;
        // float verticalInput = movementJoystick.Vertical;
        // Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        // float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
        // rb2d.velocity = (Vector2)transform.up * currentSpeed * currentForwardDirection * Time.fixedDeltaTime;
        // // rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, angle * Time.fixedDeltaTime));
        // transform.Rotate(0f, 0f, -horizontalInput);
    }
}

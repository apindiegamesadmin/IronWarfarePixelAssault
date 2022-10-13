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
    private float rotationSpeed = 3f;

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
        Vector2 movementDirection = movementJoystick.Direction;
        movementDirection.Normalize();

        // transform.Translate(movementDirection * Time.deltaTime);
        // rb2d.MoveRotation(movementJoystick.Horizontal);

        // if (movementDirection != Vector2.zero)
        // {
        //     Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, movementDirection);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        // }

        if (movementJoystick.CheckDistance() > 40f)
        {
            rb2d.velocity = new Vector2(movementJoystick.Horizontal, movementJoystick.Vertical);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}

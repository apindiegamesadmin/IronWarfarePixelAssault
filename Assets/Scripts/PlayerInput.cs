using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    int count;
    bool W, A, S, D;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(count < 4 && FindObjectOfType<TutorialManager>().tutorialIndex == 0)//Check for tutorial Movement //Not an efficient method,will fix later
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (W)
                    return;
                count++;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (A)
                    return;
                count++;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (S)
                    return;
                count++;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (D)
                    return;
                count++;
            }
            if(count == 4)
            {
                FindObjectOfType<TutorialManager>().completeStep = true;
            }
        }

        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();
    }

    private void GetShootingInput()
    {
        //Changed to Getmousebutton 0 instead to backup the fix
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            StartCoroutine(delayShoot());
        }
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePositon());
    }

    private Vector2 GetMousePositon()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveBody?.Invoke(movementVector.normalized);
    }

    //Not a good fix but it'll do @ Xavier
    IEnumerator delayShoot()
    {
        yield return new WaitForSeconds(.13f);
        OnShoot?.Invoke();
    }
}

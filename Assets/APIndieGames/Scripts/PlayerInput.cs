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
    public UnityEvent OnMachineGunShoot = new UnityEvent();
    public UnityEvent OnMachineGunStopShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        //Cursor.visible = false;
    }

    void Update()
    {
        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();
        MachineGunShootingInput();
    }

    private void GetShootingInput()
    {
        //Changed to Getmousebutton 0 instead to backup the fix
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            StartCoroutine(delayShoot());
        }
    }

    /// <summary>
    /// Get player's input for firing machine gun
    /// </summary>
    void MachineGunShootingInput()
    {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            OnMachineGunShoot.Invoke();
        }
        else if (Input.GetMouseButtonUp(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            OnMachineGunStopShoot.Invoke();
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

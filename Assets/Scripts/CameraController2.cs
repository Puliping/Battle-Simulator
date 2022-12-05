using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController2 : MonoBehaviour
{
    private Controls cameraActions;
    private InputAction movement;
    private Transform cameraTransform;

    public float maxSpeed = 5f;
    private float speed;
    public float acceleration = 10f;
    public float damping = 10f;

    public float stepSize = 2f;
    public float zoomDamping = 7.5f;
    public float minHeight = 5f;
    public float maxHeight = 50f;
    public float zoomSpeed = 2f;

    public float maxRotationSpeed = 1f;

    private Vector3 targetPosition;

    private float zoomHeight;

    private Vector3 horizontalVelocity;
    private Vector3 lastPosition;

    private Vector3 startDrag;

    private void Awake()
    {
        cameraActions = new Controls();
        cameraTransform = this.GetComponentInChildren<Camera>().transform;
    }

    private void OnEnable()
    {
        zoomHeight = cameraTransform.localPosition.y;
        cameraTransform.LookAt(this.transform);

        lastPosition = this.transform.position;

        movement = cameraActions.Camera.Move;
        cameraActions.Camera.Rotate.performed += Rotate;
        cameraActions.Camera.Zoom.performed += Zoom;
        cameraActions.Camera.Enable();
    }

    private void OnDisable()
    {
        cameraActions.Camera.Rotate.performed -= Rotate;
        cameraActions.Camera.Zoom.performed -= Zoom;
        cameraActions.Camera.Disable();
    }

    private void Zoom(InputAction.CallbackContext context)
    {
        float inputValue = -context.ReadValue<Vector2>().y / 100f;

        if (Mathf.Abs(inputValue) > 0.1f)
        {
            zoomHeight = cameraTransform.localPosition.y + inputValue * stepSize;

            if (zoomHeight < minHeight)
                zoomHeight = minHeight;
            else if (zoomHeight > maxHeight)
                zoomHeight = maxHeight;
        }
    }

    private void Rotate(InputAction.CallbackContext context)
    {
        if (!Mouse.current.rightButton.isPressed)
            return;

        float inputValue = context.ReadValue<Vector2>().x;
        float rotY = inputValue * maxRotationSpeed + transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f, rotY, 0f);
    }

    private void Update()
    {
        //inputs
        GetKeyboardMovement();
        DragCamera();

        //move base and camera objects
        UpdateVelocity();
        UpdateRigPosition();
        UpdateCameraPosition();
    }

    private void GetKeyboardMovement()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;
        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0f;

        Vector3 inputValue = (movement.ReadValue<Vector2>().x * cameraRight
                            + movement.ReadValue<Vector2>().y * cameraForward)
                            .normalized;

        if (inputValue.sqrMagnitude > 0.1f)
            targetPosition += inputValue;
    }

    private void DragCamera()
    {
        if (!Mouse.current.middleButton.isPressed)
            return;

        //create plane to raycast to
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
    
        if(plane.Raycast(ray, out float distance))
        {
            if (Mouse.current.middleButton.wasPressedThisFrame)
                startDrag = ray.GetPoint(distance);
            else
                targetPosition += startDrag - ray.GetPoint(distance);
        }
    }

    private void UpdateVelocity()
    {
        horizontalVelocity = (this.transform.position - lastPosition) / Time.deltaTime;
        horizontalVelocity.y = 0f;
        lastPosition = this.transform.position;
    }

    private void UpdateRigPosition()
    {
        if (targetPosition.sqrMagnitude > 0.1f)
        {
            //create a ramp up or acceleration
            speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime * acceleration);
            transform.position += targetPosition * speed * Time.deltaTime;
        }
        else
        {
            //create smooth slow down
            horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, Time.deltaTime * damping);
            transform.position += horizontalVelocity * Time.deltaTime;
        }

        //reset for next frame
        targetPosition = Vector3.zero;
    }

    private void UpdateCameraPosition()
    {
        //set zoom target
        Vector3 zoomTarget = new Vector3(cameraTransform.localPosition.x, zoomHeight, cameraTransform.localPosition.z);
        //add vector for forward/backward zoom
        zoomTarget -= zoomSpeed * (zoomHeight - cameraTransform.localPosition.y) * Vector3.forward;

        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, zoomTarget, Time.deltaTime * zoomDamping);
        cameraTransform.LookAt(this.transform);

    }
}

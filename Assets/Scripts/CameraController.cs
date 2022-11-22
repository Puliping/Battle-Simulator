using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField]
    private Rigidbody2D rbMinimap;
    private float speedMovement;
    private Vector3 Origin;
    private Vector3 Difference;
    private bool drag;
    public void Rotate()
    {

    }
    public void Pan()
    {
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            Difference = (mainCamera.ScreenToWorldPoint(Input.mousePosition)) - mainCamera.transform.position;
            if (drag == false)
            {
                drag = true;
                Origin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        if (drag)
        {
            mainCamera.transform.position = Origin - Difference;
        }
    }
    public void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            if ((mainCamera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * 7) >= 10 && (mainCamera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * 7) <= 80)
            {
                mainCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 7;
            }
        }
        rbMinimap.velocity = new Vector2(speedMovement * Input.GetAxisRaw("Horizontal"), speedMovement * Input.GetAxisRaw("Vertical"));
    }
    public void Movement()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            if ((mainCamera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * 7) >= 10 && (mainCamera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * 7) <= 80)
            {
                mainCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 7;
            }
        }
        rbMinimap.velocity = new Vector2(speedMovement * Input.GetAxisRaw("Horizontal"), speedMovement * Input.GetAxisRaw("Vertical"));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

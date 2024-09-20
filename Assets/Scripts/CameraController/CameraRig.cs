using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField]
    private float camMovSpeed;

    private Vector3 movementDirection;

    private Transform cameraReference;

    private void Awake()
    {
        cameraReference = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 tmpMove = InputManager.Instance.GetMovementInput();
        movementDirection = new Vector3(tmpMove.x, tmpMove.y, 0);
        transform.position += movementDirection * camMovSpeed;
        if (tmpMove == Vector2.zero)
        {
            cameraReference.position = new Vector3(cameraReference.position.x, cameraReference.position.y, 0);
            transform.position = cameraReference.position;
        }
    }
}


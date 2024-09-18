using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    public static InputManager Instance
    {
        get; private set;
    }

    private void Awake()
    {
        playerInput = new PlayerInput();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public Vector2 GetMouseDelta()
    {
        return playerInput.Player.Mouse.ReadValue<Vector2>();
    }

    public bool GetLeftClick()
    {
        return playerInput.Player.Interact.triggered;
    }

}

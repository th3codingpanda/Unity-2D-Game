using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputEventScript : MonoBehaviour
{
    private InputAction MoveAction;
    private InputAction JumpAction;
    private InputAction DashAction;
    private InputAction GrabAction;
    [NonSerialized] public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    [NonSerialized] public UnityEvent<Vector2> OnJump = new UnityEvent<Vector2>();
    [NonSerialized] public UnityEvent<Vector2> OnDash = new UnityEvent<Vector2>();
    [NonSerialized] public UnityEvent<Vector2> OnGrab = new UnityEvent<Vector2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        JumpAction = InputSystem.actions.FindAction("Jump");
        DashAction = InputSystem.actions.FindAction("Dash");
        GrabAction = InputSystem.actions.FindAction("Grab");
    }

    // Update is called once per frame
    void Update()
    {
            OnMove.Invoke(MoveAction.ReadValue<Vector2>());
    }
}

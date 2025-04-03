using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputEventScript : Singleton<InputEventScript>
{
    private InputAction MoveAction;
    private InputAction JumpAction;
    private InputAction DashAction;
    private InputAction GrabAction;
    private InputAction ReverseGravityAction;
    [NonSerialized] public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    [NonSerialized] public UnityEvent<Vector2> OnJump = new UnityEvent<Vector2>();
    [NonSerialized] public UnityEvent OnDash = new UnityEvent();
    [NonSerialized] public UnityEvent<Vector2> OnGrab = new UnityEvent<Vector2>();
    [NonSerialized] public UnityEvent OnReverseGravity = new UnityEvent();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        JumpAction = InputSystem.actions.FindAction("Jump");
        DashAction = InputSystem.actions.FindAction("Dash");
        GrabAction = InputSystem.actions.FindAction("Grab");
        ReverseGravityAction = InputSystem.actions.FindAction("ReverseGravity");
    }

    // Update is called once per frame
    void Update()
    {
        OnMove.Invoke(MoveAction.ReadValue<Vector2>());
        if (DashAction.WasPressedThisFrame())
        {
            OnDash.Invoke();
        }
        if (ReverseGravityAction.WasPressedThisFrame())
        {
            OnReverseGravity.Invoke();
        }
    }
}

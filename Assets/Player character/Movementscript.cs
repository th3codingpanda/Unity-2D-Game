using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements.Experimental;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class Movementscript : MonoBehaviour
{
    [Header("Movement variables")]
    public float Speed;
    public float jumpForce;
    public float Move;
    [NonSerialized]public UnityEvent<bool> OnJump = new UnityEvent<bool>();
    [Header("Player Interaction")]
    [SerializeField] Rigidbody2D body;
    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask groundlayer;
    [Header("Dashing")]
    [SerializeField] private float _dashingSpeed;
    [SerializeField] private float _dashingTime;
    private bool _isdashing = false;
    private bool _candash = false;
    private bool _isfacingright;
    private Vector2 _dashingdir;
    InputAction moveaction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveaction = InputSystem.actions.FindAction("Jump");

        //OnJump.AddListener(Test);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveaction.WasPressedThisFrame()) {
            Debug.Log("I jumped");
        }
        var dashinput = Input.GetButtonDown("Dash");
        if (dashinput && _candash) {
        
        }
        if (!_isdashing)
        {
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
                OnJump.Invoke(true);
            }
            if (Input.GetButtonUp("Jump") && body.linearVelocity.y > 0f)
            {
                body.linearVelocity = new Vector2(body.linearVelocityX, body.linearVelocity.y * 0.5f);
            }

            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            
            _dashingdir = new Vector2(moveX, moveY).normalized;
            body.linearVelocity = new Vector2(moveX * Speed, body.linearVelocity.y);
        }
        else {
        
        }
    }


       

    
    private void FixedUpdate()
    {



    }
    private bool isGrounded() {
        
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
        
    }

    private void Flip() {
        _isfacingright = !_isfacingright;
    }
}

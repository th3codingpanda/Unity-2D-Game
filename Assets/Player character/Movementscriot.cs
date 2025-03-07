using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements.Experimental;
using Unity.VisualScripting;
public class Movementscriot : MonoBehaviour
{
    public float Speed;
    public float jumpForce;
    public float Move;
    public bool isFacingRight;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask groundlayer;
    [SerializeField] private float _dashingSpeed;
    [SerializeField] private float _dashingTime;
    private Vector2 _dashingdDirection;
    private bool _isDashing;
    private bool _canDash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Speed = 12f;
        jumpForce = 16f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
        }
        if (Input.GetButtonUp("Jump") && body.linearVelocity.y > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, body.linearVelocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash) {
            _isDashing = true;
            _canDash = false;
            _dashingdDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
            //add that it goes anyways if ur not moving but need a flip for that
        }
        if (_isDashing) {
            body.linearVelocity = _dashingdDirection.normalized * _dashingSpeed;
            return;
        }
           
        



    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(moveHorizontal * Speed, body.linearVelocity.y);
        //X movement

    }
    private bool isGrounded() {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }
    /*private void Flip() {
        if (isFacingRight && body.linearVelocityX < 0f) {
        
        }
    }*/
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements.Experimental;
using Unity.VisualScripting;
using UnityEngine.Events;
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


    public Vector2 savedVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //OnJump.AddListener(Test);
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
            OnJump.Invoke(true);
        }
        if (Input.GetButtonUp("Jump") && body.linearVelocity.y > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, body.linearVelocity.y * 0.5f);
        }
    }


       

    
    private void FixedUpdate()
    {
       
            float moveHorizontal = Input.GetAxis("Horizontal");
            body.linearVelocity = new Vector2(moveHorizontal * Speed, body.linearVelocity.y);
        

    }
    private bool isGrounded() {
        
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
        
    }

    /*private void Flip() {
        if (isFacingRight && body.linearVelocityX < 0f) {
        
        }
    }*/
}

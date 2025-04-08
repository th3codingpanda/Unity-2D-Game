using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements.Experimental;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using JetBrains.Annotations;
using UnityEditor.Tilemaps;
using Unity.Burst.CompilerServices;
using static UnityEngine.ParticleSystem;
public class Movementscript : MonoBehaviour
{
    [Header("Movement variables")]
    private InputEventScript _inputscript;

    public float Speed;
    public float jumpForce;
    public float Move;
    [Header("Player Interaction")]
    [SerializeField] Rigidbody2D body;
    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask groundlayer;
    [Header("Dashing")]
    [SerializeField] private float _dashingSpeed;
    [SerializeField] private float _dashingTime;
    private float _lastgravityscale;
    private float _dashingdirection;
    private float _timedashing;
    private bool _isdashing;
    private bool _candash = true;
    private bool _isfacingright;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputscript = InputEventScript.Instance;
        _inputscript.OnMove.AddListener(Movement);
        _inputscript.OnDash.AddListener(Dash);
        _inputscript.OnReverseGravity.AddListener(ReverseGravity);
        _lastgravityscale = body.gravityScale;
    }



    // Update is called once per frame
    void Update()
    {

        if (_isdashing == true && _timedashing <= _dashingTime)
        {
            if (_isfacingright)
            {
                _dashingdirection = _dashingSpeed;
            }
            else
            {
                _dashingdirection = -_dashingSpeed;
            }
            body.AddForce(new Vector2(_dashingdirection, 0));
            body.gravityScale = 0;
            body.linearVelocity = new Vector2(body.linearVelocityX, 0);
            _timedashing += Time.deltaTime;
        }
        else if (_timedashing > 0)
        {
            body.gravityScale = _lastgravityscale;
            _timedashing -= Time.deltaTime;
            _isdashing = false;
        }
        else if (_timedashing <= 0)
        {
            _candash = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
        }
        if (Input.GetButtonUp("Jump") && body.linearVelocity.y > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, body.linearVelocity.y * 0.5f);
        }
    }





    private bool isGrounded()
    {

        return Physics2D.OverlapCircle(groundcheck.position, 0.5f, groundlayer);

    }

    private void Flip(float xMove)
    {
        if (xMove == 1)
        {
            _isfacingright = true;
            GetComponentInChildren<SpriteRenderer>(true).flipX = true;
        }
        else if (xMove == -1)
        {
            _isfacingright = false;
            GetComponentInChildren<SpriteRenderer>(true).flipX = false;
        }
    }
    private void Movement(Vector2 Dir)
    {
        Flip(Dir.x);
        body.linearVelocity = new Vector2(Dir.x * Speed, body.linearVelocity.y);
    }
    private void Dash()
    {
        if (!_isdashing && _candash)
        {
            _isdashing = true;
            _candash = false;

        }
    }
    private void ReverseGravity()
    {

        if (body.gravityScale != 0)
        {
            GetComponentInChildren<SpriteRenderer>(true).flipY = !GetComponentInChildren<SpriteRenderer>(true).flipY;
            body.gravityScale = -body.gravityScale;
            _lastgravityscale = body.gravityScale;
            jumpForce = -jumpForce;
            groundcheck.transform.localPosition = -groundcheck.transform.localPosition;
            ParticleSystem rainparticle = GetComponentInChildren<ParticleSystem>();
            rainparticle.transform.localPosition = -rainparticle.transform.localPosition;
            VelocityOverLifetimeModule velocityoverlife = rainparticle.velocityOverLifetime;
            
            velocityoverlife.speedModifierMultiplier = -velocityoverlife.speedModifierMultiplier;
        }
    }
}

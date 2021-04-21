using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputPlayer input;
    private Rigidbody2D body;

    [Header("Layers")]
    [SerializeField]
    private LayerMask groundLayer;

    [Header("Movement")]
    [SerializeField]
    float jumpVel;
    [SerializeField]
    float fallMult;
    [SerializeField]
    float shortJumpMult;
    [SerializeField]
    float maxSpeed;

    [Header("Booleans")]
    public bool isFacingRight = true;
    bool isShooting;
    public bool resetShooting = true;
    [SerializeField]
    bool isGround = false;
    public bool isJumping;
    public bool canDoJump;
    public bool wasPressed = false;

    [Header("Variables")]
    float movInputCtx;
    public float timer;
    public float timerReset = 0.2f;
    public float startTime;
    public float jumpRemember = 0f;
    public float jumpRememberTime = 0.1f;

    void Awake()
    {
        input = new InputPlayer();
        input.Player.MovementLeftRight.performed += ctx => MovementLeftRight(ctx);
        input.Player.Jump.performed += ctx => Jump(ctx);
        input.Player.Jump.canceled += ctx => JumpCancel(ctx);
        input.Player.Shoot.performed += ctx => Shoot(ctx);
        input.Player.Melee.performed += ctx => Melee(ctx);
        timer = startTime;
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void MovementLeftRight(InputAction.CallbackContext ctx)
    {
        movInputCtx = ctx.ReadValue<float>();
        if((isFacingRight && movInputCtx == -1) || (!isFacingRight && movInputCtx == 1))
        {
            Flip();
        }
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        isJumping = ctx.ReadValue<float>() == 0 ? false : true;
    }

    private void JumpCancel(InputAction.CallbackContext ctx)
    {
        body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
    }

    private void Shoot(InputAction.CallbackContext ctx)
    {
        isShooting = ctx.ReadValue<float>() == 0 ? false : true;
    }

    private void Melee(InputAction.CallbackContext ctx)
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        //Checking if player is in Ground
        isGround = transform.Find("GroundChecker").GetComponent<GroundChecker>().isGrounded;

        //Movement
        if (movInputCtx == 0)
        {
            body.velocity = new Vector2 (0, body.velocity.y);
        }
        else if (movInputCtx < 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
            isFacingRight = false;
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);
        }
        else
        {
            if (!isFacingRight)
            {
                Flip();
            }
            isFacingRight = true;
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        }

        //Jumping
        /*if (isJumping && isGround && !wasPressed)
        {
            canDoJump = true;
            jumpRemember = jumpRememberTime;
        }

        if (canDoJump)
        {
            if(jumpRemember > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVel + 10);
                jumpRemember -= Time.deltaTime;
            }
            else
            {
                canDoJump = false;
            }
        }

        if (!isJumping)
        {
            canDoJump = false;
        }
        wasPressed = isJumping;*/
        if (isGround)
        {
            if (isJumping)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVel + 10);
            }
        }

        //Shooting
        if (isShooting)
        {
            if (resetShooting)
            {
                gameObject.GetComponent<WeaponScript>().Shoot();
                resetShooting = false;
            }
            if(timer <= 0)
            {
                gameObject.GetComponent<WeaponScript>().Shoot();                
                timer = startTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }            
        }
        else
        {
            if(timerReset > 0)
            {
                timerReset -= Time.deltaTime;
            }
            else
            {
                resetShooting = true;
                timerReset = 0.2f;
            }            
            timer = startTime;
        }
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }
}
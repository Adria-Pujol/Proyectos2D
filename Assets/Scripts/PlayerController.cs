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
    [SerializeField]
    bool isGround = false;
    bool isShortJump;
    bool isLongJump;

    [Header("Variables")]
    float movInputCtx;

    public float holdTimer = 0;
    public float timeHeld = 2;
    public float jumpRemember = 0f;
    public float jumpRememberTime = 0.1f;
    public float groundRemember = 0f;
    public float groundRememberTime = 0.88f;

    void Awake()
    {
        input = new InputPlayer();
        input.Player.MovementLeftRight.performed += ctx => MovementLeftRight(ctx);
        input.Player.Jump.started += ctx => JumpShort(ctx);
        input.Player.Jump.performed += ctx => JumpLong(ctx);
        input.Player.Shoot.performed += ctx => Shoot(ctx);
        input.Player.Melee.performed += ctx => Melee(ctx);
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

    private void JumpShort(InputAction.CallbackContext ctx)
    {
        isShortJump = ctx.ReadValue<float>() == 0 ? false : true;
    }

    private void JumpLong(InputAction.CallbackContext ctx)
    {
        isLongJump = ctx.ReadValue<float>() == 0 ? false : true;
    }

    private void Shoot(InputAction.CallbackContext ctx)
    {
        throw new NotImplementedException();
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
        if (isGround)
        {
            if (isLongJump && isShortJump)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVel + 1);
                Debug.Log("Long Jump");
                isLongJump = false;
                isShortJump = false;
            }
            else if (isShortJump && !isLongJump)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVel);
                Debug.Log("Short Jump");
                isLongJump = false;
                isShortJump = false;
            }
        }        
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }
}
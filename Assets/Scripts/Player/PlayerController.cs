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
    float maxSpeed;
    [SerializeField]
    float dashSpeed;
    float movInputCtx;
    public bool isFacingRight = true;

    [Header("Jumping")]
    [SerializeField]
    bool isJumping;
    [SerializeField]
    float jumpVel;
    [SerializeField]
    float fallMult;
    [SerializeField]
    float shortJumpMult;
    public float timer;
    public float startTime;
    public float jumpRemember = 0f;
    public float jumpRememberTime = 0.1f;

    [Header("Wall")]
    [SerializeField]
    float slideSpeed;
    public float wallClimbSpeed;
    public float jumpWallValX;
    public float jumpWallValY;
    public float wallTimer;

    [Header("Shooting")]
    [SerializeField]
    bool isShooting;
    bool resetShooting = true;
    public float timerReset = 0.2f;

    [Header("Booleans")]       
    [SerializeField]
    bool isGround = false;
    bool isTopWall = false;
    bool isDashing = false;
    bool hasDashed = false;
    public bool isWall = false;
    public bool isShifting = false;
    public bool isDead = false;

    [Header("Confusion State")]
    public bool confusionState = false;
    public float confusionTimer;
    public float confusionTotalTime;

    void Awake()
    {
        input = new InputPlayer();
        input.Player.MovementLeftRight.performed += ctx => MovementLeftRight(ctx);
        input.Player.Jump.started += ctx => Jump(ctx);
        input.Player.Jump.canceled += ctx => Jump(ctx);
        input.Player.Shoot.performed += ctx => Shoot(ctx);
        input.Player.Melee.performed += ctx => Melee(ctx);
        input.Player.GrabWall.performed += ctx => Shift(ctx);
        input.Player.Dash.performed += ctx => Control(ctx);
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
        if (ctx.phase == InputActionPhase.Started)
        {
            isJumping = true;
        }
        if (ctx.phase == InputActionPhase.Canceled)
        {
            isJumping = false;
        }
    }

    private void Shoot(InputAction.CallbackContext ctx)
    {
        isShooting = ctx.ReadValue<float>() == 0 ? false : true;
    }

    private void Melee(InputAction.CallbackContext ctx)
    {
        throw new NotImplementedException();
    }

    private void Shift(InputAction.CallbackContext ctx)
    {
        isShifting = ctx.ReadValue<float>() == 0 ? false : true;
    }

    private void Control(InputAction.CallbackContext ctx)
    {
        isDashing = ctx.ReadValue<float>() == 0 ? false : true;
    }

    private void FixedUpdate()
    {
        //Checking if player is in Ground
        isGround = transform.Find("GroundChecker").GetComponent<GroundChecker>().isGrounded;
        isTopWall = transform.Find("GroundChecker").GetComponent<GroundChecker>().isTopWalled;
        //Checking if player is in Wall
        isWall = transform.Find("WallChecker").GetComponent<WallChecker>().isWall;

        //Movement
        if (!isWall)
        {
            if (confusionState)
            {
                if (isDead)
                {
                    confusionState = false;
                    confusionTimer = 0;
                }
                if (confusionTimer <= 0)
                {
                    confusionState = false;
                }
                else
                {
                    if (movInputCtx == 0)
                    {
                        body.velocity = new Vector2(0, body.velocity.y);
                    }
                    else if (movInputCtx < 0)
                    {
                        if (!isFacingRight)
                        {
                            Flip();
                        }
                        isFacingRight = true;
                        body.velocity = new Vector2(maxSpeed, body.velocity.y);
                    }
                    else
                    {
                        if (isFacingRight)
                        {
                            Flip();
                        }
                        isFacingRight = false;
                        body.velocity = new Vector2(-maxSpeed, body.velocity.y);
                    }
                    confusionTimer -= Time.deltaTime;
                }
            }
            else
            {
                if (movInputCtx == 0)
                {
                    body.velocity = new Vector2(0, body.velocity.y);
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
            }
        }                

        //Jumping
        if ((isGround && isJumping) || (isTopWall && isJumping))
        {
            body.velocity = new Vector2(body.velocity.x, jumpVel);
        }
        if (isJumping && body.velocity.y > 0)
        {
            body.gravityScale = fallMult;
        }
        else
        {
            body.gravityScale = shortJumpMult;
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

        //Wall 
        if (isWall && !isShifting && !isTopWall)
        {
            body.velocity = new Vector2(body.velocity.x, -slideSpeed * Time.deltaTime);
        }
        else if (isWall && isShifting && !isGround && !isTopWall)
        {
            isShooting = false;
            if (movInputCtx != 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpWallValY);
            }
            else
            {
                body.velocity = new Vector2(body.velocity.x, 0);
                body.gravityScale = 0;
            }                         
        }        

        //Dash
        if (isGround && isDashing)
        {
            if (!hasDashed)
            {
                if (isFacingRight)
                {
                    body.velocity = new Vector2(dashSpeed, body.velocity.y);
                    hasDashed = true;
                }
                else
                {
                    body.velocity = new Vector2(-dashSpeed, body.velocity.y);
                    hasDashed = true;
                }
            }        
        }
        else
        {
            hasDashed = false;
        }
    }

    public void MakeConfusion()
    {
        confusionState = true;
        confusionTimer = confusionTotalTime;
        Debug.Log("Dong");
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }
}
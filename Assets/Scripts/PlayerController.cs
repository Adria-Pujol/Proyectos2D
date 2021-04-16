using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputPlayer input;
    private Rigidbody2D body;

    [Header("Movement")]
    [SerializeField]
    float jumpVel;
    [SerializeField]
    float fallMult;
    [SerializeField]
    float shortJumpMult;

    [Header("Booleans")]
    bool isJumping;

    void Awake()
    {
        input = new InputPlayer();
        input.Player.MovementLeftRight.performed += ctx => MovementLeftRight(ctx);
        input.Player.Jump.performed += ctx => Jump(ctx);
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

    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        /*if (!isReading)
        {
            isJumping = ctx.ReadValue<float>() == 0 ? false : true;
        }
        else
        {
            isJumping = false;
        }*/
        isJumping = ctx.ReadValue<float>() == 0 ? false : true;
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
        if (isJumping)
        {
            if(body.velocity.y < 0)
            {
                body.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime; 
            }
            //else if (body.velocity.y > 0 )
            body.velocity = Vector2.up * jumpVel;
        }
    }


}

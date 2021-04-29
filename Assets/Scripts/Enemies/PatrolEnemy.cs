using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEditor.UIElements;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    private Transform _player;
    private bool _isFacingRight = true;
    private Rigidbody2D _body;

    [Header("Movement")]
    public float speed;
    [SerializeField]
    private bool isGround;
    [SerializeField]
    private bool isWall;
    [SerializeField]
    private bool isObject;
    [SerializeField]
    private bool isEnemy;

    private GeneralChecker _generalChecker;
    private EnemyGroundChecker _groundChecker;

    private void Start()
    {
        _generalChecker = transform.Find("GeneralChecker").GetComponent<GeneralChecker>();
        _groundChecker = transform.Find("GroundChecker").GetComponent<EnemyGroundChecker>();
    }

    public void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        //Checking if enemy is colliding to a Wall
        isWall = _generalChecker.isWall;
        //Checking if enemy is in Ground
        isGround = _groundChecker.isGrounded;
        //Checking if enemy is colliding to an Object
        isObject = _generalChecker.isObject;
        //Checking if enemy is colliding to an Enemy
        isEnemy = _generalChecker.isEnemy;
        if (_player)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
        }
        else
        {
            Patrol();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player = collision.gameObject.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player = null;
        }
    }

    private void Patrol()
    {
        if (isWall || !isGround || isObject || isEnemy)
        {
            Flip();
        }

        var velocity = _body.velocity;
        velocity = _isFacingRight ? new Vector2(speed, velocity.y) : new Vector2(-speed, velocity.y);
        _body.velocity = velocity;
    }
    
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.rotation = Quaternion.Euler(0, _isFacingRight ? 0 : 180, 0);
    }
}

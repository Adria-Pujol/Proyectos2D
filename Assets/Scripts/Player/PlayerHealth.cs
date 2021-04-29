using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 7f;
    public float knockback;
    public float invulnerableTotalTime;
    public float invulnerableCurrentTime;
    public bool canRecieveDmg;
    public Transform respawnPosition;

    private Rigidbody2D body;

    public void Awake()
    {
        invulnerableCurrentTime = invulnerableTotalTime;
        body = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (invulnerableCurrentTime < invulnerableTotalTime)
        {
            invulnerableCurrentTime += Time.deltaTime;
        }
        else
        {
            canRecieveDmg = true;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (canRecieveDmg)
        {
            health -= dmg;
            invulnerableCurrentTime = 0f;
            canRecieveDmg = false;
        }

        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        gameObject.transform.position = respawnPosition.position;
        gameObject.GetComponent<PlayerController>().isDead = true;
        health = 7f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (canRecieveDmg)
            {
                health -= 1;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
                body.AddForce(new Vector2(-knockback * 20, knockback));
            }
            if (health <= 0)
            {
                Death();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (canRecieveDmg)
            {                
                health -= 1;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
                body.AddForce(new Vector2(-knockback * 20, knockback));
            }
            else
            {
                invulnerableCurrentTime += Time.deltaTime;
            }
            if (health <= 0)
            {
                Death();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            invulnerableCurrentTime += Time.deltaTime;
        }
    }
}
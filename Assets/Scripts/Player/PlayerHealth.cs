using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float invulnerableTotalTime;
    public float invulnerableCurrentTime;
    public bool canRecieveDmg;
    public Transform respawnPosition;

    public void Awake()
    {
        invulnerableCurrentTime = invulnerableTotalTime;
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
    }
}
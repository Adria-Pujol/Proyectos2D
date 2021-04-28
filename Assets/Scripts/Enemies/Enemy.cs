using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float invulnerabilityTime;
    public float counter;

    public void Awake()
    {
        counter = invulnerabilityTime;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (counter > 0)
        {
            counter -= counter * Time.deltaTime;
        }
        else
        {            
            counter = invulnerabilityTime;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

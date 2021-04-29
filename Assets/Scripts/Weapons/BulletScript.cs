using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 20f;
    [SerializeField]
    float bulletDamage = 20f;
    [SerializeField]
    Rigidbody2D body;
    [SerializeField]
    float timeAlive = 5f;
    float timer;
    [SerializeField]
    public GameObject weapon;

    void Start()
    {
        timer = timeAlive;        
    }

    private void OnEnable()
    {
        body.velocity = transform.right * bulletSpeed;
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            body.velocity = transform.right * bulletSpeed;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            timer = timeAlive;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}

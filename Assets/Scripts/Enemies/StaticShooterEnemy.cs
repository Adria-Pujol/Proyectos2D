using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticShooterEnemy : MonoBehaviour
{
    [SerializeField]
    public float timer;
    public float timeBetweenShoots;

    public Transform firePoint;

    void Awake()
    {
        timer = timeBetweenShoots;
    }

    void FixedUpdate()
    {
        if (timer < 0)
        {
            Shoot();
            timer = timeBetweenShoots;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        BulletPooler.Instance.SpawnFromPool("EnemyBullet", firePoint.position, firePoint.rotation);
    }
}

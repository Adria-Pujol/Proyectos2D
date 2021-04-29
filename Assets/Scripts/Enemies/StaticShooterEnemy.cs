using Player;
using UnityEngine;

namespace Enemies
{
    public class StaticShooterEnemy : MonoBehaviour
    {
        [SerializeField] public float timer;

        public float timeBetweenShoots;

        public Transform firePoint;

        private void Awake()
        {
            timer = timeBetweenShoots;
        }

        private void FixedUpdate()
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

        private void Shoot()
        {
            BulletPooler.instance.SpawnFromPool("EnemyBullet", firePoint.position, firePoint.rotation);
        }
    }
}